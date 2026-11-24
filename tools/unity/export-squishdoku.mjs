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
// The hub, the level map and Blitz (SquishdokuScreen):
//   wood-bg.png, levels-<season>.png   the hub's wood page (royal WoodBg) and the map's world (royal/WorldBg.js)
//   mode-regular.png, mode-blitz.png   the mode panels' pictures;  gem.png  the gem (Blitz's save card)
//   cushions/<name>.png, heads/<key>.png   the patches' cushions and the creatures' heads (HOW TO PLAY's little board)
//   orb-<icon>.xml            the wood look's round buttons (royal Orb: back 40, left / right 36), whole (they sink 2 dp)
//   panel-regular.xml, panel-blitz.xml   the hub's mode panels without what changes (the progress bar, 12/600, BEST: n)
//                             and their names (royal Lettering: SVG text, drawn by Unity)
//   headstart.xml             HEAD START's plaque without its switch;  toggle-off.xml, toggle-on.xml, toggle-knob.xml
//                             the switch (ToggleSwitch) in each state without its knob, and the knob
//   rules-lip.xml, rules-face.xml   HOW TO PLAY (SdButton)
//   hub.json                  where they are on the reference screen (dp)
// node tools/unity/export-squishdoku.mjs [--hub-only]
import fs from 'node:fs';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const OUT = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Squishdoku');
fs.mkdirSync(path.join(OUT, 'rooms'), { recursive: true });
const HUB_ONLY = process.argv.includes('--hub-only');
if (!HUB_ONLY) {

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
}

// ---- the hub, the map, Blitz ------------------------------------------------------------------------------------------
{
  // pictures (WebP and JPEG to PNG: Unity's tests read PNG; Unity reads either)
  const pics = [
    ['assets/royal/wood-bg.jpg', 'wood-bg'], ['assets/royal/levels-sunny.jpg', 'levels-sunny'], ['assets/royal/levels-rainy.jpg', 'levels-rainy'],
    ['assets/royal/levels-snowy.jpg', 'levels-snowy'], ['assets/squishdoku/mode-regular.jpg', 'mode-regular'], ['assets/squishdoku/mode-blitz.jpg', 'mode-blitz'],
    ['assets/squad/currency/gem-mittens.png', 'gem'],
  ];
  fs.mkdirSync(path.join(OUT, 'cushions'), { recursive: true });
  fs.mkdirSync(path.join(OUT, 'heads'), { recursive: true });
  for (const f of fs.readdirSync(path.join(ROOT, 'assets', 'squishdoku', 'cushions'))) pics.push([`assets/squishdoku/cushions/${f}`, `cushions/${f.replace('.webp', '')}`]);
  for (const f of fs.readdirSync(path.join(ROOT, 'assets', 'squishdoku', 'heads')).filter((f) => f.endsWith('-idle.webp'))) pics.push([`assets/squishdoku/heads/${f}`, `heads/${f.replace('-idle.webp', '')}`]);
  execFileSync('python3', ['-c', `
import sys
from PIL import Image
root, out = sys.argv[1], sys.argv[2]
args = sys.argv[3:]
for i in range(0, len(args), 2):
    im = Image.open(root + '/' + args[i])
    im = im.convert('RGBA' if im.mode in ('RGBA', 'LA', 'P') else 'RGB')
    if args[i + 1].startswith('heads/') and im.width > 160: im = im.resize((160, round(im.height * 160 / im.width)), Image.LANCZOS)
    im.save(out + '/' + args[i + 1] + '.png', optimize=True)
`, ROOT, OUT, ...pics.flat()]);
  console.log(`pictures: ${pics.length}`);

  const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-squishdoku');
  await page.waitForTimeout(6000);
  const hub = {};
  const save = (name, s) => fs.writeFileSync(path.join(OUT, name + '.xml'), s.svg);
  // a snapped piece's images: their Resources paths
  const PIC = { 'mode-regular': 'Squishdoku/mode-regular', 'mode-blitz': 'Squishdoku/mode-blitz' };
  const local = (s) => {
    for (const [id, src] of Object.entries(s.images)) {
      const k = Object.keys(PIC).find((k) => String(src).includes(k));
      if (k) s.svg = s.svg.split(`href="${id}"`).join(`href="${PIC[k]}"`);
    }
    return s;
  };
  const rect = (h) => h.evaluate((e) => { const r = e.getBoundingClientRect(); return [r.x, r.y, r.width, r.height].map((v) => +v.toFixed(3)); });
  const comp = (name, i = 0) => page.evaluateHandle(([n, i]) => window.__components(n).filter((c) => c.el)[i].el, [name, i]);
  const hide = (h, on) => h.evaluate((e, on) => (e.style.visibility = on ? 'hidden' : ''), on);

  // the back orb
  const orb = await comp('Orb');
  save('orb-back', await snap(page, orb));
  hub.orbBack = await rect(orb);
  // the mode panels: their info rows hidden (the plaque is the SlideIn's child)
  for (const [i, kind] of [[0, 'regular'], [1, 'blitz']]) {
    const panel = await page.evaluateHandle((i) => window.__components('ModePanel')[i].el.firstElementChild || window.__components('ModePanel')[i].el, i);
    const info = await page.evaluateHandle((i) => {
      const el = window.__components('ModePanel')[i].el;
      const divs = [...el.querySelectorAll('div')];
      // the info row: the row holding the bar / the text, under the window
      return divs.filter((d) => /\d/.test(d.textContent) && d.children.length >= 1 && getComputedStyle(d).flexDirection === 'row').pop();
    }, i);
    hub[`info-${kind}`] = await rect(info);
    hub[`panel-${kind}`] = await rect(panel);
    if (kind === 'regular') hub.track = await page.evaluate((el) => { const t = [...el.querySelectorAll('div')].find((d) => getComputedStyle(d).backgroundColor === 'rgba(60, 30, 10, 0.38)'); const r = t.getBoundingClientRect(); return [r.x, r.y, r.width, r.height]; }, info);
    // (and its name: SVG text, which Unity draws itself, SdArt.Lettering)
    const lettering = await page.evaluateHandle((i) => window.__components('Lettering').filter((c) => c.el)[i].el, i);
    await hide(info, true);
    await hide(lettering, true);
    save(`panel-${kind}`, local(await snap(page, panel, { inline: false })));
    await hide(info, false);
    await hide(lettering, false);
  }
  // HEAD START's plaque without its switch, the switch in each state without its knob, and the knob
  const head = await page.evaluateHandle(() => window.__components('HeadStart')[0].el.firstElementChild || window.__components('HeadStart')[0].el);
  const sw = await comp('ToggleSwitch');
  hub.headstart = await rect(head);
  hub.toggle = await rect(sw);
  await hide(sw, true);
  save('headstart', await snap(page, head));
  await hide(sw, false);
  const knob = await sw.evaluateHandle((e) => [...e.querySelectorAll('div')].find((d) => getComputedStyle(d).position === 'absolute' && getComputedStyle(d).width === '17px' && getComputedStyle(d).top === '2px'));
  hub.knob = await rect(knob);
  save('toggle-knob', await snap(page, knob));
  await hide(knob, true);
  save('toggle-off', await snap(page, sw));
  await hide(knob, false);
  const sr = hub.toggle;
  await page.mouse.click(sr[0] + sr[2] / 2, sr[1] + sr[3] / 2);
  await page.waitForTimeout(1500);
  await hide(knob, true);
  save('toggle-on', await snap(page, sw));
  await hide(knob, false);
  hub.knobOn = await rect(knob);
  await page.mouse.click(sr[0] + sr[2] / 2, sr[1] + sr[3] / 2);
  await page.waitForTimeout(1500);
  // HOW TO PLAY: its lip and its ring
  const parts = await page.evaluateHandle(() => {
    const b = window.__components('SdButton').map((c) => c.el).find((e) => e.innerText.includes('HOW TO PLAY'));
    const inner = b.firstElementChild;
    return { b, lip: inner.children[0], ring: inner.children[1] };
  });
  hub.rules = await parts.evaluate((p) => { const r = p.b.getBoundingClientRect(), g = p.ring.getBoundingClientRect(); return { b: [r.x, r.y, r.width, r.height], ring: [g.x - r.x, g.y - r.y, g.width, g.height] }; });
  save('rules-lip', await snap(page, await parts.evaluateHandle((p) => p.lip)));
  save('rules-face', await snap(page, await parts.evaluateHandle((p) => p.ring)));
  // the map's chapter arrows
  await page.mouse.click(220, 200);
  await page.waitForTimeout(3000);
  for (const [i, icon] of [[1, 'left'], [2, 'right']]) {
    const o = await comp('Orb', i);
    save(`orb-${icon}`, await snap(page, o));
    hub[`orb-${icon}`] = await rect(o);
  }
  fs.writeFileSync(path.join(OUT, 'hub.json'), JSON.stringify(hub, null, 1));
  console.log('hub pieces:', Object.keys(hub).join(' '));
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
}
