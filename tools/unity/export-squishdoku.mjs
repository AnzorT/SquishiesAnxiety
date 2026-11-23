// Squishdoku's pieces for Unity (unity/Assets/Resources/Squishdoku/), cut out of the app's own level screen (Expo web on
// http://localhost:8081, src/web/Preview.js's "game-squishdoku": the hub, Regular Mode, the map, level 12; start it with
// `npx expo start --web --port 8081`):
//   rooms/<room>-<layer>.png  the Crib's room layers a level is played in (assets/crib/rooms/*.webp: Unity doesn't read
//                             WebP), drawn by SdRoom as src/hop/Room.js lays them out
//   crib-<icon>-lip.xml       the top bar's round button (crib/Hud.js CribButton, pause while playing, back otherwise):
//   crib-<icon>-face.xml      its lip (stays put when pressed) and the rest (moves 3 dp down), as SVG (tools/unity/ui/snap.js)
//   tool-<name>-<on|off>-lip.xml / -face.xml   PLACE and MARK (ui.js SdButton): PLACE is "on" (orange) unless the ✕ tool
//                             is, MARK "on" (wood) only then
//   squishdoku.json           where the pieces are on the reference screen (dp, for checking SquishdokuGame's layout),
//                             and the squishies' cut-outs the board stands up (Squish Stack's, Resources/Stack/art:
//                             src/stack/art.js), with their height / width
// node tools/unity/export-squishdoku.mjs
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Squishdoku');
fs.mkdirSync(path.join(OUT, 'rooms'), { recursive: true });

// ---- the rooms' layers (only the rooms and layers src/hop/Room.js draws: base, under, over) -------------------------
const roomArt = fs.readFileSync(path.join(ROOT, 'src', 'crib', 'roomArt.js'), 'utf8');
const files = [...new Set([...roomArt.matchAll(/assets\/crib\/rooms\/((living|kitchen|bath|bed|dance|yard)-(base|under-\w+|over-\w+))\.webp/g)].map((m) => m[1]))];
execFileSync('python3', ['-c', `
import sys, os
from PIL import Image
src, dst = sys.argv[1], sys.argv[2]
for f in sys.argv[3:]:
    im = Image.open(os.path.join(src, f + '.webp'))
    im = im.convert('RGBA' if im.mode in ('RGBA', 'LA', 'P') else 'RGB')
    im.save(os.path.join(dst, f + '.png'), optimize=True)
`, path.join(ROOT, 'assets', 'crib', 'rooms'), path.join(OUT, 'rooms'), ...files]);
console.log(`rooms: ${files.length} layers`);

// ---- the squishies (Squish Stack's cut-outs, already in Resources/Stack/art) ------------------------------------------
const artJs = fs.readFileSync(path.join(ROOT, 'src', 'stack', 'art.js'), 'utf8');
const artList = [...artJs.matchAll(/(\w+): \{ src: require\('\.\.\/\.\.\/assets\/stack\/(\w+)\.webp'\), ar: ([\d.]+) \}/g)].map((m) => ({ key: m[1], file: m[2], ar: +m[3] }));

// ---- the level screen --------------------------------------------------------------------------------------------
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-squishdoku');
await page.waitForTimeout(6000);
await page.mouse.click(220, 200); // Regular Mode -> the map
await page.waitForTimeout(3000);
await page.mouse.click(416, 186); // level 12
const save = (name, s) => fs.writeFileSync(path.join(OUT, name + '.xml'), s.svg);
const box = (r) => [r.x, r.y, r.width, r.height].map((v) => +v.toFixed(3));
const layout = { screen: [832, 384], crib: {}, tools: {} };

// the round button: its lip, then everything else (the lip hidden while it's cut out)
async function crib(icon) {
  const h = await page.evaluateHandle(() => window.__components('CribButton')[0].el);
  const outer = await h.evaluateHandle((el) => (el.firstElementChild && el.firstElementChild.children.length >= 3 ? el.firstElementChild : el));
  const lip = await outer.evaluateHandle((o) => o.children[0]);
  const b = await outer.evaluate((o) => { const r = o.getBoundingClientRect(), l = o.children[0].getBoundingClientRect(); return { b: [r.x, r.y, r.width, r.height], lip: [l.x - r.x, l.y - r.y, l.width, l.height] }; });
  save(`crib-${icon}-lip`, await snap(page, lip));
  await lip.evaluate((l) => (l.style.display = 'none'));
  save(`crib-${icon}-face`, await snap(page, outer));
  await lip.evaluate((l) => (l.style.display = ''));
  layout.crib[icon] = b;
}

// a tool button: its lip and its ring (the face moves inside the ring), both in the button's box (as export-stack.mjs)
async function tool(i, name, state) {
  const parts = await page.evaluateHandle((i) => {
    const b = window.__components('SdButton')[i].el;
    const inner = b.firstElementChild;
    return { b, lip: inner.children[0], ring: inner.children[1] };
  }, i);
  const b = await parts.evaluate((p) => {
    const r = p.b.getBoundingClientRect(), l = p.lip.getBoundingClientRect(), g = p.ring.getBoundingClientRect();
    return { b: [r.x, r.y, r.width, r.height], lip: [l.x - r.x, l.y - r.y, l.width, l.height], ring: [g.x - r.x, g.y - r.y, g.width, g.height] };
  });
  save(`tool-${name}-${state}-lip`, await snap(page, await parts.evaluateHandle((p) => p.lip)));
  save(`tool-${name}-${state}-face`, await snap(page, await parts.evaluateHandle((p) => p.ring)));
  layout.tools[`${name}-${state}`] = b;
}

await page.waitForTimeout(400); // the intro: the top bar's button is BACK until the clock starts
await crib('back');
await page.waitForTimeout(6000); // playing
await crib('pause');
await tool(0, 'place', 'on');
await tool(1, 'mark', 'off');
const comps = await page.evaluate(() => {
  const r = (e) => e.getBoundingClientRect().toJSON();
  const o = {};
  for (const n of ['RoomTitle', 'Chip', 'ScoreRow', 'TimerBar', 'PhasePill', 'Buddy', 'RoomBoard']) o[n] = window.__components(n).filter((c) => c.el).map((c) => r(c.el));
  return o;
});
for (const [k, v] of Object.entries(comps)) layout[k] = v.map(box);
// the ✕ tool on: PLACE goes cream, MARK wood
await page.mouse.click(layout.tools['mark-off'].b[0] + 50, layout.tools['mark-off'].b[1] + 25);
await page.waitForTimeout(1200);
await tool(0, 'place', 'off');
await tool(1, 'mark', 'on');

layout.artList = artList;
layout.toolList = Object.entries(layout.tools).map(([name, t]) => ({ name, b: t.b, lip: t.lip, ring: t.ring }));
fs.writeFileSync(path.join(OUT, 'squishdoku.json'), JSON.stringify(layout, null, 1));
console.log('pieces:', fs.readdirSync(OUT).filter((f) => f.endsWith('.xml')).join(' '));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
