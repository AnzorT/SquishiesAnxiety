// Page opens and loaders, from the tap (PERF 2026-11-20, the user: "the loading screens: I only hear the audio and when
// I see them they are half way done"). The same weak-phone stand-in as webview-bench.mjs (Chromium with SwiftShader, the
// CPU slowed 4x from just before the tap, the Galaxy A16's landscape WebView: 796 x 384 CSS px at DPR 2.8125).
//
// For each scene it taps the menu's button and records, from the tap:
//   - every composited frame (CDP screencast: what the screen showed, with its time), saved as JPEGs and tiled into one
//     contact sheet per scene (OUT/<scene>-sheet.jpg, the time from the tap under each frame)
//   - every main-thread frame (rAF) with what the loader was doing then (a probe per scene: is it there, its opacity,
//     how far its animation is), so "first visible frame" and "how far the animation was when first seen" can be read
//   - long frames (> 50 ms) and the frame rate over the open and after it
//
//   node webgame/build.mjs --out <dir>
//   NODE_PATH=<node_modules with playwright + ffmpeg-static> GAME=<dir> node tools/perf/open-bench.mjs [scene ...]
//
// scenes: chars level house park back (back: into the house, out again, the menu's frame rate before and after)
// env: GAME (build dir), VIEW=796x384, THROTTLE=4, SECS (recording per scene), OUT (where the frames go), SHEET=0 (no
//      contact sheet), RUNS=n (repeat each scene n times and print each)
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { execFileSync } from 'node:child_process';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
let ffmpeg = null; try { ffmpeg = require('ffmpeg-static'); } catch (e) { /* no sheets */ }
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const GAME = process.env.GAME ? path.resolve(process.env.GAME, 'App.dc.html') : path.join(REPO, 'webgame/test/out/webgame/App.dc.html');
const VIEW = (([w, h]) => ({ width: +w, height: +h }))((process.env.VIEW || '796x384').split('x'));
const THROTTLE = +(process.env.THROTTLE || 4), RUNS = +(process.env.RUNS || 1);
const OUT = path.resolve(process.env.OUT || path.join(REPO, 'webgame/test/out/open-bench'));
fs.mkdirSync(OUT, { recursive: true });
const scenes = process.argv.slice(2).length ? process.argv.slice(2) : ['chars', 'level', 'house'];
const INIT = { screen: 'menu', state: { level: 12, coins: 31342, gems: 975, owned: ['mittens', 'frybo', 'dunkie', 'bao', 'nimbo', 'biscuit', 'bean', 'zippy'], sel: 'frybo', hiddenKeys: [],
  games: [{ id: 'squishdoku', name: 'Squishdoku', best: 'Level 20 / 600', color: '#3fc4ec' }, { id: 'sort', name: 'Squish Sort', best: 'Fridge 9', color: '#ff9a3c' }, { id: 'stack', name: 'Squish Stack', best: 'Level 6 / 50', color: '#9b6bff' }, { id: 'hop', name: 'Squish Hop', best: 'Level 7 / 100', color: '#2fc6a8' }],
  xp: { level: 12, into: 280, need: 1300, per: 100 }, road: Array.from({ length: 30 }, (_, i) => ({ lv: i + 1, k: i % 3 ? 'coins' : 'gems', n: 100 + i * 20, got: i < 9, claimable: i >= 9 && i < 11 })) }, config: {} };

// what each scene taps, what its loader is, and what to read off it every frame
const SCENES = {
  chars: { tap: '.mm-tab[data-tab="creatures"]', secs: 7,
    probe: `(() => { const g = document.querySelector('.sq-gs'), p = document.querySelector('.mm-page2');
      const op = e => e ? +getComputedStyle(e).opacity : 0;
      // dealt: cards out of the deck (seen: opacity), up: cards turned over (the class of the old timeline, or the flip's
      // own animation past half way)
      const cw = g ? [...g.querySelectorAll('.cw')] : [];
      const up = c => c.classList.contains('up') || (() => { const f = c.querySelector('.fl'), a = f && f.getAnimations && f.getAnimations()[0]; return !!(a && a.effect && a.effect.getComputedTiming().progress > 0.5) || (a && a.playState === 'finished'); })();
      return { on: !!g, vis: g ? +(op(p) * op(g)).toFixed(2) : (p ? -1 : 0), dealt: cw.filter(c => op(c) > 0.5).length, up: cw.filter(up).length }; })()` },
  level: { tap: '.sq-crest', secs: 4,
    probe: `(() => { const p = document.querySelector('.mm-page2'); return { on: !!p, vis: p ? +(+getComputedStyle(p).opacity).toFixed(2) : 0 }; })()` },
  park: { tap: '.mm-play', secs: 6,
    probe: `(() => { const p = document.querySelector('.sq-pk'); return { on: !!p, vis: p ? (p.classList.contains('in') ? 1 : 0.5) : 0 }; })()` },
  house: { tap: '.mm-tab[data-tab="house"]', secs: 16,
    probe: `(() => { const u = document.querySelector('.sq-hh-ui'), n = document.querySelector('.sq-hh-night .sky, .sq-hh-night .skyl'), h = document.querySelector('.mm-house');
      const op = e => e ? +getComputedStyle(e).opacity : 0;
      // lit: windows on (the old SVG halos' opacity attribute, or the new halo layers' opacity)
      const lit = [...document.querySelectorAll('.sq-hh-night [data-g]')].filter(e => +e.getAttribute('opacity') > 0.5).length + [...document.querySelectorAll('.sq-hh-night .gl')].filter(e => op(e) > 0.5).length;
      return { on: !!u, vis: u ? +op(u).toFixed(2) : 0, night: n ? +op(n).toFixed(2) : 0, lit, house: h ? +op(h).toFixed(2) : -1 }; })()` },
};

const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--use-gl=swiftshader', '--enable-gpu-rasterization', '--ignore-gpu-blocklist'] });

// the frame recorder: put in before the page's scripts, so it holds the browser's own requestAnimationFrame
const RECORDER = () => {
  const raf = window.requestAnimationFrame.bind(window), now = performance.now.bind(performance);
  const R = window.__rec = { on: false, frames: [], probe: null, t0: 0 };
  R.start = probe => { R.frames = []; R.probe = probe ? new Function('return ' + probe) : null; R.on = true; const f = () => { if (!R.on) return; let p = null; try { p = R.probe && R.probe(); } catch (e) { p = { err: String(e) }; } R.frames.push([performance.timeOrigin + now(), p]); raf(f); }; raf(f); };
  R.stop = () => { R.on = false; return R.frames; };
  R.wall = () => performance.timeOrigin + now();
};

// who keeps scheduling frames and timers (back scene: what the house leaves running): each callback counted by the
// first page script on the stack where it was scheduled
const TALLY = () => {
  const T = window.__tally = { on: false, n: {} };
  const where = () => { const st = (new Error().stack || '').split('\n').slice(3); const l = st.find(x => /\.(js|html)/.test(x) && !/__tally|addInitScript/.test(x)) || '?'; const m = l.match(/([^/\\]+\.(?:js|html))(?:\?[^:]*)?:(\d+)/); return m ? m[1] + ':' + m[2] : l.trim().slice(0, 60); };
  const wrap = (name, fn) => function (cb, ...a) { if (typeof cb !== 'function') return fn.call(this, cb, ...a); const w = T.on ? where() : null; return fn.call(this, function () { if (T.on && w) { const k = name + ' ' + w; T.n[k] = (T.n[k] || 0) + 1; } return cb.apply(this, arguments); }, ...a); };
  window.requestAnimationFrame = wrap('raf', window.requestAnimationFrame);
  window.setTimeout = wrap('timeout', window.setTimeout);
  window.setInterval = wrap('interval', window.setInterval);
};

async function openMenu() {
  const ctx = await browser.newContext({ viewport: VIEW, deviceScaleFactor: 2.8125, hasTouch: true });
  const page = await ctx.newPage();
  page.on('pageerror', e => console.log('  pageerror', e.message.slice(0, 160)));
  await page.addInitScript(([init]) => { window.__SQUISH_INIT__ = init; window.ReactNativeWebView = { postMessage() {} }; try { localStorage.setItem('squishsquad.menu.v1', JSON.stringify({ season: 'sunny' })); } catch (e) {} }, [INIT]);
  await page.addInitScript(RECORDER);
  if (process.env.TALLY) await page.addInitScript(TALLY);
  await page.goto(pathToFileURL(GAME).href);
  await page.waitForFunction(() => document.querySelector('.mm-tab'), null, { timeout: 120000 });
  await page.waitForTimeout(5000);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Performance.enable');
  return { ctx, page, cdp };
}

const metrics = async cdp => Object.fromEntries((await cdp.send('Performance.getMetrics')).metrics.map(m => [m.name, m.value]));

// records `secs` from the tap; returns { tap, frames (rAF), shots (screencast) }
async function record(page, cdp, sc, name, secs, tapSel) {
  const shots = [];
  const onFrame = async ev => { shots.push({ t: ev.metadata.timestamp * 1000, data: ev.data }); try { await cdp.send('Page.screencastFrameAck', { sessionId: ev.sessionId }); } catch (e) { /* closed */ } };
  cdp.on('Page.screencastFrame', onFrame);
  await cdp.send('Page.startScreencast', { format: 'jpeg', quality: 45, maxWidth: 398, maxHeight: 192, everyNthFrame: 1 });
  await page.waitForTimeout(400);
  await cdp.send('Emulation.setCPUThrottlingRate', { rate: THROTTLE });
  const m0 = await metrics(cdp);
  await page.evaluate(p => window.__rec.start(p), sc.probe);
  await page.waitForTimeout(300);
  const tap = await page.evaluate(sel => { const el = document.querySelector(sel); const t = window.__rec.wall(); if (el) el.click(); return el ? t : -1; }, tapSel);
  await page.waitForTimeout(secs * 1000);
  const frames = await page.evaluate(() => window.__rec.stop());
  const m1 = await metrics(cdp);
  await cdp.send('Emulation.setCPUThrottlingRate', { rate: 1 });
  await cdp.send('Page.stopScreencast');
  cdp.off('Page.screencastFrame', onFrame);
  const d = k => ((m1[k] || 0) - (m0[k] || 0)) * 1000;
  return { tap, frames, shots, cost: { task: d('TaskDuration'), style: d('RecalcStyleDuration'), layout: d('LayoutDuration'), script: d('ScriptDuration') } };
}

function stats(times) {
  const gaps = times.slice(1).map((x, i) => x - times[i]);
  if (!gaps.length) return { fps: 0, p95: 0, long: 0, worst: 0 };
  const fps = gaps.length / ((times[times.length - 1] - times[0]) / 1000);
  const s = gaps.slice().sort((a, b) => a - b);
  return { fps, p95: s[Math.floor(s.length * 0.95)], long: gaps.filter(g => g > 50).length, worst: s[s.length - 1] };
}

// every composited frame from just before the tap as a 32 x 16 grey thumbnail (one ffmpeg run), to see when the screen
// first changed after the tap without trusting the page's own clock
function thumbs(name, shots, tap) {
  if (!ffmpeg) return null;
  const dir = path.join(OUT, name + '-all'); fs.rmSync(dir, { recursive: true, force: true }); fs.mkdirSync(dir, { recursive: true });
  const list = shots.filter(s => s.t - tap > -300);
  list.forEach((s, i) => fs.writeFileSync(path.join(dir, String(i).padStart(4, '0') + '.jpg'), Buffer.from(s.data, 'base64')));
  const raw = path.join(dir, 'thumbs.raw');
  try { execFileSync(ffmpeg, ['-y', '-loglevel', 'error', '-framerate', '30', '-i', path.join(dir, '%04d.jpg'), '-vf', 'scale=32:16,format=gray', '-f', 'rawvideo', raw], { stdio: 'ignore' }); } catch (e) { return null; }
  const buf = fs.readFileSync(raw), N = 32 * 16;
  return list.map((s, i) => ({ t: s.t - tap, px: buf.subarray(i * N, (i + 1) * N) }));
}
const diff = (a, b) => { let d = 0; for (let i = 0; i < a.length; i++) d += Math.abs(a[i] - b[i]); return d / a.length; };

function sheet(name, shots, tap) {
  if (!ffmpeg || process.env.SHEET === '0' || !shots.length) return null;
  const dir = path.join(OUT, name); fs.rmSync(dir, { recursive: true, force: true }); fs.mkdirSync(dir, { recursive: true });
  // from the tap: one frame each 50 ms for 2.4 s, then one each 300 ms
  const keep = []; let lastT = -1e9;
  for (const s of shots) { const t = s.t - tap; if (t < -60) continue; if ((t < 2400 && t - lastT >= 50) || t - lastT >= 300) { keep.push(s); lastT = t; } }
  const pick = keep.slice(0, 64);
  pick.forEach((s, i) => fs.writeFileSync(path.join(dir, String(i).padStart(3, '0') + '.jpg'), Buffer.from(s.data, 'base64')));
  const labels = pick.map(s => Math.round(s.t - tap));
  // label each frame with its time (drawtext needs a font file: Windows Arial)
  const font = 'C\\:/Windows/Fonts/arial.ttf';
  pick.forEach((s, i) => {
    const f = path.join(dir, String(i).padStart(3, '0') + '.jpg');
    try { execFileSync(ffmpeg, ['-y', '-loglevel', 'error', '-i', f, '-vf', `drawtext=fontfile='${font}':text='${labels[i]} ms':x=4:y=4:fontsize=20:fontcolor=yellow:box=1:boxcolor=black@0.6`, f + '.l.jpg'], { stdio: 'ignore' }); fs.renameSync(f + '.l.jpg', f); } catch (e) { /* no label */ }
  });
  const out = path.join(OUT, name + '-sheet.jpg');
  try { execFileSync(ffmpeg, ['-y', '-loglevel', 'error', '-framerate', '1', '-i', path.join(dir, '%03d.jpg'), '-vf', 'tile=8x8:padding=2', '-frames:v', '1', out], { stdio: 'ignore' }); } catch (e) { return null; }
  return out;
}

function report(name, r, sc) {
  const { tap, frames, shots } = r;
  if (tap < 0) { console.log(name, ': nothing to tap'); return; }
  const after = frames.filter(f => f[0] >= tap);
  const firstOn = after.find(f => f[1] && f[1].on && f[1].vis > 0.05);
  const firstFull = after.find(f => f[1] && f[1].on && f[1].vis > 0.95);
  const firstShotAfter = t => shots.find(s => s.t >= t);
  const sOn = firstOn && firstShotAfter(firstOn[0]);
  const rafT = after.map(f => f[0]);
  const all = stats(rafT), first2 = stats(rafT.filter(t => t - tap < 2000)), tail = stats(rafT.filter(t => t - tap > (sc.secs - 2.5) * 1000));
  const shotT = shots.filter(s => s.t >= tap).map(s => s.t);
  const sAll = stats(shotT);
  const f = v => v == null ? '  -  ' : String(Math.round(v)).padStart(5);
  console.log(`${name.padEnd(10)} loader on screen ${f(firstOn && firstOn[0] - tap)} ms (rAF), ${f(sOn && sOn.t - tap)} ms (composited) | fully in ${f(firstFull && firstFull[0] - tap)} ms | state when first seen: ${JSON.stringify(firstOn && firstOn[1])}`);
  console.log(`${''.padEnd(10)} main frames: first 2 s ${first2.fps.toFixed(1)} fps, worst ${f(first2.worst)} ms, ${first2.long} > 50 ms | whole ${all.fps.toFixed(1)} fps p95 ${f(all.p95)} ms, ${all.long} long | last 2.5 s ${tail.fps.toFixed(1)} fps p95 ${f(tail.p95)} | composited ${sAll.fps.toFixed(1)} fps, worst ${f(sAll.worst)} ms`);
  console.log(`${''.padEnd(10)} main thread over ${sc.secs} s: task ${Math.round(r.cost.task)} ms, script ${Math.round(r.cost.script)}, style ${Math.round(r.cost.style)}, layout ${Math.round(r.cost.layout)}`);
  // the first 1.5 s, frame by frame
  // FROMON=1: the 1.5 s from the loader's first frame in the page (on), not from the tap (Heading home comes after a walk)
  const on0 = process.env.FROMON ? after.find(f2 => f2[1] && f2[1].on) : null, a0 = on0 ? on0[0] : tap;
  if (on0) { const s0 = shots.find(sh => sh.t >= a0); console.log(`${''.padEnd(10)} loader in the page at ${Math.round(a0 - tap)} ms, first composited frame after it +${s0 ? Math.round(s0.t - a0) : '?'} ms`); }
  const lines = after.filter(f => f[0] >= a0 && f[0] - a0 < 1500).map((f2, i, a) => `${String(Math.round(f2[0] - a0)).padStart(5)}${i ? ' (+' + Math.round(f2[0] - a[i - 1][0]) + ')' : ''} ${JSON.stringify(f2[1])}`);
  if (process.env.VERBOSE) console.log(lines.join('\n'));
  const th = thumbs(name, shots, tap);
  if (th && th.length) {
    const base = th.filter(x => x.t < 0).pop() || th[0];
    const ch = th.find(x => x.t >= 0 && diff(x.px, base.px) > 6);
    const atCh = ch && frames.filter(f2 => f2[0] - tap <= ch.t + 20).pop();
    console.log(`${''.padEnd(10)} screen first changed ${f(ch && ch.t)} ms after the tap (composited); the loader then: ${JSON.stringify(atCh && atCh[1])}`);
  }
  const sh = sheet(name, shots, tap);
  if (sh) console.log(`${''.padEnd(10)} frames: ${sh}`);
}

for (const name of scenes) {
  for (let run = 0; run < RUNS; run++) {
    const { ctx, page, cdp } = await openMenu();
    try {
      if (name === 'back') {
        // the menu before the house, the house, back out, the menu after
        const sc = { probe: null, secs: 4 };
        let r = await record(page, cdp, sc, 'menu-before', 4, '#none');
        const before = stats(r.frames.map(f => f[0]));
        await page.click('.mm-tab[data-tab="house"]', { force: true });
        await page.waitForFunction(() => { const h = document.querySelector('.mm-house'); return h && +getComputedStyle(h).opacity > 0.99; }, null, { timeout: 180000 });
        await page.waitForTimeout(4000);
        r = await record(page, cdp, sc, 'house', 4, '#none');
        const inHouse = stats(r.frames.map(f => f[0]));
        await page.click('.mm-hback', { force: true });
        await page.waitForTimeout(4000);
        if (process.env.TALLY) await page.evaluate(() => { window.__tally.n = {}; window.__tally.on = true; });
        r = await record(page, cdp, sc, 'menu-after', 4, '#none');
        if (process.env.TALLY) console.log(await page.evaluate(() => { window.__tally.on = false; return Object.entries(window.__tally.n).sort((a, b) => b[1] - a[1]).slice(0, 25).map(([k, v]) => String(v).padStart(6) + '  ' + k).join('\n'); }));
        const after = stats(r.frames.map(f => f[0]));
        const leftover = await page.evaluate(() => ({ house: !!document.querySelector('.mm-house'), sh: !!(window.__sh && !window.__sh.dead), rigs: window.RiveRig && window.RiveRig._count ? window.RiveRig._count() : null, svgs: document.querySelectorAll('svg').length, anims: document.getAnimations().length, nodes: document.getElementsByTagName('*').length }));
        console.log(`back       menu before ${before.fps.toFixed(1)} fps p95 ${Math.round(before.p95)} | in the house ${inHouse.fps.toFixed(1)} fps p95 ${Math.round(inHouse.p95)}, ${inHouse.long} long | menu after ${after.fps.toFixed(1)} fps p95 ${Math.round(after.p95)}, ${after.long} long | left: ${JSON.stringify(leftover)}`);
        continue;
      }
      const sc = SCENES[name]; if (!sc) { console.log('no scene', name); continue; }
      const r = await record(page, cdp, sc, name, +(process.env.SECS || sc.secs), sc.tap);
      report(name + (RUNS > 1 ? '#' + run : ''), r, sc);
    } finally { await ctx.close(); }
  }
}
await browser.close();
