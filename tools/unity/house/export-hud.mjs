// Exports the Squad House's HUD chrome (HOUSE_PORT_PLAN.md stage 2) for Unity (House/View/HouseHud.cs): the bottom
// drawer (its wood panel with RENOVATE and CATALOG, its tab and the tab's arrow) cut from the house page itself
// (tools/unity/ui/snap.js: what Chrome laid out and painted, as SVG), with where each piece sits in the 852 x 393 frame.
//
//   node tools/unity/house/export-hud.mjs
//
// -> unity/Assets/Resources/House/hud/<piece>.xml   (the SVG of each piece, in its own CSS px)
//    unity/Assets/Resources/House/hud.json          { pieces: { name: [x, y, w, h] in frame px with the drawer at
//                                                    translate(-50%, 0) }, drawer: { closedTy, openTy, ms, ease },
//                                                    arrow: { ms, ease } }   (the page's own values, see below)
// The toast is drawn by Unity from the page's style (its text changes); its numbers are in HouseHud.cs.
import fs from 'node:fs';
import path from 'node:path';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';
import { fontData, HERE as UI } from '../ui/snap-page.mjs';
import { snap } from '../ui/snap-page.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/House');
const fixture = loadFixtures()[0];
const browser = await launch();
const H = await openHouse(browser, fixture, { room: 'living' });
await H.ready();
await H.frames(30);
await H.still();
const page = H.page;

// snap.js and the fonts it draws text with, added to the running page
const fd = fontData();
await page.evaluate((fd) => {
  window.__snapFonts = fd.names;
  window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)]));
  window.__snapUpm = fd.upm;
  window.__snapPaths = fd.paths;
}, fd);
await page.addScriptTag({ path: path.join(UI, 'snap.js') });

// the drawer at its base position (the page moves it with translateY: closed 72, open -16), its arrow hidden in the tab
const ids = await page.evaluate(() => {
  const ren = document.querySelector('button[aria-label="Renovate"]');
  const box = ren.closest('div[style*="z-index: 900"]');
  box.style.transition = 'none';
  box.style.transform = 'translate(-50%, 0px)';
  const tab = box.querySelector(':scope > button'), panel = box.querySelector(':scope > div'), arrow = tab.querySelector('svg');
  tab.dataset.hud = 'tab'; panel.dataset.hud = 'panel'; arrow.dataset.hud = 'arrow';
  arrow.style.transition = 'none'; arrow.style.transform = 'none';
  return ['tab', 'panel', 'arrow'];
});
const frame = await page.evaluate(() => { const f = document.querySelector('[data-screen-label]').getBoundingClientRect(); return { x: f.left, y: f.top, k: 852 / f.width }; });
const pieces = {};
fs.mkdirSync(path.join(OUT, 'hud'), { recursive: true });
for (const id of ids) {
  if (id === 'tab') await page.evaluate(() => { document.querySelector('[data-hud="arrow"]').style.visibility = 'hidden'; });
  const s = await snap(page, `[data-hud="${id}"]`);
  if (id === 'tab') await page.evaluate(() => { document.querySelector('[data-hud="arrow"]').style.visibility = ''; });
  fs.writeFileSync(path.join(OUT, 'hud', id + '.xml'), s.svg);
  pieces[id] = [(s.x - frame.x) * frame.k, (s.y - frame.y) * frame.k, s.w * frame.k, s.h * frame.k].map((v) => Math.round(v * 1000) / 1000);
}
// where a tap counts: the drawer's two buttons (frame px, the drawer at its base position)
const buttons = await page.evaluate(() => Object.fromEntries(['Renovate', 'Catalog'].map((n) => { const r = document.querySelector(`button[aria-label="${n}"]`).getBoundingClientRect(); return [n.toLowerCase(), [r.left, r.top, r.width, r.height]]; })));
for (const k in buttons) buttons[k] = [(buttons[k][0] - frame.x) * frame.k, (buttons[k][1] - frame.y) * frame.k, buttons[k][2] * frame.k, buttons[k][3] * frame.k].map((v) => Math.round(v * 1000) / 1000);
// the page's values (Squad House v6.dc.html: renderVals dw, the drawer's and the arrow's CSS transitions)
const hud = {
  note: 'Written by tools/unity/house/export-hud.mjs. Rects: frame px (852 x 393), the drawer at translate(-50%, 0).',
  pieces,
  buttons,
  drawer: { closedTy: 72, openTy: -16, ms: 750, ease: [0.25, 1.15, 0.4, 1] },
  arrow: { closedDeg: 0, openDeg: 180, ms: 250, ease: [0.25, 0.1, 0.25, 1] },
};
fs.writeFileSync(path.join(OUT, 'hud.json'), JSON.stringify(hud, null, 1));
console.log('hud:', JSON.stringify(pieces));
for (const e of [...new Set(H.errs || [])].slice(0, 5)) console.log('  page error:', String(e).slice(0, 160));
await browser.close();
