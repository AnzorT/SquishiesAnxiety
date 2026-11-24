// Squish Time's screen around the stage, cut from the app's own SquishScreen (src/screens/SquishScreen.js) mounted on
// the Expo web app's preview page with the bundle's own modules (Metro's __r: React, react-dom, SafeAreaProvider,
// SquishScreen), at the A15's size (832 x 384 dp, 2.8125 px per dp), landscape as the app shows it:
//   hud/<piece>.xml  each piece as SVG (tools/unity/ui/snap.js), hud.json where each sits (dp) and the layout's numbers
//   tools/unity/squish-test/ref/squish-*.png   the app's screenshots the HUD test (Program.cs `hud`) compares with
// Called by tools/unity/export-squish.mjs; `node hud.mjs <out dir>` writes only the reference screenshots + state.
import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
import { execFileSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { openApp, snap } from '../ui/snap-page.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const REF = path.join(HERE, 'ref');

// mounts SquishScreen (props merged over the defaults below) into a full-screen box; returns when it has drawn
async function mount(page, props) {
  await page.evaluate((props) => {
    const mod = (re) => { for (const [id, m] of __r.getModules()) if (m && m.verboseName && re.test(m.verboseName)) return __r(id); throw new Error('no ' + re); };
    const React = mod(/^node_modules\/react\/index\.js$/);
    const RD = mod(/^node_modules\/react-dom\/client\.js$/);
    const SA = mod(/^node_modules\/react-native-safe-area-context\/lib\/module\/index\.js$/);
    const Screen = mod(/^src\/screens\/SquishScreen\.js$/).default;
    const h = React.createElement;
    const noop = () => {};
    if (!window.__sqRoot) {
      const div = document.createElement('div');
      div.id = 'sq-screen';
      div.style.cssText = 'position:fixed;left:0;top:0;width:832px;height:384px;z-index:99999;display:flex';
      document.body.appendChild(div);
      window.__sqRoot = RD.createRoot(div);
      window.__sqH = { React, h, SA, Screen, mod };
    }
    // a 1 x 1 transparent card: the stage stays empty (the 3D stage is checked on its own: ref.mjs)
    const url = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==';
    const all = { toy: { id: '1', key: 'mittens', name: 'Mittens', card: { url }, stage: 0 }, coins: 0, onBack: noop, onEarnCoins: noop, onRecordPress: noop, onMarkAchievement: noop, onAdWatched: noop, ...props };
    window.__sqRoot.render(h(SA.SafeAreaProvider, { initialMetrics: { frame: { x: 0, y: 0, width: 832, height: 384 }, insets: { top: 0, left: 0, right: 0, bottom: 0 } }, style: { flex: 1 } }, h(Screen, all)));
  }, props);
  await page.waitForTimeout(1500);
}

const rect = (page, js) => page.evaluate((js) => { const el = eval(js); const r = el.getBoundingClientRect(); return [r.x, r.y, r.width, r.height]; }, js);
const r3 = (v) => Math.round(v * 1000) / 1000;

export async function exportHud(browser, OUT) {
  const dir = path.join(OUT, 'hud');
  fs.mkdirSync(path.join(dir, 'img'), { recursive: true });
  const { page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=scr-stats', { browser });
  await page.waitForTimeout(6000);
  // RN's Animated loops (the hints' bob and pulse) stopped at their rest values: the pieces are cut still
  const layout = { screen: [832, 384], pieces: {} };
  function save(name, s, box) {
    let svg = s.svg;
    for (const data of new Set(Object.values(s.images))) {
      const bytes = Buffer.from(data.split(',')[1], 'base64');
      const hash = crypto.createHash('sha1').update(bytes).digest('hex').slice(0, 12);
      const file = path.join(dir, 'img', hash + '.png');
      if (!fs.existsSync(file)) {
        fs.writeFileSync(file + '.src', bytes);
        execFileSync('python3', ['-c', 'import sys; from PIL import Image; Image.open(sys.argv[1]).convert("RGBA").save(sys.argv[2])', file + '.src', file]);
        fs.unlinkSync(file + '.src');
      }
      svg = svg.split(data).join('Squish/hud/img/' + hash);
    }
    fs.writeFileSync(path.join(dir, name + '.xml'), svg);
    layout.pieces[name] = (box || [s.x, s.y, s.w, s.h]).map(r3);
  }
  const el = (js) => page.evaluateHandle((js) => eval(js), js);
  const comp = (name, i = 0) => `window.__components(${JSON.stringify(name)}, document.getElementById('sq-screen'))[${i}].el`;

  await mount(page, {});
  await page.waitForTimeout(1500);
  // RN's Animated runs on requestAnimationFrame: stopped, and the hints' loops put back to their rest values (the
  // bob, the tilt and the rings' pulse at 0: no transform, rings and halo at opacity 0.95), so the pieces are cut still
  await page.evaluate(() => {
    window.__rafSaved = window.requestAnimationFrame;
    window.requestAnimationFrame = () => 0;
  });
  await page.waitForTimeout(100);
  await page.evaluate(() => {
    const root = document.getElementById('sq-screen');
    const all = (n) => window.__components(n, root).map((c) => c.el);
    for (const r of all('TouchRing')) { r.style.transform = 'none'; r.style.opacity = '0.95'; }
    for (const hnd of all('CandyHand')) hnd.parentElement.style.transform = 'none';
    const halo = all('SettingsHint')[0].querySelector('div');
    halo.style.transform = 'none'; halo.style.opacity = '0.95';
  });
  // the page under everything: the sky
  save('sky', await snap(page, await el(comp('Sky'))));
  // the back orb, the pill's coin, the gear (the button, and its glyph that turns)
  save('back', await snap(page, await el(comp('RoundButton', 0))));
  save('coin', await snap(page, await el(comp('CoinIcon', 0))));
  layout.pieces.coinPill = (await rect(page, comp('CoinCounter'))).map(r3);
  layout.pieces.coinText = (await rect(page, `[...${comp('CoinCounter')}.querySelectorAll('div')].find(d => d.textContent.startsWith('+'))`)).map(r3);
  layout.pieces.earnedText = (await rect(page, `[...${comp('CoinCounter')}.querySelectorAll('div')].find(d => d.textContent === 'EARNED')`)).map(r3);
  save('gear-glyph', await snap(page, await el(comp('GearIcon'))));
  await page.evaluate((js) => { const g = eval(js); g.parentElement.style.opacity = '0'; }, comp('GearIcon'));
  save('gear', await snap(page, await el(comp('RoundButton', 1))));
  await page.evaluate((js) => { const g = eval(js); g.parentElement.style.opacity = '1'; }, comp('GearIcon'));
  layout.pieces.gearGlyphBox = (await rect(page, `${comp('GearIcon')}.parentElement`)).map(r3);
  // the hints: the hands (stage left / right, under the gear), their captions, the pulsing rings
  const hands = await page.evaluate((js) => window.__components('CandyHand', document.getElementById('sq-screen')).length, '');
  for (let i = 0; i < hands; i++) save(`hand-${i}`, await snap(page, await el(comp('CandyHand', i))));
  const pills = await page.evaluate(() => window.__components('HintPill', document.getElementById('sq-screen')).length);
  for (let i = 0; i < pills; i++) save(`hint-${i}`, await snap(page, await el(comp('HintPill', i))));
  const rings = await page.evaluate(() => window.__components('TouchRing', document.getElementById('sq-screen')).length);
  for (let i = 0; i < rings; i++) layout.pieces[`ring-${i}`] = (await rect(page, comp('TouchRing', i))).map(r3);
  layout.pieces.gearHalo = (await rect(page, `${comp('SettingsHint')}.querySelector('div')`)).map(r3);
  layout.pieces.stage = (await rect(page, `${comp('SquishStage')}`)).map(r3);
  // the boosts' panel (the ads aren't in Unity: shown as the app shows them, a tap says so)
  save('boosts', await snap(page, await el(`${comp('WatchAdButton', 0)}.parentElement.parentElement`)));
  await page.screenshot({ path: path.join(REF, 'squish-a15.png') });

  await page.evaluate(() => { window.requestAnimationFrame = window.__rafSaved; });
  // the settings card: open, then each toggle and choice in both states (the screen's props)
  await page.evaluate((js) => eval(js).click(), comp('RoundButton', 1));
  await page.waitForTimeout(800);
  const card = `${comp('SettingsModal')}.querySelectorAll(':scope > div')[1]`;
  const variants = [
    { name: 'on', props: { squishSoundEnabled: true, coinSoundEnabled: true, releaseSoundEnabled: true, vibrationEnabled: true, showFps: true, pokeStrength: 3, pokeOutward: false } },
    { name: 'off', props: { squishSoundEnabled: false, coinSoundEnabled: false, releaseSoundEnabled: false, vibrationEnabled: false, showFps: false, pokeStrength: 1, pokeOutward: true } },
  ];
  for (const v of variants) {
    await mount(page, v.props);
    await page.waitForTimeout(600);
    const toggles = await page.evaluate(() => window.__components('ToggleSwitch', document.getElementById('sq-screen')).length);
    for (let i = 0; i < toggles; i++) save(`toggle-${i}-${v.name}`, await snap(page, await el(comp('ToggleSwitch', i))));
    if (v.name === 'on') {
      save('settings', await snap(page, await el(card)));
      await page.screenshot({ path: path.join(REF, 'squish-settings-a15.png') });
    }
  }
  // the segmented choices: poke strength 1-5, push in / pop out (each selected in turn)
  for (let s = 1; s <= 5; s++) {
    await mount(page, { pokeStrength: s, pokeOutward: s % 2 === 0 });
    save(`strength-${s}`, await snap(page, await el(comp('Segmented', 0))));
    if (s <= 2) save(`direction-${s % 2 === 0 ? 'out' : 'in'}`, await snap(page, await el(comp('Segmented', 1))));
  }
  layout.pieces.closeX = (await rect(page, `${comp('SettingsModal')}.querySelectorAll(':scope > div')[1].querySelector('[role=button],[tabindex]')`).catch(() => [0, 0, 0, 0])).map(r3);
  // close it
  await page.evaluate((js) => eval(js).click(), `${comp('SettingsModal')}.querySelector(':scope > div')`);
  await page.waitForTimeout(800);

  // the punishment: five quick jabs on the stage
  const st = layout.pieces.stage;
  for (let i = 0; i < 6; i++) { await page.mouse.click(st[0] + st[2] / 2, st[1] + st[3] / 2, { delay: 30 }); await page.waitForTimeout(60); }
  await page.waitForTimeout(1500);
  const pun = await page.evaluate(() => window.__components('PunishCard', document.getElementById('sq-screen')).length);
  if (pun) {
    // the siren's shake at rest; the title (OutlinedTitle's <text>) is drawn by the Unity code: its box
    await page.evaluate(() => { window.requestAnimationFrame = () => 0; });
    await page.waitForTimeout(100);
    await page.evaluate(() => { const s = window.__components('Siren', document.getElementById('sq-screen'))[0].el; s.style.transform = 'none'; });
    layout.pieces.punishTitle = (await rect(page, `[...${comp('PunishCard')}.querySelectorAll('svg')].find((v) => v.textContent.includes('WHOA'))`)).map(r3);
    save('punish', await snap(page, await el(comp('PunishCard'))));
    await page.screenshot({ path: path.join(REF, 'squish-punish-a15.png') });
  } else console.log('no punishment card (the jabs did not trip it)');

  // the floating "+N": FloatingCoin's spinning coin (CoinIcon 30, glow); its sticker (OutlinedTitle gold 26, outline
  // 2.5) is drawn by the Unity code (Screens/Common/Kit.OutlinedTitle: react-native-svg's <text> isn't in the exports)
  await page.evaluate(() => {
    const { h, mod } = window.__sqH;
    const RD = mod(/^node_modules\/react-dom\/client\.js$/);
    const { CoinIcon } = mod(/^src\/components\/candy\/Coin\.js$/);
    const d = document.createElement('div'); d.id = 'sq-float'; d.style.cssText = 'position:fixed;left:300px;top:100px;z-index:100000;display:flex'; document.body.appendChild(d);
    RD.createRoot(d).render(h(CoinIcon, { size: 30, glow: true }));
  });
  await page.waitForTimeout(400);
  save('float-coin', await snap(page, await el(`document.getElementById('sq-float').firstElementChild`)));
  fs.writeFileSync(path.join(OUT, 'hud.json'), JSON.stringify(layout, null, 1));
  console.log(`hud: ${Object.keys(layout.pieces).length} pieces -> ${dir}`, errors.slice(0, 3));
  await page.close();
}

if (process.argv[1] && path.resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const { chromium } = await import('../ui/snap-page.mjs');
  const browser = await chromium.launch();
  await exportHud(browser, path.join(REPO, 'unity/Assets/Resources/Squish'));
  await browser.close();
}
