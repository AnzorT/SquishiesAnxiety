// Squish Hop's pieces for Unity (unity/Assets/Resources/Hop/), from the app's own assets and its level screen (Expo web
// on http://localhost:8081, src/web/Preview.js's "game-hop"; start it with `npx expo start --web --port 8081`):
//   rooms/<room>-<layer>.png   the Crib's room pictures (assets/crib/rooms, src/crib/roomArt.js) a level is played in
//   rug.png                    the Living Room's rug (assets/crib/fixtures/living-rug.webp), laid on the floor under the board
//   flash-glow.png, flash-dots.png   the room-switch flash (src/crib/Hud.js RoomFlash)
//   heads/<key>-happy.png      each creature's happy head (src/squishdoku/heads.js), 96 px: the goal card's stickers
//   heads/<key>-sad.png        its sad head, 192 px: the STUCK! card
//   back-lip.xml, back-top.xml the back button (src/crib/Hud.js CribButton, orange): the lip stays when pressed, the top
//                              moves 3 dp down; pause-top.xml its top with the pause icon (Blitz while a board is played)
//   btn-<kind>-<on|off>-lip.xml / -face.xml   RESTART and HINT (squishdoku/ui.js SdButton), on and disabled
//   key-<white|gold>-lip.xml / -face.xml      an arrow key without its arrow (Game.js DPad; gold: the hint's way)
//   hop.json                   the cast the app plays with (src/stack/roster.js castOf; drawn from Resources/Stack/art)
//                              and where the exported pieces sit on the reference screen (dp)
// node tools/unity/export-hop.mjs [--reference <png>]   (export-stack.mjs first: the squishies' cut-outs are Squish
// Stack's; --reference also saves the app's level 12, settled, e.g. as unity/Reference/hop-level.png for CI). The level
// is opened as on develop: the hub's REGULAR MODE, then level 12 on the map.
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

// ---- the hub's mode pictures (JPEG to PNG: the tests read PNG; the panels are Squishdoku's, Games/Shared/ModeHub) ----
execFileSync('python3', ['-c', `
import sys
from PIL import Image
for k in ('regular', 'blitz'):
    Image.open(sys.argv[1] + '/mode-' + k + '.jpg').convert('RGB').save(sys.argv[2] + '/mode-' + k + '.png', optimize=True)
`, path.join(ROOT, 'assets', 'hop'), OUT]);

// ---- the level screen ------------------------------------------------------------------------------------------
// (develop: the hub first, REGULAR MODE, then level 12 on the map; the rigs' page is kept from loading, so the cut-outs
// stand as Unity's do)
async function open(mode) {
  const o = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-hop');
  await o.page.route('**/android_asset/rig/**', (r) => r.abort());
  await o.page.waitForTimeout(6000);
  await o.page.mouse.click(mode === 'blitz' ? 614 : 218, 180);   // the hub's REGULAR / BLITZ MODE
  await o.page.waitForTimeout(4000);
  if (mode !== 'blitz') await o.page.mouse.click(416, 280);   // level 12 on the map
  return o;
}
const { browser, page, errors } = await open('regular');
await page.waitForTimeout(4500);

function save(name, s) {
  if (Object.keys(s.images).length) throw new Error(`${name} has pictures`);
  fs.writeFileSync(path.join(OUT, name + '.xml'), s.svg);
}
const layout = { screen: [832, 384], buttons: [] };

// an SdButton (the arrow keys are the first four, then RESTART and HINT): its lip and its ring (the face moves inside
// the ring) as two pieces, both in the button's box; a key without its arrow (Unity draws the arrow, turned each way)
async function button(i, on, name) {
  const parts = await page.evaluateHandle((i) => {
    const b = window.__components('SdButton')[i].el;
    const inner = b.firstElementChild;
    const texts = [...inner.querySelectorAll('*')].filter((e) => e.childNodes.length && [...e.childNodes].every((n) => n.nodeType === 3)).map((e) => e.textContent.trim());
    return { b, lip: inner.children[0], ring: inner.children[1], label: [...new Set(texts)][0] || '' };
  }, i);
  const label = await parts.evaluate((p) => p.label);
  name = name || `btn-${label.replace(/\W+/g, '').toLowerCase()}-${on ? 'on' : 'off'}`;
  const b = await parts.evaluate((p) => {
    const r = p.b.getBoundingClientRect(), l = p.lip.getBoundingClientRect(), g = p.ring.getBoundingClientRect();
    return { b: [r.x, r.y, r.width, r.height], lip: [l.x - r.x, l.y - r.y, l.width, l.height], ring: [g.x - r.x, g.y - r.y, g.width, g.height] };
  });
  await parts.evaluate((p) => p.ring.querySelectorAll('svg[viewBox="0 0 24 24"]').forEach((e) => { e.style.display = 'none'; }));
  save(name + '-lip', await snap(page, await parts.evaluateHandle((p) => p.lip)));
  save(name + '-face', await snap(page, await parts.evaluateHandle((p) => p.ring)));
  await parts.evaluate((p) => p.ring.querySelectorAll('svg[viewBox="0 0 24 24"]').forEach((e) => { e.style.display = ''; }));
  layout.buttons.push({ name, label, ...b });
}

// the reference: level 12 settled (the loops play once on the web)
await page.waitForTimeout(6000);
const ref = process.argv.indexOf('--reference');
if (ref > 0) await page.screenshot({ path: path.resolve(process.argv[ref + 1]) });

// the back button (not pressed): the lip, and the ring with the face and the icon
async function backParts(top) {
  const back = await page.evaluateHandle(() => window.__components('CribButton')[0].el.firstElementChild);
  layout.back = await back.evaluate((e) => { const r = e.getBoundingClientRect(); return [r.x, r.y, r.width, r.height]; });
  if (top === 'back-top') save('back-lip', await snap(page, await back.evaluateHandle((e) => e.children[0])));
  // the ring and the face together: the button with its lip hidden for a moment
  await back.evaluate((e) => { e.children[0].style.display = 'none'; });
  const s = await snap(page, back);
  await back.evaluate((e) => { e.children[0].style.display = ''; });
  save(top, s);
}
await backParts('back-top');
await button(0, true, 'key-white');

// paused: RESTART (no hop yet) and HINT off (the card is over them; snap reads what's laid out, not what's seen)
await page.mouse.click(34, 32);
await page.waitForTimeout(1200);
await button(4, false);
await button(5, false);
// RESUME (the pause card's first button)
const tapText = async (t) => {
  const at = await page.evaluate((t) => {
    const e = [...document.querySelectorAll('div')].filter((d) => d.innerText === t).pop();
    const r = e.getBoundingClientRect();
    return [r.x + r.width / 2, r.y + r.height / 2];
  }, t);
  await page.mouse.click(at[0], at[1]);
};
await tapText('RESUME');
await page.waitForTimeout(1200);
await button(5, true);
// the full clear's first hop (Game.js's window.__hop in development), so RESTART comes on (off the full clear it would
// throb, and the snap would take it scaled)
await page.evaluate(() => window.__hop.hop(window.__hop.sol[0]));
await page.waitForTimeout(900);
await page.waitForTimeout(800);
await button(4, true);
// the hint (SHOW ME): its way's key turns gold while the cushion glows
await page.mouse.click(760, 346);
await page.waitForTimeout(1200);
await tapText('SHOW ME');
await page.waitForTimeout(900);
const lit = await page.evaluate(() => window.__components('SdButton').slice(0, 4).findIndex((c) => c.props.kind === 'gold'));
if (lit < 0) throw new Error('no key lit by the hint');
await button(lit, true, 'key-gold');

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

// BLITZ MODE while a board is played: the back button's pause icon
{
  const o = await open('blitz');
  await o.page.waitForTimeout(5000);
  const back = await o.page.evaluateHandle(() => window.__components('CribButton')[0].el.firstElementChild);
  await back.evaluate((e) => { e.children[0].style.display = 'none'; });
  save('pause-top', await snap(o.page, back));
  await o.browser.close();
}
