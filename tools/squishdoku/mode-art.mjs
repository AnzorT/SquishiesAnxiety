// The pictures on Squishdoku's two mode cards (the hub, 2026-11-16, the user: the cards in the app's new design). Both
// are the Game Park's Squishdoku clip (webgame/app/previews/squishdoku.mp4) at its end, the board with its creatures:
//   regular: as it is
//   blitz:   cooled to an electric blue, with speed streaks and two gold lightning bolts
// Drawn once by Chrome (the installed one: Playwright's own Chromium can't decode the clip's H.264).
//
//   NODE_PATH=<a folder with playwright> node tools/squishdoku/mode-art.mjs
//     -> assets/squishdoku/mode-regular.jpg, assets/squishdoku/mode-blitz.jpg
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const CLIP = path.join(REPO, 'webgame/app/previews/squishdoku.mp4');
const OUT = path.join(REPO, 'assets/squishdoku');
const CHROME = process.env.CHROME || 'C:/Users/R6 Siege/AppData/Local/Google/Chrome/Application/chrome.exe';
const AT = 4.55; // seconds into the clip: every creature placed

const browser = await chromium.launch({ executablePath: CHROME, args: ['--allow-file-access-from-files', '--autoplay-policy=no-user-gesture-required'] });
const page = await browser.newPage();
await page.goto(pathToFileURL(path.dirname(CLIP)).href + '/');
const shots = await page.evaluate(
  async ({ src, at }) => {
    const v = document.createElement('video');
    v.src = src;
    v.muted = true;
    document.body.appendChild(v);
    await new Promise((r) => v.addEventListener('loadeddata', r, { once: true }));
    await new Promise((r) => {
      v.addEventListener('seeked', r, { once: true });
      v.currentTime = at;
      setTimeout(r, 3000);
    });
    const W = v.videoWidth, H = v.videoHeight;
    const make = () => {
      const c = document.createElement('canvas');
      c.width = W;
      c.height = H;
      const x = c.getContext('2d');
      x.drawImage(v, 0, 0, W, H);
      return [c, x];
    };
    const [reg] = make();
    const [bz, x] = make();
    // cool it: a blue multiply, then a deep-blue vignette round the edges
    x.globalCompositeOperation = 'multiply';
    x.fillStyle = '#9cc2ff';
    x.fillRect(0, 0, W, H);
    x.globalCompositeOperation = 'source-over';
    const vg = x.createRadialGradient(W / 2, H / 2, H * 0.3, W / 2, H / 2, W * 0.62);
    vg.addColorStop(0, 'rgba(8,30,90,0)');
    vg.addColorStop(1, 'rgba(10,40,120,0.6)');
    x.fillStyle = vg;
    x.fillRect(0, 0, W, H);
    // speed streaks across, slanted
    x.save();
    x.translate(W / 2, H / 2);
    x.rotate(-0.12);
    const streaks = [[-0.42, 0.06, 0.5], [-0.3, 0.035, 0.42], [-0.12, 0.05, 0.6], [0.08, 0.03, 0.38], [0.24, 0.055, 0.55], [0.38, 0.035, 0.45]];
    streaks.forEach(([y, h, len], i) => {
      const sy = y * H, sh = h * H * 0.35, sx = (i % 2 ? -0.55 : 0.05) * W, sl = len * W;
      const g = x.createLinearGradient(sx, 0, sx + sl, 0);
      g.addColorStop(0, 'rgba(255,255,255,0)');
      g.addColorStop(0.6, 'rgba(210,240,255,0.55)');
      g.addColorStop(1, 'rgba(255,255,255,0)');
      x.fillStyle = g;
      x.fillRect(sx, sy, sl, sh);
    });
    x.restore();
    // two gold bolts with the app's ink outline and a warm glow
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
  },
  { src: pathToFileURL(CLIP).href, at: AT },
);
await browser.close();
fs.mkdirSync(OUT, { recursive: true });
['regular', 'blitz'].forEach((name, i) => {
  const f = path.join(OUT, `mode-${name}.jpg`);
  fs.writeFileSync(f, Buffer.from(shots[i].split(',')[1], 'base64'));
  console.log(path.relative(REPO, f), Math.round(fs.statSync(f).size / 1024) + ' KB');
});
