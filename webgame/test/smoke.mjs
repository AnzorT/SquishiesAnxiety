// Opens the built in-app game the way the phone does (file:// pages, no internet) in Chromium and fails on:
// a page error, a file the pages ask for that wasn't shipped, or any attempt to reach the internet.
//   node webgame/build.mjs --out webgame/test/out/webgame && node webgame/test/smoke.mjs [webgame/test/out/webgame]
// Screenshots go to webgame/test/out/smoke/.
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const DIR = path.resolve(process.argv[2] || path.join(HERE, 'out/webgame'));
const SHOTS = path.join(HERE, 'out/smoke');
fs.mkdirSync(SHOTS, { recursive: true });

const VIEWPORTS = { design: { width: 852, height: 393 }, pixel9: { width: 924, height: 412 } };

const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
let failed = 0;
async function run(name, url, viewport, steps) {
  const ctx = await browser.newContext({ viewport, deviceScaleFactor: 1, hasTouch: true });
  const page = await ctx.newPage();
  const problems = [];
  const requested = new Set();
  page.on('pageerror', e => problems.push('pageerror: ' + e.message));
  page.on('console', m => { if (m.type() === 'error') problems.push('console: ' + m.text().slice(0, 300)); });
  page.on('requestfailed', r => problems.push('missing: ' + decodeURIComponent(r.url()).replace(pathToFileURL(DIR).href, '')));
  page.on('request', r => { if (r.url().startsWith('file:')) requested.add(decodeURIComponent(r.url().replace(pathToFileURL(DIR).href + '/', '')).split('?')[0]); });
  await page.route(/^(https?|wss?):/, r => { problems.push('internet: ' + r.request().url().slice(0, 140)); r.abort(); });
  const [file, query] = url.split('?');
  await page.goto(pathToFileURL(path.join(DIR, file)).href + (query ? '?' + query : ''));
  for (const [label, fn] of steps) {
    try { await fn(page); } catch (e) { problems.push(label + ': ' + e.message.split('\n')[0]); }
    await page.screenshot({ path: path.join(SHOTS, `${name}-${label}.png`) });
  }
  await ctx.close();
  const uniq = [...new Set(problems)];
  console.log(`${uniq.length ? 'FAIL' : 'ok  '} ${name} (${requested.size} files loaded)`);
  for (const p of uniq.slice(0, 40)) console.log('   ', p);
  if (uniq.length) failed++;
  return requested;
}

const wait = ms => p => p.waitForTimeout(ms);
const all = new Set();
const add = s => s.forEach(f => all.add(f));
add(await run('menu', 'App.dc.html', VIEWPORTS.design, [
  ['loaded', wait(9000)],
  ['games', async p => { await p.click('.mm-tab >> nth=3'); await p.waitForTimeout(2500); }],
]));
add(await run('menu-pixel9', 'App.dc.html', VIEWPORTS.pixel9, [['loaded', wait(9000)]]));
add(await run('house', 'App.dc.html?screen=house', VIEWPORTS.design, [['loaded', wait(30000)]]));
fs.writeFileSync(path.join(HERE, 'out/requested.json'), JSON.stringify([...all].sort(), null, 1));
await browser.close();
process.exit(failed ? 1 : 0);
