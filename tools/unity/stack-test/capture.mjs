// A Squish Stack level as the app shows it (Expo web, src/web/Preview.js "game-stack"): its screenshot and the state
// the HUD shows (which squishies, the goal, the star cushion, par, moves, the tier), for Program.cs to draw the same
// from the Unity code and compare.  node capture.mjs <out dir> [level node x,y on the forest map]
import fs from 'node:fs';
import path from 'node:path';
import { openApp } from '../ui/snap-page.mjs';

const [out, node = '416,283'] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const { browser, page } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-stack');
await page.waitForTimeout(5000);
await page.mouse.click(218, 180);   // the hub's REGULAR MODE -> the forest map
await page.waitForTimeout(3500);
const [x, y] = node.split(',').map(Number);
await page.mouse.click(x, y);       // level 12, where the walker stands
await page.waitForTimeout(9000);
const state = await page.evaluate(() => {
  const g = window.__components('GoalCard')[0].props;
  const leaf = [...document.querySelectorAll('div')].filter((d) => d.childNodes.length && [...d.childNodes].every((n) => n.nodeType === 3)).map((d) => d.textContent);
  const lab = [...document.querySelectorAll('div')].find((d) => d.innerText === 'MOVES');
  const [moves, par] = lab.nextElementSibling.innerText.split('/').map((t) => parseInt(t, 10));
  return {
    who: g.who.map((c) => c.key),
    goal: g.goal,
    k: g.k,
    star: g.star,
    tier: ['EASY', 'MEDIUM', 'HARD', 'EXPERT'].findIndex((t) => leaf.includes(t)),
    par,
    moves,
  };
});
fs.writeFileSync(path.join(out, 'state.json'), JSON.stringify(state));
await page.screenshot({ path: path.join(out, 'app.png') });
console.log(JSON.stringify(state));
await browser.close();
