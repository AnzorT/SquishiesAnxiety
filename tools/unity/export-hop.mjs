// Squish Hop's pieces for Unity (unity/Assets/Resources/Hop/), from the app's own assets and its level screen (Expo web
// on http://localhost:8081, src/web/Preview.js's "game-hop"; start it with `npx expo start --web --port 8081`):
//   rooms/<room>-<layer>.png   the Crib's room pictures (assets/crib/rooms, src/crib/roomArt.js) a level is played in
//   rug.png                    the Living Room's rug (assets/crib/fixtures/living-rug.webp), laid on the floor under the board
//   flash-glow.png, flash-dots.png   the room-switch flash (src/crib/Hud.js RoomFlash)
//   heads/<key>-happy.png      each creature's happy head (src/squishdoku/heads.js), 96 px: the goal card's stickers
//   heads/<key>-sad.png        its sad head, 192 px: the STUCK! card
//   back-lip.xml, back-top.xml the back button (src/crib/Hud.js CribButton, orange): the lip stays when pressed, the top
//                              moves 3 dp down
//   btn-<kind>-<on|off>-lip.xml / -face.xml   UNDO, RESTART and HINT (squishdoku/ui.js SdButton), on and disabled
//   hop.json                   the cast the app plays with (src/stack/roster.js castOf; drawn from Resources/Stack/art)
//                              and where the exported pieces sit on the reference screen (dp)
// node tools/unity/export-hop.mjs [--reference <png>]   (export-stack.mjs first: the squishies' cut-outs are Squish
// Stack's; --reference also saves the app's level 12, settled, e.g. as unity/Reference/hop-level.png for CI)
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Hop');
for (const d of ['rooms', 'heads']) fs.mkdirSync(path.join(OUT, d), { recursive: true });

// ---- pictures (Unity doesn't read WebP) ------------------------------------------------------------------------
// [source, destination, size (a square side to scale to, or 0 to keep)]
const pics = [];
const roomArt = fs.readFileSync(path.join(ROOT, 'src', 'crib', 'roomArt.js'), 'utf8');
const ROOMS = ['living', 'kitchen', 'bath', 'bed', 'yard', 'dance'];
for (const m of roomArt.matchAll(/assets\/crib\/rooms\/([\w-]+)\.webp/g)) {
  const name = m[1];
  if (!ROOMS.includes(name.split('-')[0]) || name.endsWith('-front')) continue;
  pics.push([path.join(ROOT, 'assets', 'crib', 'rooms', name + '.webp'), path.join(OUT, 'rooms', name + '.png'), 0]);
}
pics.push([path.join(ROOT, 'assets', 'crib', 'fixtures', 'living-rug.webp'), path.join(OUT, 'rug.png'), 0]);
pics.push([path.join(ROOT, 'assets', 'crib', 'flash-glow.png'), path.join(OUT, 'flash-glow.png'), 0]);
pics.push([path.join(ROOT, 'assets', 'crib', 'flash-dots@3x.png'), path.join(OUT, 'flash-dots.png'), 0]);   // (22 dp: the 3x one)
const headsJs = fs.readFileSync(path.join(ROOT, 'src', 'squishdoku', 'heads.js'), 'utf8');
const heads = [...new Set([...headsJs.matchAll(/^  (\w+): \{ idle:/gm)].map((m) => m[1]))];
for (const k of heads) {
  pics.push([path.join(ROOT, 'assets', 'squishdoku', 'heads', `${k}-happy.webp`), path.join(OUT, 'heads', `${k}-happy.png`), 96]);
  pics.push([path.join(ROOT, 'assets', 'squishdoku', 'heads', `${k}-sad.webp`), path.join(OUT, 'heads', `${k}-sad.png`), 192]);
}
fs.writeFileSync(path.join(OUT, 'pics.tmp.json'), JSON.stringify(pics));
execFileSync('python3', ['-c', `
import sys, json
from PIL import Image
for src, dst, size in json.load(open(sys.argv[1])):
    im = Image.open(src).convert('RGBA')
    if size and im.size != (size, size): im = im.resize((size, size), Image.LANCZOS)
    im.save(dst, optimize=True)
`, path.join(OUT, 'pics.tmp.json')]);
fs.unlinkSync(path.join(OUT, 'pics.tmp.json'));
console.log(`pictures: ${pics.length} (${heads.length} heads)`);

// ---- the level screen ------------------------------------------------------------------------------------------
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-hop');
await page.waitForTimeout(6000);
await page.mouse.click(416, 187);   // level 12 on the map
await page.waitForTimeout(4500);

function save(name, s) {
  if (Object.keys(s.images).length) throw new Error(`${name} has pictures`);
  fs.writeFileSync(path.join(OUT, name + '.xml'), s.svg);
}
const layout = { screen: [832, 384], buttons: [] };

// a button: its lip and its ring (the face moves inside the ring) as two pieces, both in the button's box
async function button(i, on) {
  const parts = await page.evaluateHandle((i) => {
    const b = window.__components('SdButton')[i].el;
    const inner = b.firstElementChild;
    const texts = [...inner.querySelectorAll('*')].filter((e) => e.childNodes.length && [...e.childNodes].every((n) => n.nodeType === 3)).map((e) => e.textContent.trim());
    return { b, lip: inner.children[0], ring: inner.children[1], label: [...new Set(texts)][0] || '' };
  }, i);
  const label = await parts.evaluate((p) => p.label);
  const name = `btn-${label.replace(/\W+/g, '').toLowerCase()}-${on ? 'on' : 'off'}`;
  const b = await parts.evaluate((p) => {
    const r = p.b.getBoundingClientRect(), l = p.lip.getBoundingClientRect(), g = p.ring.getBoundingClientRect();
    return { b: [r.x, r.y, r.width, r.height], lip: [l.x - r.x, l.y - r.y, l.width, l.height], ring: [g.x - r.x, g.y - r.y, g.width, g.height] };
  });
  save(name + '-lip', await snap(page, await parts.evaluateHandle((p) => p.lip)));
  save(name + '-face', await snap(page, await parts.evaluateHandle((p) => p.ring)));
  layout.buttons.push({ name, label, ...b });
}
const hops = () => page.evaluate(() => {
  const t = [...document.querySelectorAll('div')].find((d) => /^HOPS \d+$/.test(d.innerText || ''));
  return t ? Number(t.innerText.slice(5)) : -1;
});

// the reference: level 12 settled (the loops play once on the web)
await page.waitForTimeout(6000);
const ref = process.argv.indexOf('--reference');
if (ref > 0) await page.screenshot({ path: path.resolve(process.argv[ref + 1]) });

// the back button (not pressed): the lip, and the ring with the face and the icon
const back = await page.evaluateHandle(() => window.__components('CribButton')[0].el.firstElementChild);
layout.back = await back.evaluate((e) => { const r = e.getBoundingClientRect(); return [r.x, r.y, r.width, r.height]; });
save('back-lip', await snap(page, await back.evaluateHandle((e) => e.children[0])));
// the ring and the face together: the button with its lip hidden for a moment
await back.evaluate((e) => { e.children[0].style.display = 'none'; });
const s = await snap(page, back);
await back.evaluate((e) => { e.children[0].style.display = ''; });
save('back-top', s);

// paused: every button off (the card is over them; snap reads what's laid out, not what's seen)
await page.mouse.click(34, 32);
await page.waitForTimeout(1200);
for (let i = 0; i < 3; i++) await button(i, false);
// RESUME (the pause card's first button)
const resume = await page.evaluate(() => {
  const t = [...document.querySelectorAll('div')].find((d) => d.innerText === 'RESUME');
  const r = t.getBoundingClientRect();
  return [r.x + r.width / 2, r.y + r.height / 2];
});
await page.mouse.click(resume[0], resume[1]);
await page.waitForTimeout(1200);
await button(2, true);
// a hop, so UNDO and RESTART come on: tap each cushion in turn until one is next to the squishy
const tiles = await page.evaluate(() => window.__components('Tile').map((t) => { const r = t.el.getBoundingClientRect(); return [r.x + r.width / 2, r.y + r.height / 2]; }));
for (const [x, y] of tiles) {
  if ((await hops()) > 0) break;
  await page.mouse.click(x, y);
  await page.waitForTimeout(700);
}
await page.waitForTimeout(800);
await button(0, true);
await button(1, true);

// the cast (castOf), for friendsOf / hopperOf; the squishies' cut-outs are Squish Stack's (Resources/Stack/art)
const stackArt = fs.readFileSync(path.join(ROOT, 'src', 'stack', 'art.js'), 'utf8');
const files = {};
for (const m of stackArt.matchAll(/(\w+): \{ src: require\('\.\.\/\.\.\/assets\/stack\/(\w+)\.webp'\), ar: ([\d.]+) \}/g)) files[m[1]] = m[2];
const cast = await page.evaluate(() => window.__components('HopGame')[0].props.cast.map((c) => ({ id: c.id, key: c.key, ar: c.ar, box: c.box })));
layout.cast = cast.map((c) => ({ ...c, file: files[c.key] || '' }));
layout.heads = heads;
fs.writeFileSync(path.join(OUT, 'hop.json'), JSON.stringify(layout, null, 1));
console.log('buttons:', layout.buttons.map((b) => b.name).join(' '), '| cast:', cast.length);
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
