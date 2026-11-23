// Squish Sort's pieces for Unity (unity/Assets/Resources/Sort/):
//   props.json   the clutter (src/sort/props.js: 16 foods for the fridge, 16 toys for the cupboard), each the inner
//                markup of its 64 x 64 drawing, made by running props.js itself (sucrase for its JSX, react-native-svg's
//                elements written out as SVG)
//   sort.json    each container's squishies to draw from (src/sort/themes.js poolOf: its groups' creatures that are
//                out, not Pass ones) that have a cut-out in Resources/Stack/art (the preview's stills, src/web/Preview.js)
//   bg.xml       the page behind the game (PageBg) and back.xml, the back orb, cut out of the app's level screen
//                (Expo web on http://localhost:8081, src/web/Preview.js's "game-sort") as SVG (tools/unity/ui/snap.js)
//   img/<hash>.png  pictures those pieces show
//   blitz.json   the characters Blitz's HUD has that its fonts don't (the title's ⚡, Chrome's colour emoji, and the
//                revive chip's ♥), each as Chrome draws it (img/blitz-<n>.png) with the box Chrome gave it: SortArt draws
//                the text around them and puts the pictures there
// Everything else on the level screen (the fridges and cupboards, the tray, the HUD, the squishies' marks) changes
// with the level and is drawn by the Unity code (Games/Sort/SortArt.cs) the way the exporter writes what Chrome paints.
// node tools/unity/export-sort.mjs [--no-page] [--no-blitz]
import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
import { createRequire } from 'node:module';
import { execFileSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '..', '..');
const require = createRequire(import.meta.url);
const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Sort');
fs.mkdirSync(OUT, { recursive: true });

// ---- the clutter: props.js run as it is ------------------------------------------------------------------------
const { transform } = require(path.join(ROOT, 'node_modules', 'sucrase'));
const src = fs.readFileSync(path.join(ROOT, 'src', 'sort', 'props.js'), 'utf8');
const cjs = transform(src, { transforms: ['jsx', 'imports'] }).code;
const el = (type) => type;
const React = { createElement: (type, props, ...children) => ({ type, props: { ...(props || {}), children: children.flat(Infinity) } }), memo: (f) => f, Fragment: 'Fragment' };
const svgLib = { __esModule: true, default: 'Svg', Svg: 'Svg', G: 'G', Path: 'Path', Rect: 'Rect', Circle: 'Circle', Ellipse: 'Ellipse' };
const mod = { exports: {} };
new Function('require', 'module', 'exports', cjs)((n) => (n === 'react' ? { __esModule: true, default: React, ...React } : n === 'react-native-svg' ? svgLib : el), mod, mod.exports);
const TAGS = { G: 'g', Path: 'path', Rect: 'rect', Circle: 'circle', Ellipse: 'ellipse' };
const attr = (k) => k.replace(/[A-Z]/g, (c) => '-' + c.toLowerCase());
function write(n) {
  if (n == null || n === false) return '';
  if (Array.isArray(n)) return n.map(write).join('');
  if (n.type === 'Svg' || n.type === 'Fragment') return write(n.props.children);
  const tag = TAGS[n.type];
  if (!tag) throw new Error('props.js: no SVG for ' + n.type);
  const a = Object.entries(n.props).filter(([k, v]) => k !== 'children' && k !== 'key' && !k.startsWith('__') && v != null).map(([k, v]) => ` ${attr(k)}="${v}"`).join('');
  const kids = write(n.props.children);
  return kids ? `<${tag}${a}>${kids}</${tag}>` : `<${tag}${a}/>`;
}
const { Prop, KINDS } = mod.exports;
const props = {};
for (const theme of ['fridge', 'cupboard']) props[theme] = Array.from({ length: KINDS }, (_, k) => write(Prop({ theme, kind: k, size: 64 })));
fs.writeFileSync(path.join(OUT, 'props.json'), JSON.stringify(props));
console.log(`props: ${KINDS} kinds x 2`);

// ---- the squishies each container draws from ----------------------------------------------------------------------
const squad = (await import(path.join(ROOT, 'functions', 'squad.js'))).default;
const artJs = fs.readFileSync(path.join(ROOT, 'src', 'stack', 'art.js'), 'utf8');
const art = {};
for (const m of artJs.matchAll(/(\w+): \{ src: require\('\.\.\/\.\.\/assets\/stack\/(\w+)\.webp'\), ar: ([\d.]+) \}/g)) art[m[1]] = m[2];
const GROUPS = { fridge: ['snack', 'fruit', 'bakery'], cupboard: ['pet', 'forest', 'dream', 'sky'] };
const pools = {};
for (const [theme, groups] of Object.entries(GROUPS)) {
  pools[theme] = Object.values(squad.BY_ID)
    .filter((d) => groups.includes(d.set) && squad.isOut(d, squad.HIDDEN) && !d.pass && art[d.key])
    .map((d) => ({ id: String(d.id), file: art[d.key] }));
}
fs.writeFileSync(path.join(OUT, 'sort.json'), JSON.stringify({ fridge: pools.fridge, cupboard: pools.cupboard }, null, 1));
console.log(`pools: fridge ${pools.fridge.length}, cupboard ${pools.cupboard.length}`);

// ---- the page and the back orb, from the level screen --------------------------------------------------------------
if (!process.argv.includes('--no-page')) {
  const { openApp, snap } = await import('./ui/snap-page.mjs');
  const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-sort');
  await page.waitForTimeout(6000);
  await page.mouse.click(600, 160);   // the hub's PLAY on the fridge's card -> the map
  await page.waitForTimeout(3000);
  await page.evaluate(() => window.__components('LevelMap')[0].props.onPlay(1));
  await page.waitForTimeout(3000);
  fs.mkdirSync(path.join(OUT, 'img'), { recursive: true });
  const save = (name, s) => {
    let svg = s.svg;
    for (const data of new Set(Object.values(s.images))) {
      const bytes = Buffer.from(data.split(',')[1], 'base64');
      const hash = crypto.createHash('sha1').update(bytes).digest('hex').slice(0, 12);
      const file = path.join(OUT, 'img', hash + '.png');
      if (!fs.existsSync(file)) {
        fs.writeFileSync(file + '.src', bytes);
        execFileSync('python3', ['-c', 'import sys; from PIL import Image; Image.open(sys.argv[1]).convert("RGBA").save(sys.argv[2])', file + '.src', file]);
        fs.unlinkSync(file + '.src');
      }
      svg = svg.split(`href="${data}"`).join(`href="Sort/img/${hash}"`);
    }
    fs.writeFileSync(path.join(OUT, name + '.xml'), svg);
  };
  save('bg', await snap(page, await page.evaluateHandle(() => window.__components('PageBg').pop().el)));
  save('back', await snap(page, await page.evaluateHandle(() => window.__components('Orb')[0].el)));
  const back = await page.evaluate(() => window.__components('Orb')[0].el.getBoundingClientRect().toJSON());
  console.log('back orb at', back.x, back.y, back.width, back.height);
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
}

// ---- Blitz's HUD: the characters from a fallback font, from the app's Blitz (the hub's GO) ---------------------------
if (!process.argv.includes('--no-blitz')) {
  const { openApp, snap } = await import('./ui/snap-page.mjs');
  const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-sort');
  await page.waitForTimeout(6000);
  await page.mouse.click(334, 237);   // the hub's BLITZ GO
  await page.waitForTimeout(4000);
  fs.mkdirSync(path.join(OUT, 'img'), { recursive: true });
  const rasters = [];
  for (const [find, size] of [['BLITZ ⚡', 13], ['♥ 1 REVIVE', 11.5]]) {
    const el = await page.evaluateHandle((find) => [...document.querySelectorAll('div')].find((d) => d.childElementCount === 0 && d.textContent.startsWith(find)), find);
    const s = await snap(page, el);
    // each character's box as Chrome laid it out, from the text's top-left
    const boxes = await page.evaluate((el) => {
      const node = el.firstChild, r0 = el.getBoundingClientRect(), range = document.createRange(), out = [];
      for (let i = 0; i < node.data.length; i++) {
        range.setStart(node, i); range.setEnd(node, i + 1);
        const r = range.getBoundingClientRect();
        out.push({ ch: node.data[i], x: r.left - r0.left, y: r.top - r0.top, w: r.width, h: r.height });
      }
      return out;
    }, el);
    for (const r of s.rasters) {
      const b = boxes.find((q) => q.ch === r.ch);
      const file = `blitz-${rasters.length}`;
      fs.writeFileSync(path.join(OUT, 'img', file + '.png'), Buffer.from(s.images[r.id].split(',')[1], 'base64'));
      rasters.push({ ch: r.ch, size, file: 'Sort/img/' + file, w: b.w, h: b.h, dy: b.y, x: b.x });
      console.log(`blitz: ${r.ch} at ${b.x.toFixed(3)} (in "${find}…"), ${b.w.toFixed(3)} x ${b.h.toFixed(3)}, top ${b.y.toFixed(3)}`);
    }
  }
  fs.writeFileSync(path.join(OUT, 'blitz.json'), JSON.stringify({ rasters }, null, 1));
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
}
