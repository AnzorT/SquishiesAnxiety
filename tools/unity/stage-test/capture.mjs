// The app's own rig stage pages (tools/rig/sort.html, hop.html, as the Android app loads them from
// android/app/src/main/assets/rig) in Chromium, given a scene's calls (scenes.mjs) as src/hop/RigStage.js gives them,
// held still once everyone has settled, and shot over a flat colour; Program.cs replays the same calls on the page
// compiled into Unity's rig realm and draws its squishies the way Creatures/StageView does.
//   node tools/unity/stage-test/capture.mjs <out dir> [scene...]     -> <out>/<scene>.png, <scene>.json (the page's boxes)
import fs from 'node:fs';
import http from 'node:http';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';
import { SCENES, BG } from './scenes.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const ASSETS = path.join(REPO, 'android/app/src/main/assets/rig');
const require = createRequire(path.join(REPO, 'tools/package.json'));
const { chromium } = require('playwright');
const [out, ...want] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });

// the pages from tools/rig, everything else (the rig's scripts, the creatures' art) from the app's assets
const TYPES = { '.html': 'text/html', '.js': 'text/javascript', '.svg': 'image/svg+xml', '.json': 'application/json', '.png': 'image/png' };
const server = http.createServer((req, res) => {
  const u = decodeURIComponent(req.url.split('?')[0]).replace(/^\/+/, '');
  const f = /^(sort|hop)\.html$/.test(u) ? path.join(REPO, 'tools/rig', u) : path.join(ASSETS, u);
  if (!f.startsWith(REPO) || !fs.existsSync(f) || fs.statSync(f).isDirectory()) { res.writeHead(404); res.end(); return; }
  res.writeHead(200, { 'content-type': TYPES[path.extname(f)] || 'application/octet-stream' });
  res.end(fs.readFileSync(f));
});
await new Promise((r) => server.listen(0, '127.0.0.1', r));
const port = server.address().port;
const browser = await chromium.launch();
for (const sc of SCENES.filter((s) => !want.length || want.includes(s.name))) {
  const ctx = await browser.newContext({ viewport: { width: sc.W, height: sc.H }, deviceScaleFactor: sc.dpr });
  const page = await ctx.newPage();
  await page.goto(`http://127.0.0.1:${port}/${sc.page}.html`);
  const api = sc.page + 'Stage', outQ = '__' + sc.page + 'Out';
  await page.waitForFunction((o) => (window[o] || []).some((m) => m.type === 'ready'), outQ, { timeout: 60000 });
  await page.evaluate((bg) => { document.body.style.background = bg; }, BG);
  for (const step of sc.steps) {
    if (step.wait) {
      if (step.wait === 'cast') await page.waitForFunction((o) => (window[o] || []).some((m) => m.type === 'cast'), outQ, { timeout: 60000 });
      else await page.waitForTimeout(step.wait);
      continue;
    }
    await page.evaluate(([a, fn, args]) => window[a][fn](...args), [api, step.call, step.args]);
  }
  const msgs = await page.evaluate((o) => window[o] || [], outQ);
  const boxes = await page.evaluate((a) => [...window[a]._C.values()].map((c) => ({ id: c.id, tf: c.el.style.transform, o: c.el.style.opacity, z: c.el.style.zIndex, sh: c.sh ? c.sh.style.transform : null })), api);
  await page.screenshot({ path: path.join(out, sc.name + '.png') });
  fs.writeFileSync(path.join(out, sc.name + '.json'), JSON.stringify({ msgs, boxes }, null, 1));
  console.log(sc.name, JSON.stringify(msgs));
  await ctx.close();
}
await browser.close();
server.close();
