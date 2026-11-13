// Screenshots of the design prototype (Squish Squad Prototype Nov13.zip, extracted).
//   cd tools/design-shots && npm i --no-save playwright react@18.3.1 react-dom@18.3.1 @babel/standalone@7.29.0 three@0.128.0
//   (if Chromium is missing: npx playwright install chromium)
//   node shoot.js ../design-nov13/squish-squad ./out            -> out/*.png, one per screen below
//   node shoot.js ../design-nov13/squish-squad ./out "Main Menu.dc.html"   -> just that page
// It serves the folder itself and answers the CDN requests (React, Babel, three.js) from node_modules here,
// so it also works where unpkg.com is blocked. Google Fonts are skipped (pages fall back to system fonts).
const http = require('http'), fs = require('fs'), path = require('path');
const { chromium } = require('playwright');
const [, , ROOT = '../design-nov13/squish-squad', OUT = './out', ...ONLY] = process.argv;
const NM = path.join(__dirname, 'node_modules');
const LIB = u => u.includes('babel') ? '@babel/standalone/babel.min.js' : u.includes('react-dom') ? 'react-dom/umd/react-dom.production.min.js'
  : u.includes('three') ? 'three/build/three.min.js' : 'react/umd/react.production.min.js';
const TYPES = { '.html': 'text/html', '.js': 'text/javascript', '.json': 'application/json', '.svg': 'image/svg+xml', '.png': 'image/png', '.jpg': 'image/jpeg',
  '.webp': 'image/webp', '.wav': 'audio/wav', '.mp3': 'audio/mpeg', '.csv': 'text/csv', '.css': 'text/css' };
// [file, wait ms, what to do before the shot]
const SHOTS = [
  ['Main Menu.dc.html', 9000, null],
  ['Main Menu.dc.html', 9000, async p => { await p.click('.mm-tab >> nth=3'); await p.waitForTimeout(2000); }, 'Main Menu - games'],
  ['Squad House v6.dc.html', 30000, null],
  ['All Creatures Animations.dc.html', 9000, null],
  ['Yard Mini Games.dc.html', 9000, null],
  ['Shop Screen v5.dc.html', 9000, null],
  ['Squad Select v2.dc.html', 9000, null],
  ['Chest Smash v2.dc.html', 9000, null],
];
(async () => {
  fs.mkdirSync(OUT, { recursive: true });
  const srv = http.createServer((q, s) => { const f = path.join(ROOT, decodeURIComponent(q.url.split('?')[0])); fs.readFile(f, (e, b) => { if (e) { s.writeHead(404); s.end(); return; } s.writeHead(200, { 'Content-Type': TYPES[path.extname(f)] || 'application/octet-stream' }); s.end(b); }); }).listen(8797);
  const b = await chromium.launch();
  for (const [file, wait, act, name] of SHOTS.filter(s => !ONLY.length || ONLY.includes(s[0]))) {
    const p = await b.newPage({ viewport: { width: 1280, height: 800 }, deviceScaleFactor: 2 }); const errs = [];
    p.on('pageerror', e => errs.push(e.message));
    await p.route(/unpkg\.com/, r => r.fulfill({ path: path.join(NM, LIB(r.request().url())), contentType: 'text/javascript' }));
    await p.route(/fonts\.(googleapis|gstatic)\.com/, r => r.fulfill({ body: '', contentType: 'text/css' }));
    await p.goto('http://localhost:8797/' + encodeURIComponent(file)); await p.waitForTimeout(wait);
    if (act) { try { await act(p); } catch (e) { errs.push('action: ' + e.message); } }
    const out = path.join(OUT, (name || file.replace('.dc.html', '')) + '.png'); await p.screenshot({ path: out });
    console.log(out, errs.length ? 'errors: ' + errs.slice(0, 3).join(' | ') : 'ok'); await p.close();
  }
  await b.close(); srv.close();
})();
