// The yard games' opening pictures: the page's (YardGames mounted on a 360 x 640 stage, each game's intro with the
// card and HUD hidden) beside the C# ones (house-test `yard` -> out/yard-<id>.svg), one PNG for a look by eye.
//
//   dotnet run --project tools/unity/house-test -- yard && node tools/unity/house/yard-check.mjs
import fs from 'node:fs'; import path from 'node:path';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';
const OUT = path.join(REPO, 'tools/unity/house-test/out'), ids = ['hoop', 'soccer', 'hop', 'tramp', 'slide', 'corn', 'pong'];
const browser = await launch();
const H = await openHouse(browser, loadFixtures().find((f) => f.name === 'lv12'), { room: 'living' });
await H.ready(); await H.frames(20);
// the yard games' scripts (the house page doesn't load them: the Main Menu does)
const WEB = path.join(REPO, 'webgame/test/out/unity-house');
for (const f of ['yard-games.js', ...ids.map((i) => 'yg-' + i + '.js')]) await H.page.addScriptTag({ path: path.join(WEB, f) });
await H.frames(10);
await H.page.setViewportSize({ width: 1280, height: 800 });
const shots = [];
for (const id of ids) {
  await H.page.evaluate((id) => { let el = document.getElementById('ygx'); if (el) el.remove(); el = document.createElement('div'); el.id = 'ygx'; el.style.cssText = 'position:fixed;left:0;top:0;width:360px;height:640px;z-index:2147483647;background:#fff';
    document.body.appendChild(el); const app = window.YardGames.mount(el); const G = window.YardGames.GAMES.find((g) => g.id === id); app.play(G);
    const st = el.querySelector('.yg-stage'), fr = el.querySelector('.yg-frame'); ['width:360px', 'height:640px', 'border-radius:0', 'box-shadow:none', 'aspect-ratio:auto'].forEach((d) => { const [k, v] = d.split(':'); fr.style.setProperty(k, v, 'important'); }); el.querySelectorAll('.yg-ov,.yg-hud,.yg-toasts').forEach((e) => { e.style.display = 'none'; }); }, id);
  await H.frames(3);
  shots.push(await H.page.screenshot({ clip: { x: 0, y: 0, width: 360, height: 640 } }));
}
const P2 = await (await browser.newContext({ viewport: { width: 360 * 7, height: 1280 } })).newPage();
const img = (b) => 'data:image/png;base64,' + b.toString('base64'), svg = (id) => 'data:image/svg+xml;base64,' + Buffer.from(fs.readFileSync(path.join(OUT, 'yard-' + id + '.svg'))).toString('base64');
await P2.setContent('<body style="margin:0;display:grid;grid-template-columns:repeat(7,360px)">' + shots.map((b) => '<img src="' + img(b) + '" width="360" height="640">').join('') + ids.map((id) => '<img src="' + svg(id) + '" width="360" height="640">').join('') + '</body>');
await P2.screenshot({ path: path.join(OUT, 'yard-check.png') });
console.log('yard-check: out/yard-check.png (top: the page, bottom: C#)');
await browser.close();
