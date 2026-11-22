// The page asleep under the app's own screens (PERF 2026-11-20, SquishApp.receive({ type: 'sleep', on })): what it
// costs while asleep, and that it carries on exactly where it was on wake. The same weak-phone stand-in as the other
// benches (Chromium + SwiftShader, CPU x4 while measuring, 796 x 384 at DPR 2.8125).
//   NODE_PATH=<node_modules with playwright> GAME=<build dir> node tools/perf/sleep-bench.mjs [menu|house|park]
// Prints the main thread's work and the frames drawn per second awake / asleep / awake again, which animations were
// running while asleep, the page clock across the sleep (it must not jump), a timer set before the sleep (it must fire
// on wake after the time it had left), and the first frame back.
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const GAME = process.env.GAME ? path.resolve(process.env.GAME, 'App.dc.html') : path.join(REPO, 'webgame/test/out/webgame/App.dc.html');
const VIEW = (([w, h]) => ({ width: +w, height: +h }))((process.env.VIEW || '796x384').split('x'));
const scene = process.argv[2] || 'menu';
const INIT = { screen: 'menu', state: { level: 12, coins: 31342, gems: 975, owned: ['mittens', 'frybo', 'dunkie', 'bao'], sel: 'frybo', hiddenKeys: [], games: [], xp: { level: 12, into: 280, need: 1300, per: 100 }, road: [] }, config: {} };
const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--use-gl=swiftshader', '--enable-gpu-rasterization', '--ignore-gpu-blocklist'] });
const ctx = await browser.newContext({ viewport: VIEW, deviceScaleFactor: 2.8125, hasTouch: true });
const page = await ctx.newPage();
page.on('pageerror', e => console.log('  pageerror', e.message.slice(0, 160)));
await page.addInitScript(([init]) => { window.__SQUISH_INIT__ = init; window.ReactNativeWebView = { postMessage() {} }; try { localStorage.setItem('squishsquad.menu.v1', JSON.stringify({ season: 'rainy' })); } catch (e) {} }, [INIT]);
// frames as the browser draws them (its own rAF, not the page's), counted from outside the page's clock
// (paused while the page sleeps, or the counter itself would keep the browser drawing: window.__count(false))
await page.addInitScript(() => { const raf = window.requestAnimationFrame.bind(window), now = performance.now.bind(performance); const F = window.__frames = []; let on = true; const f = t => { if (!on) return; F.push(now()); raf(f); }; raf(f); window.__count = v => { if (v && !on) { on = true; raf(f); } else on = !!v; }; });
await page.goto(pathToFileURL(GAME).href);
await page.waitForFunction(() => document.querySelector('.mm-tab'), null, { timeout: 120000 });
await page.waitForTimeout(4000);
if (scene === 'park') { await page.click('.mm-play', { force: true }); await page.waitForFunction(() => document.querySelector('.sq-pk.in'), null, { timeout: 60000 }); await page.waitForTimeout(2500); }
if (scene === 'house') { await page.click('.mm-tab[data-tab="house"]', { force: true }); await page.waitForFunction(() => { const h = document.querySelector('.mm-house'); return h && +getComputedStyle(h).opacity > 0.99; }, null, { timeout: 180000 }); await page.waitForTimeout(4000); }
const cdp = await ctx.newCDPSession(page);
await cdp.send('Performance.enable');
const metrics = async () => Object.fromEntries((await cdp.send('Performance.getMetrics')).metrics.map(m => [m.name, m.value]));
await cdp.send('Emulation.setCPUThrottlingRate', { rate: 4 });
async function span(label, ms) {
  const m0 = await metrics(), f0 = await page.evaluate(() => window.__frames.length);
  await page.waitForTimeout(ms);
  const m1 = await metrics(), f1 = await page.evaluate(() => window.__frames.length);
  const d = k => ((m1[k] || 0) - (m0[k] || 0)) * 1000 / (ms / 1000);
  console.log(`${label.padEnd(12)} main thread ${d('TaskDuration').toFixed(0).padStart(4)} ms/s (script ${d('ScriptDuration').toFixed(0)}, style ${d('RecalcStyleDuration').toFixed(0)}, layout ${d('LayoutDuration').toFixed(0)}) | page frames ${((f1 - f0) / (ms / 1000)).toFixed(1)}/s`);
}
await span('awake', 3000);
// a timer 2 s long, set 1 s before the sleep: it has 1 s left when the page falls asleep
await page.evaluate(() => { window.__t = { set: performance.now() }; setTimeout(() => { window.__t.fired = performance.now(); }, 2000); });
await page.waitForTimeout(1000);
const before = await page.evaluate(() => { const p0 = performance.now(); window.__count(false); window.SquishApp.receive({ type: 'sleep', on: true }); return { p0, running: document.getAnimations().filter(a => a.playState === 'running').length }; });
await page.waitForTimeout(300);
const asleep = await page.evaluate(() => ({ running: document.getAnimations().filter(a => a.playState === 'running').map(a => a.animationName || a.constructor.name), clock: performance.now(), videos: [...document.querySelectorAll('video')].filter(v => !v.paused).length }));
await span('asleep', 4000);
const clockAsleep = await page.evaluate(() => performance.now());
const wake = await page.evaluate(() => new Promise(res => { const t0 = performance.now(); window.__count(true); const n0 = window.__frames.length; window.SquishApp.receive({ type: 'sleep', on: false }); const F = window.__frames; requestAnimationFrame(t => { const t1 = performance.now(); requestAnimationFrame(() => res({ t0, firstFrameTs: t, t1, frames: F.slice(n0, n0 + 4).map((x, i, a) => i ? Math.round(x - a[i - 1]) : 0) })); }); }));
await span('awake again', 3000);
const timer = await page.evaluate(() => window.__t);
await cdp.send('Emulation.setCPUThrottlingRate', { rate: 1 });
console.log(`animations running: ${before.running} awake, ${asleep.running.length} asleep${asleep.running.length ? ' (' + [...new Set(asleep.running)].join(', ') + ')' : ''}; videos playing asleep: ${asleep.videos}`);
console.log(`page clock: ${Math.round(before.p0)} at sleep, ${Math.round(asleep.clock)} 0.3 s later, ${Math.round(clockAsleep)} after 4 s asleep, ${Math.round(wake.t0)} at wake (frozen: ${Math.abs(clockAsleep - before.p0) < 50 ? 'yes' : 'NO'}); first frame back at ${Math.round(wake.firstFrameTs)} (+${Math.round(wake.firstFrameTs - wake.t0)} ms of page time); browser frame gaps after wake: ${wake.frames.slice(1).join(', ')} ms`);
console.log(`timer (2 s, 1 s left at sleep): fired ${timer.fired ? Math.round(timer.fired - timer.set) + ' ms of page time after it was set' : 'NOT YET'} (want ~2000)`);
await browser.close();
