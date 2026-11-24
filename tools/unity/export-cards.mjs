// The games' cards' exported pieces for Unity (unity/Assets/Resources/Cards/), cut out of the app's own cards (Expo web
// on http://localhost:8081, src/web/Preview.js; start it with `npx expo start --web --port 8081`):
//   coin.xml   the coin (squad/ui.js CoinIcon, 26 dp) beside a result's coins
// Everything else on the cards changes with what they show (numbers, sizes, labels) and is drawn by the Unity code
// (Assets/Scripts/Ui/Cards), the way the exporter writes what Chrome painted.
// node tools/unity/export-cards.mjs
import fs from 'node:fs';
import path from 'node:path';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Cards');
fs.mkdirSync(OUT, { recursive: true });
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=stack-result');
await page.waitForTimeout(9000);   // settled
// the coin: the 26 x 26 view holding the coin's <svg> in the reward row
const coin = await page.evaluateHandle(() => [...document.querySelectorAll('svg')].find((s) => s.getAttribute('viewBox') === '0 0 64 64' && s.innerHTML.includes('_cf"')).parentElement);
const s = await snap(page, coin);
if (Object.keys(s.images).length || s.rasters.length) throw new Error('the coin has pictures: save them as in export-stack.mjs');
// (snap.js measures with every transform off: the copied <svg> keeps that inline style, which means nothing here)
fs.writeFileSync(path.join(OUT, 'coin.xml'), s.svg.split(' style="transform: none !important;"').join(''));
console.log(`coin.xml ${s.w} x ${s.h}, ${s.svg.length} bytes`);
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
