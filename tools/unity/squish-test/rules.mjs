// The rules a squish moves, from the app's own src/progression.js (the Expo web bundle's module): today's challenges
// for many dates, bumpDaily for random profiles and events, the streak's coin multiplier. Program.cs `rules` runs
// SquishRules on the same inputs and compares.   node tools/unity/squish-test/rules.mjs <out dir>
import fs from 'node:fs';
import path from 'node:path';
import { openApp } from '../ui/snap-page.mjs';

const [out] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const { browser, page } = await openApp('http://localhost:8081/?phone=1&preview=1&card=scr-stats');
await page.waitForTimeout(5000);
const res = await page.evaluate(() => {
  let P = null;
  for (const [id, m] of __r.getModules()) if (m && m.verboseName === 'src/progression.js') P = __r(id);
  let seed = 77;
  const rnd = () => ((seed = (seed * 1103515245 + 12345) % 2147483648) / 2147483648);
  const pad = (n) => String(n).padStart(2, '0');
  const dates = [];
  for (let i = 0; i < 400; i++) dates.push(`20${25 + Math.floor(rnd() * 3)}-${pad(1 + Math.floor(rnd() * 12))}-${pad(1 + Math.floor(rnd() * 28))}`);
  const challenges = dates.map((d) => ({ date: d, list: P.challengesFor(d) }));
  const bumps = [];
  for (let i = 0; i < 600; i++) {
    const date = dates[i % dates.length];
    const evs = ['squish', 'earn', 'ad', 'bath', 'feed'];
    const prog = {};
    for (const e of evs) if (rnd() < 0.7) prog[e] = Math.floor(rnd() * 130);
    const claimed = rnd() < 0.3 ? { g_squish: true } : {};
    const profile = { daily: rnd() < 0.85 ? { date: rnd() < 0.8 ? date : '2020-01-01', prog, claimed, chest: rnd() < 0.1 } : undefined };
    if (rnd() < 0.5) profile.pxp = Math.floor(rnd() * 5000);
    else profile.level = 1 + Math.floor(rnd() * 12);
    const ev = evs[Math.floor(rnd() * evs.length)];
    const n = ev === 'earn' ? Math.floor(rnd() * 60) + 1 : 1;
    bumps.push({ profile, ev, n, date, out: P.bumpDaily(profile, ev, n, date) });
  }
  const streaks = [];
  for (let i = 0; i < 200; i++) {
    const now = new Date(2026, Math.floor(rnd() * 12), 1 + Math.floor(rnd() * 28), 12);
    const d = new Date(now); d.setDate(d.getDate() - Math.floor(rnd() * 3));
    const lastFull = `${d.getFullYear()}-${pad(d.getMonth() + 1)}-${pad(d.getDate())}`;
    const profile = { lastFull, streak: Math.floor(rnd() * 15) };
    streaks.push({ profile, now: [now.getFullYear(), now.getMonth() + 1, now.getDate()], mult: P.streakMultiplier(profile, now) });
  }
  return { challenges, bumps, streaks };
});
fs.writeFileSync(path.join(out, 'rules.json'), JSON.stringify(res));
console.log(`${res.challenges.length} dates, ${res.bumps.length} bumps, ${res.streaks.length} streaks -> ${out}/rules.json`);
await browser.close();
