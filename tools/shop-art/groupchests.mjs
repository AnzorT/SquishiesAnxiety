// Renders the v6 design's group chests (chest-models.js + chest-<group>.js,
// drawn the way "Chest Art v2.dc.html" draws them) to images for the Shop
// (REDESIGN_V6 step 5), in headless Chrome. Three looks:
//   grow  every group × size in a 240×200 box, sized up with the chest
//         (Chest Art v2's `grow`): the "All chests" carousel and its sheet
//   tile  Common and Rare in a 300×192 box: the Free and Rare chest tiles
//   deal  Legendary in a 224×212 box without its glow: the daily deal
// All at 2×, transparent WebP, the art's spinning parts at rest. Also each
// group's card backdrop (chest-loot.js GROUPS bg, with the card's white
// centre glow): bg-<group>.webp, 400×232 at 2×.
//
//   node tools/shop-art/groupchests.mjs
// Output: assets/squad/gchests/<group>-<size>-<look>.webp and
// src/squad/groupChestArt.js (the require map).

import fs from 'node:fs';
import http from 'node:http';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { connect, evaluate } from './cdp.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const DESIGN = path.join(ROOT, 'tools/design-v6');
const OUT = path.join(ROOT, 'assets/squad/gchests');
const OUT_JS = path.join(ROOT, 'src/squad/groupChestArt.js');
const GROUPS = ['snack', 'fruit', 'ocean', 'pet', 'forest', 'sky', 'dream', 'bakery', 'heroes', 'elemental', 'spooky'];
const SIZES = ['common', 'rare', 'epic', 'legendary', 'set'];
const LOOKS = {
  grow: { w: 240, h: 200, grow: true, glow: true, sizes: SIZES },
  tile: { w: 300, h: 192, grow: false, glow: true, sizes: ['common', 'rare'] },
  deal: { w: 224, h: 212, grow: false, glow: false, sizes: ['legendary'] },
};
const DPR = 2;
const SCRIPTS = ['chest-loot.js', 'chest-models.js', 'chest-fruit.js', 'chest-ocean.js', 'chest-pet.js', 'chest-kit.js', 'chest-forest.js', 'chest-sky.js', 'chest-dream.js', 'chest-bakery.js', 'chest-heroes.js', 'chest-elemental.js', 'chest-spooky.js'];
const PORT = 9600 + Math.floor(Math.random() * 300);

const PAGE = `<!doctype html><html><head><style>html,body{margin:0;background:transparent}#bg{position:absolute;left:0;top:0;width:400px;height:232px}#bg>div{position:absolute;inset:0;background:radial-gradient(circle at 50% 58%, rgba(255,255,255,0.6) 0, rgba(255,255,255,0) 55%)}</style>
${SCRIPTS.map((f) => `<script src="/${f}"></script>`).join('\n')}
</head><body><canvas id="cv"></canvas><div id="bg"><div></div></div><script>
window.bgOf = (g) => { document.getElementById('cv').style.display = 'none'; document.getElementById('bg').style.background = window.ChestLoot.GK[g].bg; return true; };
// Chest Art v2's geo() and render(), at T = 0
const TAU = Math.PI * 2, IDW = (x, y, o) => { o[0] = x; o[1] = y; };
const rgba = (h, a) => { const n = parseInt(h.slice(1), 16); return 'rgba(' + (n >> 16) + ',' + ((n >> 8) & 255) + ',' + (n & 255) + ',' + a.toFixed(3) + ')'; };
window.draw = (g, ti, w, h, grow, glow, d) => {
  const CM = window.ChestModels, m = CM.model(g, ti), cv = document.getElementById('cv');
  cv.width = w * d; cv.height = h * d; cv.style.width = w + 'px'; cv.style.height = h + 'px';
  const c = cv.getContext('2d'); c.setTransform(1, 0, 0, 1, 0, 0); c.clearRect(0, 0, cv.width, cv.height);
  const fit = (mm) => { const bb = mm.bb; return Math.min(w * 0.92 / (bb.x1 - bb.x0), h * 0.84 / (6 - bb.y0)); };
  let s = fit(m);
  if (grow) { let mx = Infinity; for (let i = 0; i < 5; i++) mx = Math.min(mx, fit(CM.model(g, i))); s = mx * Math.pow(s / mx, 0.45); }
  const G = { s, x: w / 2 - (m.bb.x0 + m.bb.x1) / 2 * s, y: h * 0.91 };
  c.save(); c.setTransform(d, 0, 0, d, 0, 0); c.translate(G.x, G.y); c.scale(G.s, G.s);
  if (ti >= 3 && glow) {
    const R = Math.max(m.W, m.H) * 0.75, cy = -m.H * 0.5, a = 0.5, gr = c.createRadialGradient(0, cy, 0, 0, cy, R);
    gr.addColorStop(0, 'rgba(255,255,255,' + a.toFixed(3) + ')'); gr.addColorStop(0.4, rgba(ti === 4 ? '#ff9fd6' : '#ffd84a', a * 0.7)); gr.addColorStop(1, rgba(ti === 4 ? '#9fd8ff' : '#ffd84a', 0));
    c.fillStyle = gr; c.fillRect(-R, cy - R, R * 2, R * 2);
  }
  c.save(); c.scale(1, 0.14); const sg = c.createRadialGradient(0, 14, 0, 0, 14, m.W * 0.55); sg.addColorStop(0, 'rgba(42,10,40,0.3)'); sg.addColorStop(1, 'rgba(42,10,40,0)'); c.fillStyle = sg; c.beginPath(); c.arc(0, 14, m.W * 0.55, 0, TAU); c.fill(); c.restore();
  for (const p of m.parts) CM._drawPart(c, p, IDW, 0, 0);
  c.restore();
  return { url: cv.toDataURL('image/webp', 0.9), name: m.name };
};
</script></body></html>`;

const server = http
  .createServer((req, res) => {
    const p = decodeURIComponent(new URL(req.url, 'http://x').pathname);
    if (p === '/') return res.writeHead(200, { 'Content-Type': 'text/html' }).end(PAGE);
    const file = path.join(DESIGN, p);
    if (!file.startsWith(DESIGN) || !fs.existsSync(file)) return res.writeHead(404).end();
    res.writeHead(200, { 'Content-Type': 'text/javascript' }).end(fs.readFileSync(file));
  })
  .listen(PORT);

const { send, close } = await connect();
const names = {};
const lines = [];
try {
  await send('Page.navigate', { url: `http://127.0.0.1:${PORT}/` });
  let ok = false;
  for (let i = 0; i < 100 && !ok; i++) {
    await new Promise((r) => setTimeout(r, 150));
    ok = await evaluate(send, `!!(window.ChestModels && ${JSON.stringify(GROUPS)}.every((g) => window.ChestModels.groups.includes(g)))`).catch(() => false);
  }
  if (!ok) throw new Error('the chest models never loaded');
  fs.mkdirSync(OUT, { recursive: true });
  for (const g of GROUPS) {
    const row = [];
    for (const [look, L] of Object.entries(LOOKS)) {
      for (const size of L.sizes) {
        const ti = SIZES.indexOf(size);
        const r = await evaluate(send, `window.draw(${JSON.stringify(g)}, ${ti}, ${L.w}, ${L.h}, ${L.grow}, ${L.glow}, ${DPR})`);
        fs.writeFileSync(path.join(OUT, `${g}-${size}-${look}.webp`), Buffer.from(r.url.split(',')[1], 'base64'));
        names[g] = names[g] || [];
        names[g][ti] = r.name;
        row.push(`'${size}-${look}': require('../../assets/squad/gchests/${g}-${size}-${look}.webp')`);
      }
    }
    await evaluate(send, `window.bgOf(${JSON.stringify(g)})`);
    await new Promise((r) => setTimeout(r, 60));
    const shot = await send('Page.captureScreenshot', { format: 'webp', quality: 90, clip: { x: 0, y: 0, width: 400, height: 232, scale: DPR } });
    fs.writeFileSync(path.join(OUT, `bg-${g}.webp`), Buffer.from(shot.data, 'base64'));
    await evaluate(send, `document.getElementById('cv').style.display = ''`);
    row.push(`bg: require('../../assets/squad/gchests/bg-${g}.webp')`);
    lines.push(`  ${g}: { ${row.join(', ')} },`);
    process.stdout.write(`${g} `);
  }
  console.log();
} finally {
  close();
  server.close();
}

fs.writeFileSync(
  OUT_JS,
  `// Generated by tools/shop-art/groupchests.mjs — don't edit.\n// The design's group chests (chest-models.js), by group: '<size>-<look>'\n// (grow 240×200, tile 300×192, deal 224×212; drawn at ${DPR}×),\n// and 'bg', the group's card backdrop (400×232).\nexport const CHEST_NAMES = ${JSON.stringify(names)};\nexport default {\n${lines.join('\n')}\n};\n`,
);
console.log(`→ ${path.relative(ROOT, OUT)}, ${path.relative(ROOT, OUT_JS)}`);
