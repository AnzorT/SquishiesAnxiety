// A Squish Stack level as the app shows it (Expo web, src/web/Preview.js "game-stack"): its screenshot and the state
// the HUD shows (which squishies, the goal, the star cushion, par, moves, the stars still possible, the tip), for
// Program.cs to draw the same from the Unity code and compare.  node capture.mjs <out dir> [level node x,y on the map]
import fs from 'node:fs';
import path from 'node:path';
import { openApp } from '../ui/snap-page.mjs';

const [out, node = '416,187'] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const { browser, page } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-stack');
await page.waitForTimeout(5000);
await page.mouse.click(705, 143);
await page.waitForTimeout(3000);
const [x, y] = node.split(',').map(Number);
await page.mouse.click(x, y);
await page.waitForTimeout(9000);
const state = await page.evaluate(() => {
  const g = window.__components('GoalCard')[0].props;
  const leaf = [...document.querySelectorAll('div')].filter((d) => d.childNodes.length && [...d.childNodes].every((n) => n.nodeType === 3)).map((d) => d.textContent);
  const lvl = leaf.find((t) => /^LEVEL \d+$/.test(t));
  return {
    who: g.who.map((c) => c.key),
    goal: g.goal,
    k: g.k,
    star: g.star,
    stars: window.__components('Meter')[0].props.stars,
    lv: +lvl.slice(6),
    tier: ['EASY', 'MEDIUM', 'HARD', 'EXPERT'].findIndex((t) => leaf.includes(t)),
    par: +leaf.find((t) => /^PAR \d+$/.test(t)).slice(4),
    moves: +leaf[leaf.indexOf('MOVES') + 1],
    tip: leaf.find((t) => /cushion|squishy|GOAL card/.test(t) && t.length > 20) || null,
  };
});
fs.writeFileSync(path.join(out, 'state.json'), JSON.stringify(state));
await page.screenshot({ path: path.join(out, 'app.png') });
console.log(JSON.stringify(state));
await browser.close();
