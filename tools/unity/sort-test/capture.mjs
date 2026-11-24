// A Squish Sort level as the app plays it (Expo web, src/web/Preview.js "game-sort"), on a virtual clock: the page's
// clock is replaced by tools/unity/rig/virtual-clock.js just before the level opens, then stepped 16 ms a frame (the
// last step landing on each moment), so the Unity code (Program.cs) can run the same frames. Writes the level's board
// (read from SortGame's hooks: the deal Math.random made), the sizes the app worked out, and a screenshot at each
// moment (ms after the level's first render, when its intro starts).
//   node capture.mjs <out dir> <fridge|cupboard> <level> <ms,ms,...> [tap script: "ms:x,y ..."]
//   <out>/state.json   <out>/app-<ms>.png
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out, theme = 'fridge', lvArg = '1', timesArg = '2000', tapsArg = ''] = process.argv.slice(2);
const lv = +lvArg;
const times = timesArg.split(',').map(Number).sort((a, b) => a - b);
// taps: "ms:x,y" (a tap: down and up 60 ms apart) or "ms:x,y>x2,y2" (a drag over 200 ms), in screen dp
const taps = tapsArg.split(/\s+/).filter(Boolean).map((s) => {
  const [ms, rest] = s.split(':');
  const [a, b] = rest.split('>');
  const p = (q) => q.split(',').map(Number);
  return { ms: +ms, from: p(a), to: b ? p(b) : null };
});
fs.mkdirSync(out, { recursive: true });
const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-sort');
await page.waitForTimeout(6000);
await page.mouse.click(600, theme === 'cupboard' ? 310 : 160);   // the hub's PLAY on the fridge's / cupboard's card
await page.waitForTimeout(3000);
const clock = fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8');
await page.evaluate(clock);
// the tumble's random starting spots (Game.js tumble: Math.random), kept so the Unity code can start from the same ones
await page.evaluate(() => {
  const r = Math.random;
  window.__tumbleRandoms = [];
  Math.random = () => { const v = r(); if (/tumble/.test(new Error().stack)) window.__tumbleRandoms.push(v); return v; };
});
await page.evaluate((lv) => window.__components('LevelMap')[0].props.onPlay(lv), lv);
// one frame at a time, letting React render in between, until the level's intro banner is up: that's its time 0
async function frame(ms = 16) {
  await page.evaluate((ms) => window.__clock.frame(ms), ms);
  await page.waitForTimeout(25);
}
let t0 = null;
for (let i = 0; i < 400 && t0 == null; i++) {
  await frame();
  t0 = await page.evaluate(() => (window.__components('Banner').some((b) => b.props.banner) ? window.__clock.now : null));
}
await page.waitForTimeout(1500);   // the squishies' pictures load (real time; the virtual clock stands still)
// the board, the level's spec and sizes from SortGame's hooks and its children's props
const readState = () => page.evaluate(() => {
  const root = document.getElementById('root');
  let f = null;
  for (const k in root) if (k.startsWith('__reactContainer$')) f = root[k];
  if (f && f.stateNode && f.stateNode.current) f = f.stateNode.current;
  let game = null;
  const walk = (x) => { for (; x && !game; x = x.sibling) { if (x.type && x.type.name === 'SortGame') game = x; else if (x.child) walk(x.child); } };
  walk(f);
  const memos = [];
  for (let h = game.memoizedState; h; h = h.next) if (Array.isArray(h.memoizedState) && h.memoizedState.length === 2 && Array.isArray(h.memoizedState[1])) memos.push(h.memoizedState[0]);
  const board = memos.find((m) => m && m.pieces && m.trayCap != null);
  const spec = memos.find((m) => m && m.peekMs != null);
  const tg = memos.find((m) => m && m.perRow != null);
  const g = memos.find((m) => m && m.bodyW != null);
  return { board, spec, tg, g, theme: game.memoizedProps.theme };
});
const state = await readState();
// every board the level deals (NEXT, REPLAY and RETRY deal again), in order
const boards = [JSON.stringify(state.board)];
state.t0 = t0;
state.lv = lv;
// the play area's origin on screen
state.area = await page.evaluate((tg) => {
  // (the tray's ring sits at tg.tx, tg.ty in it, tw x th)
  const ring = [...document.querySelectorAll('div')].find((d) => { const r = d.getBoundingClientRect(); return Math.abs(r.width - tg.tw) < 0.01 && Math.abs(r.height - tg.th) < 0.01; });
  const r = ring.getBoundingClientRect();
  return [r.x - tg.tx, r.y - tg.ty, tg.tx + tg.tw + 10];   // x, y, width
}, state.tg);
fs.writeFileSync(path.join(out, 'state.json'), JSON.stringify(state, null, 1));
console.log(`t0 ${t0}, level ${state.spec.lv}, ${state.board.pieces.length} pieces, S ${state.g.S}, area ${state.area}`);
// step to each moment (taps on the way), a screenshot there
const rel = () => page.evaluate(() => window.__clock.now).then((n) => n - t0);
let ti = 0;
async function stepTo(ms) {
  for (;;) {
    const now = await rel();
    if (now >= ms) return;
    await frame(Math.min(16, ms - now));
  }
}
const events = [];
for (const t of taps) { events.push({ ms: t.ms, kind: 'down', t }); events.push({ ms: t.ms + (t.to ? 200 : 60), kind: 'up', t }); if (t.to) for (let k = 1; k <= 8; k++) events.push({ ms: t.ms + k * 20, kind: 'move', t, k }); }
for (const ms of times) events.push({ ms, kind: 'shot' });
events.sort((a, b) => a.ms - b.ms || (a.kind === 'shot') - (b.kind === 'shot'));
for (const e of events) {
  await stepTo(e.ms);
  if (e.kind === 'shot') {
    await page.waitForTimeout(700);
    await page.screenshot({ path: path.join(out, `app-${e.ms}.png`) });
    const b = JSON.stringify((await readState()).board);
    if (b !== boards[boards.length - 1]) boards.push(b);
    console.log(`at ${e.ms} ms`);
  } else if (e.kind === 'down') { await page.mouse.move(...e.t.from); await page.mouse.down(); }
  else if (e.kind === 'move') { const [x0, y0] = e.t.from, [x1, y1] = e.t.to; await page.mouse.move(x0 + ((x1 - x0) * e.k) / 8, y0 + ((y1 - y0) * e.k) / 8); }
  else { await page.mouse.move(...(e.t.to || e.t.from)); await page.mouse.up(); }
}
fs.writeFileSync(path.join(out, 'boards.json'), `[${boards.join(',')}]`);
fs.writeFileSync(path.join(out, 'randoms.json'), JSON.stringify(await page.evaluate(() => window.__tumbleRandoms)));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
