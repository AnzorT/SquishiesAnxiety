// The Main Menu, round 11 (the user's requests of 2026-11-14 on the Nov 13 design's menu):
//  - HUD: no "Cozy home" / "Next room" pills, no GAMES tab, no "Let's play" board (PLAY stays, on its own),
//    CREATURES is CHARACTERS, and the coin / gem pills have room between the icon and the number
//    (the markup changes are patches in webgame/patches.mjs; the look is the CSS below)
//  - the level crest is alive (wings flap, the gold shines, sparkles, an XP ring, a "!" for prizes waiting) and opens
//    the Level Pass: every level, its prize and what it unlocks (rooms, the yard games, the house's next look)
//  - PLAY: the creature turns, walks left and the camera follows it to the Game Park, a new part of the map left of the
//    house (drawn with the scene's own sky, grass, trees and weather). There the games line up in a carousel like the
//    app's Achievements screen; Squish Time's card plays a 5 s clip (app/previews/squish.mp4), the four mini-games'
//    show a still poster each (app/art/park/<id>.jpg, since 2026-11-21)
//  - CHARACTERS: a full screen to look at every character (its live rig) and swap the one standing in front of the house
// main-menu.js hands this file its insides (opts._x, patched in) and calls SquishMenu.crest / .play / .levels /
// .characters / .mounted / .inPark; main-menu-scene.js calls SquishMenu.parkArt for the park's picture.
(function () {
  'use strict';
  const App = window.SquishApp || null;
  const M = window.SquishMenu = {};

  // ---------- helpers ----------
  const esc = t => String(t == null ? '' : t).replace(/[&<>"]/g, c => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c]);
  const fmt = n => n == null ? '' : Number(n).toLocaleString('en-US');
  const clamp = (x, a, b) => Math.max(a, Math.min(b, x));
  const r1 = x => (Math.round(x * 10) / 10).toString();
  const wait = ms => new Promise(r => setTimeout(r, ms));
  const tween = (ms, fn, ease) => new Promise(res => {
    const t0 = performance.now();
    const step = () => { const t = Math.min(1, (performance.now() - t0) / ms); fn(ease ? ease(t) : t, t); if (t < 1) requestAnimationFrame(step); else res(); };
    requestAnimationFrame(step);
  });
  const EIO = t => t < 0.5 ? 2 * t * t : 1 - Math.pow(-2 * t + 2, 2) / 2;
  const EIOC = t => t < 0.5 ? 4 * t * t * t : 1 - Math.pow(-2 * t + 2, 3) / 2;
  const EOUT = t => 1 - (1 - t) * (1 - t);
  const ft = (t, s, z, c) => window.MainMenu.ft(t, s, z, c);
  const ic = (d, c, w) => '<svg viewBox="0 0 24 24" fill="none" stroke="' + (c || 'currentColor') + '" stroke-width="' + (w || 2.2) + '" stroke-linecap="round" stroke-linejoin="round"><path d="' + d + '"/></svg>';
  const BACK = 'M15 5L8 12L15 19', LEFT = 'M14 6L8 12L14 18', RIGHT = 'M10 6L16 12L10 18', CHECK = 'M5 12.5l4.5 4.5L19 7.5';
  const LOCK = s => '<svg viewBox="0 0 16 16" width="' + s + '" height="' + s + '"><path d="M4.5 7V5a3.5 3.5 0 0 1 7 0v2" stroke="#6b4426" stroke-width="1.8" fill="none"/><rect x="2.5" y="7" width="11" height="8" rx="2" fill="#ffd54a" stroke="#6b4426" stroke-width="1.2"/></svg>';
  const STAR = '<svg viewBox="0 0 24 24"><path d="M12 2.5l2.9 6 6.6.8-4.9 4.5 1.3 6.5L12 17l-5.9 3.3 1.3-6.5L2.5 9.3l6.6-.8Z" fill="#ffc928" stroke="#5a2a06" stroke-width="1.6" stroke-linejoin="round"/></svg>';
  const SPARK = '<svg viewBox="0 0 20 20"><path d="M10 0 Q11.4 8.6 20 10 Q11.4 11.4 10 20 Q8.6 11.4 0 10 Q8.6 8.6 10 0Z" fill="#fff7c8"/></svg>';
  const sfx = n => { try { const S = window.YardGames && window.YardGames.SFX; if (S && S[n]) S[n](); } catch (e) { /* no audio */ } };
  const send = (t, p) => { if (App) App.send(t, p); };
  const S = () => (App && App.state) || {};
  const BL = 'data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7';
  const coinImg = () => (window.SquishCoin && window.SquishCoin.coin(0)) || BL;
  const gemImg = () => (window.SquishCoin && window.SquishCoin.gem(0)) || BL;
  // a page opened before the coin / gem art is drawn (straight into the park): fill the icons in once it is
  function fillIcons(root, n) { root.querySelectorAll('img[data-cur]').forEach(im => { const s = im.dataset.cur === 'gem' ? gemImg() : coinImg(); if (s !== BL && im.getAttribute('src') !== s) im.src = s; });
    if ((n | 0) < 12 && [...root.querySelectorAll('img[data-cur]')].some(im => im.getAttribute('src') === BL)) setTimeout(() => fillIcons(root, (n | 0) + 1), 400); }
  const allowed = (I, list) => (window.SquishConfig && I && I.ak ? window.SquishConfig.filter(I.ak, list) : list);
  const pill = (img, n, cls) => '<div class="mm-pill mm-p tip v-vel ' + (cls || '') + '"><img alt="" data-cur="' + (img === gemImg() && img !== BL ? 'gem' : 'coin') + '" src="' + img + '"><span class="tx-w">' + fmt(n) + '</span></div>';
  let UID = 0;
  // A creature's still picture: its border look when the app has one for it (REDESIGN_V9: the look config/roster picks,
  // sent by the app as state.looks, src/squad/looks.js; the pictures are the app's own, android assets/looks), else the
  // design's own still.
  // the small copy of a card picture (webgame/tools/small-cards.py), or the picture itself (PERF 2026-11-20)
  const smallPic = u => typeof u !== 'string' ? u : u
    .replace(/^(?:\.\/)?export\/cards4\/((?:frame|bg)-[\w-]+\.webp|names\/[\w-]+\.webp)(?:\?[\w=.&-]*)?$/, 'app/sm/cards4/$1')
    .replace(/^\.\.\/looks\/(\d+)\/([\w-]+\.webp)$/, '../looks-sm/$1/$2');
  function still(c, Q) {
    const L = S().looks, key = c && c.key;
    if (L && key && L.keys && L.keys.indexOf(key) >= 0) { const n = L.over && L.over[key] != null ? L.over[key] : L.n; if (n > 0) return '../looks/' + n + '/' + key + '.webp'; }
    const T = window.SQ_THUMBS || {}, s = c && Q ? Q.src(c.id) : null;
    return s ? T[s] || s : null;
  }

  // ---------- the look ----------
  // REDESIGN_V9 (2026-11-16, the user): the pages' background is the wood the Game Park shows its games on (the game
  // card's planks: --dia over --vel), with a soft light in the middle and darker edges. The app's own screens show a
  // picture of this (webgame/tools/wood-bg.mjs -> assets/royal/wood-bg.jpg, src/royal/parts.js WoodBg).
  const WOOD_BG = 'radial-gradient(70% 80% at 50% 45%,rgba(255,240,210,.30) 0%,rgba(255,240,210,0) 70%),radial-gradient(140% 130% at 50% 50%,rgba(60,30,8,0) 55%,rgba(60,30,8,.30) 100%),repeating-linear-gradient(90deg,rgba(107,68,38,.09) 0 2px,transparent 2px 22px),linear-gradient(180deg,#e6b47c 0%,#cf955a 55%,#b47a42 100%)';
  // The Characters platform: a 200 circle seen at a slant (200 x 40), its 16 lights riding round its rim, a lap in
  // BULB_LAP s like the plate's own turn. The lights are spaced evenly along the ellipse as it's drawn, not by angle:
  // by angle, on a rim only 40 px tall, they bunched up two and three deep at its left and right ends (the user,
  // 2026-11-16). One keyframe list (points the same distance apart round the ellipse, the nearer ones a little bigger);
  // each light starts further along it.
  const BULBS = 16, PLATE_RX = 100, PLATE_RY = 20, BULB_LAP = 12;
  function bulbRun() {
    const N = 720, pts = [], len = [0];
    for (let i = 0; i <= N; i++) {
      const t = i / N * 2 * Math.PI; pts.push([PLATE_RX * Math.cos(t), PLATE_RY * Math.sin(t)]);
      if (i) len.push(len[i - 1] + Math.hypot(pts[i][0] - pts[i - 1][0], pts[i][1] - pts[i - 1][1]));
    }
    const L = len[N], K = 48; let j = 0, out = '';
    for (let k = 0; k <= K; k++) {
      const s = k / K * L; while (j < N - 1 && len[j + 1] < s) j++;
      const f = (s - len[j]) / (len[j + 1] - len[j] || 1), x = pts[j][0] + (pts[j + 1][0] - pts[j][0]) * f, y = pts[j][1] + (pts[j + 1][1] - pts[j][1]) * f;
      out += +(k / K * 100).toFixed(3) + '%{transform:translate(' + (x + PLATE_RX).toFixed(1) + 'px,' + (y + PLATE_RY).toFixed(1) + 'px) scale(' + (0.95 + 0.11 * y / PLATE_RY).toFixed(3) + ')}';
    }
    return '@keyframes sqBulbRun{' + out + '}';
  }
  let cssOn = false;
  function addCss() {
    if (cssOn) return; cssOn = true;
    const s = document.createElement('style'); s.id = 'sq-menu-css';
    s.textContent = `
/* ---- REDESIGN_V8 (2026-11-14, the user): the wood look of the house's Renovate / Catalog buttons replaces the purple
   velvet and the pink. The design's colours are variables on .mm-root, so every velvet plaque, page and outline turns
   wood: a striped wood panel (#e6b47c -> #b47a42), a dark brown outline and lip (#6b4426), cream lettering. No diamond
   tips (the small squares at the ends of the buttons). ---- */
body .mm-root{--ink:#6b4426;
  --vel:linear-gradient(180deg,#e6b47c 0%,#cf955a 55%,#b47a42 100%);
  --rimG:linear-gradient(180deg,#f8dcae 0%,#d9a066 50%,#a86e3a 100%);
  --dia:repeating-linear-gradient(90deg,rgba(107,68,38,.09) 0 2px,transparent 2px 22px);
  --spk:linear-gradient(transparent,transparent);}
.mm-p.tip::before,.mm-p.tip::after{display:none !important;}
.mm-root .tx-w{color:#fff6e2;}
.mm-root .mm-orb{background:radial-gradient(circle at 34% 28%,#fff6e2 0 7%,#f2cc94 16%,#dba468 38%,#b47a42 70%,#7f4c24 100%) padding-box,var(--rimG) border-box;}
/* REDESIGN_V9 (2026-11-16, the user: the house's back button like the app's): the wood back orb, not the purple jewel */
body .mm-hback{width:44px;height:44px;background:radial-gradient(circle at 34% 28%,#fff6e2 0 7%,#f2cc94 16%,#dba468 38%,#b47a42 70%,#7f4c24 100%) padding-box,linear-gradient(180deg,#f8dcae 0%,#d9a066 50%,#a86e3a 100%) border-box;
  box-shadow:0 0 0 1.6px #6b4426,0 3px 0 1.6px #6b4426,0 6px 12px rgba(40,16,0,.4);}
body .mm-hback svg{width:21px;height:21px;filter:drop-shadow(0 1.4px 0 #6b4426);}
/* 2026-11-17 (the user): not on the house map, which has its own Back (top left) and its hint sits where the orb is */
body .mm-house:has([data-screen-label="House map"]) .mm-hback{display:none;}
/* 2026-11-20: nor over the open Catalog, which has its own close (the orb covered its first category tab, "Walls") */
body .mm-house:has([data-screen-label="Catalog"]) .mm-hback{display:none;}
/* PERF 2026-11-21: room first, creatures after (houseDrawn): the furniture fades in after the bare room */
.sq-items{transition:opacity .35s ease;}
.sq-filling .sq-items{opacity:0;transition:none;}
/* PERF 2026-11-20: the house map on a layer of its own (opening it doesn't make the WebView raster the room under it again
   with it), and once its picture is up (SquishMapShown) the SVG is not drawn at all, only hit: its shapes still take the
   taps (pointer-events painted ignores visibility) */
[data-screen-label="House map"]{will-change:transform;}
svg.sq-baked{visibility:hidden;}
svg.sq-baked *{pointer-events:painted;}
.mm-root .mm-page2{background:${WOOD_BG};}
.mm-root .mm-frame{background:#6b4426;}
/* HUD (REDESIGN_V8): no SQUAD (patched out), the tabs start at the left with room between them; the coin and gem
   pictures big, over the left end of their pills; room between the pills, the trophy and the gear; the gear kept off
   the screen's edge (it was cut off there) */
.mm-hud .mm-top{left:22px;right:30px;}
.mm-hud .mm-tabs{gap:12px;padding:0;}
.mm-hud .mm-tab{padding:0 14px;}
.mm-hud .mm-pill{position:relative;height:32px;gap:0;padding:0 14px 0 32px;font-size:14px;}
.mm-hud .mm-pill img{position:absolute;left:-15px;top:50%;width:44px;height:44px;margin:-22px 0 0 0;filter:drop-shadow(0 2px 2px rgba(60,30,10,.45));}
.mm-hud .mm-top > .mm-pill + .mm-pill{margin-left:26px;}
.mm-hud .mm-top > .mm-pill + .mm-orb{margin-left:14px;}
.mm-hud .mm-top > .mm-orb + .mm-orb{margin-left:10px;}
.mm-hud .mm-orb.sq-troph svg{width:26px;height:26px;filter:none;}
/* tapping the house no longer walks into a room (REDESIGN_V8): MY HOUSE does */
.mm-root .mm-hot{pointer-events:none !important;box-shadow:none !important;background:none !important;}
.mm-root .mm-hot .lab{display:none !important;}
/* PLAY on its own (the "Let's play" board is gone) */
.mm-card.sq-solo{width:212px;padding:0;left:18px;bottom:18px;border:0;background:none;box-shadow:none;}
.mm-card.sq-solo .mm-play{height:64px;border-radius:20px;}
.sq-glint{position:absolute;inset:0;border-radius:inherit;overflow:hidden;pointer-events:none;}
.sq-glint::after{content:'';position:absolute;top:-20%;bottom:-20%;width:26%;left:0;background:linear-gradient(100deg,transparent,rgba(255,255,255,.8),transparent);transform:translateX(-160%) skewX(-18deg);}
.mm-card.sq-solo.fl .sq-glint::after{animation:sqSweep .9s ease-in-out;}
@keyframes sqSweep{0%{transform:translateX(-160%) skewX(-18deg);}100%{transform:translateX(490%) skewX(-18deg);}}
/* the level crest, alive */
.mm-lv{right:12px;bottom:6px;}
.sq-crest{position:relative;cursor:pointer;-webkit-tap-highlight-color:transparent;}
.sq-crest .sq-cin{transform-origin:50% 62%;}
.sq-crest.fl .sq-cin{animation:sqFloat .9s ease-in-out;}
.sq-crest:active .sq-cin{animation:none;transform:scale(.92);}
@keyframes sqFloat{0%,100%{transform:translateY(0) scale(1);}40%{transform:translateY(-4px) scale(1.05);}}
.sq-crest .mm-crest{width:118px;height:102px;filter:drop-shadow(0 4px 4px rgba(20,0,50,.45));}
.sq-crest::before{content:'';position:absolute;left:2px;right:2px;top:4px;bottom:-2px;border-radius:50%;background:radial-gradient(closest-side,rgba(255,214,110,.75),rgba(255,214,110,0));opacity:.45;pointer-events:none;}
@keyframes sqGlowO{0%,100%{opacity:.15;}50%{opacity:.85;}}

.sq-wing1{transform-origin:44px 50px;}
.sq-crest.fl .sq-wing1{animation:sqFlapL .9s ease-in-out;}
.sq-wing-1{transform-origin:76px 50px;}
.sq-crest.fl .sq-wing-1{animation:sqFlapR .9s ease-in-out;}
@keyframes sqFlapL{0%,100%{transform:rotate(0);}25%{transform:rotate(17deg);}50%{transform:rotate(-5deg);}75%{transform:rotate(12deg);}}
@keyframes sqFlapR{0%,100%{transform:rotate(0);}25%{transform:rotate(-17deg);}50%{transform:rotate(5deg);}75%{transform:rotate(-12deg);}}
.sq-cstar{transform-origin:60px 18px;}
.sq-crest.fl .sq-cstar{animation:sqStarFlip .9s ease-in-out;}
@keyframes sqStarFlip{0%,100%{transform:scaleX(1);}50%{transform:scaleX(-1);}}
.sq-sweep{transform:translateX(-80px);}
.sq-crest.fl .sq-sweep{animation:sqShine .9s ease-in-out;}
@keyframes sqShine{0%{transform:translateX(-80px);}100%{transform:translateX(80px);}}
.sq-spark{position:absolute;width:13px;height:13px;pointer-events:none;opacity:0;}
.sq-spark svg{width:100%;height:100%;display:block;}
@keyframes sqTw{0%,100%{opacity:0;transform:scale(.3) rotate(0);}45%{opacity:1;transform:scale(1) rotate(45deg);}70%{opacity:0;transform:scale(.4) rotate(90deg);}}
.sq-crest.fl .sq-spark{animation:sqTw .9s ease-in-out;}
.sq-badge{position:absolute;right:16px;top:4px;min-width:21px;height:21px;padding:0 5px;box-sizing:border-box;border-radius:999px;background:radial-gradient(circle at 35% 30%,#ffc29a,#ff6a2c 60%,#c8380e);color:#fff;font:900 12.5px/21px Nunito,sans-serif;text-align:center;box-shadow:0 0 0 2px #fff,0 0 0 3.6px #6b4426,0 3px 6px rgba(0,0,0,.35);pointer-events:none;}
@keyframes sqBob{0%,100%{transform:translateY(0) scale(1);}50%{transform:translateY(-3px) scale(1.12);}}
/* ---- the Game Park ---- */
.sq-pk{position:absolute;inset:0;pointer-events:none;}
.sq-pkdim{position:absolute;inset:0;opacity:0;transition:opacity .5s ease;background:linear-gradient(90deg,rgba(30,8,64,0) 0%,rgba(30,8,64,.12) 24%,rgba(30,8,64,.5) 48%,rgba(30,8,64,.58) 100%),linear-gradient(180deg,rgba(30,8,64,.55) 0,rgba(30,8,64,0) 22%);}
.sq-pk.in .sq-pkdim{opacity:1;}
.sq-pk .mm-pg{pointer-events:none;}
.sq-pk .mm-pgh{pointer-events:auto;opacity:0;transform:translateY(-14px);transition:opacity .4s ease,transform .5s cubic-bezier(.2,.9,.25,1);}
.sq-pk.in .mm-pgh{opacity:1;transform:none;}
.sq-pk .mm-pgh .s{font:700 11.5px Nunito,sans-serif;color:#f3eaff;text-shadow:0 1px 2px rgba(30,0,60,.8);}
.sq-car{position:absolute;right:0;top:56px;bottom:0;pointer-events:auto;touch-action:pan-y;}
.sq-rays{position:absolute;left:50%;top:50%;width:492px;height:492px;margin:-260px 0 0 -246px;border-radius:50%;pointer-events:none;opacity:0;transition:opacity .6s ease .2s;
  background:repeating-conic-gradient(from 0deg,rgba(255,240,180,.5) 0deg 9deg,rgba(255,240,180,0) 9deg 22deg);
  -webkit-mask-image:radial-gradient(circle 246px at 50% 50%,#000 47.52px,rgba(0,0,0,0) 245.51px);mask-image:radial-gradient(circle 246px at 50% 50%,#000 47.52px,rgba(0,0,0,0) 245.51px);}
.sq-pk.in .sq-rays{opacity:.55;}
@keyframes sqSpin{to{transform:rotate(360deg);}}
.sq-halo{position:absolute;left:50%;top:50%;width:320px;height:320px;margin:-174px 0 0 -160px;border-radius:50%;pointer-events:none;opacity:0;transition:opacity .6s ease .2s;
  background:radial-gradient(circle,rgba(255,255,255,.85) 0%,rgba(255,230,160,.5) 30%,rgba(255,170,80,.28) 50%,rgba(255,255,255,0) 70%);}
.sq-pk.in .sq-halo{opacity:1;}
@keyframes sqHalo{from{transform:scale(.9);}to{transform:scale(1.12);}}
/* (the user, 2026-11-16: the card a bit higher, so its dots below it clear the screen's edge) */
.sq-slot{position:absolute;left:50%;top:50%;height:318px;margin-top:-175px;transition:transform .5s cubic-bezier(.3,1.3,.5,1),opacity .35s ease;}
.sq-slot .sq-gc{width:100%;height:100%;opacity:0;transform:translateX(160px) scale(.8);transition:opacity .45s ease,transform .6s cubic-bezier(.2,1.2,.4,1);}
.sq-pk.in .sq-slot .sq-gc{opacity:1;transform:none;}
.sq-gc{position:relative;box-sizing:border-box;display:flex;flex-direction:column;align-items:stretch;gap:7px;padding:8px 10px 10px;border-radius:24px;border-width:3.5px;cursor:pointer;
  background:var(--dia) padding-box,var(--vel) padding-box,var(--rimG) border-box !important; /* REDESIGN_V8: wood, not each game's colour (Squish Time's was pink) */
  box-shadow:0 0 0 2px var(--ink),0 5px 0 2px var(--ink),0 14px 26px rgba(10,0,40,.55),inset 0 0 0 1.5px rgba(255,236,170,.6) !important;}
.sq-gc .win{width:100%;flex:1;min-height:0;border-radius:16px;overflow:hidden;position:relative;background:#1e0a40;box-shadow:0 0 0 2px var(--ink),0 0 0 4.5px #ffd76a,0 0 0 6px var(--ink);}
.sq-gc .win > *{position:absolute;inset:0;width:100%;height:100%;display:block;object-fit:cover;}
.sq-gc .win::after{content:'';position:absolute;inset:0;border-radius:inherit;box-shadow:inset 0 -10px 16px rgba(0,0,0,.22),inset 0 2px 0 rgba(255,255,255,.25);pointer-events:none;}
.sq-gc .ttl{flex:none;display:flex;justify-content:center;line-height:0;margin:-3px 0 -2px;}
/* a mini-game's poster (its name is in the picture): when the window is wider than the picture, the top (the name) stays */
.sq-gc.po .win > img{object-position:50% 12%;}
.sq-gc .info{flex:none;display:flex;align-items:center;gap:12px;}
.sq-gc .info .txt{flex:1;min-width:0;display:flex;flex-direction:column;align-items:flex-start;gap:5px;text-align:left;}
.sq-gc .info .ds{font:700 12px/1.3 Nunito,sans-serif;color:#fff;text-shadow:0 1px 2px rgba(30,0,60,.55);max-width:100%;display:-webkit-box;-webkit-line-clamp:2;-webkit-box-orient:vertical;overflow:hidden;}
.sq-gc .best{margin-top:0;padding:2px 10px;border-radius:999px;background:rgba(30,0,60,.38);box-shadow:inset 0 0 0 1px rgba(255,236,170,.6);font:800 10.5px Nunito,sans-serif;color:#ffe9a8;white-space:nowrap;max-width:100%;overflow:hidden;text-overflow:ellipsis;}
.sq-gc .go{width:148px;height:46px;flex:none;border-radius:15px;display:flex;align-items:center;justify-content:center;}
.sq-gc .go:active{transform:translateY(2px);}
.sq-slot:not(.c) .go{pointer-events:none;filter:saturate(.7);}
.sq-slot.c .sq-gc{animation:sqCen .5s ease;}
.sq-gc.lock .win > :not(.lockv){filter:saturate(.2) brightness(.7);}
.sq-gc .lockv{position:absolute;inset:0;justify-content:center;display:flex;flex-direction:column;align-items:center;gap:4px;font:700 12px Fredoka,sans-serif;color:#fff;text-align:center;text-shadow:0 1px 2px #000;}
.sq-sqz{background:radial-gradient(circle at 50% 42%,#ffe3f6,#ffb3e6 55%,#ff8fd6);}
.sq-sqz img{position:absolute;left:20%;top:8%;width:60%;height:88%;object-fit:contain;transform-origin:50% 100%;animation:sqSqz 1.9s ease-in-out infinite;}
@keyframes sqSqz{0%,100%{transform:scale(1,1);}18%{transform:scale(1.22,.72);}30%{transform:scale(.9,1.14);}42%{transform:scale(1.05,.95);}54%{transform:scale(1,1);}70%{transform:scale(1.12,.84) rotate(-4deg);}82%{transform:scale(.95,1.06) rotate(3deg);}}
.sq-sqz i{position:absolute;top:38%;width:9%;height:24%;border:3px solid #fff;border-color:#fff transparent;border-radius:50%;opacity:0;animation:sqLines 1.9s ease-out infinite;}
.sq-sqz i.l{left:3%;border-width:0 0 0 3px;border-left-color:#fff;}.sq-sqz i.r{right:3%;border-width:0 3px 0 0;border-right-color:#fff;}
@keyframes sqLines{0%,12%{opacity:0;}20%{opacity:1;}46%,100%{opacity:0;}}
@keyframes sqCen{0%{filter:brightness(1.35);}100%{filter:none;}}
.sq-arr{position:absolute;top:50%;margin-top:-20px;z-index:60;}
.sq-arr.l{left:10px;}.sq-arr.r{right:12px;}
.sq-arr.off{opacity:.4;}
.sq-pos{position:absolute;left:50%;bottom:7px;transform:translateX(-50%);display:flex;gap:6px;z-index:55;}
.sq-pos i{cursor:pointer;width:7px;height:7px;border-radius:50%;background:rgba(255,255,255,.35);box-shadow:0 0 0 1.5px rgba(107,68,38,.6);transition:all .3s;}
.sq-pos i.on{background:#ffd24a;width:18px;border-radius:4px;}
/* ---- shared page bits ---- */
.sq-toast.r{left:auto;right:18px;transform:none;animation:none;}
.sq-toast{position:absolute;left:50%;bottom:20px;transform:translateX(-50%);max-width:70%;padding:5px 18px;font:700 13px Fredoka,sans-serif;text-align:center;animation:mmToast 2.4s ease forwards;pointer-events:none;z-index:90;}
.sq-chip{display:inline-flex;align-items:center;gap:5px;height:24px;padding:0 11px;border-radius:999px;font:800 11px Nunito,sans-serif;color:#fff;background:rgba(255,255,255,.12);box-shadow:inset 0 0 0 1.5px rgba(255,236,170,.45);white-space:nowrap;cursor:pointer;flex:none;}
.sq-chip.on{background:linear-gradient(180deg,#fff1b0,#ffd650 45%,#f6a524);color:#6b4426;box-shadow:0 0 0 1.6px #6b4426,0 2px 0 1.6px #6b4426;}
/* ---- Level Pass ---- */
.sq-lvx{height:34px;display:flex;align-items:center;gap:9px;padding:0 14px 0 8px;cursor:default;}
.sq-lvx b{font:700 15px Fredoka,sans-serif;}
.sq-lvbar{width:118px;height:12px;border-radius:999px;background:rgba(20,0,50,.55);box-shadow:inset 0 0 0 1.5px rgba(255,236,170,.5);overflow:hidden;position:relative;}
.sq-lvbar i{position:absolute;left:0;top:0;bottom:0;border-radius:999px;background:linear-gradient(180deg,#ffb3e6,#ff4fbf 60%,#d0128a);box-shadow:inset 0 1.5px 0 rgba(255,255,255,.55);}
.sq-lvx small{font:800 10.5px Nunito,sans-serif;color:#f6e8ff;white-space:nowrap;}
.sq-lvall{height:30px;padding:0 13px;display:flex;align-items:center;font:700 12.5px Fredoka,sans-serif;}
/* REDESIGN_V9 (2026-11-16, the user): one row of levels, each one tappable, and the tapped level's rewards in one
   panel along the bottom (no reward under every level, no big card for the next one); the rewards drawn as what they
   are: a group's own chest, a picture of the room, the house's next look */
.sq-lvtrack{position:absolute;left:0;right:0;top:60px;height:118px;overflow-x:auto;overflow-y:hidden;scrollbar-width:none;touch-action:none;cursor:grab;}
.sq-lvtrack::-webkit-scrollbar{display:none;}
.sq-lvin{position:relative;height:100%;}
.sq-rail{position:absolute;left:0;top:58px;height:12px;border-radius:999px;background:rgba(74,42,16,.42);box-shadow:inset 0 0 0 1.5px rgba(255,236,170,.35),0 1px 0 rgba(255,255,255,.25);}
.sq-rail i{position:absolute;left:0;top:0;bottom:0;border-radius:999px;background:linear-gradient(180deg,#fff3b8,#ffd24a 45%,#f09a14);box-shadow:inset 0 1.5px 0 rgba(255,255,255,.6),0 0 10px rgba(255,214,110,.7);transition:width .8s cubic-bezier(.2,.9,.25,1);}
.sq-you{position:absolute;top:0;width:34px;height:34px;margin-left:-17px;border-radius:50%;background:radial-gradient(circle at 35% 30%,#fff,#fff3dc 50%,#ffd9a8);box-shadow:0 0 0 2.5px #6b4426,0 0 0 5px #ffd24a,0 0 0 6.6px #6b4426,0 0 16px 6px rgba(255,214,110,.75);z-index:5;overflow:hidden;}
.sq-you img{position:absolute;left:4%;top:6%;width:92%;height:92%;object-fit:contain;}
.sq-youp{position:absolute;top:35px;width:0;height:0;margin-left:-6px;border:6px solid transparent;border-top:7px solid #ffd24a;z-index:5;}
.sq-ln{position:absolute;top:41px;width:46px;height:46px;margin-left:-23px;border:0;padding:0;border-radius:50%;display:flex;align-items:center;justify-content:center;cursor:pointer;z-index:2;box-sizing:border-box;
  font:700 18px Fredoka,sans-serif;color:#fff6e2;text-shadow:0 1.5px 0 #6b4426;
  background:radial-gradient(circle at 35% 30%,#dcae78,#a8703e 62%,#7f4c24);box-shadow:0 0 0 2.5px #6b4426,0 3px 0 2.5px #6b4426;transition:transform .15s;}
.sq-ln.on{background:radial-gradient(circle at 35% 30%,#fffbe0,#ffd24a 50%,#e08a10);color:#6b4426;text-shadow:0 1px 0 rgba(255,255,255,.6);}
.sq-ln.cur{transform:scale(1.12);}
.sq-ln.cl{animation:sqClaim 1.2s ease-in-out infinite;will-change:transform;box-shadow:0 0 0 2.5px #6b4426,0 3px 0 2.5px #6b4426,0 0 16px 7px rgba(255,214,110,.95);}
.sq-ln.sel{box-shadow:0 0 0 2.5px #6b4426,0 0 0 6.5px #fff6e2,0 0 0 9px #6b4426,0 4px 12px 6px rgba(255,246,214,.6);}
.sq-ln.sel::after{content:'';position:absolute;left:50%;top:100%;margin:12px 0 0 -9px;border:9px solid transparent;border-top:10px solid #fff6e2;filter:drop-shadow(0 2px 0 #6b4426);}
@keyframes sqClaim{0%,100%{transform:translateY(0);}50%{transform:translateY(-4px);}}
.sq-ln .st{position:absolute;right:-7px;top:-7px;width:20px;height:20px;border-radius:50%;display:flex;align-items:center;justify-content:center;box-shadow:0 0 0 2px #fff6e2,0 0 0 3.5px #6b4426;font:900 12px Nunito,sans-serif;color:#fff;text-shadow:none;}
.sq-ln .st svg{width:12px;height:12px;}
.sq-ln .st.ok{background:#26a94e;}
.sq-ln .st.lkb{background:#8a5a32;}
.sq-ln .st.ex{background:#ff6a2a;}
.sq-lvpan{position:absolute;left:16px;right:16px;top:184px;bottom:12px;border-radius:22px;border-width:3.5px;display:flex;align-items:center;gap:16px;padding:10px 16px;cursor:default;box-sizing:border-box;}
.sq-lvpan .lv{flex:none;width:156px;display:flex;flex-direction:column;align-items:center;gap:7px;text-align:center;}
.sq-lvpan .lv .sub{font:800 11.5px Nunito,sans-serif;color:#fff6e2;text-shadow:0 1px 0 #6b4426;}
.sq-lvpan .act{width:150px;height:40px;border-radius:14px;display:flex;align-items:center;justify-content:center;gap:6px;font:700 14px Fredoka,sans-serif;}
.sq-lvpan .act.v-gold{cursor:pointer;}
.sq-lvpan .act.done{cursor:default;}
.sq-lvpan .act > svg:not(.mm-ft){width:17px;height:17px;}
.sq-lvpan .items{flex:1;min-width:0;align-self:stretch;display:flex;align-items:stretch;justify-content:center;gap:12px;}
.sq-it{position:relative;flex:0 1 196px;min-width:0;display:flex;flex-direction:column;align-items:center;gap:3px;padding:12px 8px 8px;border-radius:16px;box-sizing:border-box;text-align:center;
  background:rgba(255,246,226,.24);box-shadow:inset 0 0 0 2px rgba(255,246,226,.5),inset 0 -3px 0 rgba(107,68,38,.18);}
.sq-it .tag{position:absolute;top:-8px;left:50%;transform:translateX(-50%);padding:1px 8px;border-radius:999px;background:#ff8a3d;color:#fff;font:900 8.5px Nunito,sans-serif;letter-spacing:.8px;white-space:nowrap;box-shadow:0 0 0 1.5px #6b4426;}
.sq-it .ar{width:100%;height:86px;flex:none;display:flex;align-items:center;justify-content:center;position:relative;}
.sq-it .ar::before{content:'';position:absolute;left:50%;top:50%;width:120px;height:100px;margin:-50px 0 0 -60px;border-radius:50%;background:radial-gradient(closest-side,rgba(255,246,214,.6),rgba(255,246,214,0));}
.sq-it .ar > *{position:relative;}
.sq-it .ar img.pic{height:100%;width:auto;max-width:100%;aspect-ratio:4/3;object-fit:cover;border-radius:12px;box-shadow:0 0 0 2.5px #6b4426,0 3px 0 2.5px #6b4426;}
/* (the chest pictures have room round the chest: drawn bigger than the box) */
.sq-it .ar img.chest{height:150%;width:auto;max-width:none;margin:-22% 0 -20%;object-fit:contain;filter:drop-shadow(0 3px 0 rgba(107,68,38,.3));}
.sq-it .ar > svg{height:84%;}
.sq-it .ar .pile{width:96px;height:80px;}
.sq-it .t{line-height:0;margin-top:2px;}
.sq-it .d{font:700 11px/1.25 Nunito,sans-serif;color:#fff6e2;text-shadow:0 1px 0 #6b4426;}
.sq-it.none{justify-content:center;}
/* ---- Heading home (REDESIGN_V9): night on the house while it loads ---- */
.sq-hh-night{position:absolute;inset:0;pointer-events:none;}
.sq-hh-night .lay{position:absolute;inset:0;width:100%;height:100%;overflow:visible;}
/* PERF 2026-11-20: each part its own GPU layer, faded by Web Animations (headingHome): the night multiplied over the
   house, then each lit window's day picture, the stars and the moon, the halos (screen) and the warm panes (soft-light) */
.sq-hh-night .skyl{mix-blend-mode:multiply;will-change:opacity;opacity:0;}
.sq-hh-night .holes,.sq-hh-night .glows,.sq-hh-night .hal,.sq-hh-night .pan{position:absolute;left:0;top:0;width:100%;height:100%;}
/* PERF 2026-11-20: the night and each lit window as canvases drawn once (headingHome nightPics), faded in */
.sq-hh-night .pics{position:absolute;inset:0;}
.sq-hh-night .hl,.sq-hh-night .gl,.sq-hh-night .pn{position:absolute;overflow:visible;will-change:opacity;opacity:0;}
.sq-hh-night .gl{mix-blend-mode:screen;}
.sq-hh-night .pn{mix-blend-mode:soft-light;}
.sq-hh-night .stars{position:absolute;inset:0;opacity:0;}
.sq-hh-night .stars i{position:absolute;width:2px;height:2px;border-radius:50%;background:#fff;box-shadow:0 0 4px 1px rgba(255,255,255,.6);animation:sqTw 2.4s ease-in-out infinite;}
@keyframes sqTw{0%,100%{opacity:.35;}50%{opacity:1;}}

.sq-hh-night .moon{position:absolute;right:9%;top:8%;width:52px;height:52px;opacity:0;transform:translateY(10px);filter:drop-shadow(0 0 10px rgba(255,246,200,.7));}
.sq-hh-ui{position:absolute;inset:0;z-index:6;pointer-events:none;opacity:0;}
.sq-hh-ui .in{position:absolute;left:0;top:0;transform-origin:0 0;}
.sq-hh-ui .ttl{position:absolute;left:0;right:0;top:16px;display:flex;justify-content:center;line-height:0;}
.sq-hh-ui .bot{position:absolute;left:0;right:0;bottom:14px;display:flex;flex-direction:column;align-items:center;gap:7px;}
.sq-hh-ui .tip{font:800 12.5px Nunito,sans-serif;color:#fff6e2;text-shadow:0 1.5px 0 #2a1608;transition:opacity .25s ease;max-width:560px;text-align:center;}
.sq-hh-ui .tip em{font-style:normal;color:#ffd24a;}
.sq-hh-ui .tip.sw{opacity:0;}
/* ---- Gathering your squad (REDESIGN_V9): the Characters page's loading screen ---- */
.sq-gs{position:absolute;left:0;top:0;right:0;height:100%;min-height:393px;z-index:40;background:${WOOD_BG};opacity:1;transition:opacity .45s ease;overflow:hidden;}
.sq-gs.out{opacity:0;}
/* PERF 2026-11-20: the turning rays were a 900 px square, the mask shows only a 357 px circle of it (56% of the 636 px
   reach of "circle" to the corner): the box is cut to that circle, the mask written in px (the same pixels, 37% less GPU
   memory for a layer redrawn as it turns). The same for the Characters page's (32% less) and the Game Park's (23% less) rays below. */
.sq-gs .rays{position:absolute;left:50%;top:44%;width:714px;height:714px;margin:-357px 0 0 -357px;border-radius:50%;pointer-events:none;background:repeating-conic-gradient(rgba(255,246,214,.30) 0deg 7deg,rgba(255,246,214,0) 7deg 18deg);-webkit-mask-image:radial-gradient(circle 357px at 50% 50%,#000 38.18px,rgba(0,0,0,0) 356.38px);mask-image:radial-gradient(circle 357px at 50% 50%,#000 38.18px,rgba(0,0,0,0) 356.38px);animation:sqSpin 60s linear infinite;}
.sq-gs .ttl{position:absolute;left:0;right:0;top:12px;display:flex;justify-content:center;line-height:0;}
.sq-gs .cnt{position:absolute;left:50%;top:56px;transform:translateX(-50%);padding:2px 12px;border-radius:999px;background:#fff6e2;color:#5b3418;font:800 11.5px Nunito,sans-serif;box-shadow:0 0 0 2px #6b4426,0 2px 0 2px #6b4426;white-space:nowrap;}
.sq-gs .table{position:absolute;left:50%;top:176px;width:0;height:0;}
.sq-gs .deck,.sq-gs .cw{position:absolute;left:-46px;top:-68px;width:92px;height:137px;}
.sq-gs .deck{z-index:0;transform:none;transition:transform .3s ease,opacity .3s ease;}
.sq-gs .deck.gone{opacity:0;transform:scale(.85);}
.sq-gs .deck .back{position:absolute;inset:0;border-radius:10px;}
.sq-gs .deck .back:nth-child(1){transform:translate(-5px,4px) rotate(-4deg);}
.sq-gs .deck .back:nth-child(2){transform:translate(-2px,2px) rotate(-1.5deg);}
.sq-gs .back,.sq-gs .bk{background:repeating-linear-gradient(90deg,rgba(107,68,38,.10) 0 2px,transparent 2px 10px),linear-gradient(180deg,#fff1b0,#f6c75a 55%,#e8a23a);box-shadow:0 0 0 2.5px #6b4426,0 4px 0 2.5px #4a2c14,inset 0 0 0 4px rgba(255,246,214,.6);display:flex;align-items:center;justify-content:center;}
.sq-gs .back span,.sq-gs .bk span{width:38px;height:38px;border-radius:50%;background:#fff6e2;box-shadow:0 0 0 2.5px #6b4426;display:flex;align-items:center;justify-content:center;}
.sq-gs .back span svg,.sq-gs .bk span svg{width:26px;height:26px;}
.sq-gs .cw{z-index:1;transform:none;opacity:0;transition:transform .45s cubic-bezier(.2,.9,.3,1.05),opacity .2s ease;perspective:600px;}
.sq-gs .cw.dealt{opacity:1;transform:translate(var(--fx),var(--fy)) rotate(var(--fr));}
.sq-gs.away .cw{opacity:0;transform:translate(var(--fx),calc(var(--fy) - 46px)) rotate(var(--fr));transition:transform .45s ease-in,opacity .4s ease;}
.sq-gs .fl{position:absolute;inset:0;transform-style:preserve-3d;transform:rotateY(180deg);transition:transform .45s ease;}
.sq-gs .cw.up .fl{transform:rotateY(0);}
.sq-gs .fc,.sq-gs .bk{position:absolute;inset:0;backface-visibility:hidden;-webkit-backface-visibility:hidden;border-radius:10px;}
.sq-gs .bk{transform:rotateY(180deg);}
.sq-gs .fc .sq-cc{width:100%;cursor:default;filter:drop-shadow(0 4px 0 rgba(74,44,20,.45));}
.sq-gs .band{position:absolute;left:0;right:0;bottom:0;height:46px;background:linear-gradient(180deg,#6b4426,#4a2c14);box-shadow:0 -3px 0 #3a2210,inset 0 2px 0 rgba(255,236,170,.25);display:flex;flex-direction:column;align-items:center;justify-content:center;gap:7px;}
.sq-gs .tip{font:800 12.5px Nunito,sans-serif;color:#fff6e2;transition:opacity .25s ease;text-align:center;}
.sq-gs .tip em{font-style:normal;color:#ffd24a;}
.sq-gs .tip.sw{opacity:0;}
.sq-fly{position:absolute;width:26px;height:26px;z-index:95;pointer-events:none;transition:transform .75s cubic-bezier(.5,-0.2,.7,1),opacity .2s ease .62s;}
/* ---- Characters ---- */
.sq-cs{position:absolute;left:14px;top:60px;bottom:12px;width:278px;display:flex;flex-direction:column;align-items:center;}
.sq-cs .stage{position:relative;width:236px;height:200px;flex:none;}
.sq-gs canvas.rays,.sq-c2 canvas.rays{background:none;-webkit-mask-image:none;mask-image:none;border-radius:0;will-change:transform;}
.sq-cs .stage .rays{position:absolute;left:50%;top:52%;width:300px;height:300px;margin:-150px 0 0 -150px;border-radius:50%;background:repeating-conic-gradient(rgba(255,240,180,.45) 0deg 9deg,rgba(255,240,180,0) 9deg 22deg);-webkit-mask-image:radial-gradient(circle,#000 10%,rgba(0,0,0,0) 62%);mask-image:radial-gradient(circle,#000 10%,rgba(0,0,0,0) 62%);opacity:.5;}
.sq-cs .stage .pad{position:absolute;left:50%;bottom:6px;width:170px;height:34px;margin-left:-85px;border-radius:50%;background:radial-gradient(closest-side,rgba(255,255,255,.75),rgba(255,236,170,.4) 55%,rgba(255,236,170,0));}
.sq-cs .stage .pad::after{content:'';position:absolute;left:30px;right:30px;top:9px;bottom:9px;border-radius:50%;background:radial-gradient(circle at 45% 35%,#f6efe4,#cbbca6);box-shadow:0 0 0 2px rgba(107,68,38,.5);}
.sq-cs .rig{position:absolute;left:50%;bottom:4px;width:196px;height:196px;margin-left:-98px;}
.sq-cs .rig.pop{animation:sqPop .55s cubic-bezier(.2,1.4,.4,1);}
.sq-cs .rig.sil{filter:saturate(.3) brightness(.78) drop-shadow(0 0 8px rgba(200,160,255,.8));}
@keyframes sqPop{0%{transform:scale(.55) translateY(20px);opacity:0;}100%{transform:none;opacity:1;}}
.sq-cs .np{margin-top:-2px;height:30px;padding:0 18px;display:flex;align-items:center;justify-content:center;cursor:default;position:relative;}
.sq-cs .np .mm-ft{margin:-6px 0 -5px;}
.sq-cs .np .pips{position:absolute;left:50%;top:-9px;transform:translateX(-50%);display:flex;gap:1px;}
.sq-cs .np .pips svg{width:12px;height:12px;filter:drop-shadow(0 1px 0 #6b4426);}
.sq-cs .chips{display:flex;flex-wrap:wrap;justify-content:center;gap:5px;margin-top:9px;}
.sq-cs .chips .sq-chip{cursor:default;height:21px;font-size:10px;}
.sq-cs .info{font:700 11px Nunito,sans-serif;color:#eadcff;margin-top:6px;min-height:14px;text-align:center;}
.sq-cs .act{margin-top:auto;width:236px;height:44px;border-radius:15px;display:flex;align-items:center;justify-content:center;gap:6px;font:700 15px Fredoka,sans-serif;}
.sq-cs .act.v-gold{}
.sq-cs .act.done{cursor:default;}
.sq-cs .act > svg:not(.mm-ft){width:18px;height:18px;}
.sq-cg{position:absolute;left:304px;right:14px;top:60px;bottom:10px;display:flex;flex-direction:column;}
.sq-cf{display:flex;gap:6px;overflow-x:auto;padding:3px 3px 8px;scrollbar-width:none;flex:none;}
.sq-cf::-webkit-scrollbar{display:none;}
.sq-cgr{flex:1;overflow-y:auto;overflow-x:hidden;display:grid;grid-template-columns:repeat(auto-fill,minmax(76px,1fr));gap:9px 8px;padding:6px 6px 14px;scrollbar-width:none;align-content:start;}
.sq-cgr::-webkit-scrollbar{display:none;}
.sq-cc{position:relative;width:100%;aspect-ratio:1696/2528;border:0;padding:0;background:none;cursor:pointer;container-type:inline-size;transition:transform .15s;}
.sq-cc:active{transform:scale(.95);}
.sq-cc img{position:absolute;pointer-events:none;}
.sq-cc .nmT{position:absolute;display:flex;align-items:center;justify-content:center;text-align:center;font:700 9cqw/1 Fredoka,sans-serif;}
.sq-cc.no .art{filter:brightness(0) opacity(.62) drop-shadow(0 0 3px rgba(255,255,255,.35));}
.sq-cc.no .frm,.sq-cc.no .bg,.sq-cc.no .nmi{filter:saturate(.25) brightness(.8);}
.sq-cc .lk{position:absolute;right:6%;top:4%;width:24%;filter:drop-shadow(0 1px 1px rgba(0,0,0,.4));}
.sq-cc .lk svg{width:100%;height:auto;display:block;}
.sq-cc.pv::before{content:'';position:absolute;left:5%;right:5%;top:2%;bottom:1.5%;border-radius:10% / 7%;box-shadow:0 0 0 3px #fff,0 0 14px 4px rgba(255,255,255,.7);}
.sq-cc.me::after{content:'IN USE';position:absolute;left:50%;top:-6px;transform:translateX(-50%);padding:1px 7px;border-radius:999px;background:linear-gradient(180deg,#fff1b0,#ffd650 45%,#f6a524);color:#6b4426;font:900 8px Nunito,sans-serif;letter-spacing:.8px;box-shadow:0 0 0 1.5px #6b4426;white-space:nowrap;z-index:3;}
.sq-cc .nw{position:absolute;right:-4px;top:-4px;width:12px;height:12px;border-radius:50%;background:#ff4fbf;box-shadow:0 0 0 2px #fff;z-index:3;}
/* ---- Characters, REDESIGN_V8: bright, warm and shiny ---- */
.mm-root .mm-page2.sq-chars{background:radial-gradient(34% 50% at 50% 44%,rgba(255,246,214,.55) 0%,rgba(255,246,214,0) 70%),${WOOD_BG};animation:none;}
.mm-root .mm-page2.sq-pass{animation:none;}
.sq-pass .sq-lvtrack,.sq-pass .sq-lvpan > *{transition:opacity .18s ease;}
.sq-pass.sq-filling .sq-lvtrack,.sq-pass.sq-filling .sq-lvpan > *{opacity:0;will-change:opacity;}
/* (PERF 2026-11-20: no fade-in under its loading screen: on the phone the fade froze part-way for up to 2 s while the
   page's tiles were made, a see-through ghost of the loader over the menu; the loader is whole from its first frame) */
.sq-c2{position:absolute;inset:0;pointer-events:none;}
.sq-c2 > *{pointer-events:auto;}
.sq-c2 .rays{position:absolute;left:50%;top:170px;width:674px;height:674px;margin:-337px 0 0 -337px;border-radius:50%;pointer-events:none;
  background:repeating-conic-gradient(rgba(255,255,255,.55) 0deg 7deg,rgba(255,255,255,0) 7deg 18deg);
  -webkit-mask-image:radial-gradient(circle 337px at 50% 50%,#000 46.38px,rgba(0,0,0,0) 336.29px);mask-image:radial-gradient(circle 337px at 50% 50%,#000 46.38px,rgba(0,0,0,0) 336.29px);animation:sqSpin 60s linear infinite;opacity:.6;}
/* REDESIGN_V9 (the user: the character doesn't look inside the circle): stands on the plate, its shadow on the
   plate's middle (y 210), not 30 px over its back edge */
.sq-c2 .rig{position:absolute;left:calc(50% - 75px);top:68px;width:150px;height:150px;z-index:2;}
.sq-c2 .rig.pop{animation:sqPop .55s cubic-bezier(.2,1.4,.4,1);}
/* PERF 2026-11-20: not drawn under the loading screen (it animates, so it was rastered again every frame, unseen: ~1 s
   of the WebView's GPU thread on the first open on the A16); shown as the loading screen starts to leave */
.sq-chars:has(.sq-gs:not(.sq-leaving)) .sq-c2 .rig{visibility:hidden;}
.sq-c2 .rig.sil{filter:saturate(.3) brightness(.78) drop-shadow(0 0 8px rgba(255,255,255,.9));}
.sq-c2 .ring{position:absolute;left:calc(50% - 100px);top:190px;width:200px;height:40px;z-index:1;}
/* the platform: its gold side (the plate's thickness), then the plate turning slowly (12 s a turn) with its lights
   riding round its rim (bulbRun) */
.sq-c2 .ring .side{position:absolute;left:-12px;right:-12px;top:5px;height:44px;border-radius:50%;background:linear-gradient(180deg,#d98a24,#a85a12);box-shadow:0 0 0 2.5px #6b4426,0 6px 14px rgba(107,50,10,.45);}
.sq-c2 .ring .tilt{position:absolute;left:0;top:50%;width:200px;height:200px;margin-top:-100px;transform:scaleY(.2);}
.sq-c2 .ring .turn{position:absolute;inset:0;animation:sqSpin ${BULB_LAP}s linear infinite;}
.sq-c2 .ring .plate{position:absolute;inset:0;border-radius:50%;background:radial-gradient(circle,rgba(255,255,255,.95) 0 18%,rgba(255,255,255,0) 46%),repeating-conic-gradient(#ffe9a0 0deg 15deg,#f6c457 15deg 30deg);box-shadow:0 0 0 7px #f0a21c,0 0 0 12px #6b4426,0 0 60px 30px rgba(255,236,150,.75);}
.sq-c2 .ring .bp{position:absolute;left:0;top:0;width:0;height:0;animation:sqBulbRun ${BULB_LAP}s linear infinite;}
.sq-c2 .ring .b{position:absolute;left:-7px;top:-7px;width:14px;height:14px;border-radius:50%;background:radial-gradient(circle at 35% 30%,#ffffff,#ffe27a 55%,#f0a21c);box-shadow:0 0 0 2px #8a4a12,0 0 10px 5px rgba(255,236,150,.95);}
.sq-c2 .ring .b.w{background:radial-gradient(circle at 35% 30%,#ffffff,#fff6d8 55%,#ffd27a);}
${bulbRun()}
.sq-c2 .who{position:absolute;left:146px;right:146px;top:247px;height:30px;display:flex;align-items:center;justify-content:center;gap:12px;}
.sq-c2 .who .np{height:30px;padding:0 18px;display:flex;align-items:center;justify-content:center;cursor:default;position:relative;}
.sq-c2 .who .np .mm-ft{margin:-6px 0 -5px;}
.sq-c2 .who .np .pips{position:absolute;left:50%;top:-9px;transform:translateX(-50%);display:flex;gap:1px;}
.sq-c2 .who .np .pips svg{width:12px;height:12px;filter:drop-shadow(0 1px 0 #6b4426);}
.sq-c2 .sq-chip.tag{cursor:default;height:22px;font-size:10.5px;color:#5b3418;background:#fff6e2;box-shadow:0 0 0 1.6px #6b4426,0 2px 0 1.6px #6b4426;}
.sq-c2 .act-at{position:absolute;left:calc(50% + 134px);top:118px;width:200px;display:flex;justify-content:center;}
.sq-c2 .act{width:190px;height:46px;border-radius:15px;display:flex;align-items:center;justify-content:center;gap:6px;font:700 15px Fredoka,sans-serif;}
.sq-c2 .act > svg:not(.mm-ft){width:18px;height:18px;}
.sq-c2 .row{position:absolute;left:0;right:0;top:284px;bottom:0;display:flex;align-items:flex-start;gap:22px;padding:2px 54px 0;overflow-x:auto;overflow-y:hidden;scrollbar-width:none;touch-action:none;cursor:grab;}
.sq-c2 .row:active{cursor:grabbing;}
.sq-c2 .gnav{position:absolute;top:330px;width:34px;height:34px;z-index:5;}
.sq-c2 .gnav svg{width:17px;height:17px;}
.sq-c2 .gnav.prev{left:10px;}
.sq-c2 .gnav.next{right:10px;}
.sq-c2 .gnav.off{opacity:.4;}
.sq-c2 .row::-webkit-scrollbar{display:none;}
.sq-c2 .row .grp{flex:none;display:flex;flex-direction:column;align-items:flex-start;gap:3px;position:relative;}
.sq-c2 .row .grp + .grp::before{content:'';position:absolute;left:-12px;top:20px;bottom:6px;width:2px;border-radius:1px;background:rgba(107,68,38,.35);}
.sq-c2 .row .gl{position:sticky;left:0;z-index:2;height:16px;padding:0 9px;border-radius:999px;font:800 10px/16px Nunito,sans-serif;color:#5b3418;background:#fff6e2;box-shadow:0 0 0 1.4px #6b4426;white-space:nowrap;}
.sq-c2 .row .gc{display:flex;gap:7px;padding:18px;margin:-18px;}
.sq-c2 .row .sq-cc{flex:none;width:56px;}
/* ---- performance (2026-11-14): what moves is on its own layer, glows pulse by opacity, nothing repaints every frame ---- */
.mm-stage{will-change:transform;}
.mm-card.sq-solo .mm-play{animation:none;box-shadow:0 0 0 1.8px #4a1f04,0 4px 0 1.8px #4a1f04,0 0 10px 3px rgba(255,214,110,.6),inset 0 1.5px 0 rgba(255,255,255,.6),inset 0 -4px 8px rgba(120,50,0,.35);}
.mm-card.sq-solo::before{content:'';position:absolute;left:-16px;right:-16px;top:-16px;bottom:-16px;border-radius:34px;background:radial-gradient(closest-side,rgba(255,214,110,.95),rgba(255,214,110,0));opacity:.4;pointer-events:none;}
.mm-card.sq-solo.fl::before{animation:sqGlowO .9s ease-in-out;}
.sq-sqz img{will-change:transform;}
.sq-lite .sq-wx{display:none;}
.sq-wx{position:absolute;inset:0;pointer-events:none;overflow:hidden;}
.sq-wxm{position:absolute;inset:0;will-change:transform;}
.sq-bird{position:absolute;left:0;top:0;will-change:transform;}
.sq-away .mm-hud *,.sq-away .mm-hud *::before,.sq-away .mm-hud *::after{animation-play-state:paused !important;}
.sq-away .sq-wx{display:none;}
.sq-intro .sq-wx{display:none;}
/* PERF 2026-11-20: the scene as a picture (see picture()), the live SVG hidden under it; the menu not drawn at all while
   the house or a page covers it whole */
.mm-scene > img.sq-pic{position:absolute;left:0;top:0;width:100%;height:100%;display:none;pointer-events:none;-webkit-user-drag:none;}
.mm-scene.sq-pic-on > img.sq-pic:not(.hh),.mm-scene.sq-pic-hh > img.sq-pic.hh{display:block;}
.mm-scene > .sq-live{position:absolute;left:0;top:0;width:100%;height:100%;}
.mm-scene.sq-pic-on > .sq-live,.mm-scene.sq-pic-hh > .sq-live{content-visibility:hidden;}
.mm-scene > img.sq-pic.nov{opacity:0;transition:opacity .45s ease;}
.mm-scene > img.sq-pic.nov.on{opacity:1;}
.mm-frame.sq-covered > .mm-world,.mm-frame.sq-covered > .mm-hud,.mm-frame.sq-covered > .sq-wx,.mm-frame.sq-covered > .mm-veil{content-visibility:hidden;}
@media (prefers-reduced-motion: reduce){.sq-crest .sq-cin,.sq-crest .mm-crest,.sq-wing1,.sq-wing-1,.sq-cstar,.sq-sweep,.sq-rays{animation:none;}}
`;
    document.head.appendChild(s);
  }

  // ---------- 0. performance: the scene drawn still, the weather on a layer the GPU slides (2026-11-14) ----------
  // The designer's scene SVG animated trees, smoke, lights, clouds, rain… inside one full-screen SVG with blur filters, so
  // every frame repainted all of it (~30 fps on a weak phone, ~15 in the park). Now the scene is still, and only the
  // weather moves: drawn once on its own layer, moved by transform (Web Animations: the compositor runs it).
  const rndS = (i, k) => { const v = Math.sin(i * 127.1 + k * 311.7) * 43758.5453; return v - Math.floor(v); };
  const stripAnim = svg => svg.replace(/<animate(?:Transform|Motion)?\b[^>]*\/>/g, '');
  let wx = null; // { el, key, anims }
  // the weather moving (on) or held where it is (off: the menu is covered); a sleeping page's own pause comes first
  // (SquishSleep pauses and plays only what was running)
  const weatherOn = on => { if (!wx) return; wx.anims.forEach(a => { try { if (!on && a.playState === 'running') a.pause(); else if (on && a.playState === 'paused' && !(window.SquishSleep && window.SquishSleep.asleep)) a.play(); } catch (e) { /* gone */ } }); };
  function weather(frame, st) {
    if (!frame) return;
    const W = frame.clientWidth, H = frame.clientHeight; if (!W || !H) return;
    const key = st.season + ':' + (st.f > 0.3 ? 1 : 0) + ':' + W + 'x' + H;
    if (wx && wx.key === key && wx.el.parentNode === frame) return;
    if (wx) { wx.anims.forEach(a => { try { a.cancel(); } catch (e) { /* gone */ } }); wx.el.remove(); wx = null; }
    const s = Math.max(W / 1000, H / 460), ox = (W - 1000 * s) / 2, oy = H - 460 * s;
    const el = document.createElement('div'); el.className = 'sq-wx';
    const svg = body => '<svg viewBox="0 0 1000 460" preserveAspectRatio="xMidYMax slice" width="100%" height="100%" style="position:absolute;inset:0;overflow:visible">' + body + '</svg>';
    const anims = [];
    const mover = (body, from, to, ms) => { const m = document.createElement('div'); m.className = 'sq-wxm'; m.innerHTML = svg(body); el.appendChild(m);
      anims.push(m.animate([{ transform: 'translate(' + from[0] * s + 'px,' + from[1] * s + 'px)' }, { transform: 'translate(' + to[0] * s + 'px,' + to[1] * s + 'px)' }], { duration: ms, iterations: Infinity, easing: 'linear' })); };
    if (st.season === 'rainy') {
      // a band 115 units tall, repeated 5 times; the layer moves one band per cycle (1.25x the screen's height, not 2x)
      let r = ''; for (let i = 0; i < 28; i++) { const x = rndS(i, 21) * 1100 - 50, y = rndS(i, 22) * 115; r += '<path d="M' + r1(x) + ' ' + r1(y) + ' l-4 14" stroke="#e8f2ff" stroke-width="1" opacity="' + r1(0.35 + rndS(i, 23) * 0.35) + '"/>'; }
      let band = ''; for (let k = -1; k < 4; k++) band += '<g transform="translate(0 ' + k * 115 + ')">' + r + '</g>';
      mover(band, [4, -115], [0, 0], 225);
    } else if (st.season === 'snowy') {
      let c = ''; for (let i = 0; i < 23; i++) { const x = rndS(i, 31) * 1000, y = rndS(i, 32) * 115, rr = 1 + rndS(i, 33) * 2; c += '<circle cx="' + r1(x) + '" cy="' + r1(y) + '" r="' + r1(rr) + '" fill="#ffffff" opacity="' + r1(0.6 + rndS(i, 34) * 0.4) + '"/>'; }
      let band = ''; for (let k = -1; k < 4; k++) band += '<g transform="translate(0 ' + k * 115 + ')">' + c + '</g>';
      mover(band, [0, -115], [3.5, 0], 3500);
    } else if (st.season === 'sunny' && st.f > 0.3) {
      for (let i = 0; i < 3; i++) {
        const b = document.createElement('div'); b.className = 'sq-bird'; const bw = 14 * s;
        b.innerHTML = '<svg viewBox="-1 -4 14 6" width="' + bw + '" height="' + (bw * 6 / 14) + '"><path d="M0 0 q3 -3 6 0 q3 -3 6 0" stroke="#4a4a5a" stroke-width="1" fill="none"/></svg>'; el.appendChild(b);
        const P0 = [-40 - i * 30, 60 + i * 18], C = [500, 20 + i * 10], P1 = [1060, 80 + i * 12], kf = [];
        for (let t = 0; t <= 1.0001; t += 0.125) { const x = (1 - t) * (1 - t) * P0[0] + 2 * (1 - t) * t * C[0] + t * t * P1[0], y = (1 - t) * (1 - t) * P0[1] + 2 * (1 - t) * t * C[1] + t * t * P1[1]; kf.push({ transform: 'translate(' + (ox + x * s) + 'px,' + (oy + y * s) + 'px)' }); }
        anims.push(b.animate(kf, { duration: (18 + i * 5) * 1000, iterations: Infinity, easing: 'linear' }));
      }
    }
    // over the scene and the park, under the HUD (the menu's frame: world, then veil, hud, pages)
    const after = frame.querySelector('.mm-world'); frame.insertBefore(el, after ? after.nextSibling : frame.firstChild);
    wx = { el, key, anims };
  }
  // main-menu.js draw(): the scene's markup without its animations, and the weather drawn on its layer
  // the door's white veil (walking into the house) is a full-screen layer even at opacity 0: hidden while see-through
  function veilWatch(frame) {
    const v = frame.querySelector('.mm-veil'); if (!v || v._sqW) return; v._sqW = 1;
    const sync = () => { if (v._sqZ) return; const o = parseFloat(v.style.opacity || '0'); v.style.visibility = o > 0 ? '' : 'hidden'; };
    v._sqSync = sync;
    sync(); new MutationObserver(sync).observe(v, { attributes: true, attributeFilter: ['style'] });
  }
  M.still = function (svg, st, sceneEl) {
    addCss();
    const frame = sceneEl && sceneEl.closest ? sceneEl.closest('.mm-frame') : null;
    if (frame) setTimeout(() => { weather(frame, st); veilWatch(frame); }, 0);   // (after the frame has its size)
    const s = stripAnim(svg);
    if (sceneEl) picture(sceneEl, s);
    // (in a box of its own: hidden under the picture by content-visibility, which keeps its styles and layout, so
    // showing or hiding it costs one paint, not a restyle of its thousands of shapes)
    return '<div class="sq-live">' + s + '</div>';
  };
  // PERF 2026-11-20: the scene as one picture, when it pays. The live scene SVG is thousands of shapes, and each frame
  // the creature moves Chrome re-sorts every shape of the page into GPU layers ("layerize"): ~12 ms a frame at the
  // bench's 4x slowdown, the biggest cost of the menu, and of every page or loader over it while the menu still shows.
  // The same markup drawn as an <img> (an SVG picture: no text, no fonts, nothing outside its box) is one shape. It is
  // not bit-for-bit the live SVG (its edges are smoothed a hair differently: on the bench 1.75/255 on average, the shapes'
  // edges only, nothing moved), so it's used only where it buys frames, and the live SVG (kept under it, hidden) shows
  // otherwise:
  //   - a slow phone: once the frame-rate guard has had to slow the creatures (app/perf.js step 2 or 3)
  //   - while a page opens over the menu, if the picture is already made (under its fade-in; then the menu isn't drawn at
  //     all: cover() below), and the trip home under Heading home (a picture of the scene with its door open: the house
  //     loads meanwhile)
  //   - never while something in the scene moves: the door on the trip home and back (main-menu.js goHome / back call
  //     SquishMenu.live, patched in), and the game intro (which draws its own scene)
  // SquishMenu.picture: 'auto' (that), 'on' (always), 'off' (never).
  // The vignette, faded out while the Game Park is beside the house, is a second picture without it, faded in on top
  // (the same fade as the live one).
  const VIG = /<rect x="-60" y="-20" width="1120" height="500" fill="url\(#[^)]*Vig\)" pointer-events="none"\/>/;
  let liveOn = false, picPage = false;
  M.picture = 'auto';
  // made only where it's used for good (a slow phone, or 'on'): each picture is a whole SVG document of its own in
  // memory (the scene's ~1,600 shapes again), not worth keeping on a phone that keeps up. Once made, a page opening
  // uses it too.
  const picBuild = () => M.picture === 'on' || (M.picture === 'auto' && !!(window.SquishPerf && window.SquishPerf.step >= 2));
  function picWanted() {
    if (liveOn || M.picture === 'off') return false;
    return picBuild() || picPage;
  }
  function picSync() {
    const x = M._x, sc = x && x.scene; if (!sc) return;
    if (!sc._sqPic && sc._sqMarkup && picBuild()) picture(sc, sc._sqMarkup, true);
    sc.classList.toggle('sq-pic-on', picWanted() && !!sc.querySelector(':scope > img.sq-pic:not(.hh)'));
  }
  function picture(scene, markup, now) {
    scene._sqPic = null; scene._sqMarkup = markup;
    scene.classList.remove('sq-pic-on', 'sq-pic-hh');
    scene.querySelectorAll('img.sq-pic').forEach(im => { URL.revokeObjectURL(im.src); im.remove(); });
    if (!window.Blob || !window.URL || !URL.createObjectURL) return;
    if (!now && !picBuild()) return;   // (made later, if the phone turns out slow: picSync)
    const tok = scene._sqPic = {};
    const mk = (s, cls) => { const im = new Image(); im.className = 'sq-pic' + (cls ? ' ' + cls : ''); im.alt = ''; im.src = URL.createObjectURL(new Blob([s], { type: 'image/svg+xml' })); return im; };
    const base = mk(markup), nov = VIG.test(markup) ? mk(markup.replace(VIG, ''), 'nov') : null;
    Promise.all([base, nov].filter(Boolean).map(im => im.decode ? im.decode() : Promise.resolve())).then(() => {
      if (scene._sqPic !== tok || !scene.isConnected) { [base, nov].forEach(im => im && URL.revokeObjectURL(im.src)); return; }
      const live = scene.querySelector(':scope > .sq-live');
      if (!live) return;
      scene.insertBefore(base, live); if (nov) scene.insertBefore(nov, live);
      const v = live.querySelector('rect[fill$="Vig)"]'); if (nov && v && v.style.opacity === '0') nov.classList.add('on');
      picSync();
    }).catch(() => { [base, nov].forEach(im => im && URL.revokeObjectURL(im.src)); });
  }
  // the live scene shown (on: the door opens and shuts in it) or back to the picture where it's wanted (off)
  M.live = function (on) { liveOn = !!on; picSync(); };
  // Heading home: the scene with its door open, as a picture, under the night (url: a picture of it; null: done)
  // PERF 2026-11-20: an SVG drawn into pixels once, on the CPU, as a JPEG blob URL (w x h user units at k px each). An SVG
  // shown as an image is still vectors: the WebView rasters it on its GPU thread, which every frame of the app waits
  // for, each time it shows at a new scale. Drawn into a CPU canvas (willReadFrequently) the work is the page's main
  // thread's, which Web Animations and the compositor don't wait for; JPEG: the scene has no see-through parts.
  // (the same, as the CPU canvas it was drawn into; `bands`: drawn a horizontal strip at a time, one strip a task, so
  //  frames go out between them: one drawImage of the menu scene held the page's main thread ~0.28 s on the Galaxy A16,
  //  under Heading home; the drawing skips what lies outside each strip)
  function svgCanvas(svgText, w, h, k, bands) {
    return new Promise((res, rej) => {
      const W = Math.round(w * k), H = Math.round(h * k), cut = svgText.indexOf('>') + 1;
      const head = svgText.slice(0, cut).replace(/\s(width|height)="[^"]*"/g, '').replace(/^<svg/, '<svg width="' + w + '" height="' + h + '"');
      const src = URL.createObjectURL(new Blob([head + svgText.slice(cut)], { type: 'image/svg+xml' }));
      const im = new Image();
      im.onload = () => {
        try {
          const cv = document.createElement('canvas'); cv.width = W; cv.height = H;
          const c = cv.getContext('2d', { willReadFrequently: true });
          const n = Math.max(1, bands | 0), bh = Math.ceil(H / n);
          let i = 0;
          const strip = () => {
            try {
              c.save(); c.beginPath(); c.rect(0, i * bh, W, bh); c.clip(); c.drawImage(im, 0, 0, W, H); c.restore();
              if (++i < n) { setTimeout(strip, 0); return; }
              URL.revokeObjectURL(src);
              res(cv);
            } catch (e) { URL.revokeObjectURL(src); rej(e); }
          };
          strip();
        } catch (e) { URL.revokeObjectURL(src); rej(e); }
      };
      im.onerror = () => { URL.revokeObjectURL(src); rej(new Error('svg')); };
      im.src = src;
    });
  }
  function bitmapOf(svgText, w, h, k, type) {
    return svgCanvas(svgText, w, h, k).then(cv => new Promise((res, rej) => {
      cv.toBlob(b => { cv.width = cv.height = 0; if (b) res(URL.createObjectURL(b)); else rej(new Error('toBlob')); }, type || 'image/jpeg', 0.9);
    }));
  }
  function picDoor(url) {
    const x = M._x, sc = x && x.scene; if (!sc) return;
    sc.querySelectorAll(':scope > img.sq-pic.hh').forEach(im => im.remove());
    sc.classList.remove('sq-pic-hh');
    if (!url || M.picture === 'off') return;
    const im = new Image(); im.className = 'sq-pic hh'; im.alt = ''; im.src = url;
    (im.decode ? im.decode() : Promise.resolve()).then(() => { if (!HH || !sc.isConnected) return; sc.insertBefore(im, sc.firstChild); sc.classList.add('sq-pic-hh'); }).catch(() => {});
  }
  // a rotation or resize redraws the weather for the new size
  window.addEventListener('resize', () => { const f = document.querySelector('.mm-frame'), x = M._x; if (f && x && x.st) { wx && (wx.key = ''); weather(f, x.st); } });
  // the menu's own creature isn't drawn while it can't be seen: under the house, or under a full-screen page
  // and the menu's own animations (HUD, weather) pause while the house or a page covers them
  // PERF 2026-11-20: and once the house or a page fully covers the menu (its opening fade done, the door's veil white),
  // the menu isn't drawn at all (sq-covered: its scene, creature, HUD and weather hidden): Chrome no longer sorts its
  // shapes into layers every frame under the house (the house's own frame rate nearly doubled on the bench) or keeps
  // its tiles. Uncovered at once (in the same frame) when the page closes or the trip back starts (patched in).
  function cover() {
    const x = M._x; if (!x || !x.frame) return;
    const pg = x.ov && x.ov.querySelector('.mm-page2'), I = x.ctrl && x.ctrl._I;
    const away = !!(x.inside || pg || HH);   // (HH: Heading home, the creature has gone in at the door)
    if (I) I.sqHold = away;
    if (window.SquishPerf && window.SquishPerf.scope) window.SquishPerf.scope(x.inside ? 'house' : 'menu');
    x.frame.classList.toggle('sq-away', away);
    let full = false;
    if (x.inside && !x.busy) full = (parseFloat(x.veil.style.opacity) || 0) >= 1;
    else if (pg && !x.busy) { try { full = !pg.getAnimations().some(a => a.playState === 'running'); } catch (e) { full = true; } }
    x.frame.classList.toggle('sq-covered', full);
    // PERF 2026-11-20: the weather's moving layers (Web Animations: CSS rules can't pause them) stop while the menu is
    // fully covered. Running unseen, they made the WebView draw every frame anyway, and on the phone a WebView frame
    // composites the whole page: the house's Catalog sat at 13-20 fps with nothing on it moving.
    weatherOn(!full);
    if (picPage && !pg) picPage = false;
    if (!liveOn) picSync();
  }
  M.cover = cover;
  // the menu's creature stops at once (a page is opening over it); cover() does the rest on its next round (it reads
  // the page's animations, which would make the browser restyle the page in the tap's own frame)
  // (and the scene is its picture under the page: the page's first frames don't sort the scene's shapes again)
  M.hold = function () { const x = M._x, I = x && x.ctrl && x.ctrl._I; if (I) I.sqHold = true; picPage = true; picSync(); };
  M.uncover = function () { const x = M._x; if (!x || !x.frame) return; x.frame.classList.remove('sq-covered'); const I = x.ctrl && x.ctrl._I; if (I && !x.inside && !HH) I.sqHold = false; if (picPage) { picPage = false; picSync(); } };
  setInterval(cover, 400);
  // PERF 2026-11-20: in the house, the creatures stand still while the Catalog book, the map or the level-up card covers
  // the room (SquishPerf.freeze; the house's state is window.__sh). Watched often while inside, so a panel opening is
  // smooth from its first frames.
  setInterval(() => {
    const x = M._x, sh = window.__sh, P = window.SquishPerf; if (!P) return;
    const S = x && x.inside && sh && !sh.dead && sh.state;
    const fr = !!(S && (S.shop || S.map || S.lvUp));
    // the house's map stands still: its picture is one big SVG with ~130 SMIL animations (trees, waves, smoke, rain),
    // and every step of any of them made the phone draw the whole map again at 2.8x: 4-5 fps on the Galaxy A16. Paused,
    // it draws only when something changes (a tap, the walk to a room).
    if (S && S.map) document.querySelectorAll('[data-screen-label="House map"] svg').forEach(v => { if (!v.ownerSVGElement && v.pauseAnimations && !v.animationsPaused()) v.pauseAnimations(); });
    if (S && S.map && window.SquishMapShown) window.SquishMapShown();   // (its picture: also patched into openMap)
    // (the frame-rate guard isn't judged for a moment after: the room's creatures start up again)
    if (P.freeze && !fr && P.quiet) P.quiet(1500);
    P.freeze = fr;
    document.documentElement.classList.toggle('sq-hfz', fr);   // (2026-11-21: the disco floor's fades pause too, SquishDisco)
  }, 120);
  // PERF 2026-11-20: going to a room from the house map fades through cream (the map's own veil fades in), and the new
  // room is drawn under this cream veil, which fades out once frames reach the screen in time again (the room's tiles
  // are rastered: SquishPerf.steady), at most ~1.6 s. The map closed straight onto the bare cream page and the WebView
  // took 0.5-1.2 s to raster the room's big SVG on the Galaxy A16: a blank page, then the room popping in. 0.99, not 1:
  // an opaque layer hides what's under it from the rasterizer, and the room would only start drawing once uncovered.
  // (Called by the house's enterRoom, webgame/patches.mjs.)
  // PERF 2026-11-20 (the user: the map is worse): the house map as a picture. The map is one SVG of ~1,200 shapes with
  // 26 blurs, and the WebView rastered all of it at 2.8x on its GPU thread (which every frame waits for) each time it
  // opened, and again for every change on it (a tap): 0.5-1 s of blank sea, then a frozen map after each tap, on the
  // Galaxy A16. Now the first time the map is up in a given state, once its frames flow, it is drawn ONCE into a JPEG on
  // the CPU (bitmapOf, the page's main thread), kept (memory, and IndexedDB for the next launches, by a hash of the
  // map's markup), and laid over the SVG as an opaque layer: the compositor then never rasters the SVG under it (its
  // tiles are hidden), opening the map shows one picture, and a tap changes nothing that has to be drawn again. Taps go
  // through the picture (pointer-events none) to the rooms' shapes; the room names and badges are HTML on top as before.
  // The map's animations (rain, waves, trees) were already paused while it is open.
  const MAPC = new Map(), MAPI = { key: null, im: null };
  const idb = (() => { let p = null; return () => p || (p = new Promise((res) => { try { const r = indexedDB.open('sq-bake', 2); r.onupgradeneeded = () => { const db = r.result; if (!db.objectStoreNames.contains('pics')) db.createObjectStore('pics'); if (!db.objectStoreNames.contains('tex')) db.createObjectStore('tex'); }; r.onsuccess = () => res(r.result); r.onerror = () => res(null); } catch (e) { res(null); } })); })();
  const idbGet = (k, store) => idb().then(db => db && new Promise(res => { try { const q = db.transaction(store || 'pics').objectStore(store || 'pics').get(k); q.onsuccess = () => res(q.result || null); q.onerror = () => res(null); } catch (e) { res(null); } }));
  const idbPut = (k, v, store, keep) => idb().then(db => { if (!db) return; try { const S0 = store || 'pics', st = db.transaction(S0, 'readwrite').objectStore(S0); st.put(v, k); const all = st.getAllKeys(); all.onsuccess = () => { const ks = all.result.filter(x => x !== k), n = keep || 6; if (ks.length > n) ks.slice(0, ks.length - n).forEach(x => st.delete(x)); }; } catch (e) { /* full */ } });
  // PERF 2026-11-20: the house rooms' wall, floor, ceiling and fence textures as pictures. The house makes each texture as
  // an SVG (64-232 shapes) and tiles it with an SVG pattern, slanted for the side walls; the WebView drew that SVG again,
  // at full size, for every 256-px tile of the room: 120-400 ms a tile, ~1-1.3 s of the GPU thread before a room could
  // show on the Galaxy A16 (the cream pause between rooms, the stalls under Heading home). Each texture is now drawn ONCE
  // into a WebP on the CPU (bitmapOf), kept in memory and in IndexedDB (loaded at start: the next launches have them
  // before the house draws), and the house uses the picture (webgame/patches.mjs wraps its rnTex): a tile of the room
  // then costs a bitmap fill. The first time a texture is seen, the room shows it as before and swaps to the picture as
  // soon as it is made (one at a time, between frames).
  const TEXC = new Map(), TEXQ = [], TEXPEND = new Set(), TEXSZ = { wall: [214, 150], wallS: [214, 600], floor: [1004, 294], ceil: [1260, 70], fence: [160, 56], fenceR: [160, 56], ground: [1004, 294] };
  let texBusy = false, texRedraw = null;
  const texLoaded = idb().then(db => db && new Promise(res => { try { const st = db.transaction('tex').objectStore('tex'), ks = st.getAllKeys(), vs = st.getAll(); vs.onsuccess = () => { (ks.result || []).forEach((k, i) => { const b = vs.result[i]; if (b && !TEXC.has(k)) TEXC.set(k, URL.createObjectURL(b)); }); res(); }; vs.onerror = () => res(); } catch (e) { res(); } })).catch(() => {});
  const texNext = () => {
    if (texBusy || !TEXQ.length) return;
    texBusy = true;
    const { key, url, slot } = TEXQ.shift();
    let svg = ''; try { svg = decodeURIComponent(url.slice(url.indexOf(',') + 1)); } catch (e) { /* bad */ }
    let [w, h] = TEXSZ[slot] || [400, 300], k = Math.min(4, 4096 / Math.max(w, h));
    // (a piece of furniture: its own proportions, 1,400 px on its long side, about what the room draws it at on a phone)
    if (slot === 'item') { const m = svg.match(VBOX), vw = m ? +m[1] : 0, vh = m ? +m[2] : 0; if (!(vw > 0 && vh > 0)) { done(); return; } const s = 1400 / Math.max(vw, vh); w = vw * s; h = vh * s; k = 1; }
    const done = () => { texBusy = false; TEXPEND.delete(key); setTimeout(texNext, 30); };
    if (!svg) { done(); return; }
    bitmapOf(svg, w, h, k, 'image/webp').then(u => {
      TEXC.set(key, u); fetch(u).then(r => r.blob()).then(b => idbPut(key, b, 'tex', 80)).catch(() => {});
      clearTimeout(texRedraw); texRedraw = setTimeout(() => { const sh = window.__sh; if (sh && !sh.dead && sh.forceUpdate) sh.forceUpdate(); }, 60);
      done();
    }).catch(done);
  };
  const VBOX = /viewBox=["']\s*[-\d.e]+[\s,]+[-\d.e]+[\s,]+([\d.e]+)[\s,]+([\d.e]+)\s*["']/;
  const TEXKEY = new Map();   // slot -> (url -> its key, or '' for one that stays as it is): called at every house render
  window.SquishTex = function (url, slot) {
    if (typeof url !== 'string' || !url.startsWith('data:image/svg+xml')) return url;
    let ks = TEXKEY.get(slot); if (!ks) TEXKEY.set(slot, ks = new Map());
    let key = ks.get(url);
    if (key === undefined) {
      key = slot + ':' + fnv(url);
      // (furniture without a viewBox can't be drawn to a size: left as it is)
      if (slot === 'item') { let head = ''; try { head = decodeURIComponent(url.slice(0, 4000).replace(/%[0-9A-F]?$/i, '')); } catch (e) { /* cut mid-character */ } if (!VBOX.test(head)) key = ''; }
      if (ks.size > 300) ks.clear();
      ks.set(url, key);
    }
    if (!key) return url;
    const hit = TEXC.get(key);
    if (hit) return hit;
    if (!TEXPEND.has(key)) { TEXPEND.add(key); texLoaded.then(() => { if (TEXC.has(key)) { TEXPEND.delete(key); const sh = window.__sh; clearTimeout(texRedraw); texRedraw = setTimeout(() => { if (sh && !sh.dead && sh.forceUpdate) sh.forceUpdate(); }, 30); return; } TEXQ.push({ key, url, slot }); texNext(); }); }
    return url;
  };
  const fnv = s => { let h = 0x811c9dc5; for (let i = 0; i < s.length; i++) { h ^= s.charCodeAt(i); h = Math.imul(h, 0x01000193); } return (h >>> 0).toString(36) + '.' + s.length; };
  // 2026-11-21 (the user: the light-up dance floors' colours back, "without sacrificing the fps too much"): the Dance
  // Room's floors that light up (DISCO) lost their animation that morning (their tile's SMIL made the browser draw the
  // whole tilted floor again every frame: 3 fps; webgame/patches.mjs rnFlat). Their animation is now shown as DK moments
  // of its loop: each tile is paused at that moment (svgAt: the animated values written into a still copy), drawn once
  // into a picture (kept like the room textures: IndexedDB 'tex', key disco:<tile hash>:<k>/<DK>), and the house stacks
  // copies of its 3D floor over the floor, one per moment, switched on in turn (no fade) by CSS opacity animations
  // (sqDisco*): the GPU only shows finished layers, nothing is drawn again. Not in lite mode (the frame-rate guard's step 3: sq-lite-all),
  // paused while the house stands still under the Catalog, the map or a level-up (sq-hfz). The other floors (the
  // cardboard mat's dust, the checkerboard's drifting spots) stay still.
  // (+ CLB-005 and CLB-025, the user picked them the same day: the cardboard mat's tape and dust, the checkerboard's
  //  gliding party lights)
  const DISCO = { 'CLB-005': 1, 'CLB-025': 1, 'CLB-045': 1, 'CLB-065': 1, 'CLB-085': 1, 'CLB-114': 1 }, DK = 4;
  const DMEMO = new Map(), DSEEN = new Set(), DQ = []; let dBusy = false, dCss = false;
  const svgOfUrl = url => { let s = url.slice(url.indexOf(',') + 1); try { s = decodeURIComponent(s); } catch (e) { /* plain */ } return s; };
  // a tile's loop: its longest animation up to 6 s (longer ones are slow drifts; a moment of them is enough). A tile
  // whose animations are all slower (the checkerboard's party lights, 9-20 s) is caught over its slowest one, up to
  // 20 s, so the moments differ; it is still played in at most 6 s (loopOf -> [moments over P s, shown over D s])
  const loopOf = s => { let P = 0, all = 0; for (const m of s.matchAll(/\bdur="([\d.]+)s"/g)) { const d = +m[1]; if (d > P && d <= 6) P = d; if (d > all) all = d; } if (!P) P = Math.min(all, 20) || 4; return [P, Math.min(P, 6)]; };
  // the SVG as it looks t seconds into its animations, as a still SVG (null if it can't be done)
  function svgAt(svgText, t) {
    const host = document.createElement('div');
    host.style.cssText = 'position:fixed;left:-9999px;top:0;width:8px;height:8px;overflow:hidden;visibility:hidden;pointer-events:none;';
    host.innerHTML = svgText; document.body.appendChild(host);
    try {
      const svg = host.querySelector('svg'); if (!svg || !svg.setCurrentTime) return null;
      svg.pauseAnimations(); svg.setCurrentTime(t);
      const anims = [...svg.querySelectorAll('animate, animateTransform, animateMotion, animateColor, set')], writes = [];
      anims.forEach(a => {
        const el = a.targetElement, n = a.getAttribute('attributeName'); if (!el) return;
        // (the animated transform list is read-only, consolidate() throws: its items' matrices multiplied instead)
        if (a.tagName === 'animateTransform') { const L = el.transform && el.transform.animVal; let m = new DOMMatrix(); for (let i = 0; L && i < L.numberOfItems; i++) m = m.multiply(DOMMatrix.fromMatrix(L.getItem(i).matrix)); writes.push([el, 'transform', L && L.numberOfItems ? 'matrix(' + [m.a, m.b, m.c, m.d, m.e, m.f].map(v => +v.toFixed(4)).join(' ') + ')' : null]); return; }
        if (!n) return;
        const p = el[n], av = p && p.animVal;   // geometry (cx, r, offset...): the animated DOM value
        if (av != null && typeof av === 'object' && 'value' in av) { writes.push([el, n, String(av.value)]); return; }
        if (typeof av === 'number' || typeof av === 'string') { writes.push([el, n, String(av)]); return; }
        // presentation attributes (opacity, fill, d...): the computed style carries the animated value
        let v = getComputedStyle(el).getPropertyValue(n); if (n === 'd') v = v.replace(/^path\(\s*["']?/, '').replace(/["']?\s*\)$/, '');
        if (v) writes.push([el, n, v]);
      });
      writes.forEach(([el, n, v]) => { if (v == null) el.removeAttribute(n); else el.setAttribute(n, v); });
      anims.forEach(a => a.remove());
      return new XMLSerializer().serializeToString(svg);
    } catch (e) { return null; } finally { host.remove(); }
  }
  function discoJob() {
    if (dBusy || !DQ.length) return;
    dBusy = true;
    const { key, svgText, t } = DQ.shift();
    const done = () => { dBusy = false; setTimeout(discoJob, 60); };
    const go = () => {
      const svg = svgAt(svgText, t), m = svg && svg.match(VBOX), vw = m ? +m[1] : 0, vh = m ? +m[2] : 0;
      if (!svg || !(vw > 0 && vh > 0)) { done(); return; }
      const s = 1400 / Math.max(vw, vh);   // (as SquishTex 'item': about the tile's size on the phone)
      bitmapOf(svg, vw * s, vh * s, 1, 'image/webp').then(u => {
        TEXC.set(key, u); fetch(u).then(r => r.blob()).then(b => idbPut(key, b, 'tex', 80)).catch(() => {});
        clearTimeout(texRedraw); texRedraw = setTimeout(() => { const sh = window.__sh; if (sh && !sh.dead && sh.forceUpdate) sh.forceUpdate(); }, 60);
        done();
      }).catch(done);
    };
    // (made while frames flow: each is ~0.1-0.3 s of the page's main thread on the Galaxy A16)
    const P = window.SquishPerf; if (P && P.steady) P.steady(go, 2500, 4); else setTimeout(go, 200);
  }
  function discoCss() {
    if (dCss) return; dCss = true;
    const slot = 100 / DK, p = x => +x.toFixed(2) + '%';
    let css = '.sq-disco{opacity:0;will-change:opacity;pointer-events:none;}.sq-lite-all .sq-disco{display:none;}.sq-hfz .sq-disco{animation-play-state:paused;}';
    // layer j is shown during its slot only, switched on and off at once (no fade: the user, "i don't want it like
    // that"; the animations run step-end, so each keyframe's value holds until the next); after the last slot the
    // floor's own moment 0 is back. During the slot BEFORE its own, a layer is already there at 1% (invisible): at 0 the
    // WebView doesn't draw it and drops its tiles, so it had to draw it at the moment it came on and showed its dark
    // colour meanwhile (the user: "black flickers on the floors when they change"; the copies have no colour of their own
    // now either). Drawn a slot early it switches in one frame (recorded on the Galaxy A16). At most the floor, the
    // copy on show and the next one are drawn.
    for (let j = 1; j < DK; j++) {
      const a = j * slot, top = j === DK - 1;
      css += '@keyframes sqDisco' + DK + '_' + j + '{0%{opacity:' + (j === 1 ? 0.01 : 0) + '}' + (j > 1 ? p(a - slot) + '{opacity:0.01}' : '') + p(a) + '{opacity:1}' + (top ? '100%{opacity:1}' : p(a + slot) + ',100%{opacity:0}') + '}';
    }
    const st = document.createElement('style'); st.textContent = css; document.head.appendChild(st);
  }
  // f: the floor item; layers: its 3D floor's tile layers (rnDraw(..).floorRoom.layers). Returns null (the floor stays
  // still) or { frames: per layer, null or its DK pictures, anims: the DK - 1 layers' CSS animations }.
  window.SquishDisco = function (f, layers) {
    if (!DISCO[f] || !layers || !layers.length || document.documentElement.classList.contains('sq-lite-all')) return null;
    let ready = true, P = 0;
    const frames = layers.map((l, i) => {
      const src = l.url; if (typeof src !== 'string' || src.indexOf('data:image/svg') !== 0) return null;
      const mk = f + ':' + i + ':' + src.length;
      let d = DMEMO.get(mk);
      if (!d) { const s = svgOfUrl(src), anim = /<(animate|animateTransform|set)\b/.test(s), lp = anim ? loopOf(s) : [0, 0]; d = { anim, h: anim ? fnv(src) : '', P: lp[0], D: lp[1], s: anim ? s : '' }; DMEMO.set(mk, d); }
      if (!d.anim) return null;
      P = Math.max(P, d.D);
      return Array.from({ length: DK }, (x, k) => {
        const key = 'disco:' + d.h + ':' + k + '/' + DK, hit = TEXC.get(key);
        if (hit) return hit;
        ready = false;
        if (!DSEEN.has(key)) { DSEEN.add(key); texLoaded.then(() => { if (TEXC.has(key)) { const sh = window.__sh; if (sh && !sh.dead && sh.forceUpdate) sh.forceUpdate(); return; } DQ.push({ key, svgText: d.s, t: k * d.P / DK }); discoJob(); }); }
        return null;
      });
    });
    if (!ready || !frames.some(Boolean)) return null;
    discoCss();
    return { frames, anims: Array.from({ length: DK - 1 }, (x, j) => 'sqDisco' + DK + '_' + (j + 1) + ' ' + P + 's step-end infinite') };
  };
  // the map's last picture, read and decoded at start (sq.mapKey: the key it was made for), so the first opening after a
  // launch shows it in its first frame instead of waiting for IndexedDB while the SVG starts drawing
  try {
    const last = localStorage.getItem('sq.mapKey');
    if (last) idbGet(last).then(blob => { if (!blob || MAPC.has(last)) return; const u = URL.createObjectURL(blob); MAPC.set(last, u); const im = document.createElement('img'); im.className = 'sq-bake'; im.alt = ''; im.style.cssText = 'position:absolute;inset:0;width:100%;height:100%;pointer-events:none;'; im.src = u; if (im.decode) im.decode().catch(() => {}); MAPI.key = last; MAPI.im = im; });
  } catch (e) { /* no storage */ }
  window.SquishMapShown = function () {
    const m = document.querySelector('[data-screen-label="House map"]'), svg = m && m.querySelector(':scope > div > svg');
    if (!svg || svg._sqBake) return;
    const box = svg.parentElement, w = box.clientWidth, h = box.clientHeight, k = Math.min(3, window.devicePixelRatio || 1);
    if (!w || !h) return;
    let markup; try { markup = new XMLSerializer().serializeToString(svg).replace(/<(animate|animateTransform|animateMotion|animateColor|set)\b[^>]*\/>/g, '').replace(/<(animate|animateTransform|animateMotion|animateColor)\b[^>]*>[\s\S]*?<\/\1>/g, ''); } catch (e) { return; }
    const key = 'map:' + w + 'x' + h + '@' + k + ':' + fnv(markup);
    svg._sqBake = key;
    // (one picture element, kept across openings: decoded once, it shows in the map's first frame; the SVG stops being
    //  drawn only once the picture can be: before, it was hidden at once and the sea showed bare until the JPEG decoded)
    const put = url => {
      if (!svg.isConnected || svg._sqBake !== key) return;
      let im = MAPI.key === key ? MAPI.im : null;
      if (!im) { im = document.createElement('img'); im.className = 'sq-bake'; im.alt = ''; im.style.cssText = 'position:absolute;inset:0;width:100%;height:100%;pointer-events:none;'; im.src = url; MAPI.im = im; MAPI.key = key; }
      if (im.parentNode !== box) svg.after(im);
      const hide = () => { if (svg.isConnected && svg._sqBake === key) svg.classList.add('sq-baked'); };
      if (im.complete && im.naturalWidth) hide(); else (im.decode ? im.decode() : Promise.resolve()).then(hide, () => {});
    };
    const hit = MAPC.get(key); if (hit) { try { localStorage.setItem('sq.mapKey', key); } catch (x) { /* full */ } put(hit); return; }
    idbGet(key).then(blob => {
      if (blob) { const u = URL.createObjectURL(blob); MAPC.set(key, u); try { localStorage.setItem('sq.mapKey', key); } catch (e) { /* full */ } put(u); return; }
      // not made yet: once the map is up and frames flow (it stays still while open), draw it
      const P = window.SquishPerf;
      const make = () => { if (!svg.isConnected) return; bitmapOf(markup, w, h, k).then(u => { MAPC.set(key, u); fetch(u).then(r => r.blob()).then(b => idbPut(key, b)).catch(() => {}); try { localStorage.setItem('sq.mapKey', key); } catch (e) { /* full */ } put(u); }).catch(() => {}); };
      if (P && P.steady) P.steady(make, 3000, 6); else setTimeout(make, 800);
    });
  };
  // 2026-11-21 (the user wanted the map's zoom back, without fps trouble): picking a room zooms the map 2.6x into it
  // again, as the design did, but only while the map shows its picture (above: the SVG under it is visibility:hidden,
  // so none of it is drawn). The zooming box is made its own layer here (will-change: transform); the house's mapPick
  // (webgame/patches.mjs) starts the zoom two frames later, once that layer is drawn at 1x, and the zoom then only
  // scales it on the GPU: nothing is drawn again (it goes a little soft towards 2.6x, under the cream that fades in).
  // The SVG zoom of 2026-11-20 rastered the whole map again at 2.6x first: 0.7-0.9 s frozen on the Galaxy A16. Without
  // the picture (the first opening of a new map state) the map fades to cream with no zoom. The box is the map's own
  // and goes when the map closes, its will-change with it.
  window.SquishMapZoom = function () {
    const m = document.querySelector('[data-screen-label="House map"]'), svg = m && m.querySelector(':scope > div > svg');
    if (!svg || !svg.classList.contains('sq-baked')) return false;
    svg.parentElement.style.willChange = 'transform';
    return true;
  };
  window.SquishVeil = function () {
    const host = document.querySelector('.mm-house'); if (!host) return;
    let v = host.querySelector(':scope > .sq-veil');
    if (!v) { v = document.createElement('div'); v.className = 'sq-veil'; v.style.cssText = 'position:absolute;inset:0;z-index:1001;background:#fff6e2;pointer-events:none;opacity:.99;transition:opacity .28s ease-out;'; host.appendChild(v); }
    v.style.transition = 'none'; v.style.opacity = '.99'; clearTimeout(v._t);
    const P = window.SquishPerf, off = () => { v.style.transition = 'opacity .28s ease-out'; v.style.opacity = '0'; v._t = setTimeout(() => v.remove(), 400); };
    requestAnimationFrame(() => requestAnimationFrame(() => { if (P && P.steady) P.steady(off, 1600, 4); else setTimeout(off, 600); }));
  };
  document.addEventListener('animationend', e => { if (e.target && e.target.classList && e.target.classList.contains('mm-page2')) cover(); });
  // the crest's flourish (wings flap, star flips, a shine): a short burst every few seconds, not a non-stop repaint
  // (between flourishes nothing in the HUD moves: a non-stop animation keeps its own GPU layer, and a weak GPU pays for
  //  every layer every frame; the menu doubled its frame rate without them)
  setInterval(() => {
    if (document.hidden) return;
    // (PERF 2026-11-20: restarted over two frames, not by reading offsetWidth, which made the browser restyle and lay
    // out the whole page there and then: a hitch every 5 s)
    ['.sq-crest', '.mm-card.sq-solo'].forEach((q, i) => { const c = document.querySelector(q); if (!c || c.closest('.sq-away')) return; setTimeout(() => { c.classList.remove('fl'); requestAnimationFrame(() => requestAnimationFrame(() => c.classList.add('fl'))); }, i * 1300); });
  }, 5200);
  // still too slow with the creatures at 20 fps (app/perf.js step 3): no weather layer (the picture keeps its rainy look)
  setInterval(() => { const f = M._x && M._x.frame; if (f && window.SquishPerf) f.classList.toggle('sq-lite', window.SquishPerf.step >= 3); if (window.SquishPerf) document.documentElement.classList.toggle('sq-lite-all', window.SquishPerf.step >= 3); }, 1000);   // (sq-lite-all: the house isn't inside the frame; its disco floor goes off too)

  // ---------- the trophy button (REDESIGN_V8): next to the gear, opens Achievements ----------
  M.trophy = function () {
    const id = 'sqtr' + (++UID);
    return '<svg viewBox="0 0 32 32" aria-hidden="true"><defs><linearGradient id="' + id + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#fffbe0"/><stop offset=".4" stop-color="#ffd85a"/><stop offset=".8" stop-color="#f0a21c"/><stop offset="1" stop-color="#b8640a"/></linearGradient></defs>'
      + '<path d="M9 6.5 Q3.5 6.5 4 11.5 Q4.6 16.5 10.5 17 M23 6.5 Q28.5 6.5 28 11.5 Q27.4 16.5 21.5 17" fill="none" stroke="#6b4426" stroke-width="4.2" stroke-linecap="round"/>'
      + '<path d="M9 6.5 Q3.5 6.5 4 11.5 Q4.6 16.5 10.5 17 M23 6.5 Q28.5 6.5 28 11.5 Q27.4 16.5 21.5 17" fill="none" stroke="url(#' + id + ')" stroke-width="2" stroke-linecap="round"/>'
      + '<path d="M8 4.5 H24 V11 Q24 19.5 16 20.5 Q8 19.5 8 11 Z" fill="url(#' + id + ')" stroke="#6b4426" stroke-width="1.8" stroke-linejoin="round"/>'
      + '<path d="M14 20.5 H18 V24 H14 Z" fill="#f0a21c" stroke="#6b4426" stroke-width="1.6"/>'
      + '<path d="M10 24 H22 Q23 24 23 25 V28 H9 V25 Q9 24 10 24 Z" fill="#b47a42" stroke="#6b4426" stroke-width="1.8" stroke-linejoin="round"/>'
      + '<path d="M16 7.6 l1.3 2.7 3 .4 -2.2 2.1 .5 2.9 -2.6 -1.4 -2.6 1.4 .5 -2.9 -2.2 -2.1 3 -.4Z" fill="#fff6c8" stroke="#b8640a" stroke-width=".8" stroke-linejoin="round"/>'
      + '<path d="M10.2 6.6 V10.5" stroke="#ffffff" stroke-width="1.4" stroke-linecap="round" opacity=".75"/></svg>';
  };

  // ---------- 1. the level crest, alive ----------
  let ringShown = false;
  M.crest = function (L, crestFn) {
    addCss();
    const s0 = S(), xp = s0.xp, lv = (xp && xp.level) || L, id = 'sqcr' + (++UID);
    let svg = crestFn(lv);
    // REDESIGN_V8 colours: brown outlines (were purple), a ruby medallion (was purple), cream wings (were lavender)
    svg = svg.replace(/#6b4426/g, '#6b4426')
      .replace('stop-color="#f3e2ff"/><stop offset="0.3" stop-color="#b783ff"/><stop offset="0.7" stop-color="#6a26d0"/><stop offset="1" stop-color="#36107a"',
        'stop-color="#ffd9c4"/><stop offset="0.3" stop-color="#ff7a4c"/><stop offset="0.7" stop-color="#cc3a1c"/><stop offset="1" stop-color="#7a1c0c"')
      .replace('stop-color="#f1e8ff"/><stop offset="1" stop-color="#cdb8f4"', 'stop-color="#fff6e2"/><stop offset="1" stop-color="#efcf9c"')
      .replace(/#b9a2e8/g, '#c99a62');
    // wings: a wrapper each, flapping from the shoulder
    svg = svg.replace(/<g transform="translate\(60 0\) scale\((-?1) 1\) translate\(-60 0\)">([\s\S]*?)<\/g>/g, (m, s) => '<g class="sq-wing' + s + '">' + m + '</g>');
    // the star on top flips now and then
    svg = svg.replace('<path d="M60 4 ', '<g class="sq-cstar"><path d="M60 4 ').replace('<circle cx="60" cy="58" r="31"', '</g><circle cx="60" cy="58" r="31"');
    // the XP ring (in the gold band, over its studs) and a shine sweeping the medallion
    const f = xp && xp.need > 0 ? clamp(xp.into / xp.need, 0, 1) : 0, C = 2 * Math.PI * 27.2, a = (C * f).toFixed(1);
    const ring = xp ? '<circle cx="60" cy="58" r="27.2" fill="none" stroke="#6b4426" stroke-opacity=".55" stroke-width="4.4"/>'
      + '<circle cx="60" cy="58" r="27.2" fill="none" stroke="url(#' + id + 'r)" stroke-width="4.4" stroke-linecap="round" transform="rotate(-90 60 58)" stroke-dasharray="' + a + ' ' + C.toFixed(1) + '">'
      + (ringShown ? '' : '<animate attributeName="stroke-dasharray" from="0 ' + C.toFixed(1) + '" to="' + a + ' ' + C.toFixed(1) + '" dur="1.4s" begin="0.3s" fill="freeze" calcMode="spline" keySplines=".2 .9 .25 1" keyTimes="0;1"/>') + '</circle>' : '';
    if (xp) ringShown = true;
    svg = svg.replace('<circle cx="60" cy="58" r="23"', ring + '<circle cx="60" cy="58" r="23"');
    const rib = 'url(#' + id + 'b)';
    svg = svg.replace(/<path d="M38 88 L60 80 L82 88 L78 98 L60 92 L42 98Z"[^>]*\/>/, '<path d="M36 86 L21 87.5 L26.5 92.5 L21 98 L36 96.5Z M84 86 L99 87.5 L93.5 92.5 L99 98 L84 96.5Z" fill="#d08a1a" stroke="#6b4426" stroke-width="1.8" stroke-linejoin="round"/>'
      + '<path d="M33 83.5 Q60 78 87 83.5 L87 97 Q60 91.5 33 97Z" fill="' + rib + '" stroke="#6b4426" stroke-width="2" stroke-linejoin="round"/><path d="M35.5 84.6 Q60 79.6 84.5 84.6" stroke="#fffbe8" stroke-width="0.9" fill="none" opacity=".85"/>')
      .replace(/<text x="60" y="95"([^>]*)font-size="8"([^>]*)>LEVEL<\/text>/, '<text x="60" y="92.2"$1font-size="8.6"$2>LEVEL</text>');
    svg = svg.replace('<path d="M36 86 L21', '<g clip-path="url(#' + id + 'c)"><g class="sq-sweep"><rect x="52" y="14" width="13" height="92" fill="#ffffff" opacity=".42" transform="rotate(22 60 58)"/></g></g><path d="M36 86 L21');
    svg = svg.replace('</defs>', '<linearGradient id="' + id + 'b" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#fff6c8"/><stop offset=".55" stop-color="#ffd85a"/><stop offset="1" stop-color="#f7b02e"/></linearGradient><clipPath id="' + id + 'c"><circle cx="60" cy="58" r="30"/></clipPath><linearGradient id="' + id + 'r" x1="1" y1="0" x2="0" y2="0"><stop offset="0" stop-color="#fffae5"/><stop offset=".5" stop-color="#fff0b7"/><stop offset="1" stop-color="#ffe079"/></linearGradient></defs>');
    const sparks = [[4, 18, 0], [96, 30, 0.15], [20, 70, 0.3], [88, 76, 0.08]].map(([l, t, d]) => '<i class="sq-spark" style="left:' + l + 'px;top:' + t + 'px;animation-delay:' + d + 's">' + SPARK + '</i>').join('');
    const n = (s0.road || []).filter(r => r.claimable).length;
    return '<div class="sq-cin">' + svg + '</div>' + sparks + (n ? '<i class="sq-badge">' + (n > 9 ? '9+' : n) + '</i>' : '');
  };

  // ---------- 2. the Game Park's picture (main-menu-scene.js svg(st) with st.park) ----------
  // viewBox 0 0 1000 460 like the house scene, so the two meet at the edge: the same sky, horizon (y ~ 238) and grass.
  const PAD = 160;   // where the creature stands (the house's pad is at 500, both at y 421)
  M.PAD = PAD;
  // the road's top and bottom edge where the park meets the house (park x 1000 = house x 0)
  const ROAD_T = 401, ROAD_B = 447;
  // stepping stones in the style of the house path's own (main-menu-scene.js path(): a shadow ellipse + a lighter stone),
  // sized like its nearest ones, one line along the road. Stone k sits at house x 440 - 62k: the house picture draws the
  // ones on its side, the park the rest (the two near the seam are drawn by both, in the same place)
  const stone = (X, k, c0, c1, mix) => { const y = 424 + (k % 2 ? 3 : -3), a = 23 + (k % 3) * 1.5, b = 5.8;
    return '<ellipse cx="' + r1(X) + '" cy="' + r1(y + 1.5) + '" rx="' + r1(a) + '" ry="' + b + '" fill="' + c1 + '"/><ellipse cx="' + r1(X) + '" cy="' + r1(y) + '" rx="' + r1(a) + '" ry="' + b + '" fill="' + mix(c0, '#ffffff', 0.35) + '" stroke="' + c1 + '" stroke-width="0.8"/>'; };
  const stones = (lo, hi, off, c0, c1, mix) => { let g = ''; for (let k = 0; k < 40; k++) { const X = 440 - 62 * k; if (X < lo - 40) break; if (X <= hi + 40) g += stone(X + off, k, c0, c1, mix); } return g; };
  // the house picture's half of the road: from the left edge to the creature's pad (main-menu-scene.js path(), patched in)
  // (straight, the same width all the way, running into the house's path where that path crosses its height: x 432 / 413)
  M.houseRoad = function (st, c0, c1, mix) {
    let g = '<path d="M-60 ' + ROAD_T + ' H452 V' + ROAD_B + ' H-60Z" fill="' + c0 + '"/>'
      + '<path d="M-60 ' + ROAD_T + ' H432 M-60 ' + ROAD_B + ' H413" stroke="' + c1 + '" stroke-width="1.6" fill="none"/>';
    return g + stones(-60, 440, 0, c0, c1, mix);
  };

  M.parkArt = function (st, P) {
    const OL = '#4a3a2e', mix = P.mix, rnd = P.rnd, snow = st.season === 'snowy', rain = st.season === 'rainy';
    const dim = c => rain && c[0] === '#' ? mix(c, '#7a8692', 0.18) : c;
    let g = '<defs><linearGradient id="mmPkStripe" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#ff7a5c"/><stop offset="1" stop-color="#d63a24"/></linearGradient>'
      + '<radialGradient id="mmPkDoor" cx="0.5" cy="0.8" r="0.9"><stop offset="0" stop-color="#fff2b8"/><stop offset="0.5" stop-color="#ffb84a"/><stop offset="1" stop-color="#9a3a1a"/></radialGradient>'
      + '<linearGradient id="mmPkGold" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#fffbe0"/><stop offset="0.45" stop-color="#ffd24a"/><stop offset="1" stop-color="#e08a10"/></linearGradient></defs>';
    // its sky without the cloud and the lighthouse at its right edge (the edge would cut them where it meets the house)
    const sky = P.sky(st).replace(/<g><g transform="translate\(1000 60\)[\s\S]*?<\/g><animateTransform[^>]*\/><\/g>/, '').replace(/<g opacity="0\.75"><path d="M968 222[\s\S]*?<\/g>/, '');
    g += '<clipPath id="mmPkClip"><rect x="-200" y="-100" width="1200" height="700"/></clipPath><g clip-path="url(#mmPkClip)">';
    g += sky + P.ground(st);
    // the Ferris wheel, far back
    const wx = 690, wy = 122, R = 84;
    let wh = '<g transform="translate(' + wx + ' ' + wy + ')">';
    wh += '<path d="M-8 4 L-58 ' + (238 - wy) + ' M8 4 L58 ' + (238 - wy) + ' M-36 ' + (150 - wy + 80) + ' H36" stroke="' + dim('#e9e2f2') + '" stroke-width="5" stroke-linecap="round"/><path d="M-8 4 L-58 ' + (238 - wy) + ' M8 4 L58 ' + (238 - wy) + '" stroke="' + OL + '" stroke-width="1" opacity=".5"/>';
    let rot = '<g>';
    rot += '<circle r="' + R + '" fill="none" stroke="' + dim('#ffffff') + '" stroke-width="4"/><circle r="' + (R - 7) + '" fill="none" stroke="' + dim('#ffe2b0') + '" stroke-width="2"/>';
    for (let i = 0; i < 12; i++) { const a = i * Math.PI / 6; rot += '<path d="M0 0 L' + r1(Math.cos(a) * R) + ' ' + r1(Math.sin(a) * R) + '" stroke="' + dim('#f3ecff') + '" stroke-width="1.8"/>'; }
    const GC = ['#ff6fb5', '#ffd24a', '#5fd0ff', '#8f7bff', '#5fe0a0', '#ff9a4a', '#ff6fb5', '#5fd0ff', '#ffd24a', '#8f7bff'];
    for (let i = 0; i < 10; i++) {
      const a = i * Math.PI / 5, cx = Math.cos(a) * R, cy = Math.sin(a) * R;
      rot += '<g transform="translate(' + r1(cx) + ' ' + r1(cy) + ')"><g><animateTransform attributeName="transform" type="rotate" from="0" to="-360" dur="60s" repeatCount="indefinite"/>'
        + '<path d="M0 0 V6" stroke="' + OL + '" stroke-width="1.4"/><path d="M-9 6 H9 L7 17 Q0 21 -7 17Z" fill="' + dim(GC[i]) + '" stroke="' + OL + '" stroke-width="1.4"/><path d="M-6 9 H6" stroke="#ffffff" stroke-width="1.6" opacity=".7"/></g></g>';
      rot += '<circle cx="' + r1(cx) + '" cy="' + r1(cy) + '" r="2.4" fill="#fff7c8"><animate attributeName="opacity" values="1;.3;1" dur="' + (1.2 + (i % 3) * 0.4) + 's" repeatCount="indefinite"/></circle>';
    }
    rot += '<circle r="9" fill="url(#mmPkGold)" stroke="' + OL + '" stroke-width="1.6"/><animateTransform attributeName="transform" type="rotate" from="0" to="360" dur="60s" repeatCount="indefinite"/></g>';
    wh += rot + '</g>';
    g += '<g opacity="' + (rain ? 0.82 : 0.95) + '">' + wh + '</g>';
    // trees behind
    g += P.tree(352, 288, 0.8, st, 41) + P.tree(905, 280, 0.85, st, 42, { fruit: true }) + P.tree(560, 276, 0.6, st, 43);
    // string lights: tent top -> pole -> off to the right
    const pole = (x, y0, y1) => '<path d="M' + x + ' ' + y0 + ' V' + y1 + '" stroke="' + OL + '" stroke-width="5" stroke-linecap="round"/><path d="M' + x + ' ' + y0 + ' V' + y1 + '" stroke="#c98a50" stroke-width="3" stroke-linecap="round"/><circle cx="' + x + '" cy="' + y0 + '" r="4" fill="url(#mmPkGold)" stroke="' + OL + '" stroke-width="1.2"/>';
    const lights = (x0, y0, x1, y1, sag, seed) => {
      let h = '<path d="M' + x0 + ' ' + y0 + ' Q' + r1((x0 + x1) / 2) + ' ' + r1((y0 + y1) / 2 + sag) + ' ' + x1 + ' ' + y1 + '" stroke="#3a2a2e" stroke-width="1.2" fill="none"/>';
      const n = Math.round(Math.abs(x1 - x0) / 20), BC = ['#ffe680', '#ff9a6a', '#8fe4ff', '#b6ff8f', '#ffb86a'];
      for (let i = 1; i < n; i++) {
        const t = i / n, x = (1 - t) * (1 - t) * x0 + 2 * (1 - t) * t * (x0 + x1) / 2 + t * t * x1, y = (1 - t) * (1 - t) * y0 + 2 * (1 - t) * t * ((y0 + y1) / 2 + sag) + t * t * y1, c = BC[(i + seed) % 5];
        h += '<circle cx="' + r1(x) + '" cy="' + r1(y + 4) + '" r="3.2" fill="' + c + '" stroke="' + OL + '" stroke-width=".7"><animate attributeName="opacity" values="1;.35;1" dur="' + r1(1 + rnd(i, seed) * 1.4) + 's" begin="' + r1(rnd(i, seed + 3)) + 's" repeatCount="indefinite"/></circle>'
          + '<circle cx="' + r1(x) + '" cy="' + r1(y + 4) + '" r="7" fill="' + c + '" opacity=".25"/>';
      }
      return h;
    };
    // the kiosk (popcorn & tickets)
    const kx = 520, ky = 300;
    g += '<g transform="translate(' + kx + ' ' + ky + ')"><ellipse cx="2" cy="1" rx="44" ry="5" fill="#1d2a16" opacity=".2"/>'
      + '<rect x="-34" y="-50" width="68" height="50" fill="' + dim('#fff4e2') + '" stroke="' + OL + '" stroke-width="1.6"/><rect x="-34" y="-22" width="68" height="22" fill="' + dim('#7fc4ff') + '" stroke="' + OL + '" stroke-width="1.4"/>'
      + '<path d="M-26 -14 H26" stroke="#ffffff" stroke-width="2" opacity=".6"/><rect x="-24" y="-46" width="48" height="20" rx="3" fill="#3a1e4e"/><text x="0" y="-32" text-anchor="middle" font-family="Fredoka,sans-serif" font-weight="700" font-size="11" fill="#ffd24a">POP!</text>'
      + [0, 1, 2, 3, 4, 5].map(i => '<path d="M' + (-40 + i * 13.4) + ' -50 h13.4 l-1 12 q-5.7 6 -11.4 0Z" fill="' + dim(i % 2 ? '#ffffff' : '#ff6f8a') + '" stroke="' + OL + '" stroke-width="1.2"/>').join('')
      + '<path d="M-42 -50 Q0 -64 42 -50" fill="' + dim('#ff6f8a') + '" stroke="' + OL + '" stroke-width="1.4"/>'
      + [[-14, -58], [-4, -61], [6, -60], [15, -57], [1, -66]].map(([x, y]) => '<circle cx="' + x + '" cy="' + y + '" r="4.2" fill="#fffbea" stroke="#e8c88a" stroke-width=".8"/>').join('') + '</g>';
    // the balloon cart
    const bx = 860, by = 318;
    let bl = '<g transform="translate(' + bx + ' ' + by + ')"><ellipse cx="0" cy="2" rx="30" ry="4.5" fill="#1d2a16" opacity=".2"/><rect x="-22" y="-24" width="44" height="22" rx="4" fill="' + dim('#8f7bff') + '" stroke="' + OL + '" stroke-width="1.5"/><circle cx="-13" cy="0" r="5" fill="#3a2a2e"/><circle cx="13" cy="0" r="5" fill="#3a2a2e"/>';
    const BB = [['#ff6fb5', -20, -86], ['#ffd24a', -4, -98], ['#5fd0ff', 12, -88], ['#5fe0a0', 2, -76], ['#ff9a4a', -12, -70]];
    BB.forEach(([c, x, y], i) => {
      bl += '<g><animateTransform attributeName="transform" type="translate" values="0 0;' + (i % 2 ? 2 : -2) + ' -4;0 0" dur="' + (2.6 + i * 0.4) + 's" repeatCount="indefinite"/><path d="M0 -24 Q' + r1(x * 0.5) + ' ' + r1((y - 24) / 2) + ' ' + x + ' ' + (y + 13) + '" stroke="#5a4a5a" stroke-width=".8" fill="none"/>'
        + '<ellipse cx="' + x + '" cy="' + y + '" rx="11" ry="13" fill="' + dim(c) + '" stroke="' + OL + '" stroke-width="1.3"/><ellipse cx="' + (x - 4) + '" cy="' + (y - 5) + '" rx="3" ry="4.5" fill="#ffffff" opacity=".55"/><path d="M' + (x - 2) + ' ' + (y + 13) + ' l2 3 l2 -3Z" fill="' + dim(c) + '"/></g>';
    });
    g += bl + '</g>';
    // the big top, behind where the creature stands, its marquee above his head
    const tx = 150, tb = 304, tw = 128, tt = 116, tv = 206;
    let tent = '<g><ellipse cx="' + (tx + 4) + '" cy="' + (tb + 2) + '" rx="' + (tw + 12) + '" ry="9" fill="#1d2a16" opacity=".22"/>';
    // walls
    for (let i = 0; i < 8; i++) { const x0 = tx - tw + i * (2 * tw / 8); tent += '<rect x="' + r1(x0) + '" y="' + tv + '" width="' + r1(2 * tw / 8 + 0.4) + '" height="' + (tb - tv) + '" fill="' + dim(i % 2 ? '#fff4e6' : '#f2553a') + '"/>'; }
    tent += '<rect x="' + (tx - tw) + '" y="' + tv + '" width="' + 2 * tw + '" height="' + (tb - tv) + '" fill="none" stroke="' + OL + '" stroke-width="2"/>';
    // the doorway, lit
    tent += '<path d="M' + (tx - 34) + ' ' + tb + ' V' + (tv + 40) + ' Q' + tx + ' ' + (tv + 6) + ' ' + (tx + 34) + ' ' + (tv + 40) + ' V' + tb + 'Z" fill="url(#mmPkDoor)" stroke="' + OL + '" stroke-width="2"/>'
      + '<path d="M' + (tx - 34) + ' ' + (tv + 40) + ' Q' + (tx - 14) + ' ' + (tv + 50) + ' ' + (tx - 22) + ' ' + tb + ' H' + (tx - 34) + 'Z M' + (tx + 34) + ' ' + (tv + 40) + ' Q' + (tx + 14) + ' ' + (tv + 50) + ' ' + (tx + 22) + ' ' + tb + ' H' + (tx + 34) + 'Z" fill="' + dim('#d93a86') + '" stroke="' + OL + '" stroke-width="1.4"/>';
    // canopy: alternating stripes from the peak
    const n = 9;
    for (let i = 0; i < n; i++) {
      const a0 = tx - tw - 8 + i * (2 * (tw + 8) / n), a1 = a0 + 2 * (tw + 8) / n;
      tent += '<path d="M' + tx + ' ' + tt + ' L' + r1(a0) + ' ' + tv + ' L' + r1(a1) + ' ' + tv + 'Z" fill="' + dim(i % 2 ? '#fff4e6' : 'url(#mmPkStripe)') + '"/>';
    }
    tent += '<path d="M' + tx + ' ' + tt + ' L' + (tx - tw - 8) + ' ' + tv + ' H' + (tx + tw + 8) + 'Z" fill="none" stroke="' + OL + '" stroke-width="2" stroke-linejoin="round"/>';
    // scalloped valance
    let sc = '';
    for (let i = 0; i < 12; i++) { const x0 = tx - tw - 8 + i * (2 * (tw + 8) / 12), w = 2 * (tw + 8) / 12; sc += '<path d="M' + r1(x0) + ' ' + tv + ' h' + r1(w) + ' v4 q' + r1(-w / 2) + ' 12 ' + r1(-w) + ' 0Z" fill="' + dim(i % 2 ? '#ffd24a' : '#e8452c') + '" stroke="' + OL + '" stroke-width="1.3"/>'; }
    tent += sc;
    // flag on top
    tent += '<path d="M' + tx + ' ' + tt + ' V' + (tt - 26) + '" stroke="' + OL + '" stroke-width="2.4"/><circle cx="' + tx + '" cy="' + (tt - 27) + '" r="3" fill="url(#mmPkGold)" stroke="' + OL + '" stroke-width="1"/>'
      + '<path d="M' + tx + ' ' + (tt - 24) + ' l20 5 l-20 6Z" fill="' + dim('#ffd24a') + '" stroke="' + OL + '" stroke-width="1.2"><animateTransform attributeName="transform" type="skewY" values="0;-8;0;6;0" dur="1.6s" repeatCount="indefinite" additive="sum"/></path>';
    // marquee sign on the canopy: GAME PARK with bulbs
    const mw = 112, mh = 30, mx = tx - mw / 2, my = 150;
    tent += '<rect x="' + (mx - 2) + '" y="' + (my + 2) + '" width="' + (mw + 4) + '" height="' + mh + '" rx="8" fill="#2a0a4e" opacity=".35"/>'
      + '<rect x="' + mx + '" y="' + my + '" width="' + mw + '" height="' + mh + '" rx="8" fill="#5a1cb8" stroke="' + OL + '" stroke-width="2"/><rect x="' + (mx + 4) + '" y="' + (my + 4) + '" width="' + (mw - 8) + '" height="' + (mh - 8) + '" rx="5" fill="none" stroke="#ffd24a" stroke-width="1.4"/>';
    for (let i = 0; i < 14; i++) {
      const t = i / 14, per = 2 * (mw + mh), d = t * per; let x, y;
      if (d < mw) { x = mx + d; y = my; } else if (d < mw + mh) { x = mx + mw; y = my + d - mw; } else if (d < 2 * mw + mh) { x = mx + mw - (d - mw - mh); y = my + mh; } else { x = mx; y = my + mh - (d - 2 * mw - mh); }
      tent += '<circle cx="' + r1(x) + '" cy="' + r1(y) + '" r="2.3" fill="#fff6b0"><animate attributeName="fill" values="#fff6b0;#ffb86a;#fff6b0" dur="1.4s" begin="' + r1(i * 0.1) + 's" repeatCount="indefinite"/></circle>';
    }
    tent += '<text x="' + tx + '" y="' + (my + 21) + '" text-anchor="middle" font-family="Fredoka,Nunito,sans-serif" font-weight="700" font-size="15.5" letter-spacing="1" fill="#6b4426" stroke="#6b4426" stroke-width="4" stroke-linejoin="round">GAME PARK</text>'
      + '<text x="' + tx + '" y="' + (my + 20) + '" text-anchor="middle" font-family="Fredoka,Nunito,sans-serif" font-weight="700" font-size="15.5" letter-spacing="1" fill="url(#mmPkGold)">GAME PARK</text>';
    if (snow) tent += '<path d="M' + tx + ' ' + (tt + 2) + ' L' + (tx - 40) + ' ' + (tt + 30) + ' Q' + tx + ' ' + (tt + 22) + ' ' + (tx + 40) + ' ' + (tt + 30) + 'Z" fill="#ffffff" opacity=".9"/>';
    tent += '</g>';
    g += tent;
    g += pole(392, 150, 302) + pole(760, 160, 306) + pole(948, 168, 318);
    g += lights(tx, tt - 2, 392, 152, 26, 0) + lights(392, 152, 760, 162, 30, 2) + lights(760, 162, 948, 170, 22, 4);
    // bunting low across the middle
    let bt = '<path d="M392 186 Q576 214 760 192" stroke="#3a2a2e" stroke-width="1" fill="none"/>';
    for (let i = 1; i < 16; i++) { const t = i / 16, x = (1 - t) * (1 - t) * 392 + 2 * (1 - t) * t * 576 + t * t * 760, y = (1 - t) * (1 - t) * 186 + 2 * (1 - t) * t * 214 + t * t * 192; bt += '<path d="M' + r1(x - 5) + ' ' + r1(y) + ' h10 l-5 10Z" fill="' + dim(['#ff6fb5', '#ffd24a', '#5fd0ff', '#5fe0a0'][i % 4]) + '" stroke="' + OL + '" stroke-width=".7"/>'; }
    g += bt;
    // bushes along the back
    [[300, 318, 1], [450, 322, 0.9], [610, 320, 0.95], [700, 326, 1.1], [960, 330, 1]].forEach(([x, y, s], i) => { g += P.bush(x, y, s, st, i + 51); });
    // the cobbled road along the front, from the creature's pad to the right edge: there it carries on, at the same height, into
    // the road drawn into the house picture (SquishMenu.houseRoad), so the park and the house are joined by one road
    const c0 = snow ? '#e8ecef' : mix(st.P.sand, '#cdbb98', 0.4), c1 = mix(c0, '#7a6a52', 0.25);
    g += '<path d="M-60 ' + ROAD_T + ' H1060 V' + ROAD_B + ' H-60Z" fill="' + c0 + '"/>'
      + '<path d="M-60 ' + ROAD_T + ' H1060 M-60 ' + ROAD_B + ' H1060" stroke="' + c1 + '" stroke-width="1.6" fill="none"/>';
    g += stones(-1060, 60, 1000, c0, c1, mix);
    // front trees and bushes frame it
    g += P.tree(14, 380, 1.4, st, 44, { fruit: true });   // (behind the road)
    g += P.bush(300, 474, 1.4, st, 56) + P.bush(640, 478, 1.3, st, 57) + P.bush(880, 472, 1.2, st, 58);   // (below the road, not on it)
    // (no vignette: the park sits right next to the house picture, and two vignettes would show a seam where they meet)
    g += P.weather(st) + '</g>';
    // on the seam with the house (drawn past the edge, over the house's own edge): a big tree and bushes, so the two pictures meet behind them
    // (the road runs between them)
    g += P.tree(1002, 396, 1.6, st, 46, { fruit: true }) + P.bush(964, 400, 1.3, st, 59) + P.bush(1044, 398, 1.25, st, 60) + P.bush(976, 478, 1.5, st, 61) + P.bush(1044, 480, 1.6, st, 62);
    return g;
  };

  // ---------- 3. PLAY: the walk to the Game Park and the games carousel ----------
  let park = null; // { x, dx, ui, cur, idle, leaving }
  M.inPark = () => !!park;

  function parkLayer(x) {
    let L = x.world.querySelector('.sq-parkL');
    const key = (x.st && x.st.season) + ':' + (x.st && x.st.L);
    if (!L) { L = document.createElement('div'); L.className = 'sq-parkL'; L.style.cssText = 'position:absolute;top:0;left:-100%;width:100%;height:100%;pointer-events:none;'; x.world.insertBefore(L, x.scene.nextSibling); }
    if (L.dataset.k !== key) { L.innerHTML = stripAnim(window.MainMenuScene.svg(Object.assign({}, x.st, { park: true }))); L.dataset.k = key; const sv = L.firstChild; if (sv && sv.style) sv.style.overflow = 'visible'; }
    return L;
  }

  // walk the creature for `ms` while place(t) moves him and the camera; spin = the way he faces (-90 left, 90 right)
  function walk(x, ms, place, spin) {
    const ctrl = x.ctrl, I = ctrl && ctrl._I, c = x.cre(), key = c && c.key, HW = window.HouseWalk;
    const E = {}, ws = {}, prev = I ? I.ext : null;
    if (I && HW) I.ext = E; else x.stage.classList.add('walk');
    let last = performance.now();
    return tween(ms, (e, t) => {
      const now = performance.now(), dt = Math.min(0.05, (now - last) / 1000); last = now;
      place(t);
      if (I && HW) {
        for (const k in E) E[k] = 0;
        const w = Math.min(1, t / 0.08, (1 - t) / 0.1);
        try { HW.step(key, ws, E, Math.max(0, w), dt, 1, spin); } catch (err) { /* no gait for him */ }
      }
    }).then(() => { if (I && HW) { for (const k in E) E[k] = 0; I.ext = prev; } x.stage.classList.remove('walk'); });
  }

  // the house picture darkens its own edges; while the park is beside it that edge would show as a seam
  function vignette(x, on) { const v = x.scene.querySelector('rect[fill$="Vig)"]'); if (v) { v.style.transition = 'opacity .45s ease'; v.style.opacity = on ? '' : '0'; }
    const n = x.scene.querySelector(':scope > img.sq-pic.nov'); if (n) n.classList.toggle('on', !on); }   // (the picture's: PERF 2026-11-20)

  async function enterPark(x, instant) {
    if (park || x.busy || x.inside || !x.geo) return false;
    const g = x.geo, W = g.W;
    x.busy = true;
    park = { x, cur: 0 };
    x.closePage(); x.ov.querySelectorAll('.mm-pick').forEach(e => e.remove());
    x.fade(false);
    if (x.sh) x.sh.stop();
    const ctrl = x.ctrl, I = ctrl && ctrl._I, X0 = g.X(500), X1 = g.X(PAD);
    park.dx = X1 - W - X0;
    if (instant) {
      parkLayer(x); vignette(x, false);
      x.world.style.transform = 'translateX(' + W + 'px)'; x.stage.style.transform = 'translateX(' + park.dx + 'px)';
      if (ctrl) ctrl.play('happy');
      showGames(x, true); return true;
    }
    if (ctrl) ctrl.play('idle');
    sfx('whoosh');
    // PERF 2026-11-20: the park's picture (a big SVG) is drawn right after the tap's frame, while the creature turns,
    // not in the tap itself (the turn and the HUD's fade started a third of a second late); the camera only reaches the
    // park after the turn
    const built = new Promise(r => window.SquishPerf.painted(() => { if (park) { parkLayer(x); vignette(x, false); } r(); }));
    await tween(380, e => { if (I) I.spinOff = -90 * e; }, EIO);
    await built;
    // the creature heads left across the screen while the camera pans after him (the park slides in from the left)
    await walk(x, 2300, t => {
      const scr = X0 + (X1 - X0) * EOUT(t), cam = W * EIOC(clamp((t - 0.06) / 0.94, 0, 1));
      x.world.style.transform = 'translateX(' + cam.toFixed(1) + 'px)';
      x.stage.style.transform = 'translateX(' + (scr - X0 - cam).toFixed(1) + 'px)';
    }, -90);
    await tween(380, e => { if (I) I.spinOff = -90 * (1 - e); }, EIO);
    if (I) I.spinOff = 0;
    if (!park) return true;
    if (x.ctrl) x.ctrl.play('happy');
    showGames(x, false);
    return true;
  }

  async function leavePark() {
    if (!park || park.leaving) return; const x = park.x; park.leaving = true;
    clearInterval(park.idle);
    const ui = park.ui; if (ui) { stopVideo(ui); ui.classList.remove('in'); setTimeout(() => ui.remove(), 420); }
    const g = x.geo, W = g.W, X0 = g.X(500), X1 = g.X(PAD), ctrl = x.ctrl, I = ctrl && ctrl._I;
    if (ctrl) ctrl.play('idle');
    sfx('whoosh');
    await tween(340, e => { if (I) I.spinOff = 90 * e; }, EIO);
    await walk(x, 2100, t => {
      const scr = X1 + (X0 - X1) * EIO(t), cam = W * (1 - EIOC(clamp(t / 0.94, 0, 1)));
      x.world.style.transform = 'translateX(' + cam.toFixed(1) + 'px)';
      x.stage.style.transform = 'translateX(' + (scr - X0 - cam).toFixed(1) + 'px)';
    }, 90);
    await tween(340, e => { if (I) I.spinOff = 90 * (1 - e); }, EIO);
    if (I) I.spinOff = 0;
    x.world.style.transform = ''; x.stage.style.transform = '';
    vignette(x, true);
    const pl = x.world.querySelector('.sq-parkL'); if (pl) pl.remove();   // its seam tree would show at the house's left edge
    park = null;
    x.busy = false; x.hudDraw(); x.fade(true);
    if (x.sh && x.ctrl) x.sh.attach(x.ctrl);
    if (x.ctrl) x.ctrl.play('happy');
  }

  const LASTG = 'squishsquad.park.v1';
  // a game's clip: app/previews/<id>.mp4 + its first frame <id>.jpg (tools/previews/make.mjs)
  // (Squish Time's clip is Frybo being squished: another creature plays its own squish on the card instead)
  const PREVIEWS = { squish: 1 }, SQUISH_CLIP_KEY = 'frybo';
  // the four mini-games' cards are one still picture each (the user, 2026-11-21: their Gemini posters instead of the
  // clips, so the park stops decoding video): app/art/park/<id>.jpg, 1376 x 768, the game's name drawn in, so the card
  // has no title row. Full-size originals: Desktop "Squish games - Gemini art/Game Park cards (originals)".
  const POSTERS = { squishdoku: 1, sort: 1, stack: 1, hop: 1 };
  // each game's line on its card (the games' own words)
  const DESC = { squishdoku: 'One creature in every row, column and patch. No two may touch!', sort: 'Remember who sits where. The doors shut, it shakes… sort them back!',
    stack: 'Move them one at a time to match the goal. Big never sits on small!', hop: 'Hop from cushion to cushion. Clear them all, then hop onto the ★.' };
  const shade = (c, k) => { const n = parseInt(c.slice(1), 16), f = v => Math.max(0, Math.min(255, Math.round(k < 0 ? v * (1 + k) : v + (255 - v) * k))); return '#' + [n >> 16 & 255, n >> 8 & 255, n & 255].map(v => f(v).toString(16).padStart(2, '0')).join(''); };

  function showGames(x, instant) {
    const G = x.games(), k = x.k, W = x.geo.W, c = x.cre(), Q = x.Q;
    let cur = 0; try { const id = JSON.parse(localStorage.getItem(LASTG) || 'null'); const i = G.findIndex(g => g.id === id); if (i >= 0) cur = i; } catch (e) { /* none */ }
    park.cur = cur;
    const nOpen = G.filter(g => x.open(g)).length;
    // the card fills the gap between the two arrows (each 40 wide, 10 / 12 in from the sides, ~8 clear of the card)
    const pgW = W / k, carL = Math.round(Math.max(200, pgW * 0.29)), CW = Math.max(300, Math.round(pgW - carL - 118));
    const card = (g, i) => {
      const op = x.open(g), col = g.color || '#ff8a3d', pv = PREVIEWS[g.id] && !(g.id === 'squish' && (!c || c.key !== SQUISH_CLIP_KEY)), po = POSTERS[g.id];
      const best = g.id === 'squish' ? 'Playing as ' + (c ? c.name : '') : g.best != null ? g.best : 'New!';
      const desc = g.id === 'squish' ? 'Squeeze, poke and stretch ' + (c ? c.name : 'your character') + '. Every squish pays coins!' : (DESC[g.id] || '');
      return '<div class="sq-slot" data-i="' + i + '" style="width:' + CW + 'px;margin-left:' + (-CW / 2) + 'px"><div class="sq-gc mm-p' + (op ? '' : ' lock') + (po ? ' po' : '') + '" style="--gc:' + col + ';--gcl:' + shade(col, 0.35) + ';--gcd:' + shade(col, -0.42) + ';transition-delay:' + (0.05 + Math.abs(i - cur) * 0.07).toFixed(2) + 's">'
        + (po ? '' : '<div class="ttl">' + ft(g.name, 'white', 22) + '</div>')
        + '<div class="win">' + (po ? '<img alt="' + esc(g.name) + '" src="app/art/park/' + g.id + '.jpg" decoding="async" data-fb="' + i + '">' : pv ? '<img alt="" src="app/previews/' + g.id + '.jpg" data-fb="' + i + '">' : g.id === 'squish' ? squishCard(c, Q) : (g.icon || '')) + (op ? '' : '<div class="lockv">' + LOCK(44) + '</div>') + '</div>'
        + '<div class="info"><div class="txt">' + (desc ? '<div class="ds">' + esc(desc) + '</div>' : '') + '<div class="best">' + esc(best) + '</div></div>'
        + '<button class="go mm-p tip v-gold" data-go="' + i + '">' + ft(op ? 'PLAY' : 'LOCKED', 'whiteB', 22) + '</button></div></div></div>';
    };
    const ui = document.createElement('div'); ui.className = 'sq-pk';
    ui.innerHTML = '<div class="sq-pkdim"></div><div class="mm-pg" style="transform:scale(' + k + ');width:' + (W / k) + 'px">'
      + '<div class="mm-pgh"><button class="mm-orb" data-x aria-label="Back to the house">' + ic(BACK, '#fff', 3) + '</button>' + ft('Game Park', 'gold', 30)
      // (REDESIGN_V8, the user: no coins pill and no "5 games · Frybo plays every one" line)
      + '<div class="mm-sp"></div></div>'
      + '<div class="sq-car" style="left:' + carL + 'px"><div class="sq-rays"></div><div class="sq-halo"></div>' + G.map(card).join('')
      + '<button class="mm-orb sq-arr l" aria-label="Previous game">' + ic(LEFT, '#fff', 3) + '</button><button class="mm-orb sq-arr r" aria-label="Next game">' + ic(RIGHT, '#fff', 3) + '</button>'
      + '<div class="sq-pos">' + G.map(() => '<i></i>').join('') + '</div></div></div>';
    x.ov.appendChild(ui); x.fitFT(ui); park.ui = ui; fillIcons(ui);
    ui.querySelectorAll('img[data-fb]').forEach(im => { im.onerror = () => {
      const g = G[+im.dataset.fb], s = still(c, Q);
      if (g.id === 'squish' && s) { im.onerror = null; im.src = s; im.style.objectFit = 'contain'; im.style.background = 'radial-gradient(circle at 50% 40%,#ffe3f6,#ff8fd6)'; return; }
      const d = document.createElement('div'); d.innerHTML = g.icon || ''; im.replaceWith(d.firstChild || d); }; });
    const slots = [...ui.querySelectorAll('.sq-slot')], car = ui.querySelector('.sq-car');
    const place = () => {
      slots.forEach((s, i) => {
        const d = i - park.cur, a = Math.abs(d);
        const tx = d === 0 ? 0 : Math.sign(d) * Math.round(CW * 0.45 + a * 40), sc = d === 0 ? 1 : 0.8;
        s.style.transform = 'translate(' + tx + 'px,0) scale(' + sc + ')';
        s.style.opacity = d === 0 ? 1 : 0;
        s.style.zIndex = 50 - a; s.style.pointerEvents = d === 0 ? '' : 'none';
        s.classList.toggle('c', d === 0);
      });
      ui.querySelector('.sq-arr.l').classList.toggle('off', park.cur === 0);
      ui.querySelector('.sq-arr.r').classList.toggle('off', park.cur === G.length - 1);
      ui.querySelectorAll('.sq-pos i').forEach((e, i) => e.classList.toggle('on', i === park.cur));
      playVideo(ui, G, park.cur);
    };
    const go = i => { i = clamp(i, 0, G.length - 1); if (i === park.cur) return; park.cur = i; sfx('whoosh'); place(); try { localStorage.setItem(LASTG, JSON.stringify(G[i].id)); } catch (e) { /* full */ } };
    park.go = go;
    place();
    ui.querySelector('[data-x]').onclick = () => leavePark();
    ui.querySelector('.sq-arr.l').onclick = () => go(park.cur - 1);
    ui.querySelector('.sq-arr.r').onclick = () => go(park.cur + 1);
    ui.querySelectorAll('.sq-pos i').forEach((e, i) => { e.onclick = () => go(i); });
    let downX = null, downY = 0, swiped = 0;
    car.addEventListener('pointerdown', e => { downX = e.clientX; downY = e.clientY; });
    car.addEventListener('pointerup', e => { if (downX == null) return; const dx = (e.clientX - downX) / k, dy = (e.clientY - downY) / k; downX = null; if (Math.abs(dx) > 36 && Math.abs(dx) > Math.abs(dy)) { swiped = Date.now(); go(park.cur + (dx < 0 ? 1 : -1)); } });
    car.addEventListener('pointercancel', () => { downX = null; });
    slots.forEach((s, i) => s.addEventListener('click', e => {
      if (Date.now() - swiped < 250) return;
      if (i !== park.cur) { go(i); return; }
      if (e.target.closest('[data-go]') || e.target.closest('.win')) playAt(x, G[i], s);
    }));
    // (a timer too: right after a cold start the WebView can hold animation frames back for seconds)
    requestAnimationFrame(() => requestAnimationFrame(() => ui.classList.add('in')));
    setTimeout(() => ui.classList.add('in'), 120);
    if (instant) ui.classList.add('in');
    // the creature stays lively while you choose
    park.idle = setInterval(() => { const ct = x.ctrl, I = ct && ct._I; if (!park || park.leaving || !ct) return; const L = allowed(I, ['happy', 'look', 'love', 'cheer', 'wave', 'hop']); if (L.length) ct.play(L[Math.floor(Math.random() * L.length)]); }, 6500);
  }

  // Squish Time for a creature without its own clip: its picture squished and stretched like in the game, with squish lines
  function squishCard(c, Q) {
    const s = still(c, Q);
    return '<div class="sq-sqz"><i class="l"></i><i class="r"></i>' + (s ? '<img alt="" src="' + s + '">' : '') + '</div>';
  }

  function playVideo(ui, G, i) {
    ui.querySelectorAll('.sq-slot').forEach((s, j) => {
      const win = s.querySelector('.win'), v = win.querySelector('video');
      if (j === i && PREVIEWS[G[j].id] && win.querySelector('img[data-fb]')) {
        if (v) { v.play().catch(() => {}); return; }
        const vid = document.createElement('video');
        vid.muted = true; vid.loop = true; vid.playsInline = true; vid.autoplay = true; vid.preload = 'auto';
        vid.setAttribute('muted', ''); vid.setAttribute('playsinline', ''); vid.setAttribute('aria-hidden', 'true');
        vid.poster = 'app/previews/' + G[j].id + '.jpg'; vid.src = 'app/previews/' + G[j].id + '.mp4';
        vid.onerror = () => vid.remove();
        win.appendChild(vid); vid.play().catch(() => {});
      } else if (v) { v.pause(); v.removeAttribute('src'); try { v.load(); } catch (e) { /* gone */ } v.remove(); }
    });
  }
  function stopVideo(ui) { ui.querySelectorAll('video').forEach(v => { v.pause(); v.removeAttribute('src'); try { v.load(); } catch (e) { /* gone */ } v.remove(); }); }

  async function playAt(x, g, slot) {
    if (!park || park.leaving || park.starting) return;
    if (!x.open(g)) { toast(park.ui, g.name + ' isn\'t open yet'); return; }
    park.starting = true; sfx('tap');
    const ct = x.ctrl; if (ct) { const L = allowed(ct._I, ['cheer', 'happy']); if (L.length) ct.play(L[0]); }
    const gc = slot.querySelector('.sq-gc'); gc.style.transition = 'transform .18s ease'; gc.style.transform = 'scale(.94)'; setTimeout(() => { gc.style.transform = 'scale(1.04)'; }, 180);
    try { localStorage.setItem(LASTG, JSON.stringify(g.id)); } catch (e) { /* full */ }
    await wait(420);
    park.starting = false;
    x.playGame(g);
  }

  function toast(host, t, cls) {
    if (!host) return; const pg = host.querySelector('.mm-pg') || host;
    pg.querySelectorAll('.sq-toast').forEach(e => e.remove());
    const d = document.createElement('div'); d.className = 'sq-toast mm-p tip v-gold' + (cls ? ' ' + cls : ''); d.textContent = t; pg.appendChild(d); setTimeout(() => d.remove(), 2400);
  }

  M.play = function (x) { addCss(); if (!x || !window.MainMenuScene) return false; enterPark(x, false); return true; };
  // the app opened the menu on the park (back from a game started there): straight in, no walk
  M.mounted = function (x) {
    addCss();
    // (the app's start data can arrive after this page's first scripts: app/bridge.js calls this again when it does)
    M._x = x;
    if (App && App.intro && !App._introDone) { App._introDone = true; if (startIntro(x)) return; App.send('intro', { phase: 'done' }); }
    if (!App || App.screen !== 'park' || App._parkDone) return;
    App._parkDone = true; App.screen = null;
    // (only the layout is waited for: on a cold start the creature's rig can take seconds; it appears in the park when ready)
    x.fade(false);
    let n = 0; const go = () => { if (x.geo) enterPark(x, true).then(ok => { if (!ok) x.fade(true); }); else if (n++ < 300) setTimeout(go, 60); else x.fade(true); };
    go();
  };
  // ---------- the game intro ----------
  // The designer's "Squish wakes the house" (app/intro.js, window.SquadIntro) replaces the app's old splash screen
  // (2026-11-16, the user). It was made for the Nov 14 menu, whose startIntro hands it an api; this is that api built from
  // our (Nov 13) menu's insides:
  //   - the HUD, the room labels and the nameplate fade out while it plays (back at the end), and the menu stays `busy` so
  //     its own moves (the idle shuffle, the season redraw, the layout of the creature) leave the scene to it
  //   - Mittens is its star: shown in the creature's spot for the story (the menu's `preview`), the player's own
  //     character comes back at the end
  //   - light(): the Nov 13 rig has no lighting, so the night is a filter on the creature (darker and cooler at first,
  //     warmer with every room lit; daylight clears it)
  //   - finish(): the real scene (the player's level and season) is drawn again under the intro's layers as they fade
  // The app hears { phase: 'start' }, { phase: 'awake' } (the third squish of Mittens: its music starts) and
  // { phase: 'done' } (App.js holds the daily spin, the streak and the level-up card until it's done). Android back skips it (SquishMenu.introBack, app/bridge.js).
  let introRun = null;
  function startIntro(x) {
    const SI = window.SquadIntro, Sc = x.Sc, Q = x.Q;
    if (!SI || !Sc || !Q || !x.geo) return false;
    const mitIdx = Object.keys(Q.ROSTER).find(i => Q.ROSTER[i] && Q.ROSTER[i].key === 'mittens');
    if (x.sh) x.sh.stop();
    x.busy = true; x.fade(false); x.frame.classList.add('sq-intro');   // (sq-intro: the menu's weather layer is hidden)
    if (mitIdx != null) { x.preview = +mitIdx; x.mountRig(); }
    const lum = c => { const n = parseInt(c.slice(1), 16); return (0.299 * (n >> 16 & 255) + 0.587 * (n >> 8 & 255) + 0.114 * (n & 255)) / 255; };
    const light = cfg => {
      if (!cfg || !cfg.tint) { x.stage.style.filter = ''; return; }
      const L = clamp(lum(cfg.tint) / lum('#efe2d2'), 0, 1), warm = clamp((cfg.rim - 0.08) / 0.36, 0, 1);
      x.stage.style.filter = 'brightness(' + (0.5 + 0.5 * L).toFixed(3) + ') saturate(' + (0.6 + 0.4 * L).toFixed(3) + ')' + (warm > 0.05 ? ' sepia(' + (0.25 * warm).toFixed(3) + ')' : '');
    };
    const api = {
      frame: x.frame, world: x.world, scene: x.scene, stage: x.stage, Sc,
      ctrl: () => x.ctrl, geo: () => x.geo,
      // the intro's house has every room's window open, to light them up (the Nov 13 scene boards up the rooms a level
      // hasn't reached): the six rooms it lights are opened, the level's look and the yard stay as they are. Drawn still,
      // as the menu draws its own (stripAnim, section 0: the scene's own animations repainted the whole picture every
      // frame; the intro has its own rain)
      sceneSvg: o => { const st = Sc.state(o); ['living', 'kitchen', 'bathroom', 'bedroom', 'dance', 'movie'].forEach(k => { if (k in st.open) st.open[k] = true; }); return stripAnim(Sc.svg(st)); },
      light, lightFor: () => null,
      // the third squish of Mittens has lit the house: the app starts its music now (2026-11-17, the user)
      awake: () => App.send('intro', { phase: 'awake' }),
      finish: () => {
        introRun = null;
        light(null); x.draw();
        x.preview = null; x.mountRig();
        x.busy = false; x.layout(); x.fade(true); x.frame.classList.remove('sq-intro');
        if (x.ctrl) x.ctrl.play('happy');
        App.send('intro', { phase: 'done' });
      },
    };
    try { introRun = SI.run(api); }
    catch (e) { console.error('[intro]', e); introRun = null; light(null); x.draw(); x.preview = null; x.mountRig(); x.busy = false; x.layout(); x.fade(true); x.frame.classList.remove('sq-intro'); return false; }
    App.send('intro', { phase: 'start' });
    return true;
  }
  // Android back during the intro: skip it (true: handled)
  M.introBack = function () { if (!introRun) return false; introRun.finish(); return true; };

  // Android back while in the park walks home (the back orb has data-x, so SquishApp.back finds it)

  // ---------- art for prizes and unlocks ----------
  const CHEST = { common: ['#8fd2ff', '#2f7fd6'], rare: ['#7ee8b4', '#16a86a'], epic: ['#c89bff', '#7a2ad8'], legendary: ['#ffc65a', '#d9772f'], set: ['#ff9ad6', '#8f5cf6'] };
  const CHEST_NAME = { common: 'Common', rare: 'Rare', epic: 'Epic', legendary: 'Legendary', set: 'Rainbow' };
  function chestArt(t) {
    const c = CHEST[t] || CHEST.common, id = 'sqch' + (++UID), rb = t === 'set';
    return '<svg viewBox="0 0 64 56"><defs><linearGradient id="' + id + '" x1="0" y1="0" x2="' + (rb ? 1 : 0) + '" y2="1">' + (rb ? '<stop offset="0" stop-color="#ff9ad6"/><stop offset=".33" stop-color="#ffe27a"/><stop offset=".66" stop-color="#7fe9b8"/><stop offset="1" stop-color="#8fb8ff"/>' : '<stop offset="0" stop-color="' + c[0] + '"/><stop offset="1" stop-color="' + c[1] + '"/>') + '</linearGradient></defs>'
      + '<ellipse cx="32" cy="52" rx="24" ry="3.5" fill="#000" opacity=".25"/><rect x="8" y="24" width="48" height="26" rx="5" fill="url(#' + id + ')" stroke="#6b4426" stroke-width="2.4"/>'
      + '<path d="M8 26 Q8 8 32 8 Q56 8 56 26Z" fill="url(#' + id + ')" stroke="#6b4426" stroke-width="2.4" stroke-linejoin="round"/><path d="M14 22 Q16 13 30 12" stroke="#fff" stroke-width="2.4" fill="none" opacity=".55" stroke-linecap="round"/>'
      + '<rect x="6" y="22" width="52" height="7" rx="3" fill="#ffd24a" stroke="#6b4426" stroke-width="2"/><rect x="27" y="25" width="10" height="13" rx="2.5" fill="#ffe680" stroke="#6b4426" stroke-width="2"/><circle cx="32" cy="31" r="2" fill="#6b4426"/>'
      + '<path d="M17 8 V50 M47 8 V50" stroke="#ffd24a" stroke-width="3" opacity=".9"/><path d="M17 8 V50 M47 8 V50" stroke="#6b4426" stroke-width="0.8" opacity=".5"/></svg>';
  }
  const ROOM_GLYPH = {
    living: 'M5 15v-4a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2v4 M3 15h18v3H3Z M5 18v2 M19 18v2',
    kitchen: 'M5 10h14v8a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2Z M3 10h18 M9 6c0-1 1-1 1-2 M13 6c0-1 1-1 1-2',
    bathroom: 'M4 12h16v3a4 4 0 0 1-4 4H8a4 4 0 0 1-4-4Z M6 12V6a2 2 0 0 1 4 0 M8 19v2 M16 19v2',
    bedroom: 'M3 18V8 M3 13h18v5 M21 18v-5 M6 13v-2a2 2 0 0 1 2-2h3v4',
    backyard: 'M12 3l5 7h-3l4 6H6l4-6H7Z M12 16v5',
    dance: 'M12 3v3 M12 6a6 6 0 1 0 .01 0Z M6.5 12h11 M12 6v12 M8 8.5l8 7 M16 8.5l-8 7',
    movie: 'M4 7h16v12H4Z M4 11h16 M8 7l2 4 M13 7l2 4',
    beach: 'M12 4a8 8 0 0 1 8 8H4a8 8 0 0 1 8-8Z M12 12v8 M8 20h8',
    yard: 'M6 9h12a3 3 0 0 1 3 3v2a3 3 0 0 1-5.4 1.8L14.5 14h-5l-1.1 1.8A3 3 0 0 1 3 14v-2a3 3 0 0 1 3-3Z M8 11v3 M6.5 12.5h3',
    tier: 'M3 18h18 M5 18l-1-9 5 4 3-7 3 7 5-4-1 9',
  };
  const ROOM_COL = { living: '#e3946a', kitchen: '#f2b235', bathroom: '#3fb4e8', bedroom: '#7f97c9', backyard: '#5fb04a', dance: '#8f7bff', movie: '#c46a3e', beach: '#e8a840', yard: '#2fc6a8', tier: '#d9772f' };
  function glyphArt(key) {
    const col = ROOM_COL[key] || '#8f7bff';
    return '<svg viewBox="0 0 56 56"><circle cx="28" cy="28" r="24" fill="' + col + '" stroke="#6b4426" stroke-width="2.4"/><circle cx="28" cy="28" r="19" fill="none" stroke="#ffffff" stroke-width="1.5" opacity=".45"/><ellipse cx="21" cy="17" rx="8" ry="4.5" fill="#fff" opacity=".35" transform="rotate(-25 21 17)"/>'
      + '<g transform="translate(14 14) scale(1.17)" fill="none" stroke="#ffffff" stroke-width="2.3" stroke-linecap="round" stroke-linejoin="round"><path d="' + ROOM_GLYPH[key] + '"/></g></svg>';
  }
  function prizeArt(r, big) {
    if (!r) return '';
    if (r.k === 'coins' || r.k === 'gems') {
      const src = r.k === 'coins' ? coinImg() : gemImg(), n = big ? 3 : 2;
      return '<div style="position:relative;width:100%;height:100%">' + Array.from({ length: n }, (_, i) => '<img alt="" src="' + src + '" style="position:absolute;width:' + (big ? 62 : 64) + '%;left:' + (n === 3 ? [2, 36, 19][i] : [8, 30][i]) + '%;top:' + (n === 3 ? [26, 26, 2][i] : [22, 6][i]) + '%;filter:drop-shadow(0 2px 2px rgba(30,0,40,.45))">').join('') + '</div>';
    }
    return chestArt(r.t);
  }
  const prizeName = r => !r ? '' : r.k === 'coins' ? fmt(r.n) + ' Coins' : r.k === 'gems' ? fmt(r.n) + ' Gems' : (CHEST_NAME[r.t] || '') + ' Chest';
  const prizeShort = r => !r ? '' : r.k === 'coins' || r.k === 'gems' ? fmt(r.n) : (CHEST_NAME[r.t] || '') + ' chest';

  // ---------- 3b. the trip home's loading screen, "Heading home" (REDESIGN_V9, 2026-11-16: the user's zip, its
  // 1-heading-home recording) ----------
  // After the walk to the door (main-menu.js goHome, patched in webgame/patches.mjs) night falls on the real house:
  // the scene darkens, stars and the moon come out, the open rooms' lights come on one by one as the house loads
  // underneath, the door last; a wooden bar with the house on it and a tip. Once the house has drawn (Main Menu.dc.html
  // calls houseDrawn) and the bar is full, the camera flies in through the door as before and the house fades in.
  // 2026-11-17 (the user: "it's not lighting the windows, it's just a weird light on all the room... look how it is on
  // the intro screen"): the rooms are lit the intro's way (app/intro.js, its night veil, halos and panes): the night has
  // holes where a lit room's windows are, each window gets a warm pane and a halo of its own. Before, a big soft glow
  // covered each room's whole area.
  // The house's windows as main-menu-scene.js win() draws them (the intro's WIN list, plus the small round ones: the
  // attic, the dormer and the dome's drum), in scene units: each a path, its box, k = how far its hole opens (the dome
  // stays dimmer, as in the intro) and R = its halo's size when not the box's
  const hwR = (x, y, w, h) => ({ d: 'M' + x + ' ' + y + 'h' + w + 'v' + h + 'h' + (-w) + 'Z', b: [x, y, w, h] });
  const hwA = (x, y, w, h) => ({ d: 'M' + x + ' ' + (y + h) + 'V' + (y + w / 2) + 'A' + (w / 2) + ' ' + (w / 2) + ' 0 0 1 ' + (x + w) + ' ' + (y + w / 2) + 'V' + (y + h) + 'Z', b: [x, y, w, h] });
  const hwC = (cx, cy, r) => ({ d: 'M' + (cx - r) + ' ' + cy + 'a' + r + ' ' + r + ' 0 1 0 ' + (2 * r) + ' 0a' + r + ' ' + r + ' 0 1 0 ' + (-2 * r) + ' 0Z', b: [cx - r, cy - r, 2 * r, 2 * r] });
  const HWIN = {
    living: [hwR(434, 218, 36, 40), hwR(530, 218, 36, 40)],
    bedroom: [hwA(298, 164, 42, 48), hwR(366, 176, 30, 30), hwC(340, 122, 5.2)],
    kitchen: [hwR(282, 246, 62, 36), hwC(385, 265, 13)],
    bathroom: [hwC(629, 185, 17), hwR(668, 164, 46, 44), hwC(652, 122, 4)],
    movie: [hwR(604, 242, 92, 40), hwR(712, 248, 16, 34)],
    dance: [{ d: 'M454 170A46 46 0 0 1 546 170Z', b: [454, 124, 92, 46], k: 0.6 }].concat([462, 481, 500, 519, 538].map(x => hwC(x, 178, 4.2))) };
  // the open doorway (its light is already on: main-menu.js doorOpen) and the two porch lamps
  const HDOOR = [Object.assign(hwA(488, 247, 24, 53), { R: 34 }), hwC(476, 250.5, 5), hwC(524, 250.5, 5)];
  const HOME_TIPS =['The Backyard unlocks the mini games', 'Your whole squad lives here. Drop by any time to see what they are up to', 'Level up to open more rooms in your house', 'Renovate a room to make your squad\'s home cozier'];
  let HH = null;
  // PERF 2026-11-20 (the user: "when I see it the night has already partly fallen and the lights are coming on"): the
  // house starts loading only once this screen is on screen (HH.shown(), awaited by main-menu.js goHome, patched), and
  // everything that moves on it is played by the GPU from its first frame on screen, so it keeps going while the house
  // loads under it: the night, the stars, the moon and the title fade in as Web Animations (the night's own layer
  // multiplied over the house); each lit window is three small layers of its own (the window as it is by day, the warm
  // pane in soft-light, the halo in screen), faded in by a Web Animation that follows the same curves as before (the
  // flash as it comes on). By day = a picture of the house as it is now (the door open), cut to the window: the same as
  // the hole the window used to cut in the night. The windows still come on as the loading goes (each started from the
  // page's clock, then left to the GPU). Before, all of it ran on the page's timers and SVG attributes, frozen or
  // jumping while the house's scripts loaded.
  M.headingHome = function (frame, world, st) {
    addCss(); if (HH) HH.kill();
    fillStart();   // (room first, creatures after: houseDrawn)
    const Sc = window.MainMenuScene, x = M._x, k = (x && x.k) || 1, MIN = 2000, geo = x && x.geo;
    if (window.SquishPerf && window.SquishPerf.quiet) window.SquishPerf.quiet(30000);
    // the open rooms, in the order they opened (the living room first), each lit in turn
    const rooms = Sc && st && st.open ? Object.keys(Sc.ROOMS).filter(r => st.open[r] && HWIN[r]).sort((a, b) => Sc.ROOMS[a].lv - Sc.ROOMS[b].lv) : [];
    let stars = '';
    for (let i = 0; i < 46; i++) stars += '<i style="left:' + (2 + ((i * 37.7) % 96)).toFixed(1) + '%;top:' + (2 + ((i * 53.3) % 38)).toFixed(1) + '%;animation-delay:' + ((i * 0.37) % 2.4).toFixed(2) + 's;' + (i % 5 ? '' : 'width:3px;height:3px;') + '"></i>';
    // the lights, in the order they come on: each open room's windows, then the door (last)
    const groups = rooms.map(r => HWIN[r]).concat([HDOOR]), r1 = v => (Math.round(v * 10) / 10).toString();
    const lay = '<svg class="lay" viewBox="0 0 1000 460" preserveAspectRatio="xMidYMax slice">';
    const night = document.createElement('div'); night.className = 'sq-hh-night';
    night.innerHTML = lay.replace('class="lay"', 'class="lay skyl"') + '<defs><linearGradient id="sqhhn" gradientUnits="userSpaceOnUse" x1="0" y1="0" x2="0" y2="460"><stop offset="0" stop-color="#1c2260"/><stop offset=".45" stop-color="#2a3070"/><stop offset="1" stop-color="#262a5a"/></linearGradient></defs>'
      + '<rect x="-300" y="-300" width="1600" height="1100" fill="url(#sqhhn)"/></svg>'
      + '<div class="pics"></div>'
      + '<div class="stars">' + stars + '</div>'
      + '<svg class="moon" viewBox="0 0 40 40"><defs><mask id="sqhhm"><rect width="40" height="40" fill="#fff"/><circle cx="27" cy="15" r="14" fill="#000"/></mask></defs><circle cx="20" cy="20" r="15" fill="#fff6d8" mask="url(#sqhhm)"/></svg>';
    world.appendChild(night);
    const ui = document.createElement('div'); ui.className = 'sq-hh-ui';
    ui.innerHTML = '<div class="in" style="transform:scale(' + k + ');width:' + (frame.clientWidth / k) + 'px;height:' + (frame.clientHeight / k) + 'px">'
      + '<div class="ttl">' + ft('Heading home', 'gold', 34) + '</div>'
      + '<div class="bot"><div class="tip"><em>Tip:</em> <span></span></div></div></div>';
    frame.appendChild(ui); if (x && x.fitFT) x.fitFT(ui);
    const tip = ui.querySelector('.tip span');
    // the fades in, from the first frame on screen (the CSS transitions they replace: .9s, 1.2s after .5s, 1s / 1.2s after .4s, .6s)
    // (started in the next frame: this screen is built inside the walk's last frame, and an animation started there
    // would count from that frame's start, a good part of its fade gone by the time it's first drawn)
    const fade = (el, ms, delay, kf) => el.animate(kf || [{ opacity: 0 }, { opacity: 1 }], { duration: ms, delay: delay || 0, easing: 'ease', fill: 'both' });
    const moon = night.querySelector('.moon');
    let uiIn = null;
    requestAnimationFrame(() => {
      if (over) return;
      fade(night.querySelector('.skyl'), 900);   // (dusk at once; the drawn night fades over it when made: dayPicture)
      fade(night.querySelector('.stars'), 1200, 500);
      fade(moon, 1000, 400); moon.animate([{ transform: 'translateY(10px)' }, { transform: 'none' }], { duration: 1200, delay: 400, easing: 'ease', fill: 'both' });
      uiIn = fade(ui, 600);
    });
    // The night and the lights (PERF 2026-11-20, the user chose it: "rebuild it"): drawn ONCE into canvases (nightPics:
    // the house by day multiplied by the night's colours, then each light's windows, halos and warm panes composited on
    // top, in the order they come on), and a window lights up by fading its canvas in: plain opacity. It was a multiply
    // layer, and for each light a masked copy of the whole house picture plus a screen and a soft-light layer, all drawn
    // again by the WebView while the house loaded under this screen: 0.2-0.3 s stalls on the Galaxy A16. Same look (the
    // same colours and blend arithmetic, done once on the CPU); a light coming on fades in instead of its brief flash.
    let dayUrl = null;
    const picsEl = night.querySelector('.pics');
    const bounds = list => { let x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9; list.forEach(([a, b, w, h]) => { x0 = Math.min(x0, a); y0 = Math.min(y0, b); x1 = Math.max(x1, a + w); y1 = Math.max(y1, b + h); }); return [x0 - 1, y0 - 1, x1 - x0 + 2, y1 - y0 + 2]; };
    const halo = w => { const [hx, hy, ww, hh] = w.b, R = w.R || Math.max(ww, hh); return [hx + ww / 2 - R * 1.3, hy + hh / 2 - R * 1.1, R * 2.6, R * 2.2]; };
    const lights = groups.map((g, i) => ({ i, g, box: bounds([bounds(g.map(w => w.b)), bounds(g.map(halo))]), at: 0, done: false, cv: null }));
    let pics = 0;   // 0: being made; 1: up; -1: none (the plain night, the windows don't light)
    const nightPics = day => new Promise((done, fail) => { try {
      const W = frame.clientWidth, H = frame.clientHeight, d = Math.min(2.6, window.devicePixelRatio || 1);
      const s = geo ? geo.s : Math.max(W / 1000, H / 460), ox = geo ? geo.ox : (W - 1000 * s) / 2, oy = geo ? geo.oy : H - 460 * s;
      const cv = document.createElement('canvas'); cv.width = Math.round(W * d); cv.height = Math.round(H * d);
      const c = cv.getContext('2d', { willReadFrequently: true });
      const units = () => c.setTransform(d * s, 0, 0, d * s, d * ox, d * oy);
      units(); c.drawImage(day, 0, 0, 1000, 460);
      const ng = c.createLinearGradient(0, 0, 0, 460); ng.addColorStop(0, '#1c2260'); ng.addColorStop(0.45, '#2a3070'); ng.addColorStop(1, '#262a5a');
      c.globalCompositeOperation = 'multiply'; c.fillStyle = ng; c.fillRect(-300, -300, 1600, 1100); c.globalCompositeOperation = 'source-over';
      const layer = (el, l, t, w, h) => { el.style.cssText = 'position:absolute;left:' + l.toFixed(2) + 'px;top:' + t.toFixed(2) + 'px;width:' + w.toFixed(2) + 'px;height:' + h.toFixed(2) + 'px;opacity:0;will-change:opacity;'; picsEl.appendChild(el); return el; };
      const nb = document.createElement('canvas'); nb.width = cv.width; nb.height = cv.height; nb.getContext('2d').drawImage(cv, 0, 0);
      layer(nb, 0, 0, W, H);
      let li = 0;
      const next = () => { try {
        if (over) { cv.width = cv.height = 0; fail(new Error('over')); return; }
        if (li >= lights.length) { cv.width = cv.height = 0; done(nb); return; }
        const L = lights[li++];
        units();
        L.g.forEach(w => { c.save(); c.clip(new Path2D(w.d)); c.globalAlpha = 0.9 * (w.k || 1); c.drawImage(day, 0, 0, 1000, 460); c.restore(); });
        c.globalCompositeOperation = 'screen'; c.globalAlpha = 0.85;
        L.g.forEach(w => { const [hx, hy, ww, hh] = w.b, R = w.R || Math.max(ww, hh); c.save(); c.translate(hx + ww / 2, hy + hh / 2); c.scale(R * 1.3, R * 1.1); const rg = c.createRadialGradient(0, 0, 0, 0, 0, 1); rg.addColorStop(0, 'rgba(255,231,166,0.8)'); rg.addColorStop(0.45, 'rgba(255,196,90,0.3)'); rg.addColorStop(1, 'rgba(255,154,42,0)'); c.fillStyle = rg; c.beginPath(); c.arc(0, 0, 1, 0, Math.PI * 2); c.fill(); c.restore(); });
        c.globalCompositeOperation = 'soft-light';
        L.g.forEach(w => { const by = w.b[1], bh = w.b[3], lg = c.createLinearGradient(0, by, 0, by + bh); lg.addColorStop(0, '#fff2c0'); lg.addColorStop(1, '#ffb347'); c.globalAlpha = 0.75 * (w.k || 1); c.fillStyle = lg; c.fill(new Path2D(w.d)); });
        c.globalCompositeOperation = 'source-over'; c.globalAlpha = 1;
        const [bx, by, bw, bh] = L.box;
        const p0 = Math.max(0, Math.floor(d * (ox + s * bx))), q0 = Math.max(0, Math.floor(d * (oy + s * by))), p1 = Math.min(cv.width, Math.ceil(d * (ox + s * (bx + bw)))), q1 = Math.min(cv.height, Math.ceil(d * (oy + s * (by + bh))));
        if (p1 > p0 && q1 > q0) { const o = document.createElement('canvas'); o.width = p1 - p0; o.height = q1 - q0; o.getContext('2d').drawImage(cv, p0, q0, o.width, o.height, 0, 0, o.width, o.height); L.cv = layer(o, p0 / d, q0 / d, o.width / d, o.height / d); }
        setTimeout(next, 0);
      } catch (e) { cv.width = cv.height = 0; fail(e); } };
      next();
    } catch (e) { fail(e); } });
    // the plain night (a multiply layer, the windows unlit) if the pictures can't be made, or take too long
    const noPics = () => { if (pics || over) return; pics = -1; };
    // the house by day, as it is now (the door open): the night's base and what a lit window shows (made once this screen
    // is on screen); its JPEG is also the scene under the night (picDoor) for the camera's flight in
    const dayPicture = () => { try {
      const live = x && x.scene && x.scene.querySelector('svg');
      if (!live || !window.Blob) { noPics(); return; }
      const svg = new XMLSerializer().serializeToString(live).replace(/visibility:\s*hidden;?/, '');
      const kk = Math.min(2.6, Math.max(frame.clientWidth / 1000, frame.clientHeight / 460) * (window.devicePixelRatio || 1));
      setTimeout(noPics, 2500);
      svgCanvas(svg, 1000, 460, kk, 6).then(day => {
        if (over) { day.width = day.height = 0; return; }
        nightPics(day).then(nb => { if (over) return; pics = 1; const sk = night.querySelector('.skyl'); fade(nb, 600).onfinish = () => { if (sk) sk.style.display = 'none'; }; }, noPics).then(() => {
          day.toBlob(b => { day.width = day.height = 0; if (!b || over) return; dayUrl = URL.createObjectURL(b); picDoor(dayUrl); }, 'image/jpeg', 0.9);
        });
      }).catch(noPics);
    } catch (e) { noPics(); } };
    // a light comes on: its canvas fades in
    const lightOn = (L, ms) => {
      if (!L.cv) { L.done = true; return; }
      L.cv.animate([{ opacity: 0 }, { opacity: 1 }], { duration: ms, easing: 'ease-out', fill: 'forwards' }).onfinish = () => { L.done = true; };
    };
    let ti = Math.floor(Math.random() * HOME_TIPS.length); tip.textContent = HOME_TIPS[ti];
    const tipT = setInterval(() => { tip.parentNode.classList.add('sw'); setTimeout(() => { ti = (ti + 1) % HOME_TIPS.length; tip.textContent = HOME_TIPS[ti]; tip.parentNode.classList.remove('sw'); }, 260); }, 3000);
    let p = 0, readyAt = 0, show = null, over = false, gone = false, t0 = 0, last = 0, res, resShown;
    const ready = new Promise(r => { res = r; }), shown = new Promise(r => { resShown = r; });
    // on screen: the loading may start (and the clock of this screen with it)
    requestAnimationFrame(() => window.SquishPerf.painted(() => { if (over) return; t0 = last = performance.now(); dayPicture(); resShown(); }));
    const me = {
      shown: () => shown,
      ready: () => ready,
      markReady(fn) { show = fn; if (!readyAt) readyAt = performance.now(); },
      zoom() { if (uiIn) uiIn.cancel(); ui.animate([{ opacity: 1 }, { opacity: 0 }], { duration: 350, easing: 'ease', fill: 'forwards' }); }, // the camera flies in: the title and the tip go
      end() { const f = show; me.kill(); if (f) f(); },
      cancel() { me.kill(); resShown(); res('cancel'); },
      kill() { over = true; clearInterval(tipT); night.remove(); ui.remove(); picDoor(null); if (dayUrl) URL.revokeObjectURL(dayUrl); dayUrl = null; if (HH === me) { HH = null; if (window.SquishPerf && window.SquishPerf.quiet) window.SquishPerf.quiet(1500); } },
    };
    const tick = () => {
      if (over) return;
      if (!t0) { requestAnimationFrame(tick); return; }
      const now = performance.now(), t = now - t0, dt = Math.min(250, now - last); last = now;
      // the loading's progress (no bar shows it: the user, 2026-11-16, "remove the progress bars"): it eases towards
      // 90% while the house loads, then runs to the end; the windows light up as it goes (the same pace as before, at
      // 60 frames a second, whatever the frame rate now)
      const goal = readyAt ? 1 : 0.9 * (1 - Math.exp(-t / 2400));
      p += (goal - p) * (1 - Math.pow(1 - (readyAt ? 0.12 : 0.07), dt / 16.67)); if (readyAt && 1 - p < 0.005) p = 1;
      const nR = lights.length - 1;   // (the last light is the door)
      lights.forEach((L, i) => {
        if (L.at || !pics) return;
        if (i < nR ? p >= ((i + 1) / (nR + 1)) * 0.9 : p >= 0.96) { L.at = now; lightOn(L, i < nR ? 500 : 450); }
      });
      // ready: the camera starts flying in (its first moments barely move) while the door finishes lighting up
      if (p >= 1 && t >= MIN && !gone) { gone = true; res('ok'); }
      if (gone && lights.every(L => L.done)) return;
      requestAnimationFrame(tick);
    };
    requestAnimationFrame(tick);
    HH = me;
    return me;
  };
  // the camera's flight in through the door (in: 900 ms, scale 1 -> 6.2 in t^3, the veil from 45% to 95%) and back out
  // (850 ms, 1 - (1-t)^3, the veil gone by 55%), as main-menu.js goHome / back drew them each frame, now played by the GPU
  // (PERF 2026-11-20: the house builds or tears down at the same moment, which froze the camera mid-flight)
  M.zoom = function (world, veil, inward) {
    if (!world.animate) return null;
    const N = 24, wk = [], vk = [], ms = inward ? 900 : 850;
    for (let i = 0; i <= N; i++) {
      const t = i / N, e = inward ? t * t * t : 1 - Math.pow(1 - t, 3);
      wk.push({ transform: 'scale(' + (inward ? 1 + 5.2 * e : 1 + 5.2 * (1 - e)).toFixed(4) + ')' });
      vk.push({ opacity: inward ? (t > 0.45 ? Math.min(1, (t - 0.45) / 0.5) : 0) : Math.max(0, 1 - t / 0.55) });
    }
    // the end state is set first (the animations play over it; the veil's watcher keeps it drawn while it fades)
    veil._sqZ = 1; veil.style.visibility = '';
    world.style.transform = inward ? 'scale(6.200)' : ''; veil.style.opacity = inward ? '1' : '0';
    const a = world.animate(wk, { duration: ms, easing: 'linear' }), b = veil.animate(vk, { duration: ms, easing: 'linear' });
    return Promise.all([a.finished, b.finished]).catch(() => {}).then(() => { veil._sqZ = 0; if (veil._sqSync) veil._sqSync(); });
  };
  // PERF 2026-11-20 (the user: "in the crib at the lower part there's something white that makes it look like we're
  // not in full screen"): the house's box on this screen. The house is laid out at the design's 852 x 393 and scaled to
  // the menu's frame; scaled to the frame's width alone it left a cream strip under it on a screen taller than 852:393
  // (the phone: 17 dp). Now its box is the screen at the scale that fits 852 x 393 in it: 852 wide and taller on a taller
  // screen, 393 tall and wider on a wider one. The room, the catalog and the map stay 852 x 393 in its middle (their
  // pictures already reach past it: more of the floor and ceiling shows), the HUD keeps to its edges (patches.mjs).
  // → { k: scale, w, h: the box in design px }, or null when there's no menu frame (the house on its own: as before).
  M.houseBox = function (w, h) {
    if (w == null) { const f = M._x && M._x.frame; if (!f) return null; const r = f.getBoundingClientRect(); w = r.width; h = r.height; }
    if (!(w > 0 && h > 0)) return null;
    const k = Math.min(w / 852, h / 393);
    return { k, w: w / k, h: h / k };
  };
  // Main Menu.dc.html: the house has drawn (show() fades it in) / the player went back while it was loading
  // PERF 2026-11-21 (the user chose it: "room first, creatures after"): on the trip in, the house is shown as its bare
  // room first; its furniture fades in half a second later and its creatures arrive one at a time after that. Revealed
  // all at once, the WebView drew the room, the furniture and every creature for the first time in the same moment:
  // 0.2-0.6 s stalls, 3-4 a trip, on the Galaxy A16. While filling, the house keeps its creatures unmounted (its
  // mountVis asks SquishFill, patched in) and the furniture layer (.sq-items) is see-through.
  const FILL = { on: false, sh: null, t: null };
  window.SquishFill = { hold(sh) { if (!FILL.on) return false; FILL.sh = sh; return true; } };
  const fillReset = () => { clearTimeout(FILL.t); FILL.on = false; FILL.sh = null; document.documentElement.classList.remove('sq-filling'); };
  const fillStart = () => { fillReset(); FILL.on = true; document.documentElement.classList.add('sq-filling'); FILL.t = setTimeout(fillEnd, 20000); };
  function fillEnd() {
    if (!FILL.on) return;
    const sh0 = FILL.sh; fillReset();
    const step = () => { const sh = sh0 || window.__sh; if (!sh || sh.dead || !sh.vis || !sh.mountVis) return; sh.mountVis(1); if (sh.vis.some(c => !c.ctrl && c.host && c.host.current)) setTimeout(step, 220); };
    setTimeout(step, 420);   // (after the furniture's fade)
  }
  M.houseDrawn = function (show) { const go = () => { show(); setTimeout(fillEnd, 500); }; if (HH) HH.markReady(go); else go(); };
  M.houseLeft = function () { if (HH) HH.cancel(); fillReset(); };

  // ---------- 4. the Level Pass ----------
  // REDESIGN_V9 (2026-11-16, the user): one row of levels across the page, each one tappable; the tapped level's
  // rewards in one panel along the bottom (the big card for the next reward and a reward under every level are gone:
  // scrolling the row slid its rewards under that card). Rewards are pictures of what you get: a chest is its group's
  // own (Pet Shop's Common chest: the prize's g, from the app: src/game/player.js roadPrizes), a room is the house
  // map's picture of it and the house's next look the house in it (webgame/tools/room-art.mjs -> app/art/rooms).
  const COL = 84;   // from one level to the next on the row
  const cxOf = L => 44 + (L - 1) * COL;   // a level's centre on the row
  function levelData(x) {
    const s = S(), Sc = window.MainMenuScene, xp = s.xp || { level: (x.st && x.st.L) || 1, into: 0, need: 0, per: 100 }, road = s.road || [];
    const N = Math.max(road.length, 30), rows = [];
    for (let L = 1; L <= N; L++) {
      const r = road[L - 1] || null, un = [];
      Object.keys(Sc.ROOMS).forEach(k => { if (Sc.ROOMS[k].lv === L && L > 1) un.push({ key: k, name: Sc.ROOMS[k].n, kind: 'room' }); });
      if (L === Sc.ROOMS.backyard.lv) un.push({ key: 'yard', name: 'Yard Games', kind: 'yard' });
      const TI = { 5: 'Cozy home', 15: 'Lovely home', 25: 'Royal palace' };
      if (TI[L]) un.push({ key: 'tier', name: TI[L], kind: 'tier', tier: L === 5 ? 1 : L === 15 ? 2 : 3 });
      rows.push({ L, r, un, reached: xp.level >= L, got: !!(r && r.got), claimable: !!(r && r.claimable) });
    }
    return { xp, rows };
  }
  // XP still to earn before level L
  function xpTo(xp, L) {
    if (xp.level >= L) return 0; let n = Math.max(0, (xp.need || 0) - (xp.into || 0)); const per = xp.per || 100;
    for (let j = xp.level + 1; j < L; j++) n += per * (j + 1);
    return n;
  }
  const UN_TEXT = { room: 'A new room opens in your house', yard: 'The backyard\'s 7 yard games (buy each one\'s toy there to play it)', tier: 'Your house gets its next look' };
  // one reward: its picture, name and line
  function rewardCard(it) {
    let art, title, desc, tag;
    if (it.r) {
      const r = it.r;
      if (r.k === 'chest') {
        art = r.g ? '<img class="chest" alt="" decoding="async" src="app/gchests/' + r.g + '-' + r.t + '-grow.webp">' : chestArt(r.t);
        title = r.cn || (CHEST_NAME[r.t] || '') + ' Chest';
        desc = (r.gn ? r.gn + ' · ' : '') + (CHEST_NAME[r.t] || '') + ' chest';
        tag = 'CHEST';
      } else {
        art = '<div class="pile">' + prizeArt(r, true) + '</div>';
        title = prizeName(r);
        desc = r.k === 'gems' ? 'Gems to spend in the Shop' : 'Coins to spend in the Shop';
        tag = r.k === 'gems' ? 'GEMS' : 'COINS';
      }
    } else {
      const u = it.u, pic = u.kind === 'tier' ? 'tier' + u.tier : u.key;
      art = '<img class="pic" alt="" decoding="async" src="app/art/rooms/' + pic + '.jpg">';
      title = u.name; desc = UN_TEXT[u.kind];
      tag = u.kind === 'tier' ? 'HOUSE' : u.kind === 'yard' ? 'GAMES' : 'NEW ROOM';
    }
    return '<div class="sq-it"><span class="tag">' + tag + '</span><div class="ar">' + art + '</div><div class="t">' + ft(title, 'white', 15) + '</div><div class="d">' + esc(desc) + '</div></div>';
  }

  M.levels = function (x) {
    addCss(); if (!x || x.busy || x.inside) return;
    let D = levelData(x), sel = null, pend = {};
    const first = D.rows.find(r => r.claimable);
    sel = first ? first.L : Math.min(D.rows.length, D.xp.level + 1);
    const nClaim = () => D.rows.filter(r => r.claimable && !pend[r.L]).length;
    const head = () => {
      const xp = D.xp, f = xp.need > 0 ? clamp(xp.into / xp.need, 0, 1) : 0, n = nClaim();
      return '<button class="mm-orb" data-x aria-label="Back">' + ic(BACK, '#fff', 3) + '</button>' + ft('Level Pass', 'gold', 30) + '<div class="mm-sp"></div>'
        + (n > 1 ? '<button class="sq-lvall mm-p tip v-gold" data-all>CLAIM ALL (' + n + ')</button>' : '')
        + '<div class="sq-lvx mm-p tip v-vel"><b class="tx-w">LV ' + xp.level + '</b><div class="sq-lvbar"><i style="width:' + (f * 100).toFixed(1) + '%"></i></div><small>' + (xp.need ? fmt(xp.into) + ' / ' + fmt(xp.need) + ' XP' : '') + '</small></div>'
        + pill(coinImg(), x.Q ? x.Q.wallet().coins : 0, 'sq-coins');
    };
    const track = () => {
      const xp = D.xp, f = xp.need > 0 ? clamp(xp.into / xp.need, 0, 1) : 0, N = D.rows.length, w = cxOf(N) + 44;
      const x0 = cxOf(1), fill = Math.min(cxOf(N), cxOf(xp.level) + f * COL), cs = x.cre(), Q = x.Q, src = cs && Q ? still(Q.ROSTER[cs.id] || cs, Q) : null;
      return '<div class="sq-lvin" style="width:' + w + 'px"><div class="sq-rail" style="left:' + x0 + 'px;width:' + (cxOf(N) - x0) + 'px"><i style="width:' + (fill - x0).toFixed(1) + 'px"></i></div>'
        + '<div class="sq-you" style="left:' + fill.toFixed(1) + 'px">' + (src ? '<img alt="" src="' + src + '">' : '') + '</div><i class="sq-youp" style="left:' + fill.toFixed(1) + 'px"></i>'
        + D.rows.map(row => {
          const p = pend[row.L], cl = row.claimable && !p, got = row.got || p === 'done' || (row.reached && !row.r);
          const st = cl ? '<span class="st ex">!</span>' : got ? '<span class="st ok">' + ic(CHECK, '#fff', 3.4) + '</span>' : row.reached ? '' : '<span class="st lkb">' + LOCK(12) + '</span>';
          return '<button class="sq-ln' + (row.reached ? ' on' : '') + (row.L === xp.level ? ' cur' : '') + (cl ? ' cl' : '') + (sel === row.L ? ' sel' : '') + '" data-l="' + row.L + '" style="left:' + cxOf(row.L) + 'px">' + row.L + st + '</button>';
        }).join('') + '</div>';
    };
    const panel = () => {
      const row = D.rows[sel - 1]; if (!row) return '';
      const p = pend[row.L], items = (row.r ? [{ r: row.r }] : []).concat(row.un.map(u => ({ u })));
      let act;
      if (row.r && row.claimable && !p) act = '<button class="act mm-p tip v-gold" data-claim="' + row.L + '">' + ft('CLAIM', 'whiteB', 19) + '</button>';
      else if (p === 1) act = '<div class="act mm-p tip v-vel done"><span class="tx-w">Claiming…</span></div>';
      else if (row.reached) act = '<div class="act mm-p tip v-vel done">' + ic(CHECK, '#7dffa8', 3.2) + '<span class="tx-w">' + (row.r ? 'CLAIMED' : 'UNLOCKED') + '</span></div>';
      else act = '<div class="act mm-p tip v-vel done">' + LOCK(16) + '<span class="tx-w">' + fmt(xpTo(D.xp, row.L)) + ' XP to go</span></div>';
      const sub = !row.reached ? 'Reach it to get ' + (items.length > 1 ? 'these' : 'this') : row.L === D.xp.level ? 'Your level' : 'Reached';
      return '<div class="lv">' + ft('LEVEL ' + row.L, row.reached ? 'gold' : 'white', 24) + '<div class="sub">' + sub + '</div>' + act + '</div>'
        + '<div class="items">' + (items.length ? items.map(rewardCard).join('') : '<div class="sq-it none"><div class="d">Nothing new at this level</div></div>') + '</div>';
    };
    // PERF 2026-11-20: the page opens with its header and empty track and panel (on screen in the next frame, its fade-in
    // starting there); the track and the panel are filled in right after that first frame, as the fade begins
    const p = x.pageOpen('<div class="mm-pgh">' + head() + '</div><div class="sq-lvtrack"></div><div class="sq-lvpan mm-p v-vel"></div>');
    const pg = p.querySelector('.mm-pg'), hd = p.querySelector('.mm-pgh'), pv = p.querySelector('.sq-lvpan'), tr = p.querySelector('.sq-lvtrack');
    p.classList.add('sq-pass');   // (no fade-in: see .sq-pass in the CSS)
    M.hold();   // (the menu's creature stops at once)
    x.frame.classList.add('sq-covered'); weatherOn(false);   // (covered from its first frame: see M.characters)
    dragRow(tr); // (the user: every sideways list scrolls by dragging, finger or mouse)
    const redraw = keepScroll => { const sl = tr.scrollLeft; hd.innerHTML = head(); pv.innerHTML = panel(); tr.innerHTML = track(); x.fitFT(p); if (keepScroll) tr.scrollLeft = sl; bind(); fillIcons(p); };
    fillIcons(p);
    const center = L => { tr.scrollLeft = Math.max(0, cxOf(L) - tr.clientWidth / 2); };
    const claim = L => {
      const row = D.rows[L - 1]; if (!row || !row.claimable || pend[L]) return;
      pend[L] = 1; sfx('tap'); redraw(true);
      if (App && App.inApp) send('claim', { lv: L, k: row.r.k });
      else { pend[L] = 'done'; burst(L); redraw(true); }
    };
    const burst = L => {
      const row = D.rows[L - 1]; if (!row || !row.r || row.r.k === 'chest') return;
      const from = (sel === L && pv.querySelector('.sq-it .ar')) || tr.querySelector('.sq-ln[data-l="' + L + '"]'), to = hd.querySelector('.sq-coins img') || hd; if (!from) return;
      const pr = pg.getBoundingClientRect(), k = x.k, a = from.getBoundingClientRect(), b = to.getBoundingClientRect(), src = row.r.k === 'gems' ? gemImg() : coinImg();
      sfx('score');
      for (let i = 0; i < 9; i++) {
        const im = document.createElement('img'); im.className = 'sq-fly'; im.src = src;
        const ax = (a.left + a.width / 2 - pr.left) / k - 13 + (Math.random() - 0.5) * 40, ay = (a.top + a.height / 2 - pr.top) / k - 13 + (Math.random() - 0.5) * 30;
        im.style.left = ax + 'px'; im.style.top = ay + 'px'; pg.appendChild(im);
        const bx = (b.left + b.width / 2 - pr.left) / k - 13, by = (b.top + b.height / 2 - pr.top) / k - 13;
        setTimeout(() => { im.style.transform = 'translate(' + (bx - ax) + 'px,' + (by - ay) + 'px) scale(.7)'; im.style.opacity = '0'; }, 30 + i * 55);
        setTimeout(() => im.remove(), 1300 + i * 55);
      }
    };
    function bind() {
      hd.querySelector('[data-x]').onclick = close;
      const all = hd.querySelector('[data-all]');
      if (all) all.onclick = () => { const ls = D.rows.filter(r => r.claimable && !pend[r.L]).map(r => r.L); if (!ls.length) return; ls.forEach(L => { pend[L] = 1; }); sfx('tap'); redraw(true); if (App && App.inApp) send('claim', { all: true, lv: ls[0] }); else { ls.forEach(L => { pend[L] = 'done'; burst(L); }); redraw(true); } };
      // a tap picks a level (its rewards show below); a second tap on a level waiting to be claimed claims it
      tr.querySelectorAll('[data-l]').forEach(b => b.onclick = () => { const L = +b.dataset.l; if (sel === L) { claim(L); return; } sel = L; sfx('tap'); redraw(true); });
      const cb = pv.querySelector('[data-claim]'); if (cb) cb.onclick = () => claim(+cb.dataset.claim);
    }
    bind();
    // (filled unseen, then shown whole once its tiles are made: the first time, the phone drew the panel half done for
    //  ~0.4 s, a row of its tiles missing; sq-filling keeps them see-through but made, SquishPerf.steady says when)
    p.classList.add('sq-filling');
    window.SquishPerf.painted(() => { if (!p.isConnected) return; tr.innerHTML = track(); pv.innerHTML = panel(); x.fitFT(tr); x.fitFT(pv); bind(); fillIcons(p); center(sel);
      window.SquishPerf.steady(() => p.classList.remove('sq-filling'), 1500); });
    // the app's answers: a claim's result, then the player's new state (prize marked got, coins up)
    const offs = [];
    if (App) {
      offs.push(App.on('claimed', m => {
        if (m.road) return; // a chest: the app opens its level road (the chest smash)
        const ls = Object.keys(pend).filter(L => pend[L] === 1).map(Number);
        if (m.ok) { ls.forEach(L => { pend[L] = 'done'; burst(L); }); }
        else { ls.forEach(L => { delete pend[L]; }); toast(p, m.error === 'claimed' ? 'Already claimed' : m.error === 'need_level' ? 'Reach that level first' : 'Something went wrong. Try again!'); }
        redraw(true);
      }));
      offs.push(App.on('state', () => { D = levelData(x); Object.keys(pend).forEach(L => { const r = D.rows[L - 1]; if (r && r.got) delete pend[L]; }); redraw(true); }));
    }
    function close() { offs.forEach(f => f && f()); x.closePage(); if (x.ctrl) x.ctrl.play('happy'); }
  };

  // ---------- 5. Characters ----------
  const PLQ = ['v-wood', 'v-bronze', 'v-amy', 'v-gold', 'v-rainbow'], NFT = ['wood', 'bronze', 'amethyst', 'whiteB', 'white'];
  // REDESIGN_V8 (2026-11-14, the user): a remodel. Bright, warm and shiny instead of purple; the character in the middle,
  // 10 dp above a golden platform that turns slowly with its lights riding round on it; its name between its two tags
  // (rarity, group); no filters, no "12 of 111", no location button, no stage ("Baby"); the characters in one row below,
  // group by group, each group Common to Rainbow. CHOOSE (or "Find it in chests") stands beside the stage.
  // a row that scrolls sideways by dragging (finger or mouse, the same everywhere: the page's own gestures can't take it),
  // gliding on after a flick; a mouse wheel scrolls it too. A drag doesn't count as a tap on what's in it.
  function dragRow(el) {
    let id = null, x0 = 0, s0 = 0, moved = false, lx = 0, lt = 0, v = 0, raf = 0;
    const sc = () => (el.getBoundingClientRect().width / (el.clientWidth || 1)) || 1; // the page's scale (k)
    const stop = () => { cancelAnimationFrame(raf); raf = 0; };
    el._glide = stop;
    el.addEventListener('pointerdown', e => { if (e.button > 0) return; stop(); id = e.pointerId; x0 = lx = e.clientX; s0 = el.scrollLeft; lt = performance.now(); v = 0; moved = false; });
    el.addEventListener('pointermove', e => {
      if (e.pointerId !== id) return;
      const dx = e.clientX - x0;
      if (!moved && Math.abs(dx) > 6) { moved = true; try { el.setPointerCapture(id); } catch (er) { /* gone */ } }
      if (!moved) return;
      const k = sc(), t = performance.now();
      el.scrollLeft = s0 - dx / k;
      v = (e.clientX - lx) / Math.max(1, t - lt) / k; lx = e.clientX; lt = t;
    });
    const up = e => {
      if (e.pointerId !== id) return; id = null;
      if (!moved || Math.abs(v) < 0.05) return;
      let last = performance.now();
      const step = now => { const dt = Math.min(40, now - last); last = now; el.scrollLeft -= v * dt; v *= Math.pow(0.94, dt / 16); raf = Math.abs(v) > 0.02 ? requestAnimationFrame(step) : 0; };
      raf = requestAnimationFrame(step);
    };
    el.addEventListener('pointerup', up); el.addEventListener('pointercancel', up);
    el.addEventListener('click', e => { if (moved) { e.stopPropagation(); e.preventDefault(); moved = false; } }, true);
    el.addEventListener('wheel', e => { const d = Math.abs(e.deltaY) > Math.abs(e.deltaX) ? e.deltaY : e.deltaX; if (d) { stop(); el.scrollLeft += d; e.preventDefault(); } }, { passive: false });
  }

  // ---------- the Characters page's loading screen, "Gathering your squad" (REDESIGN_V9, 2026-11-16: the user's zip,
  // its 3-gathering-your-squad recording; the user: it plays when Characters opens) ----------
  // Over the page while its cards load: five of your creatures' cards dealt from the deck into a fan and turned over,
  // and a tip (no progress bar: the user, 2026-11-16); once the row's first cards have loaded (and the deal has played), the
  // cards gather back into the deck, the deck flies off and the page shows.
  const SQUAD_TIPS = ['Rarities: Common, Rare, Epic, Legendary, Rainbow', 'Hold your creature to squeeze it, drag to spin it', 'Tap a card to see a creature, tap USE to put it in front of your house', 'Collect a whole group to earn its Rainbow chest'];
  const STAR_IC = '<svg viewBox="0 0 24 24"><path d="M12 3.2l2.6 5.5 6 .8-4.4 4.2 1.1 6-5.3-2.9-5.3 2.9 1.1-6-4.4-4.2 6-.8Z" fill="#ffd24a" stroke="#6b4426" stroke-width="1.6" stroke-linejoin="round"/></svg>';
  // PERF 2026-11-20 (the user: "I only hear the audio and when I see them they are half way done"): the loader is put up
  // on its own, before anything of the page is built, and all its motion is Web Animations of transform and opacity,
  // which the GPU plays (they keep going while the page is built under it); they start with the loader's first frame on
  // screen, and its card sounds are set on the sound clock from there (sfxAt), so they land with the cards even if the
  // page is busy. Before, its deal ran on timers from the tap while the whole page was built in the same frame (a
  // second or more on the phone): the deal had played by the time the loader was first seen, its sounds in a burst.
  // The timings and curves are the design's (the CSS transitions this used: .45s cubic-bezier(.2,.9,.3,1.05) deal, .2s
  // fade in, .45s ease flip, .3s deck, .45s ease-in / .4s leave, .45s fade out).
  // (its markup: put in with the page's own, so the tap lays the page out once)
  // PERF 2026-11-20: the slowly turning rays (the Characters page's and its loading screen's) drawn ONCE into a canvas
  // that the GPU turns. As a CSS repeating-conic-gradient under a radial mask-image, each was a ~1960 px square layer
  // (rasterised whole because it turns) made through an offscreen mask: on the Galaxy A16 the WebView's GPU thread spent
  // ~1-2 s making their tiles the first time the page opened, and drew no frame meanwhile (the loader froze as a
  // see-through ghost over the menu). A canvas is one texture, made once; turning it costs no raster. Same wedges,
  // colours and fade as the CSS; drawn at 1024 px (the soft rays don't show the difference).
  // o: { color, on (deg lit), step (deg per wedge), r0, r1 (the fade's start and end, as fractions of the radius) }
  function raysCanvas(cv, o) {
    if (!cv || !cv.getContext) return;
    const N = 1024, c = N / 2, g = cv.getContext('2d'); if (!g) return;
    cv.width = N; cv.height = N;
    g.clearRect(0, 0, N, N);
    g.fillStyle = o.color;
    const rad = d => (d - 90) * Math.PI / 180;   // (CSS conic 0deg is 12 o'clock, clockwise; canvas 0 is 3 o'clock)
    for (let a = 0; a < 360; a += o.step) { g.beginPath(); g.moveTo(c, c); g.arc(c, c, c, rad(a), rad(a + o.on)); g.closePath(); g.fill(); }
    g.globalCompositeOperation = 'destination-in';
    const m = g.createRadialGradient(c, c, 0, c, c, c);
    m.addColorStop(0, '#000'); m.addColorStop(o.r0, '#000'); m.addColorStop(o.r1, 'rgba(0,0,0,0)'); m.addColorStop(1, 'rgba(0,0,0,0)');
    g.fillStyle = m; g.fillRect(0, 0, N, N);
    g.globalCompositeOperation = 'source-over';
  }
  M.raysCanvas = raysCanvas;
  const RAYS_LOADER = { color: 'rgba(255,246,214,.30)', on: 7, step: 18, r0: 38.18 / 357, r1: 356.38 / 357 };
  const RAYS_CHARS = { color: 'rgba(255,255,255,.55)', on: 7, step: 18, r0: 46.38 / 337, r1: 336.29 / 337 };
  function gatherHtml(cardsHtml, owned) {
    const n = Math.min(5, cardsHtml.length), backHtml = '<div class="back"><span>' + STAR_IC + '</span></div>';
    return '<div class="sq-gs"><canvas class="rays"></canvas><div class="ttl">' + ft('Gathering your squad', 'gold', 32) + '</div><div class="cnt">' + owned + (owned === 1 ? ' creature' : ' creatures') + '</div>'
      + '<div class="table"><div class="deck">' + backHtml + backHtml + backHtml + '</div>'
      + Array.from({ length: n }, (_, i) => '<div class="cw" data-i="' + i + '"><div class="fl"><div class="fc">' + cardsHtml[i] + '</div><div class="bk"><span>' + STAR_IC + '</span></div></div></div>').join('') + '</div>'
      + '<div class="band"><div class="tip"><em>Tip:</em> <span></span></div></div></div>';
  }
  function gatherSquad(p, x, cardsHtml, owned) {
    const MIN = 1900, HOLD = 1700, n = Math.min(5, cardsHtml.length);
    let ov = p.querySelector('.sq-gs');
    if (!ov) { const d = document.createElement('div'); d.innerHTML = gatherHtml(cardsHtml, owned); ov = d.firstChild; p.querySelector('.mm-pg').appendChild(ov); if (x.fitFT) x.fitFT(ov); }
    raysCanvas(ov.querySelector('canvas.rays'), RAYS_LOADER);
    const cw = [...ov.querySelectorAll('.cw')], fl = cw.map(c => c.querySelector('.fl')), deck = ov.querySelector('.deck'), backs = [...deck.querySelectorAll('.back')];
    const tip = ov.querySelector('.tip span');
    let ti = Math.floor(Math.random() * SQUAD_TIPS.length); tip.textContent = SQUAD_TIPS[ti];
    const tipT = setInterval(() => { tip.parentNode.classList.add('sw'); setTimeout(() => { ti = (ti + 1) % SQUAD_TIPS.length; tip.textContent = SQUAD_TIPS[ti]; tip.parentNode.classList.remove('sw'); }, 260); }, 2800);
    // the row: each card's place, a little tilt one way or the other
    const pose = cw.map((c, i) => { const k = i - (n - 1) / 2; return 'translate(' + (k * 122).toFixed(0) + 'px,' + (i % 2 ? 6 : -2) + 'px) rotate(' + (i % 2 ? 4 : -4) + 'deg)'; });
    const DEAL = 'cubic-bezier(.2,.9,.3,1.05)', anims = [];
    const go = (el, kf, o) => { const a = el.animate(kf, Object.assign({ fill: 'both' }, o)); anims.push(a); return a; };
    const clear = () => { anims.splice(0).forEach(a => { try { a.cancel(); } catch (e) { /* gone */ } }); };
    // one deal from `at` ms: card i leaves the deck at at + 160 + 200 i (and the deck shows as thick as the cards still in
    // it: its backs go one by one, the deck itself with the last card), turns over 300 ms later
    let dealAt = 0, holdAt = 0, phase = 'deal', batch = 0;
    function deal(at, withSound) {
      phase = 'deal'; dealAt = at;
      cw.forEach((c, i) => {
        const d = at + 160 + i * 200;
        go(c, [{ transform: 'none' }, { transform: pose[i] }], { duration: 450, delay: d, easing: DEAL });
        go(c, [{ opacity: 0 }, { opacity: 1 }], { duration: 200, delay: d, easing: 'ease' });
        go(fl[i], [{ transform: 'rotateY(180deg)' }, { transform: 'rotateY(0deg)' }], { duration: 450, delay: d + 300, easing: 'ease' });
      });
      backs.forEach((b, j) => { if (n > 2 - j) go(b, [{ opacity: 1 }, { opacity: 0 }], { duration: 1, delay: at + 160 + Math.max(0, n - 3 + j) * 200 }); else go(b, [{ opacity: 0 }, { opacity: 0 }], { duration: 1 }); });
      go(deck, [{ opacity: 1, transform: 'none' }, { opacity: 0, transform: 'scale(.85)' }], { duration: 300, delay: at + 160 + (n - 1) * 200, easing: 'ease' });
      holdAt = at + 460 + n * 200 + 250;
      if (withSound) cw.forEach((c, i) => sfxAt('tap', at + 160 + i * 200));
    }
    // the animations' clock: ms since the loader's first frame on screen (the deal's start: its first animation's start
    // time on the page's timeline; a card's own time stops when its move ends)
    const clock = () => { const a = anims[0]; if (!a) return 0; if (a.startTime != null && document.timeline && document.timeline.currentTime != null) return document.timeline.currentTime - a.startTime; return a.currentTime || 0; };
    // the card sounds, on the sound clock: `ms` on the loader's clock, from now
    const sfxAt = (n0, ms) => { const dl = (ms - clock()) / 1000; if (dl < -0.05) return; sfxDelay(n0, Math.max(0, dl)); };
    // still loading: the cards turn back, gather into the deck, and the next five are dealt (all from `at`)
    function again(at) {
      phase = 'gather'; batch++;
      clear();
      const now0 = 0;   // (from now)
      cw.forEach((c, i) => {
        go(fl[i], [{ transform: 'rotateY(0deg)' }, { transform: 'rotateY(180deg)' }], { duration: 450, delay: now0 + i * 50, easing: 'ease' });
        go(c, [{ transform: pose[i] }, { transform: 'none' }], { duration: 450, delay: now0 + 300 + i * 70, easing: DEAL });
        go(c, [{ opacity: 1 }, { opacity: 0 }], { duration: 200, delay: now0 + 300 + i * 70, easing: 'ease' });
      });
      go(deck, [{ opacity: 0, transform: 'scale(.85)' }, { opacity: 1, transform: 'none' }], { duration: 300, delay: now0 + 300, easing: 'ease' });
      backs.forEach((b, j) => go(b, [{ opacity: 0 }, { opacity: 1 }], { duration: 1, delay: now0 + 300 + (2 - j) * 70 }));   // (the top one first)
      const swap = 300 + n * 70 + 450;
      setTimeout(() => { if (!ov.isConnected) return; cw.forEach((c, i) => { c.querySelector('.fc').innerHTML = cardsHtml[(batch * n + i) % cardsHtml.length]; }); clear(); deal(0, true); }, swap);
    }
    // The deal (and its card sounds) starts once the loader is on screen and frames are flowing (SquishPerf.steady): on
    // the phone the first open made the WebView's GPU thread build the page's tiles for 0.5-1 s with no frame drawn, and a
    // deal started on the clock was over before it was seen (2026-11-20, on the Galaxy A16). Until then: the full deck.
    let ready = 0, over = false, shownAt = 0, started = false, dealtNow = null;
    // (the first deal has played out: the page under the loader is built from then: PERF 2026-11-20, below)
    const dealt = new Promise(res => { dealtNow = res; setTimeout(res, 4000); });
    window.SquishPerf.steady(() => { if (over || !ov.isConnected) return; started = true; shownAt = performance.now(); deal(0, true); }, 2500);
    const tick = () => {
      if (over || !ov.isConnected) { over = true; clearInterval(tipT); return; }
      if (!started) { requestAnimationFrame(tick); return; }
      const t = clock();
      if (phase === 'deal' && t >= holdAt) { phase = 'hold'; dealtNow(); }
      if (phase === 'hold') {
        const sinceShown = shownAt ? performance.now() - shownAt : 0;
        if (ready && performance.now() - ready > 250 && sinceShown >= MIN) { over = true; leave(); return; }
        if (!ready && t - holdAt > HOLD && cardsHtml.length > n) { again(); phase = 'gather'; }
      }
      requestAnimationFrame(tick);
    };
    requestAnimationFrame(tick);
    // loaded: the cards fade away up the table, then the page shows
    function leave() {
      clearInterval(tipT);
      ov.classList.add('sq-leaving');   // (the page's creature shows under it now; not 'out', which is the loader's own faded state: it faded the loader out once, then the fade below brought it back and faded it again, a flicker)
      cw.forEach((c, i) => {
        const lift = pose[i].replace(/translate\(([-\d.]+)px,([-\d.]+)px\)/, (m, a, b) => 'translate(' + a + 'px,' + (+b - 46) + 'px)');
        c.animate([{ transform: pose[i] }, { transform: lift }], { duration: 450, easing: 'ease-in', fill: 'forwards' });
        c.animate([{ opacity: 1 }, { opacity: 0 }], { duration: 400, easing: 'ease', fill: 'forwards' });
      });
      const out = ov.animate([{ opacity: 1 }, { opacity: 0 }], { duration: 450, delay: 420, easing: 'ease', fill: 'forwards' });
      out.onfinish = () => ov.remove();
    }
    return { ready() { if (!ready) ready = performance.now(); }, gone: () => !ov.isConnected || over, dealt };
  }
  // a sound `delay` seconds from now, on the sound clock (the yard games' synth: its notes start at currentTime + …)
  function sfxDelay(n, delay) {
    if (!delay || delay < 0.004) { sfx(n); return; }
    const B = window.BaseAudioContext || window.AudioContext, P = B && B.prototype, d = P && Object.getOwnPropertyDescriptor(P, 'currentTime');
    if (!d || !d.get || !d.configurable) { setTimeout(() => sfx(n), delay * 1000); return; }
    Object.defineProperty(P, 'currentTime', { configurable: true, enumerable: d.enumerable, get() { return d.get.call(this) + delay; } });
    try { sfx(n); } finally { Object.defineProperty(P, 'currentTime', d); }
  }

  M.characters = function (x) {
    addCss(); const Q = x.Q; if (!Q || !window.RiveRig || x.busy || x.inside) return false;
    const C4 = window.SQ_CARD4, T = window.SQ_THUMBS || {}, on = c => c && c.art && (!window.SquishConfig || window.SquishConfig.creatureOn(c.key));
    const all = Q.ROSTER.filter(on), own = id => Q.owns(id);
    const sets = [].concat(Q.SETS, [Q.HEROES, Q.ELEMENTAL, Q.SEASON]).filter(s => s && all.some(c => c.set === s.key));
    let pick = x.selId(), rig = null, rigKey = null;
    const mine = () => x.selId();
    // group by group (the roster's group order), each group Common first, Rainbow last
    const groups = () => {
      const out = sets.map(st => ({ key: st.key, name: st.name, list: all.filter(c => c.set === st.key) }));
      const rest = all.filter(c => !sets.some(st => st.key === c.set));
      if (rest.length) out.push({ key: 'other', name: 'Others', list: rest });
      out.forEach(g => g.list.sort((a, b) => (a.rar | 0) - (b.rar | 0) || a.id - b.id));
      return out.filter(g => g.list.length);
    };
    // PERF 2026-11-20: these cards' pictures at about the size they're drawn (webgame/tools/small-cards.py: 3-10x smaller
    // than the originals, which the first open after a launch decoded and uploaded by the dozen, the loader frozen
    // meanwhile); the original if a small copy is missing
    const sm = u => { const t = smallPic(u); return t === u ? 'src="' + u + '"' : 'src="' + t + '" onerror="this.onerror=null;this.src=\'' + u + '\'"'; };
    const cardHtml = c => {
      const id = c.id, s = still(c, Q), d = C4 ? C4.of(c) : null, o = own(id), cls = 'sq-cc' + (o ? '' : ' no') + (id === pick ? ' pv' : '') + (id === mine() ? ' me' : '');
      if (!d) return '<button class="' + cls + '" data-id="' + id + '" aria-label="' + esc(c.name) + '"><img class="art" alt="" loading="lazy" style="inset:0;width:100%;height:100%;object-fit:contain" ' + sm(s) + '>' + (o ? '' : '<span class="lk">' + LOCK(24) + '</span>') + '</button>';
      const bx = p => 'left:' + d[p + 'L'] + ';top:' + d[p + 'T'] + ';width:' + d[p + 'W'] + ';height:' + d[p + 'H'];
      return '<button class="' + cls + '" data-id="' + id + '" aria-label="' + esc(c.name) + '"><img class="bg" alt="" loading="lazy" ' + sm(d.cdBg) + ' style="' + bx('cdBg') + ';object-fit:cover;object-position:center bottom"><img class="art" alt="" loading="lazy" ' + sm(s) + ' style="' + bx('cdArt') + ';object-fit:contain;object-position:center bottom"><img class="frm" alt="" loading="lazy" ' + sm(d.cdFrame) + ' style="inset:0;width:100%;height:100%">'
        + (d.cdHasName ? '<img class="nmi" alt="" loading="lazy" ' + sm(d.cdName) + ' style="' + bx('cdNm') + ';object-fit:contain">' : '<span class="nmT" style="' + bx('cdNm') + ';color:' + d.cdInk + '">' + esc(c.name) + '</span>')
        + (o ? '' : '<span class="lk">' + LOCK(24) + '</span>') + '</button>';
    };
    // PERF 2026-11-20: the page opens as its loading screen alone (the page's frame, the loader over it: a few dozen
    // elements, on screen in the next frame); the page itself is then built under the loader in slices of a few ms a
    // frame (SquishPerf.slices): its stage, the row group by group, the creature, the scroll to yours. The loader's own
    // motion runs on the GPU meanwhile (gatherSquad). It leaves once the row's pictures in view are in (or after 4 s).
    // the loading screen over it (REDESIGN_V9): five of the player's creatures (the one in use first)
    const ownList = all.filter(c => own(c.id)), five = [].concat(ownList.filter(c => c.id === mine()), ownList.filter(c => c.id !== mine())).slice(0, 15);
    const deal = (five.length ? five : all.slice(0, 5)).map(c => cardHtml(c).replace(/ pv| me| no/g, '').replace(/loading="lazy"/g, '').replace(/ data-id="\d+"/, ''));
    const p = x.pageOpen('<div class="mm-pgh"><button class="mm-orb" data-x aria-label="Back">' + ic(BACK, '#fff', 3) + '</button>' + ft('Characters', 'gold', 30) + '<div class="mm-sp"></div></div>'
      + '<div class="sq-c2"></div>' + gatherHtml(deal, ownList.length));
    p.classList.add('sq-chars');
    M.hold();   // (the menu's creature stops at once)
    // PERF 2026-11-20: the page covers the menu from its first frame (no fade-in): the menu isn't drawn from that frame on
    // (cover() would only see it on its next 400 ms round, and the menu's scene was rastered meanwhile)
    x.frame.classList.add('sq-covered'); weatherOn(false);
    const G = gatherSquad(p, x, deal, ownList.length);
    if (window.SquishPerf.quiet) window.SquishPerf.quiet(4000);
    const box = p.querySelector('.sq-c2');
    let who = null, actAt = null, row = null, prevB = null, nextB = null;
    // The platform: a round plate seen at a slant (a circle in a box squashed to 20%) turning slowly, with its lights
    // riding round its rim over it, round lights spaced evenly along the ellipse (bulbRun).
    const bulbs = Array.from({ length: BULBS }, (_, i) => '<span class="bp" style="animation-delay:' + +(-i * BULB_LAP / BULBS).toFixed(3) + 's"><i class="b' + (i % 2 ? ' w' : '') + '"></i></span>').join('');
    const groupHtml = g => '<div class="grp"><div class="gl">' + esc(g.name) + '</div><div class="gc">' + g.list.map(cardHtml).join('') + '</div></div>';
    const starts = () => [...row.querySelectorAll('.grp')].map(g => g.offsetLeft - 44);
    const groupAt = () => { const S0 = starts(), x0 = row.scrollLeft + 8; let i = 0; S0.forEach((v, j) => { if (v <= x0) i = j; }); return i; };
    const navMark = () => { const n = row.querySelectorAll('.grp').length, i = groupAt(), end = row.scrollLeft >= row.scrollWidth - row.clientWidth - 4;
      prevB.classList.toggle('off', i === 0 && row.scrollLeft < 8); nextB.classList.toggle('off', i >= n - 1 || end); };
    const jump = d => { const S0 = starts(), i = clamp(groupAt() + d, 0, S0.length - 1), from = row.scrollLeft, to = clamp(S0[i], 0, row.scrollWidth - row.clientWidth);
      sfx('whoosh'); row._glide && row._glide(); tween(380, t => { row.scrollLeft = from + (to - from) * t; }, EIO).then(navMark); };
    const showRig = (c, pop) => {
      let host = box.querySelector('.rig');
      if (rig && rigKey === c.key && !pop) return;
      if (rig) { try { rig.destroy(); } catch (e) { /* gone */ } rig = null; }
      const fresh = host.cloneNode(false); host.replaceWith(fresh); host = fresh;
      host.className = 'rig' + (pop ? ' pop' : '') + (own(c.id) ? '' : ' sil');
      try { rig = window.RiveRig.mount(host, c.key, {}); rigKey = c.key; } catch (e) { rig = null; }
      if (rig) setTimeout(() => { if (!rig) return; const L = allowed(rig._I, own(c.id) ? ['happy', 'love', 'cheer'] : ['look', 'surprised']); if (L.length) rig.play(L[Math.floor(Math.random() * L.length)]); }, 350);
    };
    const info = c => {
      const r = clamp(c.rar | 0, 0, 4), o = own(c.id), set = sets.find(s => s.key === c.set), RA = Q.RAR && Q.RAR[r];
      who.innerHTML = (RA ? '<span class="sq-chip tag" style="background:' + RA.dot + '">' + RA.label + '</span>' : '<span></span>')
        + '<div class="np mm-p ' + PLQ[r] + '"><div class="pips">' + STAR.repeat(r + 1) + '</div>' + ft(c.name, NFT[r], 19) + '</div>'
        + (set ? '<span class="sq-chip tag">' + esc(set.name) + '</span>' : '<span></span>');
      let act = '';
      if (!o) act = '<button class="act mm-p v-vel" data-shop>' + LOCK(16) + '<span class="tx-w">Find it in chests</span></button>';
      else if (c.id !== mine()) act = '<button class="act mm-p v-gold" data-sel>' + ft('CHOOSE', 'whiteB', 20) + '</button>';
      actAt.innerHTML = act;
      x.fitFT(who); x.fitFT(actAt);
      const sb = actAt.querySelector('[data-sel]'); if (sb) sb.onclick = () => choose(c.id, true);
      const sh = actAt.querySelector('[data-shop]'); if (sh) sh.onclick = () => { sfx('tap'); close(); send('open', { what: 'shop' }); };
    };
    const mark = () => row.querySelectorAll('[data-id]').forEach(b => { const id = +b.dataset.id; b.classList.toggle('pv', id === pick); b.classList.toggle('me', id === mine()); });
    function choose(id, confirm) {
      const c = Q.ROSTER[id]; if (!c) return;
      if (confirm) {
        if (!own(id) || !x.Lb) return;
        x.Lb.select(id); x.preview = null; x.mountRig(); x.hudDraw();
        sfx('win'); if (rig) { const L = allowed(rig._I, ['cheer', 'happy', 'dance']); if (L.length) rig.play(L[0]); }
        toast(p, c.name + ' is in front of your house!', 'r');
        info(c); mark(); return;
      }
      const changed = id !== pick; pick = id; sfx('tap');
      showRig(c, changed); info(c); mark();
    }
    // the rig is destroyed with the page, however it closes
    const watch = setInterval(() => { if (!p.isConnected) { clearInterval(watch); if (rig) { try { rig.destroy(); } catch (e) { /* gone */ } rig = null; } } }, 500);
    function close() { clearInterval(watch); if (rig) { try { rig.destroy(); } catch (e) { /* gone */ } rig = null; } x.closePage(); if (x.ctrl) x.ctrl.play('happy'); }
    p.querySelector('[data-x]').onclick = close;
    // the page, built under the loader
    const alive = () => p.isConnected;
    const steps = [() => {
      if (!alive()) return false;
      box.innerHTML = '<canvas class="rays"></canvas><div class="ring"><div class="side"></div><div class="tilt"><div class="turn"><div class="plate"></div></div></div>' + bulbs + '</div><div class="rig"></div>'
        + '<div class="who"></div><div class="act-at"></div><div class="row"></div>'
        + '<button class="mm-orb gnav prev" aria-label="Previous group">' + ic(LEFT, '#fff', 3) + '</button><button class="mm-orb gnav next" aria-label="Next group">' + ic(RIGHT, '#fff', 3) + '</button>';
      raysCanvas(box.querySelector('canvas.rays'), RAYS_CHARS);
      who = box.querySelector('.who'); actAt = box.querySelector('.act-at'); row = box.querySelector('.row');
      prevB = box.querySelector('.gnav.prev'); nextB = box.querySelector('.gnav.next');
      // The row scrolls sideways (the user): dragged with a finger or the mouse, gliding on after a flick, or with a mouse
      // wheel; a drag doesn't count as a tap on a card. The arrows at its ends jump to the previous / next group.
      dragRow(row);
      row.addEventListener('click', e => { const b = e.target.closest && e.target.closest('[data-id]'); if (b && row.contains(b)) choose(+b.dataset.id); });
      prevB.onclick = () => jump(row.scrollLeft > starts()[groupAt()] + 8 ? 0 : -1);
      nextB.onclick = () => jump(1);
      row.addEventListener('scroll', navMark, { passive: true });
    }];
    // the row, a group at a time (each group Common first, Rainbow last)
    // PERF 2026-11-20: a group's cards are drawn only while they're on screen (content-visibility, at the size measured as
    // it goes in, so the row's length and the groups' places never change): the WebView rastered the whole 10,800 px row
    // the first time, all 86 cards and their ~90 pictures, on the GPU thread every frame waits for (~1 s on the A16)
    groups().forEach(g => steps.push(() => {
      if (!alive()) return false;
      row.insertAdjacentHTML('beforeend', groupHtml(g));
      const gc = row.lastElementChild && row.lastElementChild.querySelector('.gc');
      if (gc && 'contentVisibility' in gc.style) { gc.style.containIntrinsicSize = gc.offsetWidth + 'px ' + gc.offsetHeight + 'px'; gc.style.contentVisibility = 'auto'; }
    }));
    steps.push(() => { if (!alive()) return false; const c0 = Q.ROSTER[pick] || all[0]; if (c0) { pick = c0.id; showRig(c0, true); info(c0); mark(); } });
    steps.push(() => {
      if (!alive()) return false;
      const sc = row.querySelector('.sq-cc.pv'); if (sc) { const r0 = row.getBoundingClientRect(), r1 = sc.getBoundingClientRect(); row.scrollLeft = Math.max(0, row.scrollLeft + (r1.left - r0.left) / (r0.width / row.clientWidth || 1) - (row.clientWidth - sc.offsetWidth) / 2); }
      navMark();
    });
    // PERF 2026-11-20: the page is built under the loader once its first deal has played (G.dealt), not at once: on the
    // first open after a launch, the WebView drawing the page for the first time (its layers, the row, the stage) held the
    // loader on a still deck for ~0.9 s on the Galaxy A16 before the deal could start; now the loader alone is drawn
    // first and deals at once, and the page's first drawing happens while the dealt cards rest (nothing moving to stop)
    G.dealt.then(() => window.SquishPerf.slices(steps)).then(() => {
      if (!alive()) return;
      // ready once the row's pictures in view are in (a lazy picture off to the side doesn't load until it's scrolled to)
      const inView = im => { const r = im.getBoundingClientRect(); return r.width > 0 && r.right > 0 && r.left < innerWidth; };
      const imgs = [...row.querySelectorAll('img')].slice(0, 60).filter(inView);
      Promise.race([Promise.all(imgs.map(im => (im.decode ? im.decode() : Promise.resolve()).catch(() => {}))), wait(4000)]).then(() => G.ready());
    });
    return true;
  };

  // ---------- 6. the page framework (REDESIGN_V7): the new menu pages (webgame/app/pages/*.js) ----------
  // A page registers itself: SquishMenu.pages.shop = (x, opts, P) => { … }, where x is the menu's insides (the same as
  // the Level Pass gets) and P the page kit below. SquishMenu.open('shop', opts) opens it over the menu; the app can ask
  // for one too ({ type: 'page', name }). Android back closes it (its back orb has data-x).
  M.pages = {};
  M.kit = { esc, fmt, clamp, r1, wait, tween, ft, ic, pill, toast, sfx, send, LOCK, STAR, SPARK, CHECK, BACK, LEFT, RIGHT, coinImg, gemImg, fillIcons, addCss,
    // the page shell: a full-screen page with the menu's header (back orb, gold title, a note, the right-hand pills)
    // → { page, pg (the 852-wide scaled box to fill), close() }
    page(x, o) {
      addCss();
      const p = x.pageOpen('<div class="mm-pgh"><button class="mm-orb" data-x aria-label="Back">' + ic(BACK, '#fff', 3) + '</button>' + ft(o.title, 'gold', 30)
        + (o.note ? '<div class="s">' + esc(o.note) + '</div>' : '') + '<div class="mm-sp"></div>' + (o.right || '') + '</div>' + (o.body || ''));
      fillIcons(p);
      const close = () => { if (o.onClose) try { o.onClose(); } catch (e) { /* page gone */ } x.closePage(); if (x.ctrl) x.ctrl.play('happy'); };
      p.querySelector('[data-x]').onclick = close;
      return { page: p, pg: p.querySelector('.mm-pg'), close };
    },
  };
  M.open = function (name, opts) {
    const x = M._x, fn = M.pages[name];
    if (!x || !fn || x.busy || x.inside) return false;
    addCss();
    try { fn(x, opts || {}, M.kit); return true; } catch (e) { console.error('[SquishMenu] page ' + name, e); return false; }
  };
  if (App) App.on('page', m => { if (m && m.name) M.open(m.name, m.opts); });
})();
