// The Squad House page made deterministic, for the Unity port's checks (HOUSE_PORT_PLAN.md stage 0).
//
//   import { openHouse, buildWeb } from './harness.mjs'
//   const H = await openHouse(browser, fixture, { room: 'kitchen' })
//   await H.frames(60)                 // the house runs 60 frames of 16 ms of virtual time
//   await H.still()                    // fonts and pictures decoded, SMIL stripped from every picture, motions paused
//   await H.page.screenshot(...)
//
// What it pins down:
//   - time: tools/unity/rig/virtual-clock.js replaces performance.now, Date.now, timers and requestAnimationFrame, so
//     the page only moves when the harness calls H.frames(n); CSS / Web Animations are paused (CDP playback rate 0)
//   - randomness: Math.random is seeded; with { split: true } every script gets its own stream (by the file that calls
//     it: the house page, the rigs, the reno pieces...), so a change in how often one part draws doesn't move the
//     others' numbers, and the C# port can replay the house's own draws (`H.rng()` lists the draws per stream)
//   - the save and the player: localStorage is cleared and seeded from the fixture (house JSON 'ssHouse5b', the
//     profile's level and coins, the creatures owned), the same keys webgame/app/bridge.js writes in the app
//   - stills: SMIL removed from every inline SVG and every data-URI picture (H.still()), fonts and pictures decoded
//   - a trace hook: H.trace(names) records calls to the house component's methods (virtual time, name, arguments)
//
// Everything runs on a local web build (webgame/build.mjs into webgame/test/out/unity-house), with the internet off.
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath, pathToFileURL } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
export const REPO = path.resolve(HERE, '../../..');
export const WORK = path.join(REPO, 'webgame/test/out/unity-house');
// the reference phone (Galaxy A15, landscape), as every other exporter
export const REF = { w: 832, h: 384, dpr: 2.8125 };
const CLOCK = fs.readFileSync(path.join(REPO, 'tools/unity/rig/virtual-clock.js'), 'utf8');

export async function buildWeb(force) {
  if (!force && fs.existsSync(path.join(WORK, 'webgame-manifest.json'))) return WORK;
  const { build } = await import('../../../webgame/build.mjs');
  await build(WORK);
  return WORK;
}

// seeded streams: xorshift32 (the generator virtual-clock.js and webgame/test/pixel-diff.mjs use), one per source when
// split; the stream name is the script file of the first caller outside this hook
const RNG = `(() => {
  const SEED = 0x2f6b9a1, split = !!(window.__houseFixture && window.__houseFixture.split);
  const mk = s0 => { let s = s0 >>> 0 || 1; return () => { s ^= s << 13; s >>>= 0; s ^= s >>> 17; s ^= s << 5; s >>>= 0; return s / 4294967296; }; };
  const hash = t => { let h = SEED; for (let i = 0; i < t.length; i++) h = Math.imul(h ^ t.charCodeAt(i), 0x01000193) >>> 0; return h || 1; };
  const one = mk(SEED), streams = new Map(), log = window.__rngLog = {};
  // (the page's own code runs from the dc runtime's eval: its frames say 'eval at ...' -> the stream 'house-page')
  const who = () => { const st = new Error().stack.split('\\n'); for (let i = 3; i < st.length; i++) { if (/eval at|<anonymous>/.test(st[i])) return 'house-page'; const m = /([^\\/\\s(]+\\.(?:js|html))(?:\\?[^:]*)?:\\d+:\\d+/.exec(st[i]); if (m) return decodeURIComponent(m[1]); } return '?'; };
  Math.random = function () {
    if (!split) return one();
    const k = who(); let g = streams.get(k); if (!g) { g = mk(hash(k)); streams.set(k, g); log[k] = 0; }
    log[k]++; return g();
  };
})();`;

// what's still loading (fetch, XHR, <script src>): the harness moves virtual time only when nothing is, so the page
// reaches each step in the same state every run
const INFLIGHT = `(() => {
  window.__inflight = 0; const inc = () => window.__inflight++, dec = () => window.__inflight--;
  const f0 = window.fetch; window.fetch = function () { inc(); return f0.apply(this, arguments).finally(dec); };
  const s0 = XMLHttpRequest.prototype.send; XMLHttpRequest.prototype.send = function () { inc(); this.addEventListener('loadend', dec, { once: true }); return s0.apply(this, arguments); };
  new MutationObserver(ms => { for (const m of ms) for (const n of m.addedNodes) if (n.tagName === 'SCRIPT' && n.src && !n.__seen) { n.__seen = 1; inc(); n.addEventListener('load', dec, { once: true }); n.addEventListener('error', dec, { once: true }); } }).observe(document, { childList: true, subtree: true });
})();`;

// the fixture into localStorage, before any script runs (the keys of webgame/app/bridge.js)
const SEED_LS = `(() => {
  const F = window.__houseFixture; if (!F) return;
  try { localStorage.clear(); } catch (e) {}
  const set = (k, v) => { try { localStorage.setItem(k, typeof v === 'string' ? v : JSON.stringify(v)); } catch (e) {} };
  set('squishsquad.profile.v1', Object.assign({ level: 1, coins: 100, owned: [] }, F.profile || {}));
  if (F.collection) set('squishsquad.collection.v1', F.collection);
  if (F.house) set('ssHouse5b', F.house);
  if (F.sz) set('ssHouseSz', F.sz);
  for (const k in (F.ls || {})) set(k, F.ls[k]);
})();`;

// hide what the static room doesn't draw: the creatures (and their name tags / speech), particles, the HUD around the room
export const ROOM_ONLY_CSS = `
  [data-house-crs] { visibility: hidden !important; }
  [data-house-fx] { visibility: hidden !important; }
`;

export async function openHouse(browser, fixture = {}, opts = {}) {
  await buildWeb();
  const ctx = await browser.newContext({ viewport: { width: opts.w || REF.w, height: opts.h || REF.h }, deviceScaleFactor: opts.dpr || REF.dpr });
  const page = await ctx.newPage();
  const errs = [];
  page.on('pageerror', e => errs.push(e.message));
  page.on('console', m => { if (m.type() === 'error') errs.push('console: ' + m.text()); });
  await page.route(/^https?:/, r => { errs.push('internet: ' + r.request().url()); r.abort(); });
  await page.addInitScript(f => { window.__houseFixture = f; }, { ...fixture, split: !!opts.split });
  await page.addInitScript(CLOCK);
  await page.addInitScript(RNG);
  await page.addInitScript(SEED_LS);
  await page.addInitScript(INFLIGHT);
  const cdp = await ctx.newCDPSession(page);
  await cdp.send('Animation.enable');
  await cdp.send('Animation.setPlaybackRate', { playbackRate: 0 });
  const q = new URLSearchParams({ screen: 'house', room: opts.room || fixture.room || 'living' });
  await page.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href + '?' + q);
  const H = {
    page, ctx, errs, cdp,
    // n frames of `ms` virtual ms each (the house's rAF loop and its 50 ms interval run on them)
    async frames(n = 1, ms = 16) { await page.evaluate(({ n, ms }) => { for (let i = 0; i < n; i++) window.__clock.frame(ms); }, { n, ms }); },
    now: () => page.evaluate(() => window.__clock.now),
    // the house component (window.__sh) is up and has run init()
    async ready(timeout = 60000) {
      const t0 = Date.now();
      for (;;) {
        const ok = await page.evaluate(() => !!(window.__sh && window.__sh.ready && window.__sh.H));
        if (ok) break;
        if (Date.now() - t0 > timeout) throw new Error('house not ready: ' + errs.slice(0, 5).join(' | '));
        // nothing loading (and the document parsed), then one 50 ms step of virtual time
        // (polled from here: the page's own timers are virtual)
        if (!(await page.evaluate(() => window.__inflight === 0 && document.readyState === 'complete'))) { await page.waitForTimeout(20); continue; }
        await page.waitForTimeout(30);
        if (await page.evaluate(() => window.__inflight !== 0)) continue;
        await page.evaluate(() => window.__clock.frame(50));
      }
      // mark the creature layer and the particles so stills can hide them
      await page.evaluate(() => {
        const sh = window.__sh;
        const w = sh.cs[0] && sh.cs[0].wrap && sh.cs[0].wrap.current; if (w && w.parentElement) w.parentElement.setAttribute('data-house-crs', '');
        const fx = sh.fxRef && sh.fxRef.current; if (fx) fx.setAttribute('data-house-fx', '');
      });
    },
    rng: () => page.evaluate(() => window.__rngLog),
    // a trace of the house's own calls: H.trace(['enterRoom', 'save', ...]) then H.traced()
    async trace(names) {
      await page.evaluate(names => {
        const sh = window.__sh; window.__trace = [];
        const safe = a => { try { return JSON.parse(JSON.stringify(a, (k, v) => typeof v === 'function' ? undefined : v && v.nodeType ? undefined : v)); } catch (e) { return String(a); } };
        for (const n of names) { const f = sh[n]; if (typeof f !== 'function' || f.__traced) continue; const g = function (...a) { window.__trace.push({ t: window.__clock.now, fn: n, args: a.map(safe) }); return f.apply(this, a); }; g.__traced = 1; sh[n] = g; }
      }, names);
    },
    traced: () => page.evaluate(() => window.__trace || []),
    // ready for a still: SMIL out of inline SVGs and of every data-URI picture, fonts and pictures decoded
    async still(extraCss = '') {
      await page.evaluate(async css => {
        const strip = s => s.replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*\/>/g, '').replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*>[\s\S]*?<\/\1>/g, '');
        const stripUri = u => { if (!u || !u.startsWith('data:image/svg+xml')) return u; const i = u.indexOf(','); const head = u.slice(0, i + 1), body = u.slice(i + 1); const b64 = /;base64,$/.test(head); const svg = b64 ? atob(body) : decodeURIComponent(body); const out = strip(svg); return out === svg ? u : 'data:image/svg+xml,' + encodeURIComponent(out); };
        document.querySelectorAll('animate,animateTransform,animateMotion,set').forEach(e => e.remove());
        for (const im of document.querySelectorAll('image')) { const h = im.getAttribute('href'); const n = stripUri(h); if (n !== h) im.setAttribute('href', n); }
        for (const el of document.querySelectorAll('[style*="url("]')) { const s = el.getAttribute('style'); const n = s.replace(/url\((["']?)(data:image\/svg\+xml[^"')]*)\1\)/g, (m, q, u) => 'url(' + q + stripUri(u) + q + ')'); if (n !== s) el.setAttribute('style', n); }
        let st = document.getElementById('__house_still'); if (!st) { st = document.createElement('style'); st.id = '__house_still'; document.head.appendChild(st); }
        st.textContent = '*,*::before,*::after{transition:none!important;caret-color:transparent!important;}' + css;
        await document.fonts.ready;
        const hrefs = new Set([...document.querySelectorAll('image')].map(e => e.getAttribute('href')).filter(Boolean));
        await Promise.all([...hrefs].map(h => new Promise(res => { const im = new Image(); im.onload = im.onerror = () => (im.decode ? im.decode().catch(() => {}) : Promise.resolve()).then(res); im.src = h; })));
      }, extraCss);
      await page.waitForTimeout(250);
    },
    close: () => ctx.close(),
  };
  return H;
}

export async function launch() {
  const { createRequire } = await import('node:module');
  const { chromium } = createRequire(import.meta.url)('playwright');
  return chromium.launch({ args: ['--allow-file-access-from-files'] });
}
