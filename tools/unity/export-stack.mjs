// Squish Stack's pieces for Unity (unity/Assets/Resources/Stack/), cut out of the app's own level screen (Expo web on
// http://localhost:8081, src/web/Preview.js's "game-stack"; start it with `npx expo start --web --port 8081`):
//   bg.xml                 the page behind the game (PageBg), as SVG (tools/unity/ui/snap.js)
//   back.xml               the back orb
//   btn-<kind>-lip.xml     a button's lip (stays put when pressed), -face.xml its ring, face and label (moves down)
//                          for RESTART (purple) and HINT (gold) and each disabled (grey) (develop: no UNDO)
//   img/<hash>.png         pictures the pieces show (the rays behind the page, ...)
//   art/<key>.png          every squishy's cut-out (assets/stack/*.webp), and stack.json: their height / width
//   stack.json             where things are on the reference screen (dp), for checking the Unity layout
//   mode-regular.png, mode-blitz.png   the hub's mode panels' pictures (assets/stack/mode-*.jpg; the panels are
//                          Squishdoku's, Games/Shared/ModeHub)
// (develop's Blitz screen is the level's, with CLEARED / BEST and the rule's chip: nothing of its own to cut out)
// node tools/unity/export-stack.mjs
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import crypto from 'node:crypto';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Stack');
fs.mkdirSync(path.join(OUT, 'art'), { recursive: true });

// ---- the squishies' cut-outs (Unity doesn't read WebP) ----------------------------------------------------------
const artJs = fs.readFileSync(path.join(ROOT, 'src', 'stack', 'art.js'), 'utf8');
const art = {};
for (const m of artJs.matchAll(/(\w+): \{ src: require\('\.\.\/\.\.\/assets\/stack\/(\w+)\.webp'\), ar: ([\d.]+) \}/g)) art[m[1]] = { file: m[2], ar: +m[3] };
execFileSync('python3', ['-c', `
import sys, os
from PIL import Image
src, dst = sys.argv[1], sys.argv[2]
for f in sorted(os.listdir(src)):
    if f.endswith('.webp'):
        Image.open(os.path.join(src, f)).convert('RGBA').save(os.path.join(dst, f[:-5] + '.png'), optimize=True)
`, path.join(ROOT, 'assets', 'stack'), path.join(OUT, 'art')]);
console.log(`art: ${Object.keys(art).length} squishies`);
// the hub's mode pictures (JPEG to PNG: the tests read PNG)
execFileSync('python3', ['-c', `
import sys
from PIL import Image
for k in ('regular', 'blitz'):
    Image.open(sys.argv[1] + '/mode-' + k + '.jpg').convert('RGB').save(sys.argv[2] + '/mode-' + k + '.png', optimize=True)
`, path.join(ROOT, 'assets', 'stack'), OUT]);

// ---- the level screen ------------------------------------------------------------------------------------------
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-stack');
await page.waitForTimeout(5000);
await page.mouse.click(218, 180);   // the hub's REGULAR MODE -> the forest map
await page.waitForTimeout(3500);
await page.mouse.click(416, 283);   // level 12 (the next one to play, where the walker stands)
await page.waitForTimeout(1500);    // the intro: both buttons are disabled (grey)

// a piece's SVG; its pictures (inlined as data URLs by snap) become PNG files in img/, named by their content
fs.mkdirSync(path.join(OUT, 'img'), { recursive: true });
function save(name, s) {
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
    svg = svg.split(`href="${data}"`).join(`href="Stack/img/${hash}"`);
  }
  fs.writeFileSync(path.join(OUT, name + '.xml'), svg);
}
const box = (r) => [r.x, r.y, r.width, r.height].map((v) => +v.toFixed(3));
const layout = { screen: [832, 384], buttons: {} };

// a button: its lip and its ring (the face moves inside the ring) as two pieces, both in the button's box
async function button(i, state, pg = page, lay = layout) {
  const parts = await pg.evaluateHandle((i) => {
    const b = window.__components('SdButton')[i].el;
    const inner = b.firstElementChild;   // the Animated.View that scales
    // (a label with an outline is drawn 4 times: the copies under it and itself)
    const texts = [...inner.querySelectorAll('*')].filter((e) => e.childNodes.length && [...e.childNodes].every((n) => n.nodeType === 3)).map((e) => e.textContent.trim());
    return { b, lip: inner.children[0], ring: inner.children[1], label: [...new Set(texts)][0] || '' };
  }, i);
  const label = await parts.evaluate((p) => p.label);
  const kind = state === 'grey' ? 'grey' : label === 'RESTART' ? 'purple' : 'gold';
  const name = `btn-${label.replace(/\W+/g, '').toLowerCase()}-${state === 'grey' ? 'off' : 'on'}`;
  const b = await parts.evaluate((p) => {
    const r = p.b.getBoundingClientRect(), l = p.lip.getBoundingClientRect(), g = p.ring.getBoundingClientRect();
    return { b: [r.x, r.y, r.width, r.height], lip: [l.x - r.x, l.y - r.y, l.width, l.height], ring: [g.x - r.x, g.y - r.y, g.width, g.height] };
  });
  save(name + '-lip', await snap(pg, await parts.evaluateHandle((p) => p.lip)));
  save(name + '-face', await snap(pg, await parts.evaluateHandle((p) => p.ring)));
  lay.buttons[name] = { label, kind, ...b };
}

// (develop, 2026-11-16: no UNDO; RESTART and HINT side by side at the bottom right)
for (let i = 0; i < 2; i++) await button(i, 'grey');
await page.waitForTimeout(8000);    // dealt and playing: HINT is on
await button(1, 'on');
// a move, so RESTART comes on: lift from each column in turn and put it on the next until MOVES isn't 0 (the cushions
// sit between the two 200 dp side columns)
const area = { x0: 200, x1: 832 - 200 };
const movesNow = () => page.evaluate(() => {
  const t = [...document.querySelectorAll('div')].find((d) => d.innerText === 'MOVES');
  return t ? parseInt(t.nextElementSibling?.innerText, 10) || 0 : 0;
});
for (let tries = 0; tries < 6; tries++) {
  if ((await movesNow()) > 0) break;
  const col = (c) => area.x0 + ((c + 0.5) * (area.x1 - area.x0)) / 3;
  await page.mouse.click(col(tries % 3), 300);
  await page.waitForTimeout(500);
  await page.mouse.click(col((tries + 1) % 3), 300);
  await page.waitForTimeout(1200);
}
await button(0, 'on');
// the counter (MOVES n / par and the tier) and the controls' row, where the app lays them out
layout.counter = box(await page.evaluate(() => [...document.querySelectorAll('div')].find((d) => d.innerText === 'MOVES').parentElement.parentElement.getBoundingClientRect().toJSON()));
layout.moves = await movesNow();
save('bg', await snap(page, await page.evaluateHandle(() => window.__components('PageBg').pop().el)));
// (the level's back orb: the forest map's is kept, laid out of sight, under the level)
const orb = () => window.__components('Orb').map((c) => c.el).filter((e) => e && e.getBoundingClientRect().width > 0).pop();
save('back', await snap(page, await page.evaluateHandle(orb)));
layout.back = box(await page.evaluate((f) => eval(f)().getBoundingClientRect().toJSON(), `(${orb})`));
for (const n of ['GoalCard', 'Seat']) {
  layout[n] = await page.evaluate((n) => window.__components(n).map((c) => c.el.getBoundingClientRect().toJSON()), n).then((l) => l.map(box));
}
layout.art = art;
// (the same as lists, for Unity's JsonUtility)
layout.artList = Object.entries(art).map(([key, a]) => ({ key, file: a.file, ar: a.ar }));
layout.buttonList = Object.entries(layout.buttons).map(([name, b]) => ({ name, b: b.b }));
fs.writeFileSync(path.join(OUT, 'stack.json'), JSON.stringify(layout, null, 1));
await page.screenshot({ path: path.join(ROOT, 'unity', 'Reference', 'stack-level.png') });
console.log('buttons:', Object.keys(layout.buttons).join(' '));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
