// Squishdoku's screen as the app shows it (Expo web, src/web/Preview.js "game-squishdoku": a made-up player on level 12),
// for Screen.cs to show the same from the Unity code (SdScreen) and compare: the hub settled, then on a virtual clock
// (tools/unity/rig/virtual-clock.js, Math.random 0.5) the slides between the views with their placeholders and the
// content fading in, the map's nodes popping in, HOW TO PLAY, a level opened from the map and left again, a Blitz run
// opened from the hub. Taps happen at set moments after T0 (the first tap); the screen is shot at set moments.
// node screen.mjs <out dir>     <out>/screen-hub.png, <out>/screen-<ms>.png;  <out>/screen.json  the steps
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
// taps are (x, y) on the screen; `node`: level n's node on the map
const STEPS = [
  { at: 0, tap: [220, 200] },                      // REGULAR MODE: the map slides in
  { at: 16, shot: true }, { at: 64, shot: true }, { at: 120, shot: true }, { at: 250, shot: true }, { at: 500, shot: true }, { at: 2500, shot: true },
  { at: 3000, node: 12 },                          // level 12: the level slides in over the map
  { at: 3100, shot: true }, { at: 3400, shot: true },
  { at: 5000, tap: [34, 39] },                     // the level's top bar: pause...
  { at: 5600, press: 'QUIT' },                     // ...QUIT: back to the kept map, at once
  { at: 5700, shot: true }, { at: 7000, shot: true },
  { at: 7100, tap: [34, 26] },                     // back: the hub slides in
  { at: 7200, shot: true }, { at: 7500, shot: true }, { at: 7800, shot: true }, { at: 10000, shot: true },
  { at: 10100, tap: [624, 338] },                  // HOW TO PLAY
  { at: 10300, shot: true }, { at: 10600, shot: true }, { at: 12500, shot: true },
  { at: 12600, press: 'GOT IT' },
  { at: 13000, shot: true },
  { at: 13100, tap: [610, 200] },                  // BLITZ MODE: the run slides in
  { at: 13150, shot: true }, { at: 13250, shot: true },
];

const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-squishdoku');
await page.waitForTimeout(7000);
await page.screenshot({ path: path.join(out, 'screen-hub.png') });
await page.evaluate(fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8'));
await page.evaluate(() => { Math.random = () => 0.5; });
const run = (ms) =>
  page.evaluate(async (target) => {
    const y = () => new Promise((r) => window.__realSetTimeout(r, 0));
    while (window.__clock.now < target - 1e-9) {
      window.__clock.frame(Math.min(16, target - window.__clock.now));
      for (let i = 0; i < 3; i++) await y();
    }
  }, ms);
async function press(label) {
  const p = await page.evaluate((label) => {
    const b = window.__components('SdButton').map((c) => c.el).filter((e) => e && e.getBoundingClientRect().width > 0).find((e) => e.innerText.includes(label));
    const r = b.getBoundingClientRect();
    return [r.x + r.width / 2, r.y + r.height / 2];
  }, label);
  await page.mouse.click(p[0], p[1]);
}
const T0 = await page.evaluate(() => window.__clock.now);
for (const s of STEPS) {
  await run(T0 + s.at);
  if (s.tap) { await page.mouse.click(s.tap[0], s.tap[1]); await page.waitForTimeout(250); }
  else if (s.press) { await press(s.press); await page.waitForTimeout(250); }
  else if (s.node) {
    const p = await page.evaluate((lv) => {
      const t = [...document.querySelectorAll('div')].find((d) => d.childNodes.length === 1 && d.textContent === String(lv) && d.getBoundingClientRect().width > 0);
      const r = t.getBoundingClientRect();
      return [r.x + r.width / 2, r.y + r.height / 2];
    }, s.node);
    s.tap = p.map((v) => +v.toFixed(2));
    await page.mouse.click(p[0], p[1]);
    await page.waitForTimeout(250);
  } else if (s.shot) {
    await page.waitForTimeout(700);
    await page.screenshot({ path: path.join(out, `screen-${s.at}.png`) });
    console.log(`screen at ${s.at} ms`);
  }
}
fs.writeFileSync(path.join(out, 'screen.json'), JSON.stringify({ steps: STEPS }));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
