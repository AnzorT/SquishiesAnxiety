// The games' screens as the app shows them (Expo web, src/web/Preview.js "game-stack" / "game-sort" / "game-hop", the
// made-up player), on a virtual clock: the page's clock is replaced by tools/unity/rig/virtual-clock.js just before the
// screen opens (virtual time 0), then stepped 16 ms a frame (letting React render in between), with the scenario's taps
// and scrolls at their moments and a screenshot at each shot (scenarios.json). Program.cs runs the same frames on the
// Unity code.   node capture.mjs <out dir> [scenario ...]      -> <out>/<scenario>/app-<ms>.png, log.json
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT, HERE } from '../ui/snap-page.mjs';

const [out, ...only] = process.argv.slice(2);
const SCEN = JSON.parse(fs.readFileSync(path.join(HERE, '..', 'maps-test', 'scenarios.json'), 'utf8'));
const clock = fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8');
const SCREEN = { 'game-stack': 'StackScreen', 'game-sort': 'SortScreen', 'game-hop': 'HopScreen' };

for (const s of SCEN) {
  if (only.length && !only.includes(s.name)) continue;
  const dir = path.join(out, s.name);
  fs.mkdirSync(dir, { recursive: true });
  const { browser, page, errors } = await openApp(`http://localhost:8081/?phone=1&preview=1&card=${s.card}`);
  await page.waitForTimeout(6000);
  // the made-up player's record, changed for this scenario (Preview.js's PLAYER, shared by the screens)
  if (s.profile) {
    await page.evaluate(([name, p]) => {
      const prof = window.__components(name)[0].props.profile;
      for (const [k, v] of Object.entries(p)) Object.assign((prof[k] = prof[k] || {}), v);
    }, [SCREEN[s.card], s.profile]);
  }
  await page.evaluate(() => window.__preview('none'));
  await page.waitForTimeout(800);
  await page.evaluate(clock);
  await page.evaluate((c) => window.__preview(c), s.card);
  await page.waitForTimeout(1500);   // React commits the screen at virtual time 0
  const now = () => page.evaluate(() => window.__clock.now);
  async function stepTo(ms) {
    for (let t = await now(); t < ms; t = await now()) {
      await page.evaluate((d) => window.__clock.frame(d), Math.min(16, ms - t));
      await page.waitForTimeout(25);
    }
  }
  // the map's scrolling element: LevelMap's own, or (develop: Squish Stack's ForestMap) the horizontal ScrollView in it
  await page.evaluate(() => {
    window.__mapScroller = () => {
      const m = window.__components('LevelMap')[0] || window.__components('ForestMap')[0];
      if (!m || !m.el) return null;
      if (m.el.scrollWidth > m.el.clientWidth) return m.el;
      return [...m.el.querySelectorAll('*')].find((d) => d.scrollWidth > d.clientWidth + 1 && getComputedStyle(d).overflowX !== 'visible') || m.el;
    };
  });
  const log = [];
  for (const e of [...s.steps].sort((a, b) => a.at - b.at)) {
    await stepTo(e.at);
    if (e.tap) {
      await page.mouse.move(...e.tap); await page.mouse.down(); await page.mouse.up();
      await page.waitForTimeout(60);
    } else if (e.scroll != null) {
      const got = await page.evaluate((x) => { const el = window.__mapScroller(); el.scrollLeft = x; return el.scrollLeft; }, e.scroll);
      await page.waitForTimeout(100);
      log.push({ at: e.at, scroll: got });
    } else if (e.shot) {
      await page.waitForTimeout(700);
      await page.screenshot({ path: path.join(dir, `app-${e.at}.png`) });
      const sl = await page.evaluate(() => { const el = window.__mapScroller(); return el ? el.scrollLeft : null; });
      log.push({ at: e.at, shot: true, scrollLeft: sl });
    }
  }
  fs.writeFileSync(path.join(dir, 'log.json'), JSON.stringify(log, null, 1));
  console.log(`${s.name}: ${log.filter((l) => l.shot).length} shots${errors.length ? ' | page errors: ' + errors.slice(0, 2).join(' | ') : ''}`);
  await browser.close();
}
