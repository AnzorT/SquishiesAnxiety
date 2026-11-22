// THE GAME INTRO (2026-11-16, the user: "squad-intro file in desktop holds the new game intro, delete the old one and put
// the new one"): the designer's Desktop/squad-intro.js, copied here below this note, unchanged but for the changes marked
// PERF (2026-11-16, the user: "the intro has very low FPS"; the look is the same), APP (2026-11-17: api.awake(), the
// third squish, when the app starts its music) and FLICKER (2026-11-20: the UI flickered while the rooms lit up and in
// the dawn, from the WebView running out of tile memory; the look is the same), WEATHER (2026-11-21, the user: "the intro
// is still raining, it should be affected by the weathers": the night and the morning are today's weather from the
// app's config/weather, rain only when it rains, snow when it snows, and it keeps falling into the morning so the menu
// after it has the same) and DOME (2026-11-21, the user: the Dance Room's light was an ellipse, not the room's shape:
// its window is now the dome itself, a half disc, as main-menu-scene.js draws it). It replaces the app's old
// splash screen (src/screens/SplashScreen.js, deleted): App.js asks for it once a launch, the first time the menu shows
// (start data `intro`, src/game/GameScreen.js), and app/menu.js (SquishMenu.intro) hands it the menu's api it was written
// for (the Nov 14 menu's startIntro; our menu is the Nov 13 one, so menu.js builds the same api from its insides).
// Nov 14 GAME INTRO "Squish wakes the house" (user: 'we need to create a new intro to the game, something unique and creative' -> picked this idea;
// 'use characters only from pet shop, snack shack and fruit').
// Runs inside the landscape Main Menu (main-menu.js startIntro -> SquadIntro.run(api)) on the menu's own house scene, so it ends where the menu begins:
//   1. Night, rain: the camera drifts in on the dark house. 'A little house is waiting for its squad...'
//   2. A cardboard box drops onto the pad and wobbles (something inside!). 'Tap the box!'
//   3. The flaps burst open, Mittens pops out (surprised, looks around), the box falls away.
//   4. 'Squish Mittens to wake up the house!' Each squish (hold or tap) shoots a spark into the house and a room lights up (3 rooms, chimes).
//   5. The whole house glows, the rain stops, dawn breaks into a sunny morning; the squad (Pet Shop, Snack Shack, Fruit only) peeks out of
//      the windows and waves; Mittens dances.
//   6. The plush SQUISH SQUAD logo drops in letter by letter and wobbles. 'Tap to start' -> api.finish() (the menu fades its HUD back in).
// Skip (top right) ends it at once. Pure DOM + SVG + WebAudio (no new files): window.SquadIntro = { v, run }.
(function () {
  if (window.SquadIntro && window.SquadIntro.v >= 3) return;
  const NS = 'http://www.w3.org/2000/svg';
  const clamp = (x, a, b) => Math.max(a, Math.min(b, x)), r1 = x => (Math.round(x * 10) / 10).toString();
  const easeOut = t => 1 - Math.pow(1 - t, 3), easeIn = t => t * t * t, easeIO = t => t < 0.5 ? 4 * t * t * t : 1 - Math.pow(-2 * t + 2, 3) / 2;
  const backOut = t => { const c = 1.9; return 1 + (c + 1) * Math.pow(t - 1, 3) + c * Math.pow(t - 1, 2); };
  const bounceOut = t => { const n = 7.5625, d = 2.75; if (t < 1 / d) return n * t * t; if (t < 2 / d) return n * (t -= 1.5 / d) * t + 0.75; if (t < 2.5 / d) return n * (t -= 2.25 / d) * t + 0.9375; return n * (t -= 2.625 / d) * t + 0.984375; };
  const hx = c => [1, 3, 5].map(i => parseInt(c.slice(i, i + 2), 16)), mixC = (a, b, t) => { const A = hx(a), B = hx(b); return '#' + A.map((v, i) => Math.round(v + (B[i] - v) * clamp(t, 0, 1)).toString(16).padStart(2, '0')).join(''); };
  const svgEl = cls => { const s = document.createElementNS(NS, 'svg'); s.setAttribute('viewBox', '0 0 1000 460'); s.setAttribute('preserveAspectRatio', 'xMidYMax slice'); s.setAttribute('class', cls); s.style.cssText = 'position:absolute;inset:0;width:100%;height:100%;overflow:visible;pointer-events:none;will-change:transform;'; return s; };
  // PERF: will-change above: each intro layer is its own GPU layer. The menu's world is one layer with the house picture in it,
  // so anything that moved in an intro layer (the rain, the box, the ring, the sparks, the window lights) repainted the house
  // under it every frame.

  // the house's windows (main-menu-scene.js win() calls, open state): r = rect x y w h, a = arch x y w h, c = circle cx cy r, e = ellipse cx cy rx ry,
  // d = dome cx baseY r (a half disc standing on its base line)
  const WIN = {
    living: [['r', 434, 218, 36, 40], ['r', 530, 218, 36, 40]],
    bedroom: [['a', 298, 164, 42, 48], ['r', 366, 176, 30, 30]],
    bathroom: [['c', 629, 185, 17], ['r', 668, 164, 46, 44]],
    kitchen: [['r', 282, 246, 62, 36], ['c', 385, 265, 13]],
    movie: [['r', 604, 242, 92, 40], ['r', 712, 248, 16, 34]],
    // DOME: the Dance Room's glass dome as the scene draws it (main-menu-scene.js: DX 500, DY 170, DR 46), was an
    // ellipse (500, 140, 44 x 33) that lit the sky above the dome
    dance: [['d', 500, 170, 46]] };
  const ORDER = ['living', 'bedroom', 'bathroom'], REST = ['kitchen', 'movie', 'dance'];
  const box = w => w[0] === 'r' || w[0] === 'a' ? [w[1], w[2], w[3], w[4]] : w[0] === 'c' ? [w[1] - w[3], w[2] - w[3], 2 * w[3], 2 * w[3]] : w[0] === 'd' ? [w[1] - w[3], w[2] - w[3], 2 * w[3], w[3]] : [w[1] - w[3], w[2] - w[4], 2 * w[3], 2 * w[4]];
  const dome = (cx, by, r) => 'M' + r1(cx - r) + ' ' + by + ' A' + r1(r) + ' ' + r1(r) + ' 0 0 1 ' + r1(cx + r) + ' ' + by + 'Z';
  const shape = (w, at) => w[0] === 'r' ? '<rect x="' + w[1] + '" y="' + w[2] + '" width="' + w[3] + '" height="' + w[4] + '" rx="1.5" ' + at + '/>'
    : w[0] === 'a' ? '<path d="M' + w[1] + ' ' + (w[2] + w[4]) + ' V' + (w[2] + w[3] / 2) + ' A' + (w[3] / 2) + ' ' + (w[3] / 2) + ' 0 0 1 ' + (w[1] + w[3]) + ' ' + (w[2] + w[3] / 2) + ' V' + (w[2] + w[4]) + 'Z" ' + at + '/>'
    : w[0] === 'd' ? '<path d="' + dome(w[1], w[2], w[3]) + '" ' + at + '/>'
    : w[0] === 'c' ? '<circle cx="' + w[1] + '" cy="' + w[2] + '" r="' + w[3] + '" ' + at + '/>' : '<ellipse cx="' + w[1] + '" cy="' + w[2] + '" rx="' + w[3] + '" ry="' + w[4] + '" ' + at + '/>';
  // who peeks out at the end: [key, room, window index, creature centre x (null = window centre)] - Pet Shop, Snack Shack and Fruit only
  const PEEK = [['biscuit', 'living', 0], ['berri', 'living', 1], ['nibbles', 'bedroom', 0], ['appy', 'bedroom', 1], ['peachy', 'bathroom', 0], ['scoop', 'bathroom', 1],
    ['truffle', 'kitchen', 0], ['boba', 'movie', 0, 628], ['bao', 'movie', 0, 672]];
  const LOGO = [['S', '#ffb3dc', '#ff5cb0', '#c4207a'], ['Q', '#ffd6a8', '#ff9a4a', '#c4560e'], ['U', '#fff0a0', '#ffd23a', '#c48a0a'], ['I', '#c8ffb8', '#5fd65a', '#2a8a2a'], ['S', '#b8f0ff', '#3fc0f0', '#1a78b8'], ['H', '#e0ccff', '#a070ff', '#5a2ac0'],
    [' '], ['S', '#ffb3dc', '#ff5cb0', '#c4207a'], ['Q', '#ffd6a8', '#ff9a4a', '#c4560e'], ['U', '#fff0a0', '#ffd23a', '#c48a0a'], ['A', '#b8f0ff', '#3fc0f0', '#1a78b8'], ['D', '#e0ccff', '#a070ff', '#5a2ac0']];

  // ---- tiny synth (no sound files): chimes for the windows, a pop for the box, soft squish blips ----
  let AC = null;
  const audio = () => { if (AC === null) { try { AC = new (window.AudioContext || window.webkitAudioContext)(); } catch (e) { AC = false; } } if (AC && AC.state === 'suspended') AC.resume(); return AC || null; };
  function tone(f, t0, dur, vol, type) { const a = AC; if (!a) return; const o = a.createOscillator(), g = a.createGain(), t = a.currentTime + (t0 || 0);
    o.type = type || 'sine'; o.frequency.setValueAtTime(f, t); g.gain.setValueAtTime(0.0001, t); g.gain.exponentialRampToValueAtTime(vol || 0.08, t + 0.012); g.gain.exponentialRampToValueAtTime(0.0001, t + dur);
    o.connect(g); g.connect(a.destination); o.start(t); o.stop(t + dur + 0.05); }
  const chime = (f, t0) => { tone(f, t0, 1.4, 0.07); tone(f * 2, t0, 0.8, 0.025, 'triangle'); tone(f * 3.01, t0, 0.4, 0.012); };
  function sweep(f0, f1, dur, vol, t0) { const a = AC; if (!a) return; const o = a.createOscillator(), g = a.createGain(), t = a.currentTime + (t0 || 0);
    o.frequency.setValueAtTime(f0, t); o.frequency.exponentialRampToValueAtTime(f1, t + dur); g.gain.setValueAtTime(0.0001, t); g.gain.exponentialRampToValueAtTime(vol, t + 0.02); g.gain.exponentialRampToValueAtTime(0.0001, t + dur);
    o.connect(g); g.connect(a.destination); o.start(t); o.stop(t + dur + 0.05); }
  const NOTE = { C5: 523.25, E5: 659.25, G5: 783.99, C6: 1046.5, E6: 1318.5, G6: 1568 };

  let CSS = false;
  function css() { if (CSS) return; CSS = true; const s = document.createElement('style'); s.textContent = `
.si-ov{position:absolute;left:0;top:0;transform-origin:0 0;pointer-events:none;z-index:6;}
.si-cap{position:absolute;left:50%;top:14px;transform:translateX(-50%);padding:0 20px;height:34px;display:flex;align-items:center;font:700 15px Fredoka,Nunito,sans-serif;letter-spacing:.4px;white-space:nowrap;opacity:0;cursor:default;transition:opacity .45s ease, transform .3s cubic-bezier(.3,1.6,.5,1);}
.si-cap.on{opacity:1;}
.si-cap.pop{transform:translateX(-50%) scale(1.1);}
.si-cap b{color:#ffe27a;font-weight:700;margin-left:5px;}
.si-dots{display:inline-flex;gap:6px;margin-left:10px;}
.si-dots i{width:13px;height:13px;border-radius:50%;background:rgba(255,255,255,.16);box-shadow:inset 0 0 0 1.6px rgba(255,236,170,.75);transition:background .3s, transform .35s cubic-bezier(.3,1.8,.5,1);}
.si-dots i.on{background:radial-gradient(circle at 35% 30%,#fffbe0 0 18%,#ffd23a 45%,#e08a0a 100%);transform:scale(1.25);box-shadow:0 0 10px 3px rgba(255,214,90,.8),inset 0 0 0 1.6px #8a4a04;}
.si-skip{position:absolute;right:16px;top:14px;height:30px;padding:0 16px;font:700 13px Fredoka,Nunito,sans-serif;pointer-events:auto;opacity:.92;}
.si-tap{position:absolute;left:50%;bottom:6px;transform:translateX(-50%);font:700 21px Fredoka,Nunito,sans-serif;letter-spacing:2.5px;color:#fff;white-space:nowrap;pointer-events:auto;cursor:pointer;opacity:0;transition:opacity .6s;
  -webkit-text-stroke:5px #3d1268;paint-order:stroke fill;text-shadow:0 3px 0 #3d1268,0 0 18px rgba(255,220,120,.95);}
.si-tap span{display:inline-block;animation:siPulse 1.3s ease-in-out infinite;}
.si-tap.on{opacity:1;}
@keyframes siPulse{0%,100%{transform:scale(1);}50%{transform:scale(1.09);}}
.si-logo{position:absolute;left:50%;top:4px;transform:translateX(-50%);width:600px;height:124px;overflow:visible;}
.si-black{position:absolute;inset:0;background:#05060f;z-index:7;pointer-events:none;transition:opacity 1.4s ease;}
.si-hit{position:absolute;pointer-events:auto;cursor:pointer;border-radius:18px;}
@keyframes siRain{from{transform:translate(0,-80px);}to{transform:translate(-26px,540px);}}
.si-rain line{animation:siRain linear infinite;}
@keyframes siRing{0%{transform:scale(.55);opacity:.95;}100%{transform:scale(1.5);opacity:0;}}
.si-ring circle{transform-box:fill-box;transform-origin:center;animation:siRing 1.25s ease-out infinite;}
.si-ring circle+circle{animation-delay:.62s;}
`; document.head.appendChild(s); }

  function run(api) {
    css();
    const { frame, world, scene, stage, Sc } = api;
    let dead = false, raf = 0; const timers = [], cleanups = [];
    const wait = ms => new Promise(res => { const t = setTimeout(res, ms); timers.push(t); });
    const tween = (ms, fn, ease) => new Promise(res => { const t0 = performance.now(), E = ease || easeIO; const step = () => { if (dead) return res(); const t = Math.min(1, (performance.now() - t0) / ms); fn(E(t), t); if (t < 1) requestAnimationFrame(step); else res(); }; requestAnimationFrame(step); });
    const ctrl = () => api.ctrl(), I = () => { const c = ctrl(); return c && c._I; }, play = s => { const c = ctrl(); if (c) c.play(s); };
    const noSigns = el => el.querySelectorAll('.mm-sign').forEach(e => e.remove());
    // WEATHER: today's weather (the scene's own pick, which asks the app's config/weather first: app/bridge.js
    // SquishWeatherNow); the design's night was always rainy
    const WX = Sc.state({ level: 1 }).season;
    // the house at night: level 1, today's weather, every room's window open (no boards / lock signs: the story lights them up)
    scene.innerHTML = api.sceneSvg({ level: 1, season: WX }); noSigns(scene);
    // (WEATHER: a sunny scene draws its sun, main-menu-scene.js: not at night, under the moon; the morning's scene has it)
    scene.querySelectorAll('circle[cx="150"][cy="70"]').forEach(e => e.remove());

    // ---- layers in the world (they move with the camera) ----
    const back = svgEl('si-back'), boxB = svgEl('si-boxb'), boxF = svgEl('si-boxf'), top = svgEl('si-top');
    back.style.willChange = 'auto';   // PERF exception: its window glows blend (screen, soft-light, multiply) with the house under it, so it stays on the house's layer
    const sceneB = document.createElement('div'); sceneB.className = 'mm-scene si-sceneb'; sceneB.style.opacity = '0';
    sceneB.style.willChange = 'opacity';   // PERF: its fade-in is the compositor's, not a repaint of both houses every frame
    // PERF: the squad peeking out of the windows waves every frame to the end: on a layer of its own, not in `back` (with
    // its mask and blend modes, all repainted with every wave)
    const peekL = svgEl('si-peekl');
    // PERF: the rain was 80 lines each moved by a CSS animation inside the `top` SVG (repainted every frame); now it's drawn
    // once on two layers, near and far, that the compositor slides (rainBuild below)
    const rainL = document.createElement('div'); rainL.className = 'si-rainl'; rainL.style.cssText = 'position:absolute;inset:0;overflow:hidden;pointer-events:none;';
    world.insertBefore(sceneB, scene.nextSibling); world.insertBefore(back, sceneB.nextSibling); world.insertBefore(peekL, back.nextSibling); world.insertBefore(boxB, stage); world.insertBefore(boxF, stage.nextSibling); world.insertBefore(top, boxF.nextSibling);
    frame.insertBefore(rainL, world.nextSibling);
    stage.style.willChange = 'transform';   // PERF: Mittens (and the night's filter on him) on his own layer while the intro plays
    const hitBox = document.createElement('div'); hitBox.className = 'si-hit'; hitBox.style.display = 'none'; world.appendChild(hitBox);
    // ---- frame overlay (does not move with the camera), designed at 852 x 393 and scaled like the menu HUD ----
    const ov = document.createElement('div'); ov.className = 'si-ov'; frame.appendChild(ov);
    const black = document.createElement('div'); black.className = 'si-black'; frame.appendChild(black);
    const fit = () => { const W = frame.clientWidth, H = frame.clientHeight, k = H / 393; ov.style.width = (W / k) + 'px'; ov.style.height = '393px'; ov.style.transform = 'scale(' + k + ')'; };
    fit(); let ro = null; if (window.ResizeObserver) { ro = new ResizeObserver(() => { fit(); veilFit(); }); ro.observe(frame); }   // (FLICKER: veilFit, below)
    const cap = document.createElement('div'); cap.className = 'si-cap mm-p tip v-vel tx-w'; ov.appendChild(cap);
    const skip = document.createElement('button'); skip.className = 'si-skip mm-p v-vel tx-w'; skip.textContent = 'Skip ›'; ov.appendChild(skip);
    let capN = 0;
    const say = async (html, pop) => { const my = ++capN; if (cap.classList.contains('on')) { cap.classList.remove('on'); await wait(300); } if (my !== capN || dead) return; cap.innerHTML = html; cap.classList.add('on'); if (pop) bump(); };
    const bump = () => { cap.classList.add('pop'); setTimeout(() => cap.classList.remove('pop'), 280); };
    const hush = () => { capN++; cap.classList.remove('on'); };

    // ---- night: veil (with holes where the windows are lit), moon glow, window halos, the squad peeking ----
    let holes = '', halos = '', panes = '';
    Object.keys(WIN).forEach(room => WIN[room].forEach(w => { const [x, y, ww, hh] = box(w), cx = x + ww / 2, cy = y + hh / 2, R = Math.max(ww, hh);
      holes += shape(w, 'class="h-' + room + '" fill="#000" opacity="0"');
      // (DOME: the dome's glow is a bigger half disc on the same base, lit from the middle of its base: it follows the dome)
      halos += w[0] === 'd' ? '<path class="g-' + room + '" d="' + dome(w[1], w[2], w[3] * 1.35) + '" fill="url(#siGlowD)" opacity="0"/>'
        : '<ellipse class="g-' + room + '" cx="' + r1(cx) + '" cy="' + r1(cy) + '" rx="' + r1(R * 1.3) + '" ry="' + r1(R * 1.1) + '" fill="url(#siGlow)" opacity="0"/>';
      panes += shape(w, 'class="p-' + room + '" fill="url(#siPane)" opacity="0"'); }));
    const VEIL = 'x="0" y="0" width="1000" height="460"';
    const veilFit = () => { const W = frame.clientWidth, H = frame.clientHeight; if (!W || !H) return; const s = Math.max(W / 1000, H / 460), w = W / s, h = H / s;
      back.querySelectorAll('.si-veil').forEach(r => { r.setAttribute('x', r1(500 - w / 2 - 1)); r.setAttribute('y', r1(460 - h - 1)); r.setAttribute('width', r1(w + 2)); r.setAttribute('height', r1(h + 2)); }); };
    back.innerHTML = '<defs>'
      + '<linearGradient id="siNight" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#090d2e"/><stop offset="0.55" stop-color="#141a46"/><stop offset="1" stop-color="#1b1838"/></linearGradient>'
      + '<linearGradient id="siDawn" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#ff7a8a"/><stop offset="0.5" stop-color="#ffaa66"/><stop offset="1" stop-color="#ffd890"/></linearGradient>'
      + '<radialGradient id="siMoon"><stop offset="0" stop-color="#fff8dc" stop-opacity="0.9"/><stop offset="0.25" stop-color="#e8ecff" stop-opacity="0.35"/><stop offset="1" stop-color="#c8d4ff" stop-opacity="0"/></radialGradient>'
      + '<radialGradient id="siGlow"><stop offset="0" stop-color="#ffe7a6" stop-opacity="0.8"/><stop offset="0.45" stop-color="#ffc45a" stop-opacity="0.3"/><stop offset="1" stop-color="#ff9a2a" stop-opacity="0"/></radialGradient>'
      + (([, dx, dy, dr]) => '<radialGradient id="siGlowD" gradientUnits="userSpaceOnUse" cx="' + dx + '" cy="' + dy + '" r="' + r1(dr * 1.35) + '"><stop offset="0" stop-color="#ffe7a6" stop-opacity="0.8"/><stop offset="0.5" stop-color="#ffc45a" stop-opacity="0.3"/><stop offset="1" stop-color="#ff9a2a" stop-opacity="0"/></radialGradient>')(WIN.dance[0])
      + '<linearGradient id="siPane" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#fff2c0"/><stop offset="1" stop-color="#ffb347"/></linearGradient>'
      + '<mask id="siVeilM" class="si-veil" maskUnits="userSpaceOnUse" ' + VEIL + '><rect class="si-veil" ' + VEIL + ' fill="#fff"/>' + holes + '</mask>'
      + '</defs>'
      + '<rect class="si-dawn si-veil" ' + VEIL + ' fill="url(#siDawn)" opacity="0" style="mix-blend-mode:multiply"/>'
      + '<rect class="si-night si-veil" ' + VEIL + ' fill="url(#siNight)" opacity="0.8" mask="url(#siVeilM)"/>'
      + '<g class="si-moon" opacity="0.6"><circle cx="846" cy="56" r="74" fill="url(#siMoon)"/><circle cx="846" cy="56" r="14" fill="#fffbe8" opacity="0.75"/></g>'
      + '<g class="si-halo" style="mix-blend-mode:screen">' + halos + '</g><g class="si-pane" style="mix-blend-mode:soft-light">' + panes + '</g><g class="si-peek"></g>';
    const night = back.querySelector('.si-night'), dawn = back.querySelector('.si-dawn'), moon = back.querySelector('.si-moon'), peekG = peekL;   // PERF: was back's .si-peek group
    veilFit();
    const setLit = (room, v, flash, keepHoles) => { const f = flash || 0, dk = room === 'dance' ? 0.6 : 1;
      if (!keepHoles) back.querySelectorAll('.h-' + room).forEach(e => e.setAttribute('opacity', (clamp(v * 0.9 + f * 0.1, 0, 1) * dk).toFixed(3)));
      back.querySelectorAll('.g-' + room).forEach(e => e.setAttribute('opacity', clamp(v * 0.85 + f * 0.6, 0, 1.4).toFixed(3)));
      back.querySelectorAll('.p-' + room).forEach(e => e.setAttribute('opacity', (clamp(v * 0.75 + f * 0.25, 0, 1) * dk).toFixed(3))); };
    const center = room => { const B = WIN[room].map(box); return [B.reduce((a, b) => a + b[0] + b[2] / 2, 0) / B.length, B.reduce((a, b) => a + b[1] + b[3] / 2, 0) / B.length]; };

    // rain + effects, in front of everything in the world
    top.innerHTML = '<defs><radialGradient id="siGlowF"><stop offset="0" stop-color="#fffbe0" stop-opacity="1"/><stop offset="0.35" stop-color="#ffd76a" stop-opacity="0.6"/><stop offset="1" stop-color="#ffb02a" stop-opacity="0"/></radialGradient></defs>'
      // PERF: (the rain is on rainL now: rainBuild)
      + '<g class="si-ring" opacity="0"><circle cx="0" cy="0" r="30" fill="none" stroke="#ffe8a0" stroke-width="3"/><circle cx="0" cy="0" r="30" fill="none" stroke="#ffe8a0" stroke-width="3"/></g><g class="si-fx"></g>';
    // PERF: the rain, drawn once: two layers of drops (near: brighter and faster; far: fainter and slower), each a band of
    // drops repeated down the screen (each row shifted along the drops' drift) that the compositor slides one band per loop.
    // About the old drop count, length, colour, slant and speed (80 drops falling 620 units in 0.55-0.88 s, drifting 26 left).
    // WEATHER: only when it rains; when it snows the same layers carry snowflakes (rounder, slower, drifting); a sunny
    // night has none
    const rainAnims = [], SNOW = WX === 'snowy';
    function rainBuild() {
      rainAnims.forEach(a => { try { a.cancel(); } catch (e) { /* gone */ } }); rainAnims.length = 0; rainL.innerHTML = '';
      if (WX !== 'rainy' && !SNOW) return;
      const W = frame.clientWidth, H = frame.clientHeight; if (!W || !H) return;
      const s = Math.max(W / 1000, H / 460), B = Math.round(115 * s), rows = Math.ceil(H / B) + 1, DX = SNOW ? 40 / 620 : 26 / 620;
      (SNOW ? [[10, 2.6, 0.85, 70], [8, 1.8, 0.55, 45]] : [[9, 1.4, 0.6, 900], [7, 1.1, 0.4, 680]]).forEach(([n, sw, op, v], li) => {
        let band = '';
        for (let i = 0; i < n; i++) { const h = k => { const t = Math.sin((i + li * 50) * 12.9898 + k * 78.233) * 43758.5453; return t - Math.floor(t); };
          // (a snowflake: a dot, a zero-length round-capped line as wide as the flake)
          band += 'M' + r1(h(1) * (W + 60 * s)) + ' ' + r1(h(2) * B) + (SNOW ? 'l0 0.01' : 'l' + r1(-4 * s) + ' ' + r1(16 * s)); }
        let body = ''; for (let k = 0; k < rows; k++) body += '<path transform="translate(' + r1(-k * B * DX) + ' ' + (k * B) + ')" d="' + band + '"/>';
        const m = document.createElement('div'); m.style.cssText = 'position:absolute;left:0;top:' + (-B) + 'px;width:' + r1(W + 60 * s) + 'px;height:' + (rows * B) + 'px;will-change:transform;';
        m.innerHTML = '<svg width="100%" height="100%" style="position:absolute;inset:0;overflow:visible"><g stroke="' + (SNOW ? '#ffffff' : '#c8d6ff') + '" stroke-width="' + r1(sw * s) + '" stroke-linecap="round" opacity="' + op + '" fill="none">' + body + '</g></svg>';
        rainL.appendChild(m);
        rainAnims.push(m.animate([{ transform: 'translate(0px,0px)' }, { transform: 'translate(' + r1(-B * DX) + 'px,' + B + 'px)' }], { duration: Math.round(B / (v * s) * 1000), iterations: Infinity, easing: 'linear' }));
      });
    }
    rainBuild(); cleanups.push(() => rainAnims.forEach(a => { try { a.cancel(); } catch (e) { /* gone */ } }));
    // (WEATHER: the dawn faded the rain out here, rainG; it now keeps falling into the morning)
    const fxG = top.querySelector('.si-fx'), ring = top.querySelector('.si-ring');
    const ringAt = (x, y, r) => { if (x == null) { ring.setAttribute('opacity', 0); return; } ring.setAttribute('opacity', 1); ring.querySelectorAll('circle').forEach(c => { c.setAttribute('cx', x); c.setAttribute('cy', y); c.setAttribute('r', r); }); };

    // ---- the box: back = its inside + the two top flaps (behind Mittens), front = its face (in front of him) ----
    const BX = 500, BY = 432, BW = 168, BH = 116, fx0 = BX - BW / 2, fx1 = BX + BW / 2, ftop = BY - BH, TOPH = 20, IN = 18;
    boxB.innerHTML = '<g class="si-bxb" style="filter:brightness(.62) saturate(.85)"><path class="si-in" fill="#3e2412" opacity="0"/><path class="si-fl" fill="#d9a066" stroke="#5a3418" stroke-width="2" stroke-linejoin="round"/><path class="si-fr" fill="#c98f55" stroke="#5a3418" stroke-width="2" stroke-linejoin="round"/></g>';
    boxF.innerHTML = '<defs><linearGradient id="siCard" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#e6b075"/><stop offset="1" stop-color="#b9783e"/></linearGradient>'
      + '<linearGradient id="siTape" x1="0" y1="0" x2="1" y2="0"><stop offset="0" stop-color="#f3dca6"/><stop offset="1" stop-color="#e2c27e"/></linearGradient></defs>'
      + '<ellipse class="si-bsh" cx="' + BX + '" cy="' + (BY + 1) + '" rx="' + r1(BW * 0.6) + '" ry="9" fill="#0c0820" opacity="0"/>'
      + '<g class="si-bxf" style="filter:brightness(.62) saturate(.85)">'
      + '<path d="M' + fx0 + ' ' + ftop + ' H' + fx1 + ' V' + BY + ' H' + fx0 + 'Z" fill="url(#siCard)" stroke="#5a3418" stroke-width="2.6" stroke-linejoin="round"/>'
      + '<path d="M' + (fx0 + 5) + ' ' + (BY - 8) + ' H' + (fx1 - 5) + '" stroke="#9a6030" stroke-width="2" opacity="0.45"/>'
      + '<path d="M' + (fx0 + 6) + ' ' + (ftop + 3.5) + ' H' + (fx1 - 6) + '" stroke="#f6d3a0" stroke-width="2" stroke-linecap="round" opacity="0.7"/>'
      + '<rect x="' + (BX - 12) + '" y="' + ftop + '" width="24" height="' + r1(BH * 0.42) + '" fill="url(#siTape)" opacity="0.95"/>'
      + '<g transform="translate(' + (BX - 66) + ' ' + (ftop + 54) + ') rotate(-6)"><rect x="0" y="0" width="74" height="30" rx="4" fill="#fff4e0" stroke="#d2453a" stroke-width="2"/>'
      + '<text x="37" y="13" text-anchor="middle" font-family="Fredoka, Nunito, sans-serif" font-weight="700" font-size="10.5" fill="#d2453a" letter-spacing="0.8">FRAGILE</text>'
      + '<text x="37" y="25" text-anchor="middle" font-family="Fredoka, Nunito, sans-serif" font-weight="700" font-size="9.5" fill="#d2453a" letter-spacing="0.5">SQUISHY ♥</text></g>'
      + '<g transform="translate(' + (BX + 46) + ' ' + (ftop + 58) + ') rotate(10)" fill="#7a3a6a" opacity="0.85"><ellipse cx="0" cy="6" rx="9" ry="7.5"/><circle cx="-9" cy="-3.5" r="3.6"/><circle cx="-3" cy="-8" r="3.6"/><circle cx="4" cy="-8" r="3.6"/><circle cx="9.6" cy="-3" r="3.6"/></g>'
      + [[-56, 26], [-44, 26], [50, 92], [62, 92]].map(([dx, dy]) => '<circle cx="' + (BX + dx) + '" cy="' + (ftop + dy) + '" r="3" fill="#3a2010"/>').join('')
      + '</g>';
    const bxb = boxB.querySelector('.si-bxb'), bxf = boxF.querySelector('.si-bxf'), inP = boxB.querySelector('.si-in'), flL = boxB.querySelector('.si-fl'), flR = boxB.querySelector('.si-fr'), bsh = boxF.querySelector('.si-bsh');
    // the top in a 3/4 view; each flap is hinged on its outer edge: o = 0 closed (lying flat), 1 = flung open up and out
    function flaps(o) {
      const L0 = [fx0, ftop], L1 = [fx0 + IN, ftop - TOPH], R0 = [fx1, ftop], R1 = [fx1 - IN, ftop - TOPH];
      inP.setAttribute('d', 'M' + L0 + ' L' + L1 + ' L' + R1 + ' L' + R0 + 'Z'); inP.setAttribute('opacity', r1(clamp(o * 4, 0, 1)));
      const a = o * 2.3, lf = (h0, h1, sgn) => { const w0 = (BX - h0[0]) * sgn, w1 = (BX - h1[0]) * sgn;
        return 'M' + h0 + ' L' + h1 + ' L' + r1(h1[0] + Math.cos(a) * w1 * sgn) + ' ' + r1(h1[1] - Math.sin(a) * w1 * 0.85) + ' L' + r1(h0[0] + Math.cos(a) * w0 * sgn) + ' ' + r1(h0[1] - Math.sin(a) * w0 * 0.85) + 'Z'; };
      flL.setAttribute('d', lf(L0, L1, 1)); flR.setAttribute('d', lf(R0, R1, -1));
    }
    flaps(0);
    const boxT = (dy, rot, sx, sy, op) => { const t = 'translate(' + r1(BX) + ' ' + r1(BY + (dy || 0)) + ') rotate(' + r1(rot || 0) + ') scale(' + (sx || 1).toFixed(3) + ' ' + (sy || 1).toFixed(3) + ') translate(' + (-BX) + ' ' + (-BY) + ')';
      bxb.setAttribute('transform', t); bxf.setAttribute('transform', t); if (op != null) { bxb.setAttribute('opacity', op); bxf.setAttribute('opacity', op); } };
    boxT(-480);
    const placeHit = () => { const g = api.geo(); if (!g) return; hitBox.style.left = g.X(fx0 - 16) + 'px'; hitBox.style.top = g.Y(ftop - 40) + 'px'; hitBox.style.width = (BW + 32) * g.s + 'px'; hitBox.style.height = (BH + 52) * g.s + 'px'; };

    // ---- little effects ----
    const fxg = () => { const g = document.createElementNS(NS, 'g'); fxG.appendChild(g); return g; };
    const star = (X, Y, r) => 'M' + r1(X) + ' ' + r1(Y - r * 1.4) + ' Q' + r1(X) + ' ' + r1(Y) + ' ' + r1(X + r * 1.4) + ' ' + r1(Y) + ' Q' + r1(X) + ' ' + r1(Y) + ' ' + r1(X) + ' ' + r1(Y + r * 1.4) + ' Q' + r1(X) + ' ' + r1(Y) + ' ' + r1(X - r * 1.4) + ' ' + r1(Y) + ' Q' + r1(X) + ' ' + r1(Y) + ' ' + r1(X) + ' ' + r1(Y - r * 1.4) + 'Z';
    function burst(x, y, n, cols, spd, life) { const P = Array.from({ length: n }, (_, i) => { const a = -Math.PI / 2 + (Math.random() - 0.5) * Math.PI * 1.6, v = spd * (0.45 + Math.random() * 0.75); return { vx: Math.cos(a) * v, vy: Math.sin(a) * v, r: 2.2 + Math.random() * 3.2, c: cols[i % cols.length], rot: Math.random() * 360, sh: i % 3 }; });
      const g = fxg(), t0 = performance.now();
      const step = () => { if (dead) return; const t = (performance.now() - t0) / life; if (t >= 1) { g.remove(); return; } const k = t * life / 1000; let h = '';
        P.forEach(p => { const X = x + p.vx * k, Y = y + p.vy * k + 300 * k * k, o = (1 - t * t).toFixed(2);
          h += p.sh === 0 ? '<circle cx="' + r1(X) + '" cy="' + r1(Y) + '" r="' + r1(p.r) + '" fill="' + p.c + '" opacity="' + o + '"/>'
            : p.sh === 1 ? '<rect x="' + r1(X - p.r) + '" y="' + r1(Y - p.r * 0.6) + '" width="' + r1(p.r * 2) + '" height="' + r1(p.r * 1.2) + '" rx="' + r1(p.r * 0.6) + '" fill="' + p.c + '" opacity="' + o + '" transform="rotate(' + r1(p.rot + t * 500) + ' ' + r1(X) + ' ' + r1(Y) + ')"/>'
            : '<path d="' + star(X, Y, p.r) + '" fill="' + p.c + '" opacity="' + o + '"/>'; });
        g.innerHTML = h; requestAnimationFrame(step); }; requestAnimationFrame(step); }
    function puff(x, y) { const g = fxg(), t0 = performance.now(); const step = () => { if (dead) return; const t = (performance.now() - t0) / 700; if (t >= 1) { g.remove(); return; } let h = '';
      [-1, 1].forEach(s => { for (let i = 0; i < 3; i++) { const X = x + s * (36 + i * 24) * easeOut(t), R = (9 + i * 4) * (0.6 + t * 0.8); h += '<circle cx="' + r1(X) + '" cy="' + r1(y - 4 - i * 2 - t * 9) + '" r="' + r1(R) + '" fill="#8f8aa6" opacity="' + ((1 - t) * 0.5).toFixed(2) + '"/>'; } });
      g.innerHTML = h; requestAnimationFrame(step); }; requestAnimationFrame(step); }
    // a spark flies from Mittens to a room along an arc, leaving a twinkly trail
    function spark(from, to, ms) { return new Promise(res => { const g = fxg(), t0 = performance.now(), trail = [], cx = (from[0] + to[0]) / 2 + (to[0] < 500 ? 40 : -40), cy = Math.min(from[1], to[1]) - 110;
      const step = () => { if (dead) return res(); const t = Math.min(1, (performance.now() - t0) / ms), e = easeIO(t), u = 1 - e;
        const X = u * u * from[0] + 2 * u * e * cx + e * e * to[0], Y = u * u * from[1] + 2 * u * e * cy + e * e * to[1]; trail.push([X, Y]); if (trail.length > 16) trail.shift();
        let h = '';
        trail.forEach((p, i) => { const k = (i + 1) / trail.length; h += '<circle cx="' + r1(p[0] + Math.sin(i * 2.3 + t * 20) * 2.5) + '" cy="' + r1(p[1] + Math.cos(i * 1.7 + t * 17) * 2) + '" r="' + r1(0.8 + k * 2.4) + '" fill="' + (i % 3 ? '#ffe08a' : '#ffffff') + '" opacity="' + (k * 0.85).toFixed(2) + '"/>'; });
        h += '<circle cx="' + r1(X) + '" cy="' + r1(Y) + '" r="18" fill="url(#siGlowF)"/><path d="' + star(X, Y, 5.5) + '" fill="#fffbe6" transform="rotate(' + r1(t * 360) + ' ' + r1(X) + ' ' + r1(Y) + ')"/>';
        g.innerHTML = h; if (t < 1) requestAnimationFrame(step); else { g.remove(); res(); } }; requestAnimationFrame(step); }); }

    // ---- Mittens: the menu's own rig, lit for the night; the warm rim grows as the house lights up ----
    const nightLight = n => ({ dir: [0.1, 1], sh: 0.42, shC: '#232a5a', ao: 0.5, aoC: '#161b40', rim: 0.08 + 0.12 * n, rimC: '#ffcf7a', bounce: 0, bounceC: '#000000', tint: mixC('#8f99cc', '#efe2d2', n / 3), cast: 0.22, castC: '#0e1230', castLen: 6, contact: 2.2, line: 1.05 });
    const wrap = () => stage.firstChild;
    stage.style.transformOrigin = '50% 96%'; stage.style.opacity = '0';

    // ---- the plush logo (overlay): pillow letters with a dark outline, candy gradient, white stitching, shine ----
    // PERF: each letter is its own small SVG on its own GPU layer, moved by its wrapper's transform (same letters, same
    // place): the letters (five outlined, gradient-filled text layers each) used to share one SVG, all of it redrawn every
    // frame while they bounced and bobbed.
    function logoSvg() {
      const box = document.createElement('div'); box.className = 'si-logo'; ov.insertBefore(box, cap);
      const K = 600 / 640;   // the old SVG's viewBox (640 x 132) in its 600 x 124 box
      const probeS = document.createElementNS(NS, 'svg'); probeS.setAttribute('viewBox', '0 0 640 132'); probeS.style.cssText = 'position:absolute;left:0;top:0;width:600px;height:124px;visibility:hidden;'; box.appendChild(probeS);
      const F = 'font-family="Fredoka, Nunito, sans-serif" font-weight="700" font-size="86" text-anchor="middle"';
      const probe = document.createElementNS(NS, 'text'); probe.setAttribute('font-family', 'Fredoka, Nunito, sans-serif'); probe.setAttribute('font-weight', '700'); probe.setAttribute('font-size', '86'); probeS.appendChild(probe);
      const widths = LOGO.map(L => { if (L[0] === ' ') return 22; probe.textContent = L[0]; let w = 0; try { w = probe.getComputedTextLength(); } catch (e) {} return (w || 54) + 3; });
      probeS.remove(); const total = widths.reduce((a, b) => a + b, 0); let x = 320 - total / 2; const letters = [];
      LOGO.forEach((L, i) => { const w = widths[i]; if (L[0] !== ' ') { const cx = r1(x + w / 2), x0 = x - 14, ww = w + 28, d = document.createElement('div');
          d.style.cssText = 'position:absolute;left:' + r1(x0 * K) + 'px;top:0;width:' + r1(ww * K) + 'px;height:124px;will-change:transform;transform-origin:50% 96%;';
          d.innerHTML = '<svg viewBox="' + r1(x0) + ' 0 ' + r1(ww) + ' 132" width="100%" height="100%" style="display:block;overflow:visible"><defs>'
            + '<linearGradient id="siShine' + i + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#ffffff" stop-opacity="0.75"/><stop offset="0.4" stop-color="#ffffff" stop-opacity="0"/></linearGradient>'
            + '<linearGradient id="siL' + i + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="' + L[1] + '"/><stop offset="0.55" stop-color="' + L[2] + '"/><stop offset="1" stop-color="' + L[3] + '"/></linearGradient></defs>'
            + '<text x="' + cx + '" y="108" ' + F + ' fill="#1e0640" stroke="#1e0640" stroke-width="16" stroke-linejoin="round" opacity="0.4" transform="translate(0 6)">' + L[0] + '</text>'
            + '<text x="' + cx + '" y="108" ' + F + ' fill="#3d1268" stroke="#3d1268" stroke-width="16" stroke-linejoin="round">' + L[0] + '</text>'
            + '<text x="' + cx + '" y="108" ' + F + ' fill="url(#siL' + i + ')" stroke="url(#siL' + i + ')" stroke-width="5" stroke-linejoin="round">' + L[0] + '</text>'
            + '<text x="' + cx + '" y="108" ' + F + ' fill="none" stroke="#ffffff" stroke-width="1.7" stroke-dasharray="4.5 3.6" stroke-linecap="round" opacity="0.85">' + L[0] + '</text>'
            + '<text x="' + cx + '" y="108" ' + F + ' fill="url(#siShine' + i + ')">' + L[0] + '</text></svg>';
          box.appendChild(d); letters.push({ g: d }); } x += w; });
      return letters;
    }

    // ---- the end: hand the screen back to the menu ----
    let finished = false;
    function finish() { if (finished) return; finished = true; dead = true; timers.forEach(clearTimeout); cancelAnimationFrame(raf); if (ro) ro.disconnect(); cleanups.forEach(f => { try { f(); } catch (e) {} });
      stage.style.opacity = ''; stage.style.transform = ''; stage.style.transformOrigin = ''; stage.style.willChange = ''; world.style.transform = ''; world.style.transformOrigin = '';
      api.finish();   // the menu redraws its real scene underneath, then the intro layers fade away over it
      const L = [back, peekL, rainL, boxB, boxF, top, sceneB, ov]; hitBox.remove(); black.remove();
      L.forEach(e => { e.style.transition = 'opacity .7s ease'; e.style.pointerEvents = 'none'; }); requestAnimationFrame(() => L.forEach(e => { e.style.opacity = '0'; }));
      setTimeout(() => L.forEach(e => e.remove()), 800); }
    skip.onclick = e => { e.stopPropagation(); finish(); };

    // ---- the show ----
    (async () => {
      api.light(nightLight(0)); world.style.transformOrigin = '50% 64%'; world.style.transform = 'scale(1.2) translateY(3%)';
      await wait(60); black.style.opacity = '0';
      tween(4200, e => { world.style.transform = 'scale(' + (1.2 - 0.2 * e).toFixed(4) + ') translateY(' + (3 - 3 * e).toFixed(3) + '%)'; }, easeIO);
      await wait(900); if (dead) return; say('A little house is waiting for its squad…');
      await wait(2900); if (dead) return; hush();
      // 2. the box drops in and wobbles
      await wait(350); if (dead) return; placeHit(); bsh.setAttribute('opacity', 0);
      await tween(900, e => { boxT(-480 * (1 - e)); bsh.setAttribute('opacity', (0.42 * e).toFixed(2)); }, bounceOut); if (dead) return; puff(BX, BY); audio(); sweep(160, 70, 0.25, 0.12);
      await tween(240, (e, t) => { const k = Math.sin(t * Math.PI); boxT(0, 0, 1 + 0.08 * k, 1 - 0.1 * k); }); if (dead) return;
      say('Something is moving in the box… <b>Tap it!</b>', true); hitBox.style.display = ''; ringAt(BX, ftop + BH / 2, 46);
      let wob = true; const wt0 = performance.now();
      const wobble = () => { if (!wob || dead) return; const t = (performance.now() - wt0) / 1000, ph = t % 1.7, hop = ph < 0.34 ? Math.sin(ph / 0.34 * Math.PI) : 0;
        boxT(-10 * hop, Math.sin(t * 9) * 1.6 * (0.3 + hop) + (ph < 0.34 ? Math.sin(t * 34) * 2.4 : 0), 1 + 0.04 * hop, 1 - 0.05 * hop + 0.015 * Math.sin(t * 6)); flaps(0.07 * hop); raf = requestAnimationFrame(wobble); };
      raf = requestAnimationFrame(wobble);
      const nudge = setInterval(bump, 3200); timers.push(nudge);
      await new Promise(res => { hitBox.onclick = () => { audio(); res(); }; cleanups.push(res); }); if (dead) return;
      clearInterval(nudge); wob = false; cancelAnimationFrame(raf); hitBox.style.display = 'none'; ringAt(null); hush();
      // 3. it bursts open, Mittens pops out
      await tween(300, (e, t) => { const k = Math.sin(t * Math.PI * 4) * (1 - t); boxT(0, k * 5, 1 + 0.07 * Math.sin(t * Math.PI), 1 - 0.1 * Math.sin(t * Math.PI)); }); if (dead) return;
      sweep(300, 900, 0.22, 0.09); tone(NOTE.G5, 0.06, 0.5, 0.05); tone(NOTE.C6, 0.14, 0.6, 0.04);
      tween(420, e => flaps(e), backOut); burst(BX, ftop - 6, 30, ['#ff8fd0', '#ffe27a', '#8fe0ff', '#b8f0a0', '#ffffff'], 260, 1200);
      // he grows up out of the box from his feet (hidden behind its face at first) with a little jump, so nothing shows below the box
      stage.style.opacity = '1'; stage.style.transform = 'scale(0.3)'; play('surprised');
      await tween(720, (e, t) => { const j = Math.sin(Math.min(1, t * 1.3) * Math.PI) * 20; stage.style.transform = 'translateY(' + (-j).toFixed(2) + '%) scale(' + (0.3 + 0.7 * backOut(t)).toFixed(3) + ')'; }, t => t); if (dead) return;
      await wait(250); if (dead) return;
      // the box falls away (folds flat and fades)
      await tween(560, (e, t) => { boxT(0, 0, 1 + 0.18 * t, 1 - 0.9 * easeIn(t), (1 - easeIn(t)).toFixed(2)); bsh.setAttribute('opacity', r1(0.42 * (1 - t))); }); if (dead) return;
      bxb.style.display = 'none'; bxf.style.display = 'none'; stage.style.transform = ''; puff(BX, BY - 2);
      play('look'); await wait(1500); if (dead) return; play('idle');
      // 4. squish him three times: each squish lights a room
      let n = 0; const dots = () => '<span class="si-dots">' + [0, 1, 2].map(i => '<i class="' + (i < n ? 'on' : '') + '"></i>').join('') + '</span>';
      say('Squish Mittens to wake up the house!' + dots(), true); ringAt(500, 352, 58);
      const W = wrap();
      await new Promise(res => {
        if (!W) return res();
        let mine = false, flying = false;
        // the rig squeezes after a 170 ms hold; the intro starts the squeeze at once so a quick tap counts as a squish too
        const down = () => { const i = I(); if (!i || flying) return; mine = true; i.press = true; i.pressT = performance.now(); ringAt(null); sweep(300, 140, 0.18, 0.05); };
        const up = async () => { if (!mine) return; mine = false; if (flying) return; flying = true; const room = ORDER[n];
          tone(NOTE.E5 * (1 + n * 0.12), 0, 0.25, 0.03, 'triangle'); burst(500, 330, 10, ['#fff3c0', '#ffd76a', '#ffffff'], 120, 600);
          await spark([500, 335], center(room), 700); if (dead) return res();
          chime([NOTE.C5, NOTE.E5, NOTE.G5][n]); const [cx, cy] = center(room); burst(cx, cy, 16, ['#fff3c0', '#ffd76a', '#ffffff'], 130, 900);
          tween(500, (e, t) => setLit(room, e, Math.sin(t * Math.PI)));
          n++; api.light(nightLight(n));
          say((n === 1 ? 'The living room is awake! <b>Again!</b>' : n === 2 ? 'The bedroom too! <b>One more!</b>' : 'The whole house is waking up!') + dots(), true);
          // APP (2026-11-17, the user: "start the music only after we click Mittens the 3rd time"): api.awake() tells the
          // app the third squish has lit the house, and the game's music starts there (App.js holds it until then)
          if (n >= 3 && api.awake) api.awake();
          flying = false; if (n >= 3) { off(); res(); } else if (n === 1) wait(2500).then(() => { if (n === 1 && !dead) ringAt(500, 352, 58); }); };
        const cancel = () => { mine = false; };
        W.addEventListener('pointerdown', down); W.addEventListener('pointerup', up); W.addEventListener('pointercancel', cancel);
        const off = () => { W.removeEventListener('pointerdown', down); W.removeEventListener('pointerup', up); W.removeEventListener('pointercancel', cancel); };
        cleanups.push(() => { off(); res(); });
      }); if (dead) return;
      ringAt(null); await wait(700); if (dead) return;
      // 5. the whole house glows, then dawn: a morning in today's weather (WEATHER: was always "the rain stops, a sunny
      // morning"), the squad peeks out
      REST.forEach((room, i) => { const t = setTimeout(() => { if (dead) return; chime([NOTE.C6, NOTE.E6, NOTE.G6][i] / 2); tween(450, (e, t) => setLit(room, e, Math.sin(t * Math.PI))); }, i * 280); timers.push(t); });
      const dl = scene.querySelector('.mm-doorlight'); if (dl) tween(900, e => dl.setAttribute('opacity', (0.95 * e).toFixed(2)));
      await wait(1200); if (dead) return; hush();
      chime(NOTE.C5, 0); chime(NOTE.G5, 0.14); chime(NOTE.C6, 0.28); chime(NOTE.E6, 0.42);
      sceneB.innerHTML = api.sceneSvg({ level: 1, season: WX }); noSigns(sceneB);
      const sunny = api.lightFor(Sc.state({ level: 1, season: WX }));   // (the morning's light, in today's weather)
      play('dance');
      [night, moon, dawn].forEach(e => { e.style.opacity = e.getAttribute('opacity'); e.style.willChange = 'opacity'; });
      await tween(2800, (e, t) => {
        night.style.opacity = (0.8 * (1 - e)).toFixed(3); moon.style.opacity = (0.6 * (1 - Math.min(1, t * 2))).toFixed(3);
        dawn.style.opacity = (0.6 * Math.sin(Math.min(1, t * 1.1) * Math.PI)).toFixed(3);   // (WEATHER: the rain or snow no longer fades out here: it's the morning's too)
        sceneB.style.opacity = clamp((t - 0.2) / 0.6, 0, 1).toFixed(3);
        const day = clamp((t - 0.45) / 0.5, 0, 1); Object.keys(WIN).forEach(r => setLit(r, 1 - 0.7 * day, 0, true));
        if (Math.floor(t * 12) !== Math.floor((t - 0.02) * 12)) api.light(t < 0.55 ? nightLight(3) : sunny);
      }, t => t); if (dead) return;
      api.light(sunny);
      // (WEATHER: the rain or snow keeps falling to the end, into the menu's own: the intro's layers go when it ends)
      [night, moon, dawn].forEach(e => { e.style.display = 'none'; });
      // the squad peeks out of the windows and waves
      const peeks = PEEK.map(([key, room, wi, pcx], i) => { const w = WIN[room][wi], [x, y, ww, hh] = box(w), id = 'siPk' + i, sz = Math.min(ww * 1.1, hh * 1.3), cx = pcx || x + ww / 2;
        peekG.insertAdjacentHTML('beforeend', '<clipPath id="' + id + '">' + shape(w, '') + '</clipPath><g clip-path="url(#' + id + ')"><image href="export/thumbs/c-' + key + '.webp" x="' + r1(cx - sz / 2) + '" y="' + r1(y + hh) + '" width="' + r1(sz) + '" height="' + r1(sz) + '"/></g>');
        return { el: peekG.lastChild.querySelector('image'), y0: y + hh, y1: y + hh - sz * 0.8, cx, base: y + hh + sz * 0.3, i }; });
      const order = peeks.map((p, i) => i).sort(() => Math.random() - 0.5), pk0 = performance.now(); let waving = true;
      const peekStep = () => { if (!waving || dead) return; const now = performance.now();
        peeks.forEach(p => { const d = order.indexOf(p.i) * 150, t = clamp((now - pk0 - d) / 700, 0, 1), y = p.y0 + (p.y1 - p.y0) * backOut(t), wv = t >= 1 ? Math.sin((now - pk0 - d) / 240) * 8 * Math.min(1, (now - pk0 - d - 700) / 400) : 0;
          p.el.setAttribute('y', r1(y + (t >= 1 ? Math.abs(Math.sin((now - pk0 - d) / 480)) * -1.5 : 0))); p.el.setAttribute('transform', 'rotate(' + r1(wv) + ' ' + r1(p.cx) + ' ' + r1(p.base) + ')'); });
        raf = requestAnimationFrame(peekStep); };
      raf = requestAnimationFrame(peekStep); cleanups.push(() => { waving = false; });
      PEEK.forEach((p, i) => { const t = setTimeout(() => !dead && tone(880 + order.indexOf(i) * 90, 0, 0.14, 0.025, 'triangle'), 150 * order.indexOf(i) + 200); timers.push(t); });
      await wait(1100); if (dead) return;
      // 6. the plush logo drops in, letter by letter
      try { await Promise.race([document.fonts.load('700 86px Fredoka'), wait(800)]); } catch (e) {} if (dead) return;
      const letters = logoSvg(); letters.forEach(L => { L.g.style.transform = 'translateY(-190px)'; });
      const lt0 = performance.now(); let bob = true;
      const logoStep = () => { if (!bob || dead) return; const now = performance.now();
        letters.forEach((L, j) => { const t = clamp((now - lt0 - j * 80) / 720, 0, 1), y = -190 * (1 - bounceOut(t)), land = t > 0.36 && t < 0.62 ? Math.sin((t - 0.36) / 0.26 * Math.PI) : 0, idle = t >= 1 ? Math.sin((now - lt0) / 380 + j * 0.7) * 2.2 : 0;
          L.g.style.transform = 'translateY(' + (y + idle).toFixed(2) + 'px) scale(' + (1 + 0.16 * land).toFixed(3) + ',' + (1 - 0.2 * land).toFixed(3) + ') rotate(' + (t >= 1 ? Math.sin((now - lt0) / 520 + j) * 2 : 0).toFixed(2) + 'deg)';
          if (t > 0.36 && !L.thud) { L.thud = 1; tone(240 + j * 22, 0, 0.16, 0.045, 'triangle'); } });
        raf = requestAnimationFrame(logoStep); };
      raf = requestAnimationFrame(logoStep); cleanups.push(() => { bob = false; });
      await wait(80 * letters.length + 1000); if (dead) return;
      const tap = document.createElement('div'); tap.className = 'si-tap'; tap.innerHTML = '<span>TAP TO START</span>'; ov.appendChild(tap); requestAnimationFrame(() => tap.classList.add('on'));
      skip.style.display = 'none';
      const go = e => { if (e) e.stopPropagation(); chime(NOTE.G5, 0); finish(); };
      ov.style.pointerEvents = 'auto'; ov.style.cursor = 'pointer'; ov.onclick = go;
    })();
    return { finish };
  }

  window.SquadIntro = { v: 3, run };
})();
