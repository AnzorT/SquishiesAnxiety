// The wood planks behind the Level Pass, Achievements, Characters and Shop (REDESIGN_V9, 2026-11-16, the user: the
// background the Game Park shows its mini games on: the game card's planks). The menu's pages draw it in CSS
// (webgame/app/menu.js WOOD_BG); the app's own screens show this picture of the same CSS (src/royal/parts.js WoodBg),
// rendered once by Chrome at the A15's landscape pixels.
//
//   NODE_PATH=<a folder with playwright> node webgame/tools/wood-bg.mjs   -> assets/royal/wood-bg.jpg
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const OUT = path.join(REPO, 'assets/royal/wood-bg.jpg');
// read from menu.js, so the two can't drift apart
const menu = fs.readFileSync(path.join(REPO, 'webgame/app/menu.js'), 'utf8');
const m = menu.match(/const WOOD_BG = '([^']+)';/);
if (!m) throw new Error('WOOD_BG not found in webgame/app/menu.js');

const browser = await chromium.launch();
const page = await browser.newPage({ viewport: { width: 832, height: 384 }, deviceScaleFactor: 2340 / 832 });
await page.setContent(`<!doctype html><html><body style="margin:0;width:100vw;height:100vh;background:${m[1]}"></body></html>`);
await page.screenshot({ path: OUT, type: 'jpeg', quality: 86 });
await browser.close();
console.log(path.relative(REPO, OUT), Math.round(fs.statSync(OUT).size / 1024) + ' KB');
