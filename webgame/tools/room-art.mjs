// The Level Pass's pictures of what a level unlocks (REDESIGN_V9, 2026-11-16, the user: "change the images of the crib
// room that unlock to be more better looking"): each room as the house's own map draws it, all of them open (level 30)
// on a summer day, without the map's labels; and the house's next look (Cozy home, Lovely home, Royal palace) as the
// map draws the house at levels 14, 24 and 30. The house page runs offline from the build, as webgame/test/smoke.mjs
// runs it.
//
//   node webgame/build.mjs
//   NODE_PATH=<a folder with playwright> node webgame/tools/room-art.mjs   -> webgame/app/art/rooms/*.jpg
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const DIR = path.join(REPO, 'android/app/src/main/assets/webgame');
const OUT = path.join(REPO, 'webgame/app/art/rooms');
fs.mkdirSync(OUT, { recursive: true });

// where each room is on the map, in its 852 x 393 view: [centre x, centre y, width], cropped 4:3 round it (160 x 120
// unless said); `yard` is the Yard Games: closer in on the backyard's hoop and ball
const ROOMS = {
  bedroom: [255, 165], kitchen: [250, 236], living: [393, 216], dance: [395, 112], bathroom: [525, 172],
  movie: [525, 246], backyard: [666, 248], beach: [715, 128], yard: [630, 262, 100],
};
const HOUSE = { x: 172, y: 70, width: 420, height: 215 }; // the whole house, for its looks
const TIERS = { 1: 14, 2: 24, 3: 30 }; // tier -> its last level (Cozy home, Lovely home, Royal palace): its rooms open, no boards

const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const ctx = await browser.newContext({ viewport: { width: 852, height: 393 }, deviceScaleFactor: 2 });
// a summer day: the map's weather follows the month
await ctx.addInitScript(() => {
  const RealDate = Date, shift = RealDate.UTC(2026, 6, 15, 11) - RealDate.now();
  class D extends RealDate { constructor(...a) { if (a.length) super(...a); else super(RealDate.now() + shift); } static now() { return RealDate.now() + shift; } }
  window.Date = D;
});
const page = await ctx.newPage();
page.on('pageerror', e => console.log('pageerror', e.message.slice(0, 200)));
await page.route(/^(https?|wss?):/, r => r.abort());
const url = pathToFileURL(path.join(DIR, 'App.dc.html')).href + '?screen=house';

async function mapAt(level) {
  await page.goto(url);
  await page.waitForTimeout(5000);
  await page.evaluate(L => window.SquishProfile.set({ level: L }), level);
  await page.goto(url);
  await page.waitForTimeout(22000);
  await page.mouse.click(58, 40); // the map
  await page.waitForTimeout(3000);
  // the map's labels, pins and faces off: hide each text's small box (walking up while it stays small)
  await page.evaluate(() => {
    const leaves = [...document.querySelectorAll('body *')].filter(e => !e.children.length && (e.textContent || '').trim());
    for (const e of leaves) {
      let top = e;
      for (let x = e.parentElement; x && x !== document.body; x = x.parentElement) {
        const r = x.getBoundingClientRect();
        if (r.width > 330 || r.height > 70) break;
        top = x;
      }
      top.style.visibility = 'hidden';
    }
    // the creatures' faces and the "you're here" pin are pictures in small round boxes
    document.querySelectorAll('img').forEach(im => { const r = im.getBoundingClientRect(); if (r.width < 60) im.style.visibility = 'hidden'; });
  });
  await page.waitForTimeout(400);
}
const shot = (file, clip) => page.screenshot({ path: path.join(OUT, file), type: 'jpeg', quality: 86, clip });

await mapAt(30);
for (const [k, [cx, cy, w = 160]] of Object.entries(ROOMS)) await shot(k + '.jpg', { x: cx - w / 2, y: cy - (w * 3) / 8, width: w, height: (w * 3) / 4 });
for (const [t, L] of Object.entries(TIERS)) {
  await mapAt(L);
  await shot('tier' + t + '.jpg', HOUSE);
}
await browser.close();
for (const f of fs.readdirSync(OUT)) console.log(f, Math.round(fs.statSync(path.join(OUT, f)).size / 1024) + ' KB');
