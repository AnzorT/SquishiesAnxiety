// The game intro's frame rate, phase by phase (2026-11-16, the user: "the intro has very low FPS"): the same weak-phone
// stand-in as webview-bench.mjs (Chromium with software rendering, the CPU slowed 4x, the Galaxy A15's landscape size),
// on the menu page with the start data's `intro`, tapping through the story (the box, three squishes, TAP TO START).
//
//   node webgame/build.mjs --out webgame/test/out/webgame
//   NODE_PATH=<a node_modules with playwright> node tools/perf/intro-bench.mjs        (SEASON=rainy|sunny|snowy: the menu's own)
//
// Numbers are for comparing before / after on this machine, not a phone's fps. 2026-11-16: 12-19 fps before the PERF
// changes in webgame/app/intro.js and the still houses (app/menu.js), 39-57 after; the plain menu 54.
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const GAME = process.env.GAME ? path.resolve(process.env.GAME, 'App.dc.html') : path.join(path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..'), 'webgame/test/out/webgame/App.dc.html');   // GAME=<a build dir> (PERF 2026-11-20)
const INIT = { screen: 'menu', intro: true, state: { level: 6, coins: 31342, gems: 975, owned: ['mittens', 'frybo', 'dunkie', 'bao', 'nimbo'], sel: 'frybo', hiddenKeys: [], games: [], xp: { level: 6, into: 28, need: 700, per: 100 }, road: [] }, config: {} };
const season = process.env.SEASON || 'sunny';
// VIEW=<w>x<h>: the CSS viewport (default 796x384, the Galaxy A16's landscape WebView; the A15 was 832x384) (PERF 2026-11-20)
const VIEW = (([w, h]) => ({ width: +w, height: +h }))((process.env.VIEW || '796x384').split('x'));
const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--use-gl=swiftshader', '--enable-gpu-rasterization', '--ignore-gpu-blocklist'] });
const ctx = await browser.newContext({ viewport: VIEW, deviceScaleFactor: 2.8125, hasTouch: true });
const page = await ctx.newPage();
page.on('pageerror', e => console.log('  pageerror', e.message.slice(0, 160)));
await page.addInitScript(([init, season]) => { window.__SQUISH_INIT__ = init; window.ReactNativeWebView = { postMessage() {} }; try { localStorage.setItem('squishsquad.menu.v1', JSON.stringify({ season })); } catch (e) {} }, [INIT, season]);
const cdp = await ctx.newCDPSession(page);
await page.goto(pathToFileURL(GAME).href);
await page.waitForFunction(() => document.querySelector('.si-cap'), null, { timeout: 120000 });
await cdp.send('Emulation.setCPUThrottlingRate', { rate: 4 });
const fps = async (label, ms) => {
  const t = await page.evaluate(ms => new Promise(res => { const t = []; const f = now => { t.push(now); if (now - t[0] < ms) requestAnimationFrame(f); else res(t); }; requestAnimationFrame(f); }), ms);
  const gaps = t.slice(1).map((x, i) => x - t[i]), f = (t.length - 1) / ((t[t.length - 1] - t[0]) / 1000), p95 = gaps.slice().sort((a, b) => a - b)[Math.floor(gaps.length * 0.95)] || 0;
  console.log(label.padEnd(14), 'fps', f.toFixed(1).padStart(5), ' p95', p95.toFixed(0).padStart(4), 'ms');
};
await fps('1 camera+rain', 3000);
await page.waitForFunction(() => { const h = document.querySelector('.si-hit'); return h && h.style.display !== 'none'; }, null, { timeout: 60000 });
await fps('2 box wobble', 2500);
await page.evaluate(() => document.querySelector('.si-hit').click());
await fps('3 pop', 2000);
await page.waitForTimeout(1500);
await fps('4 squish wait', 2500);
// three squishes via the rig's pointer events on the hit area
for (let i = 0; i < 3; i++) {
  await page.evaluate(() => { const h = document.querySelector('.mm-hit'), r = h.getBoundingClientRect(), o = { bubbles: true, clientX: r.left + r.width / 2, clientY: r.top + r.height / 2, pointerId: 1, isPrimary: true }; h.dispatchEvent(new PointerEvent('pointerdown', o)); setTimeout(() => h.dispatchEvent(new PointerEvent('pointerup', o)), 200); });
  await page.waitForTimeout(i < 2 ? 1800 : 300);
}
await fps('5 lights+dawn', 4500);
await fps('6 dawn/peeks', 2500);
await page.waitForFunction(() => document.querySelector('.si-logo'), null, { timeout: 30000 });
await fps('7 logo drop', 1500);
await page.waitForTimeout(1500);
await fps('8 logo idle', 2500);
await page.evaluate(() => { const t = document.querySelector('.si-tap'); if (t) t.click(); });
await page.waitForTimeout(2500);
await fps('9 menu after', 2500);
await browser.close();
