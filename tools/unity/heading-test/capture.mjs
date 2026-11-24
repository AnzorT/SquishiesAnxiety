// "Heading home" as develop's app shows it (webgame/app/menu.js M.headingHome): the menu (the lv12 house fixture) at
// the A15's size, MY HOUSE's walk to the door, then the night held (the house never says it has drawn: houseDrawn
// swallowed) until every open room's windows have lit up (the door, last, stays dark: it waits for the house). Writes the
// screenshot and the menu's state (level, season) for Program.cs to draw the same night with Menu/HeadingNight.cs.
//   node tools/unity/heading-test/capture.mjs <out dir>       -> <out>/app.png, state.json
import fs from 'node:fs';
import path from 'node:path';
import { pathToFileURL, fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const H = await import(pathToFileURL(path.join(REPO, 'tools/unity/house/harness.mjs')).href);
const { loadFixtures } = await import(pathToFileURL(path.join(REPO, 'tools/unity/house/fixtures.mjs')).href);
const [out] = process.argv.slice(2);
await H.buildWeb();
fs.mkdirSync(out, { recursive: true });
const browser = await H.launch();
const fx = loadFixtures().find(f => f.name === 'lv12');
const ctx = await browser.newContext({ viewport: { width: 832, height: 384 }, deviceScaleFactor: 2.8125 });
const page = await ctx.newPage();
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
await page.waitForTimeout(2000);
const state = await page.evaluate(() => { const s = window.SquishApp.menu._st(); return { level: s && (s.L || s.level), season: s && s.season, keys: s ? Object.keys(s) : [] }; });
// the house never says it has drawn: the night stays
await page.evaluate(() => { window.SquishMenu.houseDrawn = () => {}; });
await page.evaluate(() => { window.SquishApp.menu.home('living'); });   // (not its promise: the trip waits for the house, held back)
await page.waitForTimeout(16000);
await page.screenshot({ path: path.join(out, 'app.png') });
fs.writeFileSync(path.join(out, 'state.json'), JSON.stringify(state, null, 1));
console.log(JSON.stringify(state));
await browser.close();
