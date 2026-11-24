// The app's start-up screens as they look (Expo web on http://localhost:8081, src/web/Preview.js's "auth" and
// "verify"; `npx expo start --web --port 8081`): a screenshot of each state Program.cs rebuilds from the Unity code,
// and the boxes of what's on screen (for finding where a layout differs).  node capture.mjs <out dir>
// No account is touched: only the screens' own checks run (an empty form says "Enter your email and password.").
import fs from 'node:fs';
import path from 'node:path';
import { openApp } from '../ui/snap-page.mjs';

const out = process.argv[2] || 'auth-shots';
fs.mkdirSync(out, { recursive: true });
const URL = (card) => `http://localhost:8081/?phone=1&preview=1&card=${card}`;

// every leaf text's box, and the inputs'
const boxes = (page) => page.evaluate(() => {
  const r = (e) => { const b = e.getBoundingClientRect(); return [b.x, b.y, b.width, b.height].map((v) => +v.toFixed(3)); };
  const texts = [...document.querySelectorAll('div')].filter((d) => d.childNodes.length && [...d.childNodes].every((n) => n.nodeType === 3)).map((d) => ({ t: d.textContent, b: r(d) }));
  const inputs = [...document.querySelectorAll('input')].map((i) => ({ t: i.placeholder, b: r(i) }));
  return { texts, inputs };
});

async function shot(page, name) {
  await page.mouse.move(0, 0);
  await page.screenshot({ path: path.join(out, name + '.png') });
  fs.writeFileSync(path.join(out, name + '.json'), JSON.stringify(await boxes(page), null, 1));
  console.log('shot', name);
}

// clicks the last element with exactly this text (ShadowText draws its copies first)
const tap = (page, text) => page.getByText(text, { exact: true }).last().click();
// the gold button: its lettering is a drawing (no text to find): one gap (9 dp) above "Keep me signed in"'s row (22),
// half its height (42) up, in the middle of the screen
const submit = async (page) => { const b = await page.getByText('Keep me signed in', { exact: true }).last().boundingBox(); await page.mouse.click(416, b.y + b.height / 2 - 11 - 9 - 21); };
const blur = (page) => page.evaluate(() => document.activeElement && document.activeElement.blur());

{
  const { browser, page } = await openApp(URL('auth'));
  await page.waitForTimeout(6000);
  await shot(page, 'login');
  await submit(page);                              // (LOG IN: an empty form)
  await page.waitForTimeout(800);
  await shot(page, 'login-error');                 // "Enter your email and password."
  await page.locator('input').nth(0).fill('mia.squish@example.com');
  await page.locator('input').nth(1).fill('secret12');
  await blur(page);
  await page.waitForTimeout(600);
  await shot(page, 'login-filled');
  await tap(page, 'Show');
  await blur(page);
  await page.waitForTimeout(400);
  await shot(page, 'login-shown');
  await tap(page, 'Register');
  await page.waitForTimeout(1500);
  await shot(page, 'register');
  await page.locator('input').nth(0).fill('Captain');
  await page.locator('input').nth(1).fill('9');
  await blur(page);
  await submit(page);
  await page.waitForTimeout(800);
  await shot(page, 'register-blocked');            // under 13: the parent line
  await tap(page, 'Log in');
  await page.waitForTimeout(400);
  await tap(page, 'Register');
  await page.waitForTimeout(1200);
  await submit(page);
  await page.waitForTimeout(800);
  await shot(page, 'register-error');              // "Enter your age."
  await browser.close();
}
{
  const { browser, page } = await openApp(URL('verify'));
  await page.waitForTimeout(6000);
  await shot(page, 'verify');
  await browser.close();
}
// (develop has no splash screen: the launch colour, then the game intro on the menu)
