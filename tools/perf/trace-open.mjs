// Where the main thread goes while a page opens (PERF 2026-11-20): a Chrome trace of the tap and the next SECS seconds
// (the same weak-phone stand-in as open-bench.mjs), summed by kind of work and, for scripts, by file; plus the longest
// tasks with what was inside them.
//   NODE_PATH=<node_modules with playwright> GAME=<build dir> node tools/perf/trace-open.mjs <house|chars|level|park> [SECS]
// env: VIEW=796x384 THROTTLE=4 TRACE=<file> (also save the raw trace, for chrome://tracing or DevTools)
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const GAME = process.env.GAME ? path.resolve(process.env.GAME, 'App.dc.html') : path.join(REPO, 'webgame/test/out/webgame/App.dc.html');
const VIEW = (([w, h]) => ({ width: +w, height: +h }))((process.env.VIEW || '796x384').split('x'));
const THROTTLE = +(process.env.THROTTLE || 4);
const scene = process.argv[2] || 'house', SECS = +(process.argv[3] || 10);
const TAP = { house: '.mm-tab[data-tab="house"]', chars: '.mm-tab[data-tab="creatures"]', level: '.sq-crest', park: '.mm-play', idle: 'body', houseidle: 'body' }[scene];   // idle: the menu, nothing tapped
const INIT = { screen: 'menu', state: { level: 12, coins: 31342, gems: 975, owned: ['mittens', 'frybo', 'dunkie', 'bao', 'nimbo', 'biscuit', 'bean', 'zippy'], sel: 'frybo', hiddenKeys: [], games: [], xp: { level: 12, into: 280, need: 1300, per: 100 }, road: [] }, config: {} };

const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--use-gl=swiftshader', '--enable-gpu-rasterization', '--ignore-gpu-blocklist'] });
const ctx = await browser.newContext({ viewport: VIEW, deviceScaleFactor: 2.8125, hasTouch: true });
const page = await ctx.newPage();
page.on('pageerror', e => console.log('  pageerror', e.message.slice(0, 160)));
await page.addInitScript(([init]) => { window.__SQUISH_INIT__ = init; window.ReactNativeWebView = { postMessage() {} }; try { localStorage.setItem('squishsquad.menu.v1', JSON.stringify({ season: 'sunny' })); } catch (e) {} }, [INIT]);
await page.goto(pathToFileURL(GAME).href);
await page.waitForFunction(() => document.querySelector('.mm-tab'), null, { timeout: 120000 });
await page.waitForTimeout(5000);
// houseidle: into the house first, then trace it standing still
if (scene === 'houseidle') {
  await page.click('.mm-tab[data-tab="house"]', { force: true });
  await page.waitForFunction(() => { const h = document.querySelector('.mm-house'); return h && +getComputedStyle(h).opacity > 0.99; }, null, { timeout: 180000 });
  await page.waitForTimeout(6000);
  // HIDE=1: the menu under the house not drawn (an experiment)
  if (process.env.HIDE) await page.evaluate(() => document.querySelectorAll('.mm-frame > .mm-world, .mm-frame > .mm-hud, .mm-frame > .sq-wx').forEach(e => { e.style.visibility = 'hidden'; }));
}
const cdp = await ctx.newCDPSession(page);
const events = [];
cdp.on('Tracing.dataCollected', d => events.push(...d.value));
const done = new Promise(r => cdp.once('Tracing.tracingComplete', r));
await cdp.send('Tracing.start', { transferMode: 'ReportEvents', traceConfig: { includedCategories: ['devtools.timeline', 'v8.execute', 'blink.user_timing', 'toplevel', 'v8'], excludedCategories: ['*'] } });
await cdp.send('Emulation.setCPUThrottlingRate', { rate: THROTTLE });
await page.waitForTimeout(300);
await page.evaluate(sel => { performance.mark('sq-tap'); if (sel !== 'body') setTimeout(() => { performance.mark('sq-click'); document.querySelector(sel).click(); }, 0); }, TAP);
await page.waitForTimeout(SECS * 1000);
await cdp.send('Tracing.end');
await done;
await cdp.send('Emulation.setCPUThrottlingRate', { rate: 1 });
if (process.env.TRACE) fs.writeFileSync(process.env.TRACE, JSON.stringify({ traceEvents: events }));
await browser.close();

// the renderer's main thread: the thread with the tap mark
const mark = events.find(e => e.name === 'sq-tap');
const tid = mark ? mark.tid : null, pid = mark ? mark.pid : null, t0 = mark ? mark.ts : 0;
const main = events.filter(e => e.pid === pid && e.tid === tid && e.ph === 'X' && e.ts >= t0);
const tasks = main.filter(e => e.name === 'RunTask' || e.name === 'ThreadControllerImpl::RunTask');
// TIMELINE=<ms>: every task over 3 ms in the first <ms> after the tap, in order, with what was in it
if (process.env.TIMELINE) {
  const lim = +process.env.TIMELINE * 1000;
  tasks.filter(t => t.ts - t0 < lim && t.dur > 3000).sort((a, b) => a.ts - b.ts).forEach(t => {
    const inner = main.filter(e => e !== t && e.ts >= t.ts && e.ts + (e.dur || 0) <= t.ts + t.dur && (e.dur || 0) > 1500 && !/RunTask|v8.callFunction|ThreadController/.test(e.name));
    const what = {}; inner.forEach(e => { const a = e.args && e.args.data; const k = e.name + (a && a.functionName ? ' ' + a.functionName : '') + (a && a.url ? ' ' + String(a.url).split('/').pop().slice(0, 24) : ''); what[k] = (what[k] || 0) + e.dur / 1000; });
    console.log(String(Math.round((t.ts - t0) / 1000)).padStart(6), String(Math.round(t.dur / 1000)).padStart(5), Object.entries(what).sort((a, b) => b[1] - a[1]).slice(0, 6).map(([k, v]) => k + ' ' + Math.round(v)).join(' | '));
  });
}
// TREE=1: what was inside the longest task, as a tree (events over 2 ms)
if (process.env.TREE) {
  const t = tasks.slice().sort((a, b) => b.dur - a.dur)[0];
  const inner = main.filter(e => e.ts >= t.ts && e.ts + (e.dur || 0) <= t.ts + t.dur && (e.dur || 0) > 2000).sort((a, b) => a.ts - b.ts || b.dur - a.dur);
  const stack = [];
  for (const e of inner) { while (stack.length && stack[stack.length - 1].ts + stack[stack.length - 1].dur <= e.ts) stack.pop(); const a = e.args && e.args.data; console.log('  '.repeat(stack.length) + Math.round(e.dur / 1000) + ' ' + e.name + (a && (a.functionName || a.url) ? ' ' + (a.functionName || '') + ' ' + String(a.url || '').split('/').pop() + ':' + (a.lineNumber || '') : '')); stack.push(e); }
}
const by = {};
const add = (k, d) => { by[k] = (by[k] || 0) + d; };
for (const e of main) {
  const d = (e.dur || 0) / 1000; const a = e.args && e.args.data;
  if (e.name === 'EvaluateScript' || e.name === 'v8.compile' || e.name === 'v8.parseOnBackground') add(e.name + ' ' + ((a && a.url) || (e.args && e.args.fileName) || '').split('/').pop().slice(0, 40), d);
  else if (['FunctionCall', 'TimerFire', 'FireAnimationFrame', 'EventDispatch', 'UpdateLayoutTree', 'Layout', 'Paint', 'PrePaint', 'Layerize', 'UpdateLayer', 'ParseHTML', 'Decode Image', 'ImageDecodeTask', 'MajorGC', 'MinorGC', 'V8.GCScavenger', 'V8.GCFinalizeMC', 'BlinkGC.AtomicPhase', 'ScheduleStyleRecalculation', 'HitTest', 'Commit', 'RasterTask', 'GPUTask', 'ParseAuthorStyleSheet', 'v8.run', 'V8.Execute'].includes(e.name)) add(e.name + (e.name === 'FunctionCall' || e.name === 'TimerFire' ? '' : ''), d);
}
const tot = tasks.reduce((s, e) => s + e.dur / 1000, 0);
console.log(`${scene}: main thread busy ${Math.round(tot)} ms of ${SECS * 1000} (CPU x${THROTTLE})`);
Object.entries(by).sort((a, b) => b[1] - a[1]).slice(0, 40).forEach(([k, v]) => console.log(String(Math.round(v)).padStart(7), k));
console.log('longest tasks (ms after the tap: length, then what was in them):');
tasks.sort((a, b) => b.dur - a.dur).slice(0, 12).forEach(t => {
  const inner = main.filter(e => e !== t && e.ts >= t.ts && e.ts + (e.dur || 0) <= t.ts + t.dur && (e.dur || 0) > 3000);
  const what = {}; inner.forEach(e => { const a = e.args && e.args.data; const k = e.name + (a && a.url ? ' ' + a.url.split('/').pop().slice(0, 30) : a && a.functionName ? ' ' + a.functionName : ''); what[k] = Math.max(what[k] || 0, e.dur / 1000); });
  console.log(String(Math.round((t.ts - t0) / 1000)).padStart(6), String(Math.round(t.dur / 1000)).padStart(5), Object.entries(what).sort((a, b) => b[1] - a[1]).slice(0, 5).map(([k, v]) => k + ' ' + Math.round(v)).join(' | '));
});
