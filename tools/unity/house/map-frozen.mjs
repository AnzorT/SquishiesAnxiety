// The house map as the app shows it: the page's own map <svg> with its SMIL paused at the moment the app freezes it
// (webgame/app/menu.js pauses the map's animations at its first 120 ms tick after it opens and bakes that frame; Unity's
// House/HouseMap.cs MapSvg samples the same moment, HouseMap.FrozenAt), for each fixture, the labels and the rest of
// drawn alone. For house-test `mapframe`, which draws Unity's map for the same state and compares the pixels.
//
//   node tools/unity/rig/bundle.mjs && node tools/unity/house/map-frozen.mjs [t seconds, default 0.06]
//     -> tools/unity/house-test/out/mapframe-<fixture>.png and .json ({ st, w, h })
import fs from 'node:fs';
import path from 'node:path';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';

const T = +(process.argv[2] || 0.06);
const OUT = path.join(REPO, 'tools/unity/house-test/out');
fs.mkdirSync(OUT, { recursive: true });
const browser = await launch();
// (each fixture in its own season, and the beach house also in the other two)
const runs = loadFixtures().flatMap((fx) => fx.name === 'lv30-beach' ? [[fx, null], [fx, 'sunny'], [fx, 'snowy']] : [[fx, null]]);
for (const [fx, season] of runs) {
  const H = await openHouse(browser, fx, { room: fx.name === 'lv30-beach' ? 'beach' : 'living', dpr: 1 });
  await H.ready(); await H.frames(30);
  if (season) { await H.page.evaluate((season) => new Promise((r) => window.__sh.setState({ season }, r)), season); await H.frames(2); }
  const tag = fx.name + (season ? '-' + season : '');
  const st = await H.page.evaluate(() => {
    const sh = window.__sh, S = sh.state;
    const open = sh.X.RKEYS.filter((r) => sh.isOpen(r)), b0 = {}; open.forEach((r) => { const s = sh.shellOf(r); b0[r] = s && s.P && s.P.b0; });
    return { lvl: sh.lvl(), cur: S.cur, open, b0, cs: sh.cs.map((c) => ({ key: c.key, name: c.name, room: c.room, N: c.N, id: c.id })), season: sh.seasonNow(), mapIn: true };
  }).catch(async () => null);
  if (!st) { console.log(fx.name + ': no state'); await H.ctx.close(); continue; }
  await H.page.evaluate(() => window.__sh.setState({ map: true, mapIn: true, mapHov: null, mapGo: null }));
  await H.frames(2);
  // (its markup too, for house-test `map`: the C# template's markup against the page's, element by element)
  const svgMarkup = await H.page.evaluate(() => { const el = document.querySelector('[data-screen-label="House map"] svg'); return el ? el.outerHTML : null; });
  fs.writeFileSync(path.join(OUT, 'map-' + tag + '.json'), JSON.stringify({ st, svg: svgMarkup }));
  // the map's own svg alone in a page of its own (a copy inside the house's page would share its ids with the map
  // still there, and take the original's filters and clips in another context), its SMIL at T, unzoomed
  if (!svgMarkup) { console.log(fx.name + ': no map'); await H.ctx.close(); continue; }
  const box = { w: 852, h: 393 };
  const blank = await H.ctx.newPage();
  await blank.setViewportSize({ width: box.w, height: box.h });
  await blank.setContent('<html><body style="margin:0;background:transparent">' + svgMarkup.replace(/style="position: ?absolute[^"]*"/, 'style="display:block;width:852px;height:393px"') + '</body></html>');
  await blank.evaluate((T) => { const s = document.querySelector('svg'); s.pauseAnimations(); s.setCurrentTime(T); }, T);
  await blank.waitForTimeout(300);
  await blank.screenshot({ path: path.join(OUT, 'mapframe-' + tag + '.png'), omitBackground: true, clip: { x: 0, y: 0, width: box.w, height: box.h } });
  await blank.close();
  fs.writeFileSync(path.join(OUT, 'mapframe-' + tag + '.json'), JSON.stringify({ st, w: box.w, h: box.h, t: T }));
  console.log(`${tag}: the map at ${T} s (${box.w} x ${box.h}, ${st.season}, ${st.open.length} rooms open)`);
  await H.ctx.close();
}
await browser.close();
