// The pictures on Squish Stack's and Squish Hop's mode cards (their hubs, 2026-11-16, the user: "the same thing" as
// Squishdoku's hub). Like tools/squishdoku/mode-art.mjs: a frame of the game's Game Park clip
// (webgame/app/previews/<game>.mp4), as it is for REGULAR MODE, and for BLITZ MODE cooled to an electric blue with speed
// streaks and two gold lightning bolts.
// ffmpeg takes the frame (Playwright's Chromium can't decode the clips' H.264); Chromium paints the Blitz one.
// Squish Sort's (2026-11-17, its hub made the same as the others') is a frame of the game itself instead, as it is now
// (the realistic fridges in the kitchen): the web version (src/web, Metro on :8081) playing a level, mid-peek with the
// doors open, laid out 1500 wide so the fridge stands clear of the side panel and the tray, cropped round it.
//
//   node tools/games/mode-art.mjs [stack] [hop] [sort]      (all three by default)
//     -> assets/<game>/mode-regular.jpg, assets/<game>/mode-blitz.jpg
import fs from 'node:fs';
import os from 'node:os';
import path from 'node:path';
import { execFileSync } from 'node:child_process';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
// the frame of each clip: Stack's tower almost built, Hop's board before the first hop
// (Squish Sort's: level 12, a big fridge with a few squishies, from the running web version)
const GAMES = [
  { key: 'stack', at: 4.9 },
  { key: 'hop', at: 0.3 },
  { key: 'sort', web: 'http://localhost:8081/?phone=1&preview=1&card=sort-level&lv=12', crop: { x: 330, y: 0, width: 1000, height: 400 } },
].filter((g) => process.argv.length < 3 || process.argv.slice(2).includes(g.key));

const tmp = fs.mkdtempSync(path.join(os.tmpdir(), 'mode-art-'));
// (Playwright's own Chromium, or the installed Chrome when that isn't downloaded)
const browser = await chromium.launch().catch(() => chromium.launch({ channel: 'chrome' }));
const page = await browser.newPage();
for (const { key, at, web, crop } of GAMES) {
  const png = path.join(tmp, `${key}.png`);
  if (web) {
    // the game, mid-peek: the deal is in and the REMEMBER! banner has gone
    const shot = await browser.newPage({ viewport: { width: 1500, height: 400 } });
    await shot.goto(web, { waitUntil: 'load', timeout: 180000 });
    await shot.waitForFunction(() => window.__sort && window.__sort.state().phase === 'peek', null, { timeout: 180000 });
    await shot.waitForTimeout(1700);
    // (and the REMEMBER! words hidden: the picture is the fridge)
    await shot.evaluate(() => {
      // (the words' own boxes only: nothing with a picture in it, which would be the play area)
      const only = (el) => /^(REMEMBER!)+$/.test(el.textContent.replace(/s+/g, '')) && !el.querySelector('svg, img, iframe, canvas');
      for (const el of document.querySelectorAll('div')) {
        if (!only(el) || el.children.length) continue;
        let top = el;
        while (top.parentElement && only(top.parentElement)) top = top.parentElement;
        top.style.visibility = 'hidden';
      }
    });
    await shot.screenshot({ path: png, clip: crop });
    await shot.close();
  } else execFileSync('ffmpeg', ['-v', 'error', '-y', '-ss', String(at), '-i', path.join(REPO, `webgame/app/previews/${key}.mp4`), '-frames:v', '1', png]);
  const src = `data:image/png;base64,${fs.readFileSync(png).toString('base64')}`;
  const shots = await page.evaluate(async (src) => {
    const img = new Image();
    img.src = src;
    await img.decode();
    const W = img.naturalWidth;
    const H = img.naturalHeight;
    const make = () => {
      const c = document.createElement('canvas');
      c.width = W;
      c.height = H;
      const x = c.getContext('2d');
      x.drawImage(img, 0, 0, W, H);
      return [c, x];
    };
    const [reg] = make();
    const [bz, x] = make();
    // (the same Blitz look as Squishdoku's: tools/squishdoku/mode-art.mjs)
    x.globalCompositeOperation = 'multiply';
    x.fillStyle = '#9cc2ff';
    x.fillRect(0, 0, W, H);
    x.globalCompositeOperation = 'source-over';
    const vg = x.createRadialGradient(W / 2, H / 2, H * 0.3, W / 2, H / 2, W * 0.62);
    vg.addColorStop(0, 'rgba(8,30,90,0)');
    vg.addColorStop(1, 'rgba(10,40,120,0.6)');
    x.fillStyle = vg;
    x.fillRect(0, 0, W, H);
    x.save();
    x.translate(W / 2, H / 2);
    x.rotate(-0.12);
    const streaks = [[-0.42, 0.06, 0.5], [-0.3, 0.035, 0.42], [-0.12, 0.05, 0.6], [0.08, 0.03, 0.38], [0.24, 0.055, 0.55], [0.38, 0.035, 0.45]];
    streaks.forEach(([y, h, len], i) => {
      const sy = y * H;
      const sh = h * H * 0.35;
      const sx = (i % 2 ? -0.55 : 0.05) * W;
      const sl = len * W;
      const g = x.createLinearGradient(sx, 0, sx + sl, 0);
      g.addColorStop(0, 'rgba(255,255,255,0)');
      g.addColorStop(0.6, 'rgba(210,240,255,0.55)');
      g.addColorStop(1, 'rgba(255,255,255,0)');
      x.fillStyle = g;
      x.fillRect(sx, sy, sl, sh);
    });
    x.restore();
    const BOLT = 'M58 0 L18 70 L44 70 L28 128 L84 46 L56 46 L74 0 Z';
    const bolt = (cx, cy, s, rot) => {
      x.save();
      x.translate(cx, cy);
      x.rotate(rot);
      x.scale(s, s);
      x.translate(-50, -64);
      const p = new Path2D(BOLT);
      x.shadowColor = 'rgba(255,214,90,0.95)';
      x.shadowBlur = 40 / s;
      x.lineJoin = 'round';
      x.strokeStyle = '#6b4426';
      x.lineWidth = 9;
      x.stroke(p);
      x.shadowBlur = 0;
      const g = x.createLinearGradient(0, 0, 0, 128);
      g.addColorStop(0, '#fffbe6');
      g.addColorStop(0.35, '#ffe57e');
      g.addColorStop(0.7, '#ffbe2e');
      g.addColorStop(1, '#f08c10');
      x.fillStyle = g;
      x.fill(p);
      x.strokeStyle = 'rgba(255,255,255,0.8)';
      x.lineWidth = 2.5;
      x.stroke(new Path2D('M56 6 L24 64'));
      x.restore();
    };
    bolt(W * 0.17, H * 0.5, 2.2, -0.18);
    bolt(W * 0.84, H * 0.47, 1.9, 0.16);
    return [reg.toDataURL('image/jpeg', 0.88), bz.toDataURL('image/jpeg', 0.88)];
  }, src);
  const out = path.join(REPO, 'assets', key);
  fs.mkdirSync(out, { recursive: true });
  ['regular', 'blitz'].forEach((name, i) => {
    const f = path.join(out, `mode-${name}.jpg`);
    fs.writeFileSync(f, Buffer.from(shots[i].split(',')[1], 'base64'));
    console.log(path.relative(REPO, f), `${Math.round(fs.statSync(f).size / 1024)} KB`);
  });
}
await browser.close();
fs.rmSync(tmp, { recursive: true, force: true });
