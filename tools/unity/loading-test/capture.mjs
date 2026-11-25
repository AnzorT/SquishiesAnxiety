// Squish Time's loading beat and sky as the app shows them: src/screens/LoadingScreen.js and src/squad/SkyBackground.js
// mounted on the Expo web app's preview page (http://localhost:8081, `npx expo start --web --port 8081`) with the
// bundle's own modules, at the A15's size (832 x 384 dp, 2.8125 px per dp). Once the page has loaded, the virtual clock
// (tools/unity/rig/virtual-clock.js) takes over its timers, requestAnimationFrame and Date.now, so each shot is at a
// known moment of the beat; Program.cs draws Unity's SquishLoading at the same moments.
//   node tools/unity/loading-test/capture.mjs <out dir>     -> <out>/<shot>.png, shots.json
// The creature is Preview.js's: its still (src/stack/art) as the plush art; "quick" has no card to wait for (only
// "I AM READY!"), "prep" a card the page can't load (preloadCreatureModel's catch: it's "ready" at once, so the dots show
// their 600 ms minimum). The page's beat starts two frames after the mount (useAfterFirstFrame): Program.cs shifts
// Unity's by those 32 ms; the screen fades over the black box it's mounted in.
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out] = process.argv.slice(2);
if (!out) { console.error('usage: node capture.mjs <out dir>'); process.exit(2); }
fs.mkdirSync(out, { recursive: true });
const KEY = process.env.KEY || 'mittens';

// name, the beat (quick or prep with its card's arrival), the moments shot (ms after the mount)
const ALL = [
  { name: 'quick', quick: true, at: [0, 100, 250, 430, 520] },
  { name: 'prep', quick: false, cardAt: 0, at: [0, 200, 400, 700, 1000, 1200, 1300, 1400, 1580] },
  { name: 'sky', sky: true, at: [0] },
];
// ONLY=<name>[,<name>]: just those
const SHOTS = process.env.ONLY ? ALL.filter((s) => process.env.ONLY.split(',').includes(s.name)) : ALL;

const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=scr-stats');
await page.waitForTimeout(6000);
const clock = fs.readFileSync(path.join(ROOT, 'tools/unity/rig/virtual-clock.js'), 'utf8');
const shots = [];

for (const S of SHOTS) {
  // a fresh page state for each: reload, then mount on the virtual clock
  await page.reload({ timeout: 240000 });
  await page.waitForTimeout(5000);
  // (the sky measures itself with onLayout, which waits on the real frames: it's shot on the real clock)
  if (!S.sky) await page.evaluate(clock);
  await page.evaluate(({ S, KEY }) => {
    const mod = (re) => { for (const [id, m] of __r.getModules()) if (m && m.verboseName && re.test(m.verboseName)) return __r(id); throw new Error('no ' + re); };
    const React = mod(/^node_modules\/react\/index\.js$/);
    const RD = mod(/^node_modules\/react-dom\/client\.js$/);
    const SA = mod(/^node_modules\/react-native-safe-area-context\/lib\/module\/index\.js$/);
    const Loading = mod(/^src\/screens\/LoadingScreen\.js$/).default;
    const Sky = mod(/^src\/squad\/SkyBackground\.js$/).default;
    const toy = mod(/^src\/components\/SquishyToy\.js$/);
    const ART = mod(/^src\/stack\/art(\/index)?\.js$/).default;
    const { BY_ID } = mod(/^src\/squad\/data\.js$/);
    const Asset = mod(/^node_modules\/expo-asset\/build\/index\.js$/).Asset;
    const d = Object.values(BY_ID).find((c) => c.key === KEY);
    const a = ART[KEY];
    const src = typeof a.src === 'number' ? Asset.fromModule(a.src).uri : a.src.uri || a.src.default || a.src;
    const fit = (ar) => (ar >= 1 ? [(1 - 1 / ar) / 2, 0, 1 / ar, 1] : [0, (1 - ar) / 2, 1, ar]);
    const art = { url: src, frame: fit(a.ar) };
    // "prep": a card whose load the shot finishes (preloadCreatureModel's promise); "quick": no card at all
    let creature = { id: d.id, key: KEY, name: d.name, plush: { lg: art, md: art, lgLocked: art, mdLocked: art, sm: art } };
    if (!S.quick) {
      const url = 'card://loading-test-' + Math.random();
      creature.card = { url };
    }
    const h = React.createElement;
    const div = document.createElement('div');
    div.style.cssText = 'position:fixed;left:0;top:0;width:832px;height:384px;z-index:99999;display:flex;background:#000';
    document.body.appendChild(div);
    const root = RD.createRoot(div);
    const inner = S.sky ? h(Sky, { style: { flex: 1 } }) : h(Loading, { creature, onFinish: () => { window.__finished = performance.now(); } });
    root.render(h(SA.SafeAreaProvider, { initialMetrics: { frame: { x: 0, y: 0, width: 832, height: 384 }, insets: { top: 0, left: 0, right: 0, bottom: 0 } }, style: { flex: 1 } }, inner));
    window.__toy = toy;
  }, { S, KEY });
  // let React commit the mount (its scheduler runs on the real clock), then move the virtual one frame by frame
  await page.waitForTimeout(S.sky ? 1500 : 400);
  let t = 0;
  for (const at of S.at) {
    while (t < at) {
      const step = Math.min(16, at - t);
      await page.evaluate((ms) => window.__clock.frame(ms), step);
      t += step;
      await page.waitForTimeout(8);
    }
    await page.waitForTimeout(120);
    const file = `${S.name}-${at}.png`;
    await page.screenshot({ path: path.join(out, file) });
    shots.push({ name: S.name, file, ms: at, quick: !!S.quick, sky: !!S.sky, cardAt: S.cardAt || 0, key: KEY });
    console.log(file);
  }
}
fs.writeFileSync(path.join(out, 'shots.json'), JSON.stringify(shots, null, 1));
if (errors.length) console.log('page errors:', errors.slice(0, 5));
await browser.close();
