// Exports SQUISH TIME (src/screens/SquishScreen.js + src/components/SquishyToy.js + squishCard.js) for the Unity app
// (unity/Assets/Resources/Squish, unity/Assets/Scripts/Games/Squish):
//
//   node tools/unity/export-squish.mjs [--keys mittens,nimbo,...] [--no-hud]
//
//   - cards/<key>.png.bytes   each creature's card atlas (front art left, back art right, 2048 x 1024, transparent PNG),
//                             made exactly as tools/rig/cards.mjs makes the published ones (Storage `creatures/{id}
//                             .card.url`): the design's front / back SVGs drawn by Chrome onto a canvas at 1024 each.
//                             The SVGs come from the design's export (webgame/.cache/<prototype>/squish-squad/export/
//                             tripo). Storage itself is only reachable signed in (the app's /__fbstorage/ relay), so
//                             these are rebuilt, not downloaded: identical to Storage's as long as the art hasn't changed.
//                             (.bytes: Unity loads them with Texture2D.LoadImage, unprocessed, as three uploads them.)
//   - crown.png.bytes         the Best Friend stage's crown (assets/squad/crown.png)
//   - squish.json             src/squad/cardMoves.js (every roster id: head, moves, sq), the roster's key -> id,
//                             STAGE_FX, which keys have a card here
//   - hud/*.xml + hud.json    the screen's pieces as SVG (tools/unity/ui/snap.js) cut from the app's own SquishScreen,
//                             mounted on the Expo web app's preview page (http://localhost:8081, see below), with where
//                             each goes (dp on the A15's 832 x 384 screen)
//
// The Expo web app must be running for the HUD (EXPO_OFFLINE=1 BROWSER=none npx expo start --web --port 8081).
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const OUT = path.join(REPO, 'unity/Assets/Resources/Squish');
const { ROSTER } = require(path.join(REPO, 'functions/squad.js'));
const arg = (k, d) => { const i = process.argv.indexOf(k); return i > 0 ? process.argv[i + 1] : d; };
const KEYS = arg('--keys', 'mittens,nimbo,mallow,bao,pip,jelli').split(',');
const SIDE = 1024;

function designDir() {
  const cache = path.join(REPO, 'webgame/.cache');
  for (const d of fs.existsSync(cache) ? fs.readdirSync(cache).sort().reverse() : []) {
    const p = path.join(cache, d, 'squish-squad/export/tripo');
    if (fs.existsSync(p)) return p;
  }
  throw new Error('no design export in webgame/.cache: run node webgame/build.mjs once (it unpacks the prototype)');
}

export async function exportCards(browser, keys = KEYS) {
  const dir = designDir();
  fs.mkdirSync(path.join(OUT, 'cards'), { recursive: true });
  const page = await browser.newPage();
  await page.setContent('<!doctype html><body></body>');
  const done = [];
  for (const key of keys) {
    const f = path.join(dir, key, `${key}-front.svg`), b = path.join(dir, key, `${key}-back.svg`);
    if (!fs.existsSync(f) || !fs.existsSync(b)) { console.log('no art for', key); continue; }
    const url = await page.evaluate(async ([front, back, SIDE]) => {
      const load = (svg) => new Promise((r) => { const i = new Image(); i.onload = () => r(i); i.onerror = () => r(null); i.src = 'data:image/svg+xml;base64,' + btoa(unescape(encodeURIComponent(svg))); });
      const [fi, bi] = await Promise.all([load(front), load(back)]);
      if (!fi || !bi) return null;
      const c = document.createElement('canvas'); c.width = SIDE * 2; c.height = SIDE;
      const x = c.getContext('2d'); x.drawImage(fi, 0, 0, SIDE, SIDE); x.drawImage(bi, SIDE, 0, SIDE, SIDE);
      return c.toDataURL('image/png');
    }, [fs.readFileSync(f, 'utf8'), fs.readFileSync(b, 'utf8'), SIDE]);
    if (!url) { console.log('FAILED', key); continue; }
    fs.writeFileSync(path.join(OUT, 'cards', `${key}.png.bytes`), Buffer.from(url.split(',')[1], 'base64'));
    done.push(key);
  }
  await page.close();
  console.log(`${done.length} card atlases -> ${path.join(OUT, 'cards')}`);
  return done;
}

export async function exportData(cardKeys) {
  const moves = (await import(pathToFileURL(path.join(REPO, 'src/squad/cardMoves.js')).href)).default;
  // src/squad/data.js STAGE_FX (read from the source: data.js imports the app's modules)
  const src = fs.readFileSync(path.join(REPO, 'src/squad/data.js'), 'utf8');
  const fx = JSON.parse(src.match(/export const STAGE_FX = (\[[^\n]*\]);/)[1].replace(/(\w+):/g, '"$1":'));
  const data = {
    roster: ROSTER.map((c) => ({ id: c.id, key: c.key, name: c.name })),
    moves,
    stageFx: fx,
    cards: cardKeys,
  };
  fs.writeFileSync(path.join(OUT, 'squish.json'), JSON.stringify(data));
  // the Best Friend crown (squishCard.js cardState: assets/squad/crown.png)
  fs.copyFileSync(path.join(REPO, 'assets/squad/crown.png'), path.join(OUT, 'crown.png.bytes'));
  console.log('squish.json:', ROSTER.length, 'creatures');
}

if (process.argv[1] && path.resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const browser = await chromium.launch();
  const keys = await exportCards(browser);
  await exportData(keys);
  if (!process.argv.includes('--no-hud')) {
    const { exportHud } = await import('./squish-test/hud.mjs');
    await exportHud(browser, OUT);
  }
  await browser.close();
}
