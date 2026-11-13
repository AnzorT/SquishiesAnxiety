// Pixel-perfect check: the design prototype exactly as the designer runs it (its own files over http, React from the
// npm package unpkg serves, fonts live from Google Fonts) against the in-app build (file://, offline, vendored React
// and fonts). Both are frozen at the same moment (fake clock, seeded Math.random, CSS animations held at their first
// frame), screenshotted, and compared pixel by pixel. Any differing pixel fails the run.
//
//   node webgame/build.mjs --out webgame/test/out/webgame
//   NODE_USE_ENV_PROXY=1 node webgame/test/pixel-diff.mjs        (needs internet for the reference's Google Fonts)
//
// Writes webgame/test/out/diff/<case>-{proto,app,diff}.png
import fs from 'node:fs';
import path from 'node:path';
import http from 'node:http';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { PNG } from 'pngjs';
import { extractPrototype, WEBGAME } from '../lib/prototype.mjs';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const BUILT = path.join(HERE, 'out/webgame');
const OUT = path.join(HERE, 'out/diff');
fs.mkdirSync(OUT, { recursive: true });
const PROTO = await extractPrototype();

// [case name, page, viewport, fake ms to run after load, real ms to wait for loading]
const CASES = [
  ['main-menu-design', 'Main Menu.dc.html', { width: 1280, height: 800 }, 9000, 8000],
  ['main-menu-app-852', 'App.dc.html', { width: 852, height: 393 }, 9000, 8000],
  ['main-menu-app-pixel9', 'App.dc.html', { width: 924, height: 412 }, 9000, 8000],
  ['house-design', 'Squad House v6.dc.html', { width: 1280, height: 800 }, 6000, 30000],
  ['house-app-852', 'App.dc.html?screen=house', { width: 852, height: 393 }, 6000, 30000],
];
const only = process.argv.slice(2);

const TYPES = { '.html': 'text/html', '.js': 'text/javascript', '.json': 'application/json', '.svg': 'image/svg+xml', '.png': 'image/png', '.jpg': 'image/jpeg',
  '.webp': 'image/webp', '.wav': 'audio/wav', '.mp3': 'audio/mpeg', '.csv': 'text/csv', '.css': 'text/css' };
// the reference: the prototype folder untouched; App.dc.html (the app's own wrapper page) from webgame/app
const server = http.createServer((q, s) => {
  const rel = decodeURIComponent(q.url.split('?')[0]).replace(/^\//, '');
  const f = rel === 'App.dc.html' ? path.join(WEBGAME, 'app', rel) : path.join(PROTO, rel);
  fs.readFile(f, (e, b) => { if (e) { s.writeHead(404); s.end(); return; } s.writeHead(200, { 'Content-Type': TYPES[path.extname(f)] || 'application/octet-stream' }); s.end(b); });
}).listen(0);
const PORT = server.address().port;

const T0 = new Date('2026-11-13T12:00:00Z');
// identical, seeded Math.random on both sides
const SEED = `(() => { let s = 0x2f6b9a1; Math.random = () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; })();`;

async function shoot(browser, url, viewport, fakeMs, realMs, side) {
  const ctx = await browser.newContext({ viewport, deviceScaleFactor: 1 });
  const page = await ctx.newPage();
  const errs = [];
  page.on('pageerror', e => errs.push(e.message));
  if (side === 'proto') {
    // the same load order as the app (app/boot.js: scripts run in the order the page lists them); inert otherwise over http
    await page.addInitScript({ path: path.join(WEBGAME, 'app/boot.js') });
    await page.route(/unpkg\.com\/react-dom@18\.3\.1/, r => r.fulfill({ path: path.join(WEBGAME, 'vendor/react-dom.production.min.js'), contentType: 'text/javascript' }));
    await page.route(/unpkg\.com\/react@18\.3\.1/, r => r.fulfill({ path: path.join(WEBGAME, 'vendor/react.production.min.js'), contentType: 'text/javascript' }));
  } else {
    await page.route(/^https?:/, r => { errs.push('internet: ' + r.request().url()); r.abort(); });
  }
  await page.addInitScript(SEED);
  await page.clock.install({ time: T0 });
  await page.clock.pauseAt(T0);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Animation.enable');
  await cdp.send('Animation.setPlaybackRate', { playbackRate: 0 });
  await page.goto(url);
  await page.waitForTimeout(realMs);         // scripts, pages, art and fonts load (no timers run: the clock is paused)
  for (let t = 0; t < fakeMs; t += 500) {    // then the same 500 ms steps of game time on both sides
    await page.clock.runFor(500);
    await page.waitForTimeout(150);
  }
  await page.evaluate(() => document.fonts.ready);
  await page.waitForTimeout(1500);
  const png = await page.screenshot();
  await ctx.close();
  return { png, errs };
}

function compare(a, b, file) {
  const A = PNG.sync.read(a), B = PNG.sync.read(b);
  if (A.width !== B.width || A.height !== B.height) return { diff: -1 };
  const D = new PNG({ width: A.width, height: A.height });
  let n = 0, box = null;
  for (let y = 0; y < A.height; y++) for (let x = 0; x < A.width; x++) {
    const i = (y * A.width + x) * 4;
    const same = A.data[i] === B.data[i] && A.data[i + 1] === B.data[i + 1] && A.data[i + 2] === B.data[i + 2] && A.data[i + 3] === B.data[i + 3];
    const g = (A.data[i] + A.data[i + 1] + A.data[i + 2]) / 3 * 0.3;
    if (same) { D.data[i] = D.data[i + 1] = D.data[i + 2] = g; } else {
      n++; D.data[i] = 255; D.data[i + 1] = 0; D.data[i + 2] = 60;
      box = box ? [Math.min(box[0], x), Math.min(box[1], y), Math.max(box[2], x), Math.max(box[3], y)] : [x, y, x, y];
    }
    D.data[i + 3] = 255;
  }
  fs.writeFileSync(file, PNG.sync.write(D));
  return { diff: n, total: A.width * A.height, box };
}

const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
let bad = 0;
for (const [name, pg, vp, fakeMs, realMs] of CASES.filter(c => !only.length || only.includes(c[0]))) {
  const [file, query] = pg.split('?');
  const protoUrl = `http://localhost:${PORT}/${encodeURIComponent(file)}${query ? '?' + query : ''}`;
  const appUrl = pathToFileURL(path.join(BUILT, file)).href + (query ? '?' + query : '');
  // CONTROL=1: the prototype against itself, to see what isn't frozen (should be 0 too)
  const [p, a] = [await shoot(browser, protoUrl, vp, fakeMs, realMs, 'proto'), process.env.CONTROL ? await shoot(browser, protoUrl, vp, fakeMs, realMs, 'proto') : await shoot(browser, appUrl, vp, fakeMs, realMs, 'app')];
  fs.writeFileSync(path.join(OUT, name + '-proto.png'), p.png);
  fs.writeFileSync(path.join(OUT, name + '-app.png'), a.png);
  const r = compare(p.png, a.png, path.join(OUT, name + '-diff.png'));
  const ok = r.diff === 0 && !a.errs.length;
  if (!ok) bad++;
  console.log(`${ok ? 'IDENTICAL' : 'DIFFERENT'} ${name}: ${r.diff} of ${r.total} pixels differ${r.box ? ' in box ' + r.box.join(',') : ''}`);
  for (const e of [...new Set(p.errs)].slice(0, 5)) console.log('    proto error:', e.slice(0, 200));
  for (const e of [...new Set(a.errs)].slice(0, 5)) console.log('    app error:', e.slice(0, 200));
}
await browser.close();
server.close();
process.exit(bad ? 1 : 0);
