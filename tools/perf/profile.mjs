// Where the page's JavaScript time goes in a scene (PERF 2026-11-20): a V8 CPU profile of SECS seconds, self and total
// time by function (the same weak-phone stand-in as the other benches: Chromium, CPU x4, 796 x 384 at DPR 2.8125).
//   NODE_PATH=<node_modules with playwright> GAME=<build dir> node tools/perf/profile.mjs <menu|house|chars|park> [SECS]
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const GAME = process.env.GAME ? path.resolve(process.env.GAME, 'App.dc.html') : path.join(REPO, 'webgame/test/out/webgame/App.dc.html');
const VIEW = (([w, h]) => ({ width: +w, height: +h }))((process.env.VIEW || '796x384').split('x'));
const scene = process.argv[2] || 'house', SECS = +(process.argv[3] || 4);
const INIT = { screen: 'menu', state: { level: 12, coins: 31342, gems: 975, owned: ['mittens', 'frybo', 'dunkie', 'bao', 'nimbo', 'biscuit', 'bean', 'zippy'], sel: 'frybo', hiddenKeys: [], games: [], xp: { level: 12, into: 280, need: 1300, per: 100 }, road: [] }, config: {} };
const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--use-gl=swiftshader', '--enable-gpu-rasterization', '--ignore-gpu-blocklist'] });
const ctx = await browser.newContext({ viewport: VIEW, deviceScaleFactor: 2.8125, hasTouch: true });
const page = await ctx.newPage();
await page.addInitScript(([init]) => { window.__SQUISH_INIT__ = init; window.ReactNativeWebView = { postMessage() {} }; try { localStorage.setItem('squishsquad.menu.v1', JSON.stringify({ season: 'sunny' })); } catch (e) {} }, [INIT]);
await page.goto(pathToFileURL(GAME).href);
await page.waitForFunction(() => document.querySelector('.mm-tab'), null, { timeout: 120000 });
await page.waitForTimeout(4000);
const tap = { house: '.mm-tab[data-tab="house"]', chars: '.mm-tab[data-tab="creatures"]', park: '.mm-play' }[scene];
if (tap) { await page.click(tap, { force: true }); await page.waitForTimeout(scene === 'house' ? 1000 : 4000); }
if (scene === 'house') { await page.waitForFunction(() => { const h = document.querySelector('.mm-house'); return h && +getComputedStyle(h).opacity > 0.99; }, null, { timeout: 180000 }); await page.waitForTimeout(5000); }
const cdp = await ctx.newCDPSession(page);
await cdp.send('Profiler.enable');
await cdp.send('Profiler.setSamplingInterval', { interval: 200 });
await cdp.send('Emulation.setCPUThrottlingRate', { rate: 4 });
await cdp.send('Profiler.start');
await page.waitForTimeout(SECS * 1000);
const { profile } = await cdp.send('Profiler.stop');
await browser.close();
const byId = new Map(profile.nodes.map(n => [n.id, n]));
const dt = {}; profile.samples.forEach((id, i) => { dt[id] = (dt[id] || 0) + (profile.timeDeltas[i] || 0); });
const self = {}, total = {};
const key = n => (n.callFrame.functionName || '(anon)') + ' ' + n.callFrame.url.split('/').pop().split('?')[0] + ':' + (n.callFrame.lineNumber + 1);
const parent = new Map(); profile.nodes.forEach(n => (n.children || []).forEach(c => parent.set(c, n.id)));
profile.nodes.forEach(n => {
  const t = (dt[n.id] || 0) / 1000; if (!t) return;
  const k = key(n); self[k] = (self[k] || 0) + t;
  const seen = new Set(); let p = n.id; while (p != null) { const q = byId.get(p), kk = key(q); if (!seen.has(kk)) { total[kk] = (total[kk] || 0) + t; seen.add(kk); } p = parent.get(p); }
});
const top = (o, n) => Object.entries(o).sort((a, b) => b[1] - a[1]).slice(0, n).map(([k, v]) => String(Math.round(v)).padStart(6) + ' ms  ' + k).join('\n');
console.log(`${scene}: ${SECS} s at CPU x4\n-- self --\n${top(self, 22)}\n-- total --\n${top(total, 28)}`);
