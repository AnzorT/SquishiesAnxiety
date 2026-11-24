// Squish Stack's pieces for Unity (unity/Assets/Resources/Stack/), cut out of the app's own level screen (Expo web on
// http://localhost:8081, src/web/Preview.js's "game-stack"; start it with `npx expo start --web --port 8081`):
//   bg.xml                 the page behind the game (PageBg), as SVG (tools/unity/ui/snap.js)
//   back.xml               the back orb
//   btn-<kind>-lip.xml     a button's lip (stays put when pressed), -face.xml its ring, face and label (moves down)
//                          for UNDO (white), RESTART (purple), HINT (gold) and each disabled (grey)
//   img/<hash>.png         pictures the pieces show (the rays behind the page, ...)
//   art/<key>.png          every squishy's cut-out (assets/stack/*.webp), and stack.json: their height / width
//   stack.json             where things are on the reference screen (dp), for checking the Unity layout
//   blitz-bolt.png         Blitz's title's ⚡ (Chrome draws it from Noto Color Emoji) and blitz-heart.png the revive
//   blitz.json             chip's ♥ (from a system font, not the Fallback one), each cut on the page's own pixel grid,
//                          and where each sits from its text's origin (dp), for StackArt.BlitzLeftColumn
// node tools/unity/export-stack.mjs [--blitz-only]
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import crypto from 'node:crypto';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Stack');
fs.mkdirSync(path.join(OUT, 'art'), { recursive: true });

// ---- Blitz's two glyphs that aren't in the app's fonts: the hub's BLITZ GO, then each one cut alone, where it was ---
async function exportBlitz() {
  const { browser, page } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-stack');
  await page.waitForTimeout(5000);
  await page.mouse.click(712, 270); // BLITZ GO
  await page.waitForTimeout(6000);
  const out = {};
  for (const [name, text, ch] of [['bolt', 'SQUISH STACK · BLITZ ⚡', '⚡'], ['heart', '♥ 1 REVIVE', '♥']]) {
    const m = await page.evaluate(([text, ch]) => {
      const el = [...document.querySelectorAll('div')].find((d) => d.childNodes.length === 1 && d.firstChild.nodeType === 3 && d.textContent === text);
      const t = el.firstChild, i = text.indexOf(ch);
      const r = document.createRange();
      r.setStart(t, i); r.setEnd(t, i + ch.length);
      const g = r.getBoundingClientRect();
      let after = { width: 0 };
      if (i + ch.length < text.length) { r.setStart(t, i + ch.length); r.setEnd(t, i + ch.length + 1); after = r.getBoundingClientRect(); }
      const e = el.getBoundingClientRect();
      // the same text over a hidden page, everything but the glyph hidden, at the same spot
      const cs = getComputedStyle(el);
      const o = document.createElement('div');
      o.id = '__glyph';
      Object.assign(o.style, { position: 'fixed', left: e.left + 'px', top: e.top + 'px', width: e.width + 'px', font: cs.font, letterSpacing: cs.letterSpacing, color: cs.color, whiteSpace: 'pre', visibility: 'visible', margin: 0, padding: 0 });
      o.innerHTML = [...text].map((c) => `<span style="visibility:${c === ch ? 'visible' : 'hidden'}">${c}</span>`).join('');
      document.getElementById('root').style.visibility = 'hidden';
      document.documentElement.style.background = 'transparent';
      document.body.style.background = 'transparent';
      document.body.appendChild(o);
      return { g: [g.x, g.y, g.width, g.height], e: [e.x, e.y], next: after.width ? after.x : g.right };
    }, [text, ch]);
    // the glyph's box rounded out to whole device pixels, with a pixel to spare
    const D = 2.8125;
    const x0 = Math.floor(m.g[0] * D) - 1, y0 = Math.floor(m.g[1] * D) - 1, x1 = Math.ceil((m.g[0] + m.g[2]) * D) + 1, y1 = Math.ceil((m.g[1] + m.g[3]) * D) + 1;
    await page.screenshot({ path: path.join(OUT, `blitz-${name}.png`), omitBackground: true, clip: { x: x0 / D, y: y0 / D, width: (x1 - x0) / D, height: (y1 - y0) / D } });
    out[name] = { box: [x0 / D - m.e[0], y0 / D - m.e[1], (x1 - x0) / D, (y1 - y0) / D].map((v) => +v.toFixed(4)), advance: +(m.next - m.g[0]).toFixed(4) };
    await page.evaluate(() => { document.getElementById('__glyph').remove(); document.getElementById('root').style.visibility = ''; });
  }
  // UNDO and RESTART on (after a move: Blitz's first puzzle, a legal move from its start); the level's export above
  // catches them before they've come on
  await page.waitForTimeout(3000);
  const mv = await page.evaluate(() => {
    const root = document.getElementById('root');
    let f;
    for (const k in root) if (k.startsWith('__reactContainer$')) f = root[k];
    if (f.stateNode && f.stateNode.current) f = f.stateNode.current;
    let game = null;
    const walk = (x) => { for (; x && !game; x = x.sibling) { if (typeof x.type === 'function' && x.type.name === 'StackGame') { game = x; return; } if (x.child) walk(x.child); } };
    walk(f);
    let pz = null;
    for (let h = game.memoizedState; h; h = h.next) if (Array.isArray(h.memoizedState) && h.memoizedState[0] && h.memoizedState[0].sol) pz = h.memoizedState[0];
    const top = (c) => pz.start.indexOf(c);
    const k = pz.sol.k;
    for (let a = 0; a < k; a++) for (let b = 0; b < k; b++) if (a !== b && top(a) >= 0 && (top(b) < 0 || top(b) > top(a))) return [a, b, k];
    return null;
  });
  const col = (c) => 250 + ((c + 0.5) * 432) / mv[2];
  await page.mouse.click(col(mv[0]), 300);
  await page.mouse.click(col(mv[1]), 300);
  await page.waitForTimeout(1500);
  const lay = { buttons: {} };
  await button(0, 'on', page, lay);
  await button(1, 'on', page, lay);
  out.buttons = lay.buttons;
  fs.writeFileSync(path.join(OUT, 'blitz.json'), JSON.stringify(out, null, 1));
  console.log('blitz glyphs:', JSON.stringify(out));
  await browser.close();
}
if (process.argv.includes('--blitz-only')) {
  await exportBlitz();
  process.exit(0);
}

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

// ---- the level screen ------------------------------------------------------------------------------------------
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-stack');
await page.waitForTimeout(5000);
await page.mouse.click(705, 143);   // the hub's REGULAR PLAY -> the map
await page.waitForTimeout(3000);
await page.mouse.click(416, 187);   // level 12
await page.waitForTimeout(1500);    // the intro: every button is disabled (grey)

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
  const kind = state === 'grey' ? 'grey' : label === 'UNDO' ? 'white' : label === 'RESTART' ? 'purple' : 'gold';
  const name = `btn-${label.replace(/\W+/g, '').toLowerCase()}-${state === 'grey' ? 'off' : 'on'}`;
  const b = await parts.evaluate((p) => {
    const r = p.b.getBoundingClientRect(), l = p.lip.getBoundingClientRect(), g = p.ring.getBoundingClientRect();
    return { b: [r.x, r.y, r.width, r.height], lip: [l.x - r.x, l.y - r.y, l.width, l.height], ring: [g.x - r.x, g.y - r.y, g.width, g.height] };
  });
  save(name + '-lip', await snap(pg, await parts.evaluateHandle((p) => p.lip)));
  save(name + '-face', await snap(pg, await parts.evaluateHandle((p) => p.ring)));
  lay.buttons[name] = { label, kind, ...b };
}

for (let i = 0; i < 3; i++) await button(i, 'grey');
await page.waitForTimeout(8000);    // dealt and playing: HINT is on
await button(2, 'on');
// a move, so UNDO and RESTART come on: lift from each column in turn and put it on the next until MOVES isn't 0
const area = { x0: 250, x1: 832 - 150 };
for (let tries = 0; tries < 6; tries++) {
  const moves = await page.evaluate(() => {
    const t = [...document.querySelectorAll('div')].find((d) => d.innerText === 'MOVES');
    return t ? Number(t.nextElementSibling?.innerText) : 0;
  });
  if (moves > 0) break;
  const col = (c) => area.x0 + ((c + 0.5) * (area.x1 - area.x0)) / 3;
  await page.mouse.click(col(tries % 3), 300);
  await page.waitForTimeout(500);
  await page.mouse.click(col((tries + 1) % 3), 300);
  await page.waitForTimeout(1200);
}
await button(0, 'on');
await button(1, 'on');

save('bg', await snap(page, await page.evaluateHandle(() => window.__components('PageBg').pop().el)));
save('back', await snap(page, await page.evaluateHandle(() => window.__components('Orb')[0].el)));
layout.back = box(await page.evaluate(() => window.__components('Orb')[0].el.getBoundingClientRect().toJSON()));
for (const n of ['GoalCard', 'Meter', 'Seat']) {
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
await exportBlitz();
