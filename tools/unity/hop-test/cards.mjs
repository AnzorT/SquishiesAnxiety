// Squish Hop's cards as the app shows them (Expo web, src/web/Preview.js: hop-result, hop-stuck, hop-pause,
// hop-hint with Preview's sample data), at known moments: the page's clock is replaced by tools/unity/rig/
// virtual-clock.js once it has loaded, the card is opened at virtual time 0, and the clock is stepped 16 ms a frame
// (the last step lands on the moment exactly), as Program.cs steps the Unity card.  node cards.mjs <out dir> [card ...]
//   <out>/<card>-<ms>.png  the screen at that moment          <out>/cards.json  which cards and moments
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out, ...only] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
// moments while it moves, and one where it has settled (none while a star's gold sparks fly, 440-2040 ms: they are random,
// and the page only starts a burst once React has rendered it, after the stepping)
const CARDS = [
  ['hop-result', [300, 2300, 7200]],
  ['hop-stuck', [400, 3600]],
  ['hop-hint', [150, 2000]],
];
const clock = fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8');
for (const [card, times] of CARDS) {
  if (only.length && !only.includes(card)) continue;
  // a fresh page for each card: nothing on it yet, then the virtual clock, then the card
  const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=none');
  await page.waitForTimeout(5000);
  await page.evaluate(clock);
  await page.evaluate((c) => window.__preview(c), card);
  await page.waitForTimeout(1500);   // React commits (twice for the result) at virtual time 0
  for (const ms of times) {
    await page.evaluate((ms) => {
      while (window.__clock.now < ms) window.__clock.frame(Math.min(16, ms - window.__clock.now));
    }, ms);
    await page.waitForTimeout(700);   // React renders what the last frame set (the counting coins)
    await page.screenshot({ path: path.join(out, `${card}-${ms}.png`) });
    console.log(`${card} at ${ms} ms`);
  }
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
}
fs.writeFileSync(path.join(out, 'cards.json'), JSON.stringify(CARDS.map(([card, times]) => ({ card, times }))));
