// The GPU layers of a scene (PERF 2026-11-20): how many composited layers the page has, how big, and what they cost in
// tile memory (each layer that draws is rastered in tiles at the device's pixel ratio: width x height x DPR^2 x 4 bytes,
// counting only the part inside the screen), the biggest ones named by their element. On the Galaxy A16 the WebView's
// tile budget is 20 screens (185 MB hard, 97 MB soft): past it frames are drawn with tiles missing (flicker).
//   NODE_PATH=<node_modules with playwright> GAME=<build dir> node tools/perf/layers.mjs [menu|chars|level|park|house ...]
// env: VIEW=796x384, DPR=2.8125
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const GAME = process.env.GAME ? path.resolve(process.env.GAME, 'App.dc.html') : path.join(REPO, 'webgame/test/out/webgame/App.dc.html');
const VIEW = (([w, h]) => ({ width: +w, height: +h }))((process.env.VIEW || '796x384').split('x'));
const DPR = +(process.env.DPR || 2.8125);
const scenes = process.argv.slice(2).length ? process.argv.slice(2) : ['menu', 'chars', 'level', 'park', 'house'];
const INIT = { screen: 'menu', state: { level: 12, coins: 31342, gems: 975, owned: ['mittens', 'frybo', 'dunkie', 'bao', 'nimbo', 'biscuit', 'bean', 'zippy'], sel: 'frybo', hiddenKeys: [], games: [], xp: { level: 12, into: 280, need: 1300, per: 100 }, road: Array.from({ length: 30 }, (_, i) => ({ lv: i + 1, k: 'coins', n: 100, got: i < 9, claimable: i >= 9 && i < 11 })) }, config: {} };
const browser = await chromium.launch({ args: ['--allow-file-access-from-files', '--use-gl=swiftshader', '--enable-gpu-rasterization', '--ignore-gpu-blocklist'] });
for (const sc of scenes) {
  const ctx = await browser.newContext({ viewport: VIEW, deviceScaleFactor: DPR, hasTouch: true });
  const page = await ctx.newPage();
  page.on('pageerror', e => console.log('  pageerror', e.message.slice(0, 160)));
  await page.addInitScript(([init]) => { window.__SQUISH_INIT__ = init; window.ReactNativeWebView = { postMessage() {} }; try { localStorage.setItem('squishsquad.menu.v1', JSON.stringify({ season: 'rainy' })); } catch (e) {} }, [INIT]);
  await page.goto(pathToFileURL(GAME).href);
  await page.waitForFunction(() => document.querySelector('.mm-tab'), null, { timeout: 120000 });
  await page.waitForTimeout(4000);
  const tap = { chars: '.mm-tab[data-tab="creatures"]', level: '.sq-crest', park: '.mm-play', house: '.mm-tab[data-tab="house"]' }[sc];
  if (tap) await page.click(tap, { force: true });
  await page.waitForTimeout(sc === 'house' ? 1000 : 500);
  if (sc === 'house') await page.waitForFunction(() => { const h = document.querySelector('.mm-house'); return h && +getComputedStyle(h).opacity > 0.99; }, null, { timeout: 180000 });
  await page.waitForTimeout(sc === 'house' ? 5000 : 5000);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('DOM.enable'); await cdp.send('DOM.getDocument', { depth: -1 });
  const got = new Promise(r => cdp.on('LayerTree.layerTreeDidChange', e => { if (e.layers) r(e.layers); }));
  await cdp.send('LayerTree.enable');
  await page.evaluate(() => new Promise(r => requestAnimationFrame(() => requestAnimationFrame(r))));
  const layers = await Promise.race([got, new Promise(r => setTimeout(() => r([]), 5000))]);
  const W = VIEW.width, H = VIEW.height;
  let total = 0; const rows = [];
  // positions are relative to the parent layer: add up the offsets
  const byId = new Map(layers.map(l => [l.layerId, l]));
  const abs = l => { let x = 0, y = 0, p = l; while (p) { x += p.offsetX + (p.transform ? p.transform[12] : 0); y += p.offsetY + (p.transform ? p.transform[13] : 0); p = p.parentLayerId ? byId.get(p.parentLayerId) : null; } return [x, y]; };
  for (const l of layers) {
    if (!l.drawsContent || l.invisible) continue;
    const [x, y] = abs(l);
    const vis = Math.max(0, Math.min(x + l.width, W) - Math.max(x, 0)) * Math.max(0, Math.min(y + l.height, H) - Math.max(y, 0));
    const mb = vis * DPR * DPR * 4 / 1048576, full = l.width * l.height * DPR * DPR * 4 / 1048576;
    total += mb;
    let who = '';
    if (l.backendNodeId) { try { const d = await cdp.send('DOM.resolveNode', { backendNodeId: l.backendNodeId }); const o = await cdp.send('Runtime.callFunctionOn', { objectId: d.object.objectId, functionDeclaration: 'function () { const nm = e => { if (!e || !e.tagName) return "#"; const c = typeof e.className === "string" ? e.className : (e.className && e.className.baseVal) || ""; return e.tagName.toLowerCase() + (c ? "." + c.trim().split(/\s+/).slice(0, 2).join(".") : ""); }; const up = []; let p = this.nodeType === 1 ? this : this.parentElement; for (let i = 0; i < 4 && p; i++) { up.push(nm(p)); p = p.parentElement; while (p && p.parentElement && !(typeof p.className === "string" ? p.className : p.className && p.className.baseVal) && p.tagName !== "svg") p = p.parentElement; } return up.join(" < "); }', returnByValue: true }); who = o.result.value; } catch (e) { who = '?'; } }
    rows.push({ id: l.layerId, mb, full, w: l.width, h: l.height, x: Math.round(x), y: Math.round(y), who, reason: '' });
  }
  rows.sort((a, b) => b.mb - a.mb);
  console.log(`${sc}: ${layers.length} layers, ${rows.length} draw; tiles on screen ~${total.toFixed(0)} MB (${(total / (W * H * DPR * DPR * 4 / 1048576)).toFixed(1)} screens)`);
  for (const r of rows.slice(0, +(process.env.TOP || 14))) {
    try { const c = await cdp.send('LayerTree.compositingReasons', { layerId: r.id }); r.reason = (c.compositingReasonIds || c.compositingReasons || []).join(','); } catch (e) { /* gone */ }
    console.log(`  ${r.mb.toFixed(1).padStart(6)} MB (whole ${r.full.toFixed(1).padStart(5)})  ${String(r.w).padStart(5)}x${String(r.h).padEnd(5)} @${r.x},${r.y}  ${r.who}  [${r.reason}]`);
  }
  await ctx.close();
}
await browser.close();
