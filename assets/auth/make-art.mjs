// The sign-in screens' two pictures (src/screens/AuthScreen.js, VerifyEmailScreen.js), drawn by headless Chrome from
// the game's own code, so they match the menu and the intro:
//
//   house-bg.jpg  the Main Menu's house (webgame main-menu-scene.js: a sunny day, the house at its best), softened and
//                 warmed, the screens' one full-screen picture: sign-in is the front door of the same game
//   logo.png      the plush SQUISH SQUAD logo the game intro drops in (webgame/app/intro.js LOGO, the same layers)
//   mittens.png   Mittens at rest, drawn by the live rig's own page (android assets rig/host.html): the header shows it
//                 until the live rig has drawn, so the two are the same creature in the same place
//
//   NODE_PATH=<a folder with playwright> node assets/auth/make-art.mjs
//
// (it reads the built menu, android/app/src/main/assets/webgame: run node webgame/build.mjs first if that's missing)
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../..');
const SCENE = path.join(REPO, 'android/app/src/main/assets/webgame/main-menu-scene.js');
const RIG = path.join(REPO, 'android/app/src/main/assets/rig/host.html');
const FREDOKA = path.join(REPO, 'node_modules/@expo-google-fonts/fredoka/700Bold/Fredoka_700Bold.ttf');
// the logo's letters, read from the intro so the two can't drift apart
const intro = fs.readFileSync(path.join(REPO, 'webgame/app/intro.js'), 'utf8');
const m = intro.match(/const LOGO = (\[[\s\S]*?\]\]);/);
if (!m) throw new Error('LOGO not found in webgame/app/intro.js');
const LOGO = JSON.parse(m[1].replace(/'/g, '"'));

// The backdrop: the scene at the widest phone shape we lay out for (900 x 412 dp), 2 px a dp. Soft (a light blur, so
// the card in front is what the eye reads) and a little warmer and darker towards the bottom, where the card stands.
const BG_W = 900, BG_H = 412, BG_K = 2;
const SOFT = { BLUR: 2.6, BRIGHT: 0.94, WARM_MID: 0.16, WARM_BOT: 0.5, VIG: 0.42 };
// The logo: 600 x 124 like the intro's .si-logo, drawn at 1.6x (it shows about 300 wide on a ~2.8x phone).
const LOGO_W = 600, LOGO_H = 124, LOGO_K = 1.6, LOGO_M = 30;

const font = `@font-face{font-family:Fredoka;font-weight:700;src:url(${pathToFileURL(FREDOKA).href});}`;
// (the rig page reads its creature's files by XHR, as in the app's WebView)
const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });

// ---- the house ----
{
  const page = await browser.newPage({ viewport: { width: BG_W, height: BG_H }, deviceScaleFactor: BG_K });
  const html = `<!doctype html><html><head><style>${font}
html,body{margin:0;width:100%;height:100%;overflow:hidden;background:#cf955a;}
#s{position:absolute;inset:-10px;filter:blur(BLURpx) saturate(1.04) brightness(BRIGHT);}
/* warm, then darker towards the bottom (where the card stands) and at the edges */
#warm{position:absolute;inset:0;background:linear-gradient(180deg,rgba(255,196,120,.08) 0%,rgba(150,80,30,WARM_MID) 40%,rgba(70,34,10,WARM_BOT) 100%);}
#vig{position:absolute;inset:0;background:radial-gradient(120% 125% at 50% 28%,rgba(40,18,4,0) 50%,rgba(40,18,4,VIG) 100%);}
</style><script src="${pathToFileURL(SCENE).href}"></script></head><body><div id="s"></div><div id="warm"></div><div id="vig"></div>
<script>const Sc = window.MainMenuScene; document.getElementById('s').innerHTML = Sc.svg(Sc.state({ level: 30, season: 'sunny' }));</script></body></html>`;
  const tmp = path.join(HERE, '.house.tmp.html');
  fs.writeFileSync(tmp, Object.entries(SOFT).reduce((h, [k, v]) => h.split(k).join(String(v)), html));
  await page.goto(pathToFileURL(tmp).href);
  await page.waitForTimeout(400);
  // (SMIL clouds / birds stopped where they start)
  await page.evaluate(() => document.querySelectorAll('svg').forEach((s) => s.pauseAnimations && (s.pauseAnimations(), s.setCurrentTime(0))));
  await page.screenshot({ path: path.join(HERE, 'house-bg.jpg'), type: 'jpeg', quality: 82 });
  fs.unlinkSync(tmp);
  await page.close();
}

// ---- the logo ----
{
  // (the letters' outlines reach past the intro's 600 box at both ends: room around it)
  const page = await browser.newPage({ viewport: { width: LOGO_W + 2 * LOGO_M, height: LOGO_H + 12 }, deviceScaleFactor: LOGO_K });
  // (a file page: an about:blank one can't load the font file)
  const tmp = path.join(HERE, '.logo.tmp.html');
  fs.writeFileSync(tmp, `<!doctype html><html><head><style>${font}html,body{margin:0;background:transparent;}</style></head><body><div id="b" style="position:relative;left:${LOGO_M}px;width:${LOGO_W}px;height:${LOGO_H}px"></div></body></html>`);
  await page.goto(pathToFileURL(tmp).href);
  fs.unlinkSync(tmp);
  await page.evaluate(() => document.fonts.load('700 86px Fredoka'));
  await page.evaluate((LOGO) => {
    // webgame/app/intro.js logoSvg(), the same letters, widths and layers (here all in one box, not moving)
    const NS = 'http://www.w3.org/2000/svg', r1 = (x) => (Math.round(x * 10) / 10).toString(), box = document.getElementById('b'), K = 600 / 640;
    const probeS = document.createElementNS(NS, 'svg'); probeS.setAttribute('viewBox', '0 0 640 132'); probeS.style.cssText = 'position:absolute;left:0;top:0;width:600px;height:124px;visibility:hidden;'; box.appendChild(probeS);
    const F = 'font-family="Fredoka, Nunito, sans-serif" font-weight="700" font-size="86" text-anchor="middle"';
    const probe = document.createElementNS(NS, 'text'); probe.setAttribute('font-family', 'Fredoka, Nunito, sans-serif'); probe.setAttribute('font-weight', '700'); probe.setAttribute('font-size', '86'); probeS.appendChild(probe);
    const widths = LOGO.map((L) => { if (L[0] === ' ') return 22; probe.textContent = L[0]; let w = 0; try { w = probe.getComputedTextLength(); } catch (e) {} return (w || 54) + 3; });
    probeS.remove(); const total = widths.reduce((a, b) => a + b, 0); let x = 320 - total / 2;
    LOGO.forEach((L, i) => { const w = widths[i]; if (L[0] !== ' ') { const cx = r1(x + w / 2), x0 = x - 14, ww = w + 28, d = document.createElement('div');
        d.style.cssText = 'position:absolute;left:' + r1(x0 * K) + 'px;top:0;width:' + r1(ww * K) + 'px;height:124px;';
        d.innerHTML = '<svg viewBox="' + r1(x0) + ' 0 ' + r1(ww) + ' 132" width="100%" height="100%" style="display:block;overflow:visible"><defs>'
          + '<linearGradient id="siShine' + i + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#ffffff" stop-opacity="0.75"/><stop offset="0.4" stop-color="#ffffff" stop-opacity="0"/></linearGradient>'
          + '<linearGradient id="siL' + i + '" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="' + L[1] + '"/><stop offset="0.55" stop-color="' + L[2] + '"/><stop offset="1" stop-color="' + L[3] + '"/></linearGradient></defs>'
          + '<text x="' + cx + '" y="108" ' + F + ' fill="#1e0640" stroke="#1e0640" stroke-width="16" stroke-linejoin="round" opacity="0.4" transform="translate(0 6)">' + L[0] + '</text>'
          + '<text x="' + cx + '" y="108" ' + F + ' fill="#3d1268" stroke="#3d1268" stroke-width="16" stroke-linejoin="round">' + L[0] + '</text>'
          + '<text x="' + cx + '" y="108" ' + F + ' fill="url(#siL' + i + ')" stroke="url(#siL' + i + ')" stroke-width="5" stroke-linejoin="round">' + L[0] + '</text>'
          + '<text x="' + cx + '" y="108" ' + F + ' fill="none" stroke="#ffffff" stroke-width="1.7" stroke-dasharray="4.5 3.6" stroke-linecap="round" opacity="0.85">' + L[0] + '</text>'
          + '<text x="' + cx + '" y="108" ' + F + ' fill="url(#siShine' + i + ')">' + L[0] + '</text></svg>';
        box.appendChild(d); } x += w; });
  }, LOGO);
  await page.waitForTimeout(200);
  // just the letters (and their outline and drop), trimmed to the pixels they cover
  const full = await page.screenshot({ omitBackground: true });
  const box = await page.evaluate(async ({ b64, k }) => {
    const im = new Image(); im.src = 'data:image/png;base64,' + b64; await im.decode();
    const c = document.createElement('canvas'); c.width = im.width; c.height = im.height; const g = c.getContext('2d'); g.drawImage(im, 0, 0);
    const a = g.getImageData(0, 0, c.width, c.height).data; let x0 = c.width, x1 = 0, y0 = c.height, y1 = 0;
    for (let y = 0; y < c.height; y++) for (let x = 0; x < c.width; x++) if (a[(y * c.width + x) * 4 + 3] > 6) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
    return { x0: x0 / k, x1: (x1 + 1) / k, y0: y0 / k, y1: (y1 + 1) / k };
  }, { b64: full.toString('base64'), k: LOGO_K });
  const clip = { x: Math.floor(box.x0) - 1, y: Math.floor(box.y0) - 1, width: 0, height: 0 };
  clip.width = Math.ceil(box.x1) + 1 - clip.x;
  clip.height = Math.ceil(box.y1) + 1 - clip.y;
  await page.screenshot({ path: path.join(HERE, 'logo.png'), omitBackground: true, clip });
  console.log('logo clip', clip);
  await page.close();
}

// ---- Mittens at rest ----
{
  const S = 64, K = 3;
  const page = await browser.newPage({ viewport: { width: S, height: S }, deviceScaleFactor: K });
  await page.goto(pathToFileURL(RIG).href);
  await page.waitForFunction(() => window.rigHost && (window.__rigOut || []).some((m) => m.type === 'ready'), null, { timeout: 20000 });
  // (as RigCreature mounts it with rigShadow false and no shuffling)
  await page.addStyleTag({ content: 'ellipse[fill="#6a1b9a"]{display:none!important}' });
  await page.evaluate(() => { window.rigHost.shuffle(false); window.rigHost.mount('mittens'); });
  await page.waitForFunction(() => (window.__rigOut || []).some((m) => m.type === 'mounted'), null, { timeout: 20000 });
  await page.waitForTimeout(700);
  await page.evaluate(() => window.rigHost.pause(true));
  await page.screenshot({ path: path.join(HERE, 'mittens.png'), omitBackground: true });
  await page.close();
}

await browser.close();
for (const f of ['house-bg.jpg', 'logo.png', 'mittens.png']) console.log('assets/auth/' + f, Math.round(fs.statSync(path.join(HERE, f)).size / 1024) + ' KB');
