// The yard games as develop's app shows them (webgame/build.mjs's menu page, as tools/unity/house/export-yardpage.mjs
// opens it: the lv12 house, the backyard, every game's toy bought, the YARD GAMES page), at the moments Shots.cs draws:
// each game's intro (3 s after its PLAY on the page), the game (2.5 s after the intro's PLAY), the results (2.5 s after
// the game is ended). Also exports what Unity draws the results with: the app's coin (SquishCoin.coin(0)) as
// unity/Assets/Resources/Yard/game/coin.png (a texture: UiPiece loads <image> pictures as Texture2D).
//   node tools/unity/yard-test/capture.mjs <out dir> [game ...]      -> <out>/<game>-intro|play|result.png, geo.json
import fs from 'node:fs';
import path from 'node:path';
import { pathToFileURL, fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const H = await import(pathToFileURL(path.join(REPO, 'tools/unity/house/harness.mjs')).href);
const { loadFixtures } = await import(pathToFileURL(path.join(REPO, 'tools/unity/house/fixtures.mjs')).href);
const [out, ...only] = process.argv.slice(2);
const GAMES = only.length ? only : ['hoop', 'soccer', 'hop', 'tramp', 'slide', 'corn', 'pong'];
const TOY = { hoop: 'YRD-102', soccer: 'YRD-104', hop: 'YRD-101', tramp: 'YRD-120', slide: 'YRD-123', corn: 'YRD-037', pong: 'YRD-057' };
await H.buildWeb();
fs.mkdirSync(out, { recursive: true });
const browser = await H.launch();
const fx = loadFixtures().find(f => f.name === 'lv12');
const ctx = await browser.newContext({ viewport: { width: 832, height: 384 }, deviceScaleFactor: 2.8125 });
const page = await ctx.newPage();
const errs = [];
page.on('pageerror', e => errs.push(e.message));
await page.route(/^https?:/, r => r.abort());
await page.addInitScript(F => {
  try { localStorage.clear(); } catch (e) { /* none */ }
  const set = (k, v) => localStorage.setItem(k, typeof v === 'string' ? v : JSON.stringify(v));
  set('squishsquad.profile.v1', Object.assign({ level: 1, coins: 100, owned: [] }, F.profile || {}));
  if (F.collection) set('squishsquad.collection.v1', F.collection);
  if (F.house) set('ssHouse5b', F.house);
}, fx);
await page.goto(pathToFileURL(path.join(H.WORK, 'App.dc.html')).href + '?screen=menu');
await page.waitForFunction(() => !!(window.SquishApp && window.SquishApp.menu && window.SquishApp.menu._geo()), null, { timeout: 120000 });
await page.waitForTimeout(1500);
await page.evaluate(() => window.SquishApp.menu.home('backyard'));
await page.waitForFunction(() => !!(window.__sh && window.__sh.state && window.__sh.state.ready && !window.SquishApp.menu._busy()), null, { timeout: 120000 });
await page.waitForTimeout(2500);
// the coin the results card shows
const coin = await page.evaluate(() => window.SquishCoin && window.SquishCoin.coin(0));
if (coin && coin.startsWith('data:image/png;base64,')) {
  const dir = path.join(REPO, 'unity/Assets/Resources/Yard/game');
  fs.mkdirSync(dir, { recursive: true });
  fs.writeFileSync(path.join(dir, 'coin.png'), Buffer.from(coin.slice(22), 'base64'));
}
const geo = {};
for (const g of GAMES) {
  await page.evaluate(({ TOY }) => { const sh = window.__sh; for (const k in TOY) sh.H.owned['R:' + TOY[k]] = 1; const p = document.querySelector('.mm-page2'); if (p) p.remove(); window.SquishApp.menu.games('yard'); }, { TOY });
  await page.waitForTimeout(2500);
  await page.evaluate((g) => document.querySelector('.sq-ygc[data-g="' + g + '"] .go').click(), g);
  await page.waitForTimeout(3000);
  await page.screenshot({ path: path.join(out, g + '-intro.png') });
  geo[g] = await page.evaluate(() => { const r = (s) => { const e = document.querySelector(s); if (!e) return null; const b = e.getBoundingClientRect(); return [b.x, b.y, b.width, b.height].map(v => Math.round(v * 100) / 100); }; return { frame: r('.yg-frame'), sheet: r('.yg-isheet'), iback: r('.yg-iback'), go: r('.yg-isheet .yg-go') }; });
  await page.evaluate(() => document.querySelector('.yg-isheet .yg-go').click());
  await page.waitForTimeout(2500);
  await page.screenshot({ path: path.join(out, g + '-play.png') });
  await page.evaluate(() => window.YardGames._cur.ctx.finish({ delay: 0 }));
  await page.waitForTimeout(2500);
  await page.screenshot({ path: path.join(out, g + '-result.png') });
  Object.assign(geo[g], await page.evaluate(() => { const r = (s) => { const e = document.querySelector(s); if (!e) return null; const b = e.getBoundingClientRect(); return [b.x, b.y, b.width, b.height].map(v => Math.round(v * 100) / 100); }; return { card: r('.yg-card'), btns: [...document.querySelectorAll('.yg-res .yg-btn')].map(e => { const b = e.getBoundingClientRect(); return [b.x, b.y, b.width, b.height].map(v => Math.round(v * 100) / 100); }) }; }));
  // back to the page for the next game
  await page.evaluate(() => { const b = [...document.querySelectorAll('.yg-res .yg-btn')][0]; if (b) b.click(); });
  await page.waitForTimeout(1200);
  console.log(g, JSON.stringify(geo[g]));
}
fs.writeFileSync(path.join(out, 'geo.json'), JSON.stringify(geo, null, 1));
if (errs.length) console.log('page errors:', errs.slice(0, 3).join(' | '));
await browser.close();
