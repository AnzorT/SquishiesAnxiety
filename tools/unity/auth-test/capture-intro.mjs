// The game intro's frames to check Unity's box against (auth-test `intro`): the app's intro (webgame build of
// export-menu.mjs / export-intro.mjs) at 6.2 s, the box landed and still (its wobble's transform cleared), the ring hidden.
//   node tools/unity/auth-test/capture-intro.mjs <out dir>
// WEATHER=rainy|snowy (default sunny): that day's intro; its rain or snow (intro.js rainBuild's layers) held at RAIN_MS
// (default 1234) into their loops -> <out>/box-<weather>.png (auth-test `rain` draws Unity's IntroRain over it).
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../../..');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const OUT = path.resolve(process.argv[2] || 'intro-shots');
const REF = { w: 832, h: 384, dpr: 2.8125 };
const T0 = new Date('2026-11-13T22:00:00Z');
fs.mkdirSync(OUT, { recursive: true });

const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const ctx = await browser.newContext({ viewport: { width: REF.w, height: REF.h }, deviceScaleFactor: REF.dpr });
const page = await ctx.newPage();
await page.route(/^https?:/, r => r.abort());
const WEATHER = process.env.WEATHER || 'sunny', RAIN_MS = +(process.env.RAIN_MS || 1234);
await page.addInitScript((w) => { window.ReactNativeWebView = { postMessage() {} }; window.__SQUISH_INIT__ = { intro: true, state: { weather: w } }; }, WEATHER);
await page.clock.install({ time: T0 });
await page.clock.pauseAt(T0);
await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href);
await page.waitForTimeout(8000);
for (let t = 0; t < 4000; t += 100) { await page.clock.runFor(100); await page.waitForTimeout(20); if (await page.evaluate(() => !!document.querySelector('.si-back'))) break; }
for (let t = 0; t < 6200; t += 32) { await page.clock.runFor(32); await page.waitForTimeout(8); }
await page.evaluate((ms) => {
  // the rain's layers (Web Animations on the document's own timeline, not the paused clock): held at a known moment
  const rl = document.querySelector('.si-rainl');
  if (rl) rl.getAnimations({ subtree: true }).forEach((a) => { a.pause(); a.currentTime = ms; });
  document.querySelectorAll('.si-bxb, .si-bxf').forEach(g => g.setAttribute('transform', ''));
  document.querySelector('.si-ring').setAttribute('opacity', 0);
  document.querySelector('.si-fx').innerHTML = '';
  const st = document.createElement('style'); st.textContent = '.si-cap, .si-skip { visibility: hidden !important; }'; document.head.appendChild(st);
}, RAIN_MS);
await page.waitForTimeout(100);
const name = WEATHER === 'sunny' ? 'box.png' : `box-${WEATHER}.png`;
await page.screenshot({ path: path.join(OUT, name) });
console.log('->', path.join(OUT, name));
await browser.close();
