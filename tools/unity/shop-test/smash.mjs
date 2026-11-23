// The chest smash's own page (android/app/src/main/assets/chest/host.html, served by Expo web at
// /android_asset/chest/host.html), as src/components/ChestSmash.js drives it, on the virtual clock: virtual-clock.js is
// loaded before the page's scripts (so the engine's Math.random is its seeded generator from the start), the page's
// CSS animations and transitions are paused and set to the virtual time they've run, chestHost.start({...}) at virtual
// time 0 with the shot's server result (sound off), taps at set moments (the page's pointerdown), shots at others.
// smashShot(shot, out) → the shot (written to shots.json with the rest).
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

// ChestSmash.js rewardOf (no catalog description: the concept line is empty; the art: the app's own path)
export async function rewardOf(r) {
  const squad = (await import(path.join(ROOT, 'functions', 'squad.js'))).default;
  const c = r.id != null ? squad.BY_ID[String(r.id)] : null;
  const R = c ? RAR_LOOK[c.rar] : null;
  return {
    name: c ? c.name : '', rar: c ? c.rar : 0, rarLabel: R ? R.label : '', rarBg: R ? R.bg : '#ffffff', rarInk: R ? R.ink : '#45107a', concept: '',
    img: c ? `../rig/export/tripo/${c.key}/${c.key}-front.svg` : '', isNew: !!r.isNew, copies: r.copies || 0, need: r.need || 0, coins: r.coins || 0, dupeCoins: r.dupeCoins || 0, setBonus: r.setBonus || 0, luck: !!r.luck,
  };
}

export async function smashShot(shot, out) {
  const browser = await chromium.launch();
  const page = await browser.newPage({ viewport: DP, deviceScaleFactor: DPR });
  const errors = [];
  page.on('pageerror', (e) => errors.push(e.message));
  await page.addInitScript({ path: path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js') });
  await page.goto('http://localhost:8081/android_asset/chest/host.html', { timeout: 120000 });
  await page.waitForFunction(() => window.chestHost && window.ChestModels, null, { timeout: 60000, polling: 50 });
  // the page waits for its fonts: let them load before the clock moves
  await page.evaluate(() => document.fonts.ready);
  await page.waitForTimeout(500);
  const r = shot.result;
  const o = { group: r.group, size: r.size, final: r.final || r.size, reward: await rewardOf(r), sound: false, insetTop: 0, insetBottom: 0 };
  await page.evaluate((o) => window.chestHost.start(o), o);
  const sync = () => page.evaluate(() => {
    const now = window.__clock.now;
    for (const a of document.getAnimations()) {
      if (a.__b == null) { a.__b = now; a.pause(); }
      a.currentTime = now - a.__b;
    }
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
