// A weak-phone stand-in for the app's WebView pages (PERFORMANCE.md, 2026-11-14): Chromium with software rendering
// (SwiftShader), the CPU slowed 4x, at the Galaxy A15's landscape size (832 x 384 CSS px, DPR 2.8125). Reports the
// frame rate (rAF), the 95th-percentile frame and where the main thread went over a few seconds of each scene.
//
//   node webgame/build.mjs --out webgame/test/out/webgame      (the menu pages, as the webgame tests use them)
//   node tools/chest/build.mjs                                   (the chest smash, android/app/src/main/assets/chest)
//   NODE_PATH=<a node_modules with playwright> node tools/perf/webview-bench.mjs [scene ...]
//
// scenes: menu-rainy menu-sunny menu-snowy park house chest-idle chest-tap (default: all but house)
// env: LITE=1 (chest: start in its lite mode)  THROTTLE=4 (CPU slowdown)  SECS=4 (seconds measured)  EARLY=1 (throttle from page load, so the pages' own
//      frame-rate guards see a slow phone and step down, as they would on one)  CDPR=<n> (chest: fake devicePixelRatio)
//      TWEAK=smil,css,rig,scene,hud (menu: switch a part off to see what it costs)  ANIMS=1 (list running animations)
//      SETTLE=<s> (menu: wait this much longer first, e.g. 8 with EARLY=1 so the frame-rate guard, which starts 4 s after load, has stepped)
// Numbers are for comparing before / after on this machine, not a phone's fps: check a phone with a release build.
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const GAME = process.env.GAME ? path.resolve(process.env.GAME, 'App.dc.html') : path.join(REPO, 'webgame/test/out/webgame/App.dc.html');   // GAME=<a build dir> (PERF 2026-11-20)
const CHEST = path.join(REPO, 'android/app/src/main/assets/chest/host.html');
const THROTTLE = +(process.env.THROTTLE || 4), SECS = +(process.env.SECS || 4);
const scenes = process.argv.slice(2).length ? process.argv.slice(2) : ['menu-rainy', 'menu-sunny', 'menu-snowy', 'park', 'chest-idle', 'chest-tap'];
const INIT = { screen: 'menu', state: { level: 6, coins: 31342, gems: 975, owned: ['mittens', 'frybo', 'dunkie', 'bao', 'nimbo'], sel: 'frybo', hiddenKeys: [],
  games: [{ id: 'squishdoku', name: 'Squishdoku', best: 'Level 20 / 600', color: '#3fc4ec' }, { id: 'sort', name: 'Squish Sort', best: 'Fridge 9', color: '#ff9a3c' }, { id: 'stack', name: 'Squish Stack', best: 'Level 6 / 50', color: '#9b6bff' }, { id: 'hop', name: 'Squish Hop', best: 'Level 7 / 100', color: '#2fc6a8' }],
  xp: { level: 6, into: 28, need: 700, per: 100 }, road: [] }, config: {} };
const REWARD = { name: 'Bubbly', rar: 3, rarLabel: 'LEGENDARY', rarBg: '#ffdcb0', rarInk: '#d9772f', concept: '', img: '', isNew: true, copies: 0, need: 0, coins: 90, dupeCoins: 0, setBonus: 0, luck: false };

// VIEW=<w>x<h>: the CSS viewport (default 796x384, the Galaxy A16's landscape WebView; the A15 was 832x384) (PERF 2026-11-20)
const VIEW = (([w, h]) => ({ width: +w, height: +h }))((process.env.VIEW || '796x384').split('x'));
const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--use-gl=swiftshader', '--enable-gpu-rasterization', '--ignore-gpu-blocklist'] });

async function measure(page, label, during) {
  const cdp = await page.context().newCDPSession(page);
  await cdp.send('Performance.enable');
  await cdp.send('Emulation.setCPUThrottlingRate', { rate: THROTTLE });
  await page.waitForTimeout(800);
  const metrics = async () => Object.fromEntries((await cdp.send('Performance.getMetrics')).metrics.map(m => [m.name, m.value]));
  const m0 = await metrics();
  const frames = page.evaluate(secs => new Promise(res => { const t = []; const f = now => { t.push(now); if (now - t[0] < secs * 1000) requestAnimationFrame(f); else res(t); }; requestAnimationFrame(f); }), SECS);
  if (during) await during(page);
  const t = await frames;
  const m1 = await metrics();
  await cdp.send('Emulation.setCPUThrottlingRate', { rate: 1 });
  const gaps = t.slice(1).map((x, i) => x - t[i]);
  const fps = (t.length - 1) / ((t[t.length - 1] - t[0]) / 1000);
  const p95 = gaps.slice().sort((a, b) => a - b)[Math.floor(gaps.length * 0.95)] || 0;
  const d = k => ((m1[k] || 0) - (m0[k] || 0)) * 1000 / SECS;
  console.log(`${label.padEnd(12)} fps ${fps.toFixed(1).padStart(5)}  p95 frame ${p95.toFixed(0).padStart(4)} ms  | per s: task ${d('TaskDuration').toFixed(0).padStart(4)} ms, style ${d('RecalcStyleDuration').toFixed(0).padStart(3)}, layout ${d('LayoutDuration').toFixed(0).padStart(3)}, script ${d('ScriptDuration').toFixed(0).padStart(3)} ms`);
}

async function throttleEarly(page) {
  if (!process.env.EARLY) return;
  const c0 = await page.context().newCDPSession(page);
  await c0.send('Emulation.setCPUThrottlingRate', { rate: THROTTLE });
}

for (const sc of scenes) {
  const ctx = await browser.newContext({ viewport: VIEW, deviceScaleFactor: 2.8125, hasTouch: true });
  const page = await ctx.newPage();
  page.on('pageerror', e => console.log('  pageerror', e.message.slice(0, 120)));
  if (sc.startsWith('chest')) {
    await page.addInitScript(d => { window.ReactNativeWebView = { postMessage() {} }; if (d) Object.defineProperty(window, 'devicePixelRatio', { get: () => +d }); }, process.env.CDPR || '');
    await throttleEarly(page);
    await page.goto(pathToFileURL(CHEST).href);
    await page.waitForTimeout(1500);
    if (process.env.LITE) await page.evaluate(() => { chestPerf.lite = true; chestPerf.setCap(1); });
    await page.evaluate(reward => chestHost.start({ sound: false, insetTop: 0, insetBottom: 0, group: 'sky', size: 'legendary', final: 'legendary', reward }), REWARD);
    await page.waitForTimeout(2000);
    // chest-tap: nine taps on the chest while measuring (the smash, its bursts and particles)
    await measure(page, sc, sc === 'chest-tap' ? async p => { for (let i = 0; i < 9; i++) { await p.mouse.click(416, 220); await p.waitForTimeout(380); } } : null);
    console.log('             ' + await page.evaluate(() => { const c = window.chestPerf; return c ? `chestPerf: lite ${c.lite}, canvas DPR ${c.cap()} (phone ${c.real})` : 'no chestPerf'; }));
  } else {
    const season = sc.startsWith('menu-') ? sc.slice(5) : 'rainy';
    await page.addInitScript(([init, season]) => { window.__SQUISH_INIT__ = init; window.ReactNativeWebView = { postMessage() {} }; try { localStorage.setItem('squishsquad.menu.v1', JSON.stringify({ season })); } catch (e) {} }, [INIT, season]);
    await throttleEarly(page);
    await page.goto(pathToFileURL(GAME).href);
    await page.waitForFunction(() => document.querySelector('.mm-tab'), null, { timeout: 90000 });
    await page.waitForTimeout(3000);
    if (sc === 'park') { await page.click('.mm-play', { force: true }); await page.waitForFunction(() => document.querySelector('.sq-pk.in'), null, { timeout: 60000 }); await page.waitForTimeout(2500); }
    if (sc === 'house') { await page.click('.mm-tab[data-tab="house"]', { force: true }); await page.waitForFunction(() => document.querySelector('.mm-hback'), null, { timeout: 180000 }); await page.waitForTimeout(6000); }
    if (process.env.TWEAK) await page.evaluate(t => {
      if (t.includes('smil')) document.querySelectorAll('svg').forEach(s => s.pauseAnimations && s.pauseAnimations());
      if (t.includes('css')) document.getAnimations().forEach(a => a.pause());
      if (t.includes('rig')) document.querySelectorAll('.mm-stage').forEach(s => { s.style.display = 'none'; });
      if (t.includes('scene')) document.querySelectorAll('.mm-scene, .sq-parkL').forEach(s => { s.style.display = 'none'; });
      if (t.includes('hud')) document.querySelectorAll('.mm-hud').forEach(s => { s.style.display = 'none'; });
      // (PERF 2026-11-20) the scene drawn as one picture instead of live SVG
      if (t.includes('img')) document.querySelectorAll('.mm-scene').forEach(s => { const sv = s.querySelector('svg'); if (!sv) return; const u = URL.createObjectURL(new Blob([sv.outerHTML], { type: 'image/svg+xml' })); s.innerHTML = '<img src="' + u + '" style="position:absolute;inset:0;width:100%;height:100%;display:block">'; });
    }, process.env.TWEAK);
    if (process.env.ANIMS) console.log(await page.evaluate(() => {
      const c = {};
      document.getAnimations().forEach(a => {
        const t = a.effect && a.effect.target;
        const cls = t ? (typeof t.className === 'string' ? t.className : (t.className && t.className.baseVal) || '') : '';
        const k = (a.animationName || a.constructor.name) + ' @ ' + (t ? (t.tagName + '.' + cls).slice(0, 60) : '?');
        c[k] = (c[k] || 0) + 1;
      });
      return Object.entries(c).sort((a, b) => b[1] - a[1]).slice(0, 25).map(([k, v]) => v + '  ' + k).join('\n');
    }));
    if (process.env.SETTLE) await page.waitForTimeout(+process.env.SETTLE * 1000);
    await measure(page, sc + (process.env.TWEAK ? ' -' + process.env.TWEAK : ''));
    console.log('  SquishPerf step', await page.evaluate(() => window.SquishPerf && SquishPerf.step), '(1: creatures every frame, 2: every other, 3: every third)');
  }
  await ctx.close();
}
await browser.close();
