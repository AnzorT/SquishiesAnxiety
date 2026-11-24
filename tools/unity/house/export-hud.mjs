// Exports the Squad House's HUD chrome (HOUSE_PORT_PLAN.md stage 2) for Unity (House/View/HouseHud.cs): the bottom
// drawer (its wood panel with RENOVATE and CATALOG, its tab and the tab's arrow) cut from the house page itself
// (tools/unity/ui/snap.js: what Chrome laid out and painted, as SVG), with where each piece sits in the 852 x 393 frame.
//
//   node tools/unity/house/export-hud.mjs
//
// -> unity/Assets/Resources/House/hud/<piece>.xml   (the SVG of each piece, in its own CSS px)
//    unity/Assets/Resources/House/hud.json          { pieces: { name: [x, y, w, h] in frame px with the drawer at
//                                                    translate(-50%, 0) }, drawer: { closedTy, openTy, ms, ease },
//                                                    arrow: { ms, ease } }   (the page's own values, see below)
// The toast is drawn by Unity from the page's style (its text changes); its numbers are in HouseHud.cs.
import fs from 'node:fs';
import path from 'node:path';
import { pathToFileURL } from 'node:url';
import { launch, openHouse, buildWeb, REPO, WORK } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';
import { fontData, HERE as UI } from '../ui/snap-page.mjs';
import { snap } from '../ui/snap-page.mjs';

const OUT = path.join(REPO, 'unity/Assets/Resources/House');
const fixture = loadFixtures()[0];
const browser = await launch();
const H = await openHouse(browser, fixture, { room: 'living' });
await H.ready();
await H.frames(30);
await H.still();
const page = H.page;

// snap.js and the fonts it draws text with, added to the running page
const fd = fontData();
await page.evaluate((fd) => {
  window.__snapFonts = fd.names;
  window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)]));
  window.__snapUpm = fd.upm;
  window.__snapPaths = fd.paths;
}, fd);
await page.addScriptTag({ path: path.join(UI, 'snap.js') });

// the drawer at its base position (the page moves it with translateY: closed 72, open -16), its arrow hidden in the tab
const ids = await page.evaluate(() => {
  const ren = document.querySelector('button[aria-label="Renovate"]');
  const box = ren.closest('div[style*="z-index: 900"]');
  box.style.transition = 'none';
  box.style.transform = 'translate(-50%, 0px)';
  const tab = box.querySelector(':scope > button'), panel = box.querySelector(':scope > div'), arrow = tab.querySelector('svg');
  tab.dataset.hud = 'tab'; panel.dataset.hud = 'panel'; arrow.dataset.hud = 'arrow';
  arrow.style.transition = 'none'; arrow.style.transform = 'none';
  return ['tab', 'panel', 'arrow'];
});
const frame = await page.evaluate(() => { const f = document.querySelector('[data-screen-label]').getBoundingClientRect(); return { x: f.left, y: f.top, k: 852 / f.width }; });
const pieces = {};
fs.mkdirSync(path.join(OUT, 'hud'), { recursive: true });
for (const id of ids) {
  if (id === 'tab') await page.evaluate(() => { document.querySelector('[data-hud="arrow"]').style.visibility = 'hidden'; });
  const s = await snap(page, `[data-hud="${id}"]`);
  if (id === 'tab') await page.evaluate(() => { document.querySelector('[data-hud="arrow"]').style.visibility = ''; });
  fs.writeFileSync(path.join(OUT, 'hud', id + '.xml'), s.svg);
  pieces[id] = [(s.x - frame.x) * frame.k, (s.y - frame.y) * frame.k, s.w * frame.k, s.h * frame.k].map((v) => Math.round(v * 1000) / 1000);
}
// where a tap counts: the drawer's two buttons (frame px, the drawer at its base position)
const buttons = await page.evaluate(() => Object.fromEntries(['Renovate', 'Catalog'].map((n) => { const r = document.querySelector(`button[aria-label="${n}"]`).getBoundingClientRect(); return [n.toLowerCase(), [r.left, r.top, r.width, r.height]]; })));
for (const k in buttons) buttons[k] = [(buttons[k][0] - frame.x) * frame.k, (buttons[k][1] - frame.y) * frame.k, buttons[k][2] * frame.k, buttons[k][3] * frame.k].map((v) => Math.round(v * 1000) / 1000);
// the page's values (Squad House v6.dc.html: renderVals dw, the drawer's and the arrow's CSS transitions)
const hud = {
  note: 'Written by tools/unity/house/export-hud.mjs. Rects: frame px (852 x 393), the drawer at translate(-50%, 0).',
  pieces,
  buttons,
  drawer: { closedTy: 72, openTy: -16, ms: 750, ease: [0.25, 1.15, 0.4, 1] },
  arrow: { closedDeg: 0, openDeg: 180, ms: 250, ease: [0.25, 0.1, 0.25, 1] },
};
// the quick-action wheel round a selected friend (stage 4): its closed button, the close button and the seven room
// buttons, each its own piece; unlocked from a level-30 house, locked (the padlock, dimmed) from a level-1 one
async function wheel(fx, locked) {
  const W = await openHouse(browser, fx, { room: 'living' });
  await W.ready(); await W.frames(30); await W.still();
  await W.page.evaluate((fd) => { window.__snapFonts = fd.names; window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)])); window.__snapUpm = fd.upm; window.__snapPaths = fd.paths; }, fd);
  await W.page.addScriptTag({ path: path.join(UI, 'snap.js') });
  const cut = async (label, id) => {
    await W.page.evaluate((label) => { const b = document.querySelector(`button[aria-label="${label}"]`); b.dataset.hud = 'q'; [b, ...b.querySelectorAll('*')].forEach((e) => { e.style.animation = 'none'; }); b.style.opacity = '1'; }, label);
    const s = await snap(W.page, '[data-hud="q"]');
    await W.page.evaluate(() => { document.querySelector('[data-hud="q"]').removeAttribute('data-hud'); });
    fs.writeFileSync(path.join(OUT, 'hud', id + '.xml'), s.svg);
    return [s.w * frame.k, s.h * frame.k].map((v) => Math.round(v * 1000) / 1000);
  };
  const sizes = {};
  await W.page.evaluate(() => { const sh = window.__sh; sh.setState({ sel: 0, qa: false }); });
  await W.frames(2);
  if (!locked) sizes['qa-open'] = await cut('Actions', 'qa-open');
  await W.page.evaluate(() => window.__sh.setState({ qa: true }));
  await W.frames(2);
  if (!locked) sizes['qa-close'] = await cut('Close actions', 'qa-close');
  for (const q of ['Dance', 'Bath', 'Kitchen', 'Club', 'Sleep', 'Movies', 'Yard']) {
    const has = await W.page.evaluate((q) => !!document.querySelector(`button[aria-label="${q}"]`), q);
    if (has && (!locked || q !== 'Dance')) sizes['qa-' + q.toLowerCase() + (locked ? '-locked' : '')] = await cut(q, 'qa-' + q.toLowerCase() + (locked ? '-locked' : ''));
  }
  await W.ctx.close();
  return sizes;
}
// the backyard's YARD GAMES button (webgame/app/games.js ensureBtn: the menu's gold tab, .sq-yard-wrap at right 22 px,
// top 14 px of the house's box) and its NEW badge (2026-11-18: a game bought since the Yard Games were last opened; it
// pulses 1 -> 1.14 -> 1 over 1.4 s, sqYardB). The menu draws it over the house, so it is cut from the menu's page
// (App.dc.html: .mm-root's colours), built there with games.js's own markup and styles.
async function yardButton() {
  const src = fs.readFileSync(path.join(REPO, 'webgame/app/games.js'), 'utf8');
  const css = new Function('return ' + /var BTN_CSS = ([\s\S]*?);\n/.exec(src)[1])();
  const pad = /var PAD = '([^']*)'/.exec(src)[1];
  const ctx = await browser.newContext({ viewport: { width: 832, height: 384 }, deviceScaleFactor: 2.8125 });
  const pg = await ctx.newPage();
  await pg.route(/^https?:/, (r) => r.abort());
  await pg.goto(pathToFileURL(path.join(WORK, 'App.dc.html')).href);
  await pg.waitForFunction(() => !!document.querySelector('.mm-root'), null, { timeout: 60000 });
  await pg.evaluate(() => document.fonts.ready);
  await pg.evaluate((fd) => { window.__snapFonts = fd.names; window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)])); window.__snapUpm = fd.upm; window.__snapPaths = fd.paths; }, fd);
  await pg.addScriptTag({ path: path.join(UI, 'snap.js') });
  await pg.evaluate(({ css, pad }) => {
    const st = document.createElement('style'); st.textContent = css + '*{animation:none!important;transition:none!important}'; document.head.appendChild(st);
    const host = document.createElement('div'); host.style.cssText = 'position:fixed;left:0;top:0;width:852px;height:393px;z-index:99999;';
    const wrap = document.createElement('div'); wrap.className = 'mm-root sq-yard-wrap';
    const btn = document.createElement('button'); btn.className = 'sq-yard mm-tab mm-p tip v-gold'; btn.dataset.hud = 'yard';
    btn.innerHTML = '<svg viewBox="0 0 24 24" fill="none" stroke="#3d1268" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="' + pad + '"/></svg><span>YARD GAMES</span>';
    const b = document.createElement('i'); b.className = 'sq-yard-b'; b.textContent = 'NEW'; b.dataset.hud = 'yard-new'; btn.appendChild(b);
    wrap.appendChild(btn); host.appendChild(wrap); document.body.appendChild(host);
  }, { css, pad });
  await pg.waitForTimeout(300);
  const out = {};
  const r = async (sel) => pg.evaluate((sel) => { const e = document.querySelector(sel).getBoundingClientRect(); return [e.left, e.top, e.width, e.height]; }, sel);
  const btnR = await r('[data-hud="yard"]'), newR = await r('[data-hud="yard-new"]');
  await pg.evaluate(() => { document.querySelector('[data-hud="yard-new"]').style.visibility = 'hidden'; });
  const s1 = await snap(pg, '[data-hud="yard"]');
  await pg.evaluate(() => { document.querySelector('[data-hud="yard-new"]').style.visibility = ''; });
  const s2 = await snap(pg, '[data-hud="yard-new"]');
  fs.writeFileSync(path.join(OUT, 'hud', 'yard.xml'), s1.svg);
  fs.writeFileSync(path.join(OUT, 'hud', 'yard-new.xml'), s2.svg);
  const R3 = (v) => Math.round(v * 1000) / 1000;
  // the button's box (right 22, top 14 in the house's box) and where the snaps sit against it (their paint reaches
  // past it: the tips, the glow), the badge's box for its pulse (scaled about its centre)
  // the menu's back orb over the house (Main Menu.dc.html .mm-hback, app/menu.js's wood look): left 12, bottom 12 of the
  // screen (menu dp, not the house's scale), 44 x 44
  await pg.evaluate(() => {
    const host = document.createElement('div'); host.className = 'mm-house'; host.style.cssText = 'position:fixed;left:0;top:0;width:832px;height:384px;z-index:99999;background:none;';
    host.innerHTML = '<button class="mm-hback" data-hud="back" aria-label="Back to the menu"><svg viewBox="0 0 24 24" fill="none" stroke="#ffffff" stroke-width="3" stroke-linecap="round" stroke-linejoin="round"><path d="M15 5L8 12L15 19"></path></svg></button>';
    document.body.appendChild(host);
  });
  await pg.waitForTimeout(100);
  const backR = await r('[data-hud="back"]'), s3 = await snap(pg, '[data-hud="back"]');
  fs.writeFileSync(path.join(OUT, 'hud', 'back.xml'), s3.svg);
  out.back = { left: R3(backR[0]), bottom: R3(384 - backR[1] - backR[3]), w: R3(backR[2]), h: R3(backR[3]), snap: [R3(s3.x - backR[0]), R3(s3.y - backR[1]), R3(s3.w), R3(s3.h)] };
  out.yard = { right: R3(852 - btnR[0] - btnR[2]), top: R3(btnR[1]), w: R3(btnR[2]), h: R3(btnR[3]), snap: [R3(s1.x - btnR[0]), R3(s1.y - btnR[1]), R3(s1.w), R3(s1.h)],
    badge: [R3(newR[0] - btnR[0]), R3(newR[1] - btnR[1]), R3(newR[2]), R3(newR[3])], badgeSnap: [R3(s2.x - btnR[0]), R3(s2.y - btnR[1]), R3(s2.w), R3(s2.h)], pulse: { ms: 1400, scale: 1.14 } };
  await ctx.close();
  return out;
}
Object.assign(hud, await yardButton());
const fixtures = loadFixtures();
hud.wheel ={ ...(await wheel(fixtures.find((f) => f.name === 'lv30-beach'), false)), ...(await wheel(fixtures.find((f) => f.name === 'fresh-lv1'), true)) };
fs.writeFileSync(path.join(OUT, 'hud.json'), JSON.stringify(hud, null, 1));
console.log('wheel:', JSON.stringify(hud.wheel));
console.log('hud:', JSON.stringify(pieces));
for (const e of [...new Set(H.errs || [])].slice(0, 5)) console.log('  page error:', String(e).slice(0, 160));
await browser.close();
