// Squishdoku's cards as the app shows them (Expo web, src/web/Preview.js: sd-result, sd-perfect, sd-timeup, sd-hearts,
// sd-pause with Preview's sample data), at known moments: the page's clock is replaced by tools/unity/rig/
// virtual-clock.js once it has loaded (and Math.random made 0.5), the card is opened at virtual time 0, and the clock is
// stepped 16 ms a frame (the last step landing on the moment), as Cards.cs steps the Unity card.
// node cards.mjs <out dir> [card ...]      <out>/<card>-<ms>.png  the screen then;  <out>/cards.json  the cards and moments
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out, ...only] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
// moments while it moves, and where it has settled (the result's gold sparks fly 480-3260 ms)
const CARDS = [
  ['sd-result', [300, 1000, 2400, 7500]],
  ['sd-perfect', [2300, 2700, 7500]],
  ['sd-timeup', [400, 3600]],
  ['sd-hearts', [3600]],
  ['sd-pause', [150, 2000]],
];
const clock = fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8');
for (const [card, times] of CARDS) {
  if (only.length && !only.includes(card)) continue;
  const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=none');
  await page.waitForTimeout(5000);
  await page.evaluate(clock);
  await page.evaluate(() => { Math.random = () => 0.5; });
  await page.evaluate((c) => window.__preview(c), card);
  await page.waitForTimeout(1500); // React commits (twice for the result) at virtual time 0
  for (const ms of times) {
    await page.evaluate(async (ms) => {
      const y = () => new Promise((r) => window.__realSetTimeout(r, 0));
      while (window.__clock.now < ms) { window.__clock.frame(Math.min(16, ms - window.__clock.now)); await y(); }
    }, ms);
    await page.waitForTimeout(700);
    await page.screenshot({ path: path.join(out, `${card}-${ms}.png`) });
    console.log(`${card} at ${ms} ms`);
  }
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
}
fs.writeFileSync(path.join(out, 'cards.json'), JSON.stringify(CARDS.map(([card, times]) => ({ card, times }))));
