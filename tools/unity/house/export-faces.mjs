// The creatures' faces in the house map's room labels (House/View/HouseMapView.cs): the page draws each as a 24 px cream
// circle (2 px border) whose inside is the creature's picture (window.SquishSquad.src: its card render, else its front
// SVG) at background-size 140 %, background-position 50 % 20 %. This renders that inside, 20 x 20 css px clipped to its
// circle, for every roster creature with a picture, at 3x: Resources/House/faces/<key>.png (Unity draws the circle,
// its border and shadow, and the need dot round it).
//
//   node tools/unity/house/export-faces.mjs
import fs from 'node:fs';
import path from 'node:path';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/House/faces');
fs.mkdirSync(OUT, { recursive: true });
const browser = await launch();
const H = await openHouse(browser, loadFixtures().find(f => f.name === 'decorated'), { dpr: 3, room: 'living' });
const page = H.page;
await H.ready();   // (the page runs on the harness's virtual clock: stepped until the house is up)
const list = await page.evaluate(() => {
  const Q = window.SquishSquad, seen = new Set(), out = [];
  for (const id of Object.keys(Q.ROSTER)) {
    const c = Q.ROSTER[id], src = Q.src(id);
    if (!c || !src || seen.has(c.key)) continue;
    seen.add(c.key); out.push({ id, key: c.key, src });
  }
  return out;
});
console.log(list.length + ' creatures with a picture');
// a box of its own over everything, the face's inside as the label has it
await page.evaluate(() => {
  const d = document.createElement('div');
  d.id = '__face';
  // (on the label's cream, as the circle's own background is; the page itself hidden, so outside the circle is clear)
  d.style.cssText = 'position:fixed; left:10px; top:10px; width:20px; height:20px; border-radius:50%; overflow:hidden; z-index:2147483647; background-color:#fff6e2; background-size:140%; background-position:50% 20%; background-repeat:no-repeat; pointer-events:none; visibility:visible;';
  document.body.appendChild(d);
  const st = document.createElement('style');
  st.textContent = 'html, body { background: transparent !important; } body * { visibility: hidden !important; } #__face { visibility: visible !important; }';
  document.head.appendChild(st);
});
let n = 0;
for (const c of list) {
  const ok = await page.evaluate(async src => {
    const im = new Image(); im.src = src;
    try { await im.decode(); } catch (e) { return false; }
    const d = document.getElementById('__face'); d.style.backgroundImage = 'url("' + src + '")';
    return true;
  }, c.src);
  if (!ok) { console.log('  no picture: ' + c.key + ' (' + c.src + ')'); continue; }
  // (a clipped page screenshot: an element's waits for animation frames, and this page's run on the harness's clock)
  await page.screenshot({ path: path.join(OUT, c.key + '.png'), omitBackground: true, clip: { x: 10, y: 10, width: 20, height: 20 } });
  n++;
}
fs.writeFileSync(path.join(OUT, '..', 'faces.json'), JSON.stringify({ note: 'The house map labels\' faces (export-faces.mjs): creature keys with a picture in House/faces.', keys: list.map(c => c.key).filter(k => fs.existsSync(path.join(OUT, k + '.png'))) }));
console.log(n + ' faces -> ' + path.relative(REPO, OUT));
if (H.errs.length) console.log('page errors: ' + H.errs.slice(0, 3).join(' | '));
await browser.close();
