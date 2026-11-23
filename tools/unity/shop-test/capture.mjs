// The Shop, its sheets, the Level Road and the treasure vault as the app shows them (Expo web on http://localhost:8081, src/web/Preview.js "scr-…" with its
// made-up player; `npx expo start --web --port 8081`), at known moments of a virtual clock: once the page has loaded,
// tools/unity/rig/virtual-clock.js replaces its timers and Date.now (and `new Date()` follows it: the made-up player's
// days and the streak's clock come from it), the time zone is UTC, the screen is opened at virtual time 0, the clock is
// stepped 16 ms a frame (each frame its own task, so promises settle between frames, as in a browser), taps land at
// set moments, and the screen is shot at others. Program.cs plays the same taps on the same clock in the Unity code.
//   node capture.mjs <out dir> [shot ...]
//   <out>/<shot>-<ms>.png   the screen at that moment     <out>/shots.json   what was shot, the player, the taps
import fs from 'node:fs';
import path from 'node:path';
import { chromium, fontData, HERE, ROOT, DP, DPR } from '../ui/snap-page.mjs';
import { SHOTS } from './shots.mjs';

const [out, ...only] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const clock = fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8');
// `new Date()` with no arguments reads the virtual Date.now too
const datePatch = `(() => { const RD = Date; function D(...a) { if (!(this instanceof D)) return new RD(RD.now()).toString(); return a.length ? new RD(...a) : new RD(RD.now()); }
  D.prototype = RD.prototype; D.now = () => RD.now(); D.UTC = RD.UTC; D.parse = RD.parse; window.Date = D; })();`;

async function open() {
  const browser = await chromium.launch();
  const ctx = await browser.newContext({ viewport: DP, deviceScaleFactor: DPR, timezoneId: 'UTC' });
  const page = await ctx.newPage();
  const errors = [];
  page.on('pageerror', (e) => errors.push(e.message));
  const fd = fontData();
  await page.addInitScript((fd) => {
    window.__snapFonts = fd.names;
    window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)]));
    window.__snapUpm = fd.upm;
    window.__snapPaths = fd.paths;
  }, fd);
  await page.addInitScript({ path: path.join(HERE, 'snap.js') });
  await page.goto('http://localhost:8081/?phone=1&preview=1&card=none', { timeout: 240000 });
  return { browser, page, errors };
}

const step = async (page, to) => {
  for (;;) {
    const now = await page.evaluate(() => window.__clock.now);
    if (now >= to) return;
    await page.evaluate((d) => window.__clock.frame(d), Math.min(16, to - now));
  }
};

// (the chest smash's page: smash.mjs)
const { smashShot } = await import('./smash.mjs');
const done = [];
for (const shot of SHOTS) {
  if (only.length && !only.includes(shot.name)) continue;
  if (shot.page) { done.push(await smashShot(shot, out)); continue; }
  const { browser, page, errors } = await open();
  await page.waitForTimeout(5000);
  await page.evaluate(clock);
  await page.evaluate(datePatch);
  await page.evaluate((c) => window.__preview(c), shot.preview);
  await page.waitForTimeout(2500);   // React commits at virtual time 0 (the Lettering measures itself)
  const profile = shot.player ? await page.evaluate((k) => JSON.stringify(window.__shopPlayer(k)), shot.player) : 'null';
  const events = [...(shot.taps || []).map(([ms, x, y]) => ({ ms, tap: [x, y] })), ...(shot.wheel || []).map(([ms, x, y, dy]) => ({ ms, wheel: [x, y, dy] })), ...(shot.wheelX || []).map(([ms, x, y, dx]) => ({ ms, wheel: [x, y, 0, dx] })), ...(shot.drag || []).map(([ms, x, y, dx]) => ({ ms, drag: [x, y, dx] })), ...(shot.scrollTo || []).map(([ms, x]) => ({ ms, scrollTo: x })), ...shot.at.map((ms) => ({ ms, shot: true }))].sort((a, b) => a.ms - b.ms || (a.shot ? 1 : -1));
  for (const ev of events) {
    await step(page, ev.ms);
    if (ev.tap) {
      await page.mouse.click(ev.tap[0], ev.tap[1]);
      await page.waitForTimeout(400);
    } else if (ev.drag) {
      const [x, y, dx] = ev.drag;
      await page.mouse.move(x, y);
      await page.mouse.down();
      for (let i = 1; i <= 6; i++) await page.mouse.move(x + (dx * i) / 6, y);
      await page.mouse.up();
      await page.waitForTimeout(400);
    } else if (ev.scrollTo != null) {
      // the sideways scroller to x (its own units; a wheel in Chrome scrolls the page, not the row)
      await page.evaluate((x) => document.querySelectorAll('*').forEach((e) => { const cs = getComputedStyle(e); if ((cs.overflowX === 'auto' || cs.overflowX === 'scroll') && e.scrollWidth > e.clientWidth + 1) e.scrollLeft = x; }), ev.scrollTo);
      await page.waitForTimeout(400);
    } else if (ev.wheel) {
      await page.mouse.move(ev.wheel[0], ev.wheel[1]);
      await page.mouse.wheel(ev.wheel[3] || 0, ev.wheel[2]);
      await page.waitForTimeout(400);
    } else {
      await page.waitForTimeout(600);   // React renders what the last frame set
      await page.mouse.move(0, 0);
      await page.screenshot({ path: path.join(out, `${shot.name}-${ev.ms}.png`) });
      console.log(`${shot.name} at ${ev.ms} ms`);
    }
  }
  done.push({ ...shot, profile: JSON.parse(profile) });
  if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
  await browser.close();
}
const prev = fs.existsSync(path.join(out, 'shots.json')) ? JSON.parse(fs.readFileSync(path.join(out, 'shots.json'), 'utf8')) : [];
const merged = [...prev.filter((p) => !done.some((d) => d.name === p.name)), ...done];
fs.writeFileSync(path.join(out, 'shots.json'), JSON.stringify(merged, null, 1));
