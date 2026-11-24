// The chest smash's own page (android/app/src/main/assets/chest/host.html, served by Expo web at
// /android_asset/chest/host.html), as src/components/ChestSmash.js drives it, on the virtual clock: virtual-clock.js is
// loaded before the page's scripts (so the engine's Math.random is its seeded generator from the start), the page's
// CSS animations and transitions are paused and set to the virtual time they've run, chestHost.start({...}) at virtual
// time 0 with the shot's server result (sound off), taps at set moments (the page's pointerdown), shots at others.
// smashShot(shot, out) → the shot (written to shots.json with the rest).
// As the phone has it: the page's ../webgame/ (the cards v6 the reveal draws: export/cards4) is the built web game
// (webgame/build.mjs, at webgame/test/out/unity-webgame as tools/unity/rig/bundle.mjs builds it; the APK ships it,
// Metro doesn't serve it). The live creature of the unlock (../rig/*.js) isn't loaded: its still stays, as Unity draws
// it. The clock waits for the group's vault room and its twinkles (the page puts them up once the picture is decoded,
// off the virtual time), and each moment waits two real frames for the twinkles' animationend (CSS animation events are
// sent with the browser's own frames), so they pop on the same spots, rolled from the same Math.random, every time.
import fs from 'node:fs';
import path from 'node:path';
import { chromium, ROOT, DP, DPR } from '../ui/snap-page.mjs';

const RAR_LOOK = [
  { label: 'COMMON', bg: '#d7f0ff', ink: '#2f7fd6' },
  { label: 'RARE', bg: '#c9f7e1', ink: '#16a86a' },
  { label: 'EPIC', bg: '#ead6ff', ink: '#8f3cf2' },
  { label: 'LEGENDARY', bg: '#ffdcb0', ink: '#d9772f' },
  { label: 'RAINBOW', bg: '#ffe0f3', ink: '#d3179a' },
];

// ChestSmash.js rewardOf (no catalog description: the concept line is empty; the art: the app's own path, the creature
// in its border look, src/squad/looks.js rigLookOf: the default look 4 with no Firebase config, none for a creature
// without look pictures)
export async function rewardOf(r) {
  const squad = (await import(path.join(ROOT, 'functions', 'squad.js'))).default;
  const LOOK_KEYS = JSON.parse(/export default (\[.*?\]);/s.exec(fs.readFileSync(path.join(ROOT, 'src', 'squad', 'lookKeys.js'), 'utf8'))[1]);
  const c = r.id != null ? squad.BY_ID[String(r.id)] : null;
  const R = c ? RAR_LOOK[c.rar] : null;
  const look = c && LOOK_KEYS.includes(c.key) ? 4 : 0;
  return {
    name: c ? c.name : '', rar: c ? c.rar : 0, rarLabel: R ? R.label : '', rarBg: R ? R.bg : '#ffffff', rarInk: R ? R.ink : '#45107a', concept: '',
    key: c ? c.key : '', set: c ? c.set : '', look,
    img: !c ? '' : look ? `../looks/${look}/${c.key}.webp` : `../rig/export/tripo/${c.key}/${c.key}-front.svg`, isNew: !!r.isNew, copies: r.copies || 0, need: r.need || 0, coins: r.coins || 0, dupeCoins: r.dupeCoins || 0, setBonus: r.setBonus || 0, luck: !!r.luck,
  };
}

export async function smashShot(shot, out) {
  const browser = await chromium.launch();
  const page = await browser.newPage({ viewport: DP, deviceScaleFactor: DPR });
  const errors = [];
  page.on('pageerror', (e) => errors.push(e.message));
  await page.addInitScript(() => { window.__realRAF = window.requestAnimationFrame.bind(window); });
  await page.addInitScript({ path: path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js') });
  const WEBGAME = path.join(ROOT, 'webgame', 'test', 'out', 'unity-webgame');
  if (!fs.existsSync(path.join(WEBGAME, 'export', 'cards4', 'cards4.js'))) { const { build } = await import(path.join(ROOT, 'webgame', 'build.mjs')); await build(WEBGAME); }
  await page.route('**/android_asset/webgame/**', (route) => {
    const f = path.join(WEBGAME, decodeURIComponent(new URL(route.request().url()).pathname.replace(/^\/android_asset\/webgame\//, '')));
    return fs.existsSync(f) ? route.fulfill({ path: f }) : route.fulfill({ status: 404, body: '' });
  });
  await page.route(/\/android_asset\/rig\/[^/]+\.js(\?|$)/, (route) => route.abort());
  await page.goto('http://localhost:8081/android_asset/chest/host.html', { timeout: 120000 });
  await page.waitForFunction(() => window.chestHost && window.ChestModels, null, { timeout: 60000, polling: 50 });
  // its fonts loaded before the clock moves (each face loads when first used: the HUD measured by the stage's first
  // resize, sized by fitStage, would otherwise be in a fallback font for a moment)
  await page.evaluate(() => Promise.all(['700 10px Fredoka', '700 10px Nunito', '800 10px Nunito', '900 10px Nunito'].map((f) => document.fonts.load(f))).then(() => document.fonts.ready));
  await page.waitForTimeout(500);
  const r = shot.result;
  const o = { group: r.group, size: r.size, final: r.final || r.size, reward: await rewardOf(r), sound: false, insetTop: 0, insetBottom: 0 };
  await page.evaluate((o) => window.chestHost.start(o), o);
  // (polled from here: the page's own timers are the virtual clock's)
  for (let i = 0; !(await page.evaluate(() => !!(document.getElementById('vault').style.backgroundImage && document.querySelectorAll('#vault .tw').length))); i++) {
    if (i > 600) throw new Error('the vault room never came up');
    await new Promise((r) => setTimeout(r, 50));
  }
  const sync = () => page.evaluate(() => {
    const now = window.__clock.now;
    for (const a of document.getAnimations()) {
      if (a.__b == null) { a.__b = now; a.pause(); }
      a.currentTime = now - a.__b;
    }
    return new Promise((ok) => window.__realRAF(() => window.__realRAF(ok)));
  });
  const step = async (to) => {
    for (;;) {
      const now = await page.evaluate(() => window.__clock.now);
      if (now >= to) return;
      await page.evaluate((d) => window.__clock.frame(d), Math.min(16, to - now));
      await sync();
    }
  };
  await sync();
  const events = [...(shot.taps || []).map(([ms, x, y]) => ({ ms, tap: [x, y] })), ...shot.at.map((ms) => ({ ms, shot: true }))].sort((a, b) => a.ms - b.ms || (a.shot ? 1 : -1));
  for (const ev of events) {
    await step(ev.ms);
    if (ev.tap) {
      await page.mouse.click(ev.tap[0], ev.tap[1]);
      await sync();
    } else {
      await sync();
      await page.mouse.move(0, 0);
      await page.screenshot({ path: path.join(out, `${shot.name}-${ev.ms}.png`) });
      console.log(`${shot.name} at ${ev.ms} ms`);
    }
  }
  if (process.env.RECTS) {
    console.log(JSON.stringify(await page.evaluate(() => ['top', 'tierLabel', 'name', 'hpbar', 'pips', 'hp', 'bannerWrap', 'bottom', 'hint', 'reveal', 'rays', 'rvUp', 'rvNew', 'card', 'art', 'rvRar', 'rvName', 'rvConcept', 'rvCopies', 'cpTrack', 'cpNote', 'loot', 'collect'].map((id) => { const e = document.getElementById(id); const b = e.getBoundingClientRect(); return [id, getComputedStyle(e).display, +b.x.toFixed(2), +b.y.toFixed(2), +b.width.toFixed(2), +b.height.toFixed(2)]; }))));
    console.log(JSON.stringify(await page.evaluate(() => window.__chestOut)));
  }
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
  return { ...shot, profile: null };
}
