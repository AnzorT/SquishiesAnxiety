// Squish Sort's BLITZ MODE as develop's app plays it (Expo web, src/web/Preview.js "game-sort": a made-up player with
// Remove Ads, nothing saved; the rigs' page kept from loading, so the stills stand in as in Unity), on a virtual clock,
// for Blitz.cs to play the same from the Unity code (SortLevel.Blitz) and compare.
//   The hub is opened in real time, then the page's clock is replaced (tools/unity/rig/virtual-clock.js, which also
//   seeds Math.random) and the hub's BLITZ MODE tapped. The clock is stepped 16 ms a frame; T0 is when the run's
//   3, 2, 1, GO! timers are set (from T0 + 200; round 1 is dealt on GO). The script then plays: the countdown, round 1's
//   whole timeline (deal, peek, shut, shake, tumble), one squishy home, a wrong spot (held, the save card), SAVE IT, the
//   rest home (the round won, CLEARED 1), round 2: the pause card and RESUME, a wrong spot, END RUN, GAME OVER. Where
//   each squishy goes is read from the board in play (SortGame's hooks); every tap is recorded with its moment, so the
//   Unity code taps the same spots at the same moments.
// node blitz.mjs <out dir>
//   <out>/blitz-<ms>.png  the screen at T0 + ms      <out>/blitz.json  the boards dealt, the taps and shots, the tumble's
//   random numbers
import fs from 'node:fs';
import path from 'node:path';
import { openApp, ROOT } from '../ui/snap-page.mjs';

const [out] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const HOST = process.env.SORT_HOST || 'http://localhost:8081';
const { browser, page, errors } = await openApp(`${HOST}/?phone=1&preview=1&card=game-sort`);
await page.route('**/android_asset/rig/**', (r) => r.abort());
await page.waitForTimeout(6000);
await page.evaluate(fs.readFileSync(path.join(ROOT, 'tools', 'unity', 'rig', 'virtual-clock.js'), 'utf8'));
await page.evaluate(() => {
  // the tumble's random starting spots (Game.js tumble: Math.random), for the Unity code to start from the same ones
  const r = Math.random;
  window.__tumbleRandoms = [];
  Math.random = () => { const v = r(); if (/tumble/.test(new Error().stack)) window.__tumbleRandoms.push(v); return v; };
  // when the countdown's timers are set (Game.js: 200, 900, 1600, 2300 and 3000 at once)
  const st = window.setTimeout;
  window.__cdAt = null;
  window.setTimeout = function (fn, ms, ...a) { if (ms === 2300 && window.__cdAt == null) window.__cdAt = window.__clock.now; return st(fn, ms, ...a); };
  // SortGame's state: its memos (board, spec, sizes) and refs (phase, play), the pips, which Blitz card is up
  window.__sortX = () => {
    const root = document.getElementById('root');
    let f = null;
    for (const k in root) if (k.startsWith('__reactContainer$')) f = root[k];
    if (f && f.stateNode && f.stateNode.current) f = f.stateNode.current;
    let game = null;
    const walk = (x) => { for (; x && !game; x = x.sibling) { if (x.type && x.type.name === 'SortGame') game = x; else if (x.child) walk(x.child); } };
    walk(f);
    if (!game) return null;
    const PH = ['load', 'intro', 'deal', 'peek', 'close', 'shake', 'open', 'tumble', 'place', 'held', 'won', 'lost'];
    const memos = [];
    let phase = null, play = null;
    for (let h = game.memoizedState; h; h = h.next) {
      const m = h.memoizedState;
      if (Array.isArray(m) && m.length === 2 && Array.isArray(m[1])) memos.push(m[0]);
      if (m && typeof m === 'object' && 'current' in m && Object.keys(m).length === 1) {
        if (PH.includes(m.current)) phase = m.current;
        else if (m.current && m.current.at && m.current.locked) play = m.current;
      }
    }
    const one = (n) => { const c = window.__components(n)[0]; return c ? c.props : null; };
    const cards = { save: one('BlitzSaveCard')?.visible, over: one('BlitzOverCard')?.visible, pause: one('PauseCard')?.visible };
    return {
      phase, play,
      board: memos.find((m) => m && m.pieces && m.trayCap != null),
      spec: memos.find((m) => m && m.peekMs != null),
      tg: memos.find((m) => m && m.perRow != null),
      g: memos.find((m) => m && m.bodyW != null),
      cards,
    };
  };
});
const S = () => page.evaluate(() => window.__sortX());
const now = () => page.evaluate(() => window.__clock.now);
// frames of 16 ms (the last one landing on the moment), React given real time to render between them
const runTo = (ms) =>
  page.evaluate(async (target) => {
    const y = () => new Promise((r) => window.__realSetTimeout(r, 0));
    while (window.__clock.now < target - 1e-9) {
      window.__clock.frame(Math.min(16, target - window.__clock.now));
      for (let i = 0; i < 3; i++) await y();
    }
  }, ms);
// frames of 16 ms until `pred` (source of a function of __sort()) holds; returns the moment (T0-relative)
const until = (pred, max = 60000) =>
  page.evaluate(async ([src, T0, max]) => {
    const p = eval(src);
    const y = () => new Promise((r) => window.__realSetTimeout(r, 0));
    const end = window.__clock.now + max;
    while (window.__clock.now < end) {
      const s = window.__sortX();
      if (s && p(s)) return window.__clock.now - T0;
      window.__clock.frame(16);
      for (let i = 0; i < 3; i++) await y();
    }
    throw new Error('timed out waiting for ' + src);
  }, [pred.toString(), T0, max]);

await page.mouse.click(614, 180);   // develop's hub: BLITZ MODE
let T0 = null;
for (let i = 0; i < 600 && T0 == null; i++) {
  await page.evaluate(async () => { window.__clock.frame(16); for (let i = 0; i < 3; i++) await new Promise((r) => window.__realSetTimeout(r, 0)); });
  T0 = await page.evaluate(() => window.__cdAt);
}
await page.waitForTimeout(1500);   // the squishies' pictures load (real time; the virtual clock stands still)
console.log('T0', T0);

const events = [];   // { ms, kind: 'tap' | 'shot', x, y, label }
const boards = [];
const rel = async () => (await now()) - T0;
async function noteBoard() {
  const s = await S();
  if (!s || !s.board) return s;
  const b = JSON.stringify(s.board);
  if (boards[boards.length - 1] !== b) boards.push(b);
  return s;
}
async function shot(ms, name = '') {
  await runTo(T0 + ms);
  await noteBoard();
  await page.waitForTimeout(700);
  await page.screenshot({ path: path.join(out, `blitz-${ms}.png`) });
  events.push({ ms, kind: 'shot', name });
  console.log(`shot ${ms} ${name}`);
}
async function tapAt(ms, x, y, label = '') {
  await runTo(T0 + ms);
  await page.mouse.click(x, y);
  events.push({ ms, kind: 'tap', x, y, label });
  await page.waitForTimeout(150);
}
// where things are on screen (the play area starts at the left column's edge: 240, 0)
const AX = 240, AY = 0, SHELF = 8;
const slotC = (g, i) => [AX + g.ix + (i % g.cols) * g.S + g.S / 2, AY + g.iy + Math.floor(i / g.cols) * (g.S + SHELF) + g.S / 2];
const trayC = (tg, j) => [AX + tg.tx + 12 + (j % tg.perRow) * tg.cell + tg.cell / 2, AY + tg.ty + 15 + Math.floor(j / tg.perRow) * tg.cell + tg.cell / 2];
const pieceC = (s, k) => { const a = s.play.at[k]; return a.kind === 'slot' ? slotC(s.g, a.i) : trayC(s.tg, a.i); };
const todo = (s) => s.board.pieces.map((p, k) => k).filter((k) => s.board.pieces[k].home != null && !s.play.locked[k]);
// one squishy home: tap it, then its spot
async function placeRight(ms, k) {
  const s = await S();
  if (k == null) k = todo(s)[0];
  await tapAt(ms, ...pieceC(s, k), `pick ${k}`);
  await tapAt(ms + 150, ...slotC(s.g, s.board.pieces[k].home), `home ${k}`);
  return ms + 150;
}
// one squishy onto a wrong spot (no clutter there, not its home, not a locked one's)
async function placeWrong(ms) {
  const s = await S();
  const k = todo(s)[0];
  const locked = new Set(Object.keys(s.play.locked).filter((q) => s.play.locked[q]).map((q) => s.play.at[q].i));
  let i = 0;
  while (i === s.board.pieces[k].home || (s.board.foodAfter && s.board.foodAfter[i] != null) || locked.has(i)) i++;
  await tapAt(ms, ...pieceC(s, k), `pick ${k}`);
  await tapAt(ms + 150, ...slotC(s.g, i), `wrong ${k} -> ${i}`);
  return ms + 150;
}
async function solve(ms) {
  for (;;) {
    const s = await S();
    if (!todo(s).length || s.phase !== 'place') return ms;
    ms = (await placeRight(ms)) + 250;
  }
}
async function press(ms, label) {
  await runTo(T0 + ms);
  const p = await page.evaluate((label) => {
    const b = window.__components('SdButton').map((c) => c.el).filter((e) => e && e.getBoundingClientRect().width > 0).find((e) => e.innerText.includes(label));
    const r = b.getBoundingClientRect();
    return [r.x + r.width / 2, r.y + r.height / 2];
  }, label);
  await tapAt(ms, p[0], p[1], label);
}
const phaseIs = (p) => `(s) => s.phase === '${p}'`;

// ---- the countdown, round 1: the whole timeline, a right one, a wrong one, the save card, SAVE IT, the rest: won ----
await shot(250, '3'); await shot(1000, '2'); await shot(2400, 'GO');
let t = await until(eval(phaseIs('deal')));
await shot(t + 150, 'deal');
t = await until(eval(phaseIs('peek')));
await shot(t + 300, 'peek'); await shot(t + 1600, 'peek');
t = await until(eval(phaseIs('close')));
await shot(t + 200, 'shutting');
t = await until(eval(phaseIs('shake')));
await shot(t + 300, 'rattle'); await shot(t + 1100, 'jump');
t = await until(eval(phaseIs('tumble')));
await shot(t + 250, 'tumble');
t = await until(eval(phaseIs('place')));
await shot(t + 300, 'place');
t = await placeRight(t + 500);
await shot(t + 300, 'one home');
t = await placeWrong(t + 600);
await shot(t + 250, 'held');
await shot(t + 1000, 'save opening');
await shot(t + 2600, 'save');
await press(t + 2700, 'SAVE IT');
await shot(t + 3000, 'saved');
t = await solve(t + 3200);
t = await until(eval(phaseIs('won')));
await shot(t + 250, 'won: hop wave');
await shot(t + 800, 'won: cleared 1');
// ---- round 2: pause, RESUME, a mistake, END RUN: GAME OVER ----
t = await until(eval(`(s) => s.phase === 'place' && s.board && JSON.stringify(s.board) !== ${JSON.stringify(boards[0])}`));
await noteBoard();
await tapAt(t + 400, 34, 32, 'back');
await shot(t + 700, 'pause opening'); await shot(t + 2200, 'pause');
await press(t + 2300, 'RESUME');
await shot(t + 2700, 'resumed');
t = await placeWrong(t + 3000);
await shot(t + 400, 'held 2');
await shot(t + 2600, 'save 2');
await press(t + 2700, 'END RUN');
await shot(t + 3000, 'over opening'); await shot(t + 5000, 'game over');
fs.writeFileSync(path.join(out, 'blitz.json'), JSON.stringify({ T0, events, boards: boards.map((b) => JSON.parse(b)), randoms: await page.evaluate(() => window.__tumbleRandoms) }, null, 1));
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
