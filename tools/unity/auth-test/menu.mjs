// The app's Main Menu (the in-app web game, as tools/unity/export-menu.mjs opens it: webgame/test/out/unity-webgame,
// built by export-menu.mjs) for a few players: their coins, gems and XP handed in the way the app does
// (window.__SQUISH_INIT__.state, src/game/player.js gamePlayer), the clock frozen. For each player:
//   menu-<n>.png       the menu as the app shows it
//   menu-<n>-bare.png  the same with the coin / gem pills and the crest's number and XP ring hidden: what Unity draws
//                      those parts over (Program.cs menu)
//   profiles.json      the players
//   node tools/unity/auth-test/menu.mjs <out dir>
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const WORK = path.resolve(HERE, '../../../webgame/test/out/unity-webgame');
const out = process.argv[2] || 'menu-shots';
fs.mkdirSync(out, { recursive: true });

// functions/squad.js playerLevel at the default xpPerLevel (100)
const toReach = (L) => (L <= 1 ? 0 : (100 * (L * (L + 1) - 2)) / 2);
function playerLevel(pxp) {
  const x = Math.max(0, Math.floor(pxp));
  let L = Math.max(1, Math.floor((Math.sqrt(9 + (8 * x) / 100) - 1) / 2));
  while (L > 1 && toReach(L) > x) L--;
  while (toReach(L + 1) <= x) L++;
  return { level: L, into: x - toReach(L), need: 100 * (L + 1) };
}

// a new player, a mid one, a rich one (coins 0 / 12,345 / 1,000,000; levels 1 / 17 / 30)
// (the first: no player handed in, the prototype's demo save: 100 coins, 600 gems, level 1, no XP ring: what the
// exported menu shows, and Unity's menu offline)
const PLAYERS = [
  { baked: true },
  { coins: 0, gems: 0, pxp: 0 },
  { coins: 12345, gems: 75, pxp: toReach(17) + 900 },
  { coins: 1000000, gems: 123456, pxp: toReach(30) + 2950 },
];

const T0 = new Date('2026-11-13T12:00:00Z');
const SEED = `(() => { let s = 0x2f6b9a1; Math.random = () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; })();`;

const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const players = [];
for (let n = 0; n < PLAYERS.length; n++) {
  const p = PLAYERS[n], xp = p.baked ? { level: 1, into: 0, need: 0 } : playerLevel(p.pxp);
  const state = p.baked ? null : { level: xp.level, coins: p.coins, gems: p.gems, owned: ['mittens'], sel: 'mittens', xp: { ...xp, per: 100 } };
  players.push({ ...p, ...xp });
  const ctx = await browser.newContext({ viewport: { width: 832, height: 384 }, deviceScaleFactor: 2.8125 });
  const page = await ctx.newPage();
  await page.route(/^https?:/, (r) => r.abort());
  await page.addInitScript(SEED);
  if (state) await page.addInitScript((state) => { window.__squishOutbox = []; window.__SQUISH_INIT__ = { state }; }, state);
  await page.clock.install({ time: T0 });
  await page.clock.pauseAt(T0);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Animation.enable');
  await cdp.send('Animation.setPlaybackRate', { playbackRate: 0 });
  await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href);
  await page.waitForTimeout(8000);
  for (let t = 0; t < 9000; t += 500) { await page.clock.runFor(500); await page.waitForTimeout(150); }
  await page.evaluate(() => document.fonts.ready);
  await page.waitForTimeout(1000);
  const shown = await page.evaluate(() => ({
    pills: [...document.querySelectorAll('.mm-top > .mm-pill span')].map((s) => s.textContent),
    crest: document.querySelector('.sq-crest svg.mm-crest').getAttribute('aria-label'),
    ring: document.querySelector('.sq-crest circle[r="27.2"]')?.parentElement.querySelectorAll('circle[r="27.2"]')[1]?.getAttribute('stroke-dasharray'),
    boxes: [...document.querySelectorAll('.mm-top > .mm-pill')].map((p) => [p, p.querySelector('span'), p.querySelector('img')].map((e) => { const r = e.getBoundingClientRect(); return [r.x, r.y, r.width, r.height].map((v) => +v.toFixed(3)); })),
  }));
  players[n].boxes = shown.boxes;
  console.log(n, JSON.stringify(state ? state.xp : 'demo save'), JSON.stringify(shown));
  await page.screenshot({ path: path.join(out, `menu-${n}.png`) });
  await page.evaluate(() => {
    document.querySelectorAll('.mm-top > .mm-pill').forEach((e) => { e.style.visibility = 'hidden'; });
    const svg = document.querySelector('.sq-crest svg.mm-crest');
    [...svg.querySelectorAll(':scope > text')].slice(-2).forEach((t) => { t.style.visibility = 'hidden'; });
    svg.querySelectorAll('circle[r="27.2"]').forEach((c) => { c.style.visibility = 'hidden'; });
  });
  await page.waitForTimeout(300);
  await page.screenshot({ path: path.join(out, `menu-${n}-bare.png`) });
  await ctx.close();
}
fs.writeFileSync(path.join(out, 'profiles.json'), JSON.stringify(players, null, 1));
await browser.close();
