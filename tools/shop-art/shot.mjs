// A screenshot of one design page, for checking the app's screens against
// it: serves tools/shop-art/design (the older zip's tools/plush-art/design
// for anything it lacks, e.g. daily-challenges.js; assets/x → x), loads the
// page in headless Chrome at a phone size, optionally runs a script on it
// (to switch a tab, open a sheet …), and saves a PNG.
//
//   node tools/shop-art/shot.mjs "Shop Screen v2.dc.html" out.png [--w 390 --h 800 --dpr 1 --wait 1500 --js "…"]
import fs from 'node:fs';
import http from 'node:http';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { connect, evaluate } from './cdp.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const DIRS = [path.join(HERE, 'design'), path.resolve(HERE, '../plush-art/design')];
const MIME = { '.html': 'text/html', '.js': 'text/javascript', '.svg': 'image/svg+xml', '.png': 'image/png', '.webp': 'image/webp', '.css': 'text/css' };
const PORT = 9600 + Math.floor(Math.random() * 300);

const [page, out, ...rest] = process.argv.slice(2);
if (!page || !out) {
  console.log('usage: node tools/shop-art/shot.mjs <page.dc.html> <out.png> [--w 390 --h 800 --dpr 1 --wait 1500 --js "…"]');
  process.exit(1);
}
const opt = { w: 390, h: 800, dpr: 1, wait: 1500, js: '' };
for (let i = 0; i < rest.length; i += 2) opt[rest[i].replace(/^--/, '')] = rest[i + 1];

const server = http
  .createServer((req, res) => {
    const rel = decodeURIComponent(new URL(req.url, 'http://x').pathname).replace(/^\/(assets\/)?/, '');
    const file = DIRS.map((d) => path.join(d, rel)).find((f) => fs.existsSync(f) && fs.statSync(f).isFile());
    if (!file) {
      res.writeHead(404);
      res.end();
      return;
    }
    res.writeHead(200, { 'Content-Type': MIME[path.extname(file)] || 'application/octet-stream' });
    fs.createReadStream(file).pipe(res);
  })
  .listen(PORT);

const { send, close } = await connect();
try {
  await send('Emulation.setDeviceMetricsOverride', { width: Number(opt.w), height: Number(opt.h), deviceScaleFactor: Number(opt.dpr), mobile: true });
  await send('Page.navigate', { url: `http://127.0.0.1:${PORT}/${encodeURIComponent(page)}` });
  await new Promise((r) => setTimeout(r, Number(opt.wait)));
  if (opt.js) {
    console.log('js →', await evaluate(send, opt.js));
    await new Promise((r) => setTimeout(r, Number(opt.wait)));
  }
  const shot = await send('Page.captureScreenshot', { format: 'png' });
  fs.writeFileSync(out, Buffer.from(shot.data, 'base64'));
  console.log(`→ ${out}`);
} finally {
  close();
  server.close();
}
