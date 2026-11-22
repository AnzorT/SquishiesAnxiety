// Reference screenshots for the Unity port: the in-app game pages (webgame/) exactly as the phone shows them, at the
// Galaxy A15's real size (832 x 384 dp landscape at 2.8125x = 2340 x 1080 px). Unity screens are checked against these
// with PlushCrush > Reference Overlay.
//
// Frozen like webgame/test/pixel-diff.mjs, so every run gives the same picture: a fake clock, a seeded Math.random,
// CSS animations held at their first frame. Pages load offline from the built webgame (file://), as on the phone.
//
//   node webgame/build.mjs --out webgame/test/out/webgame
//   node tools/unity-port/capture-references.mjs                -> unity/Assets/_Project/Reference/game/*.jpg
//   node tools/unity-port/capture-references.mjs menu house-dance  (only those)
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const BUILT = path.join(REPO, 'webgame/test/out/webgame');
const OUT = path.join(REPO, 'unity/Assets/_Project/Reference/game');

// The A15 held landscape (src/web/README.md): 832 x 384 dp, 2.8125 px per dp
const VIEWPORT = { width: 832, height: 384 };
const SCALE = 2.8125;
const T0 = new Date('2026-11-13T12:00:00Z');
const SEED = `(() => { let s = 0x2f6b9a1; Math.random = () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; })();`;

// Only the Living Room for now: a fresh player is level 1, where every other room is still locked and the house opens
// the Living Room whatever ?room= asks for. The others need a stand-in profile at a higher level first
// (kitchen 2, bathroom 4, bedroom 6, backyard 8, dance 11, movie 12, beach 30: main-menu-scene.js ROOMS).
const ROOMS = ['living'];
const click = sel => async p => { await p.click(sel, { timeout: 5000 }); };

// [name, page, real ms to load, game ms to run, then [label, action, game ms] steps each shot after]
const CASES = [
  ['menu', 'App.dc.html', 8000, 9000, [
    ['park', click('.mm-play'), 6000],
  ]],
  // Not yet: the Level Pass (tap .mm-crest) is filled with data the React Native app sends over the bridge
  // (app/bridge.js), so offline it stays shut. Needs a stand-in for that message first.
  ...ROOMS.map(room => [`house-${room}`, `App.dc.html?screen=house&room=${room}`, 30000, 6000, []]),
];

if (!fs.existsSync(path.join(BUILT, 'App.dc.html'))) {
  console.error('Build the game pages first: node webgame/build.mjs --out webgame/test/out/webgame');
  process.exit(1);
}
fs.mkdirSync(OUT, { recursive: true });
const only = process.argv.slice(2);
const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });

async function run(page, ms) {
  for (let t = 0; t < ms; t += 500) { await page.clock.runFor(500); await page.waitForTimeout(120); }
}

async function shoot(page, name) {
  await page.evaluate(() => document.fonts.ready);
  await page.waitForTimeout(800);
  const file = path.join(OUT, name + '.jpg');
  await page.screenshot({ path: file, type: 'jpeg', quality: 90 });
  console.log('  ', path.relative(REPO, file));
}

let failed = 0;
for (const [name, url, realMs, gameMs, steps] of CASES) {
  if (only.length && !only.some(o => name === o || name.startsWith(o + '-'))) continue;
  const ctx = await browser.newContext({ viewport: VIEWPORT, deviceScaleFactor: SCALE, hasTouch: true });
  const page = await ctx.newPage();
  const errs = [];
  page.on('pageerror', e => errs.push(e.message));
  await page.route(/^(https?|wss?):/, r => r.abort()); // offline, as on the phone
  await page.addInitScript(SEED);
  await page.clock.install({ time: T0 });
  await page.clock.pauseAt(T0);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Animation.enable');
  await cdp.send('Animation.setPlaybackRate', { playbackRate: 0 });
  const [file, query] = url.split('?');
  console.log(name);
  await page.goto(pathToFileURL(path.join(BUILT, file)).href + (query ? '?' + query : ''));
  await page.waitForTimeout(realMs); // scripts, art and fonts load (no game time passes: the clock is paused)
  await run(page, gameMs);
  await shoot(page, name);
  for (const [label, act, ms] of steps) {
    try { await act(page); await run(page, ms); await shoot(page, `${name}-${label}`); }
    catch (e) { errs.push(`${label}: ${e.message.split('\n')[0]}`); }
  }
  if (errs.length) { failed++; console.log('   problems:', [...new Set(errs)].slice(0, 5).join(' | ')); }
  await ctx.close();
}
await browser.close();
process.exit(failed ? 1 : 0);
