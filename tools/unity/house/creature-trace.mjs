// Stage 3's check: the page's squad walking about (a fixture's room, virtual time, split random streams) recorded for
// tools/unity/house-test `creatures`, which runs House/HouseCreatures.cs from the same starting state with the page's
// own random draws (the creature functions' share of the 'house-page' stream, house-walk.js's stream) and the rig's
// fidget answers, and compares every creature every frame.
//
//   node tools/unity/house/creature-trace.mjs [fixture] [room] [frames]   -> tools/unity/house-test/out/creature-trace.json
import fs from 'node:fs';
import path from 'node:path';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';

const [fxName = 'lv12', room = 'living', N = '900', script = ''] = process.argv.slice(2);
// script: 'frame:op:arg[:arg2],...' with op sel (a friend by index in the room), act (an act id, a piece id), floor (x,y),
// tap (a piece); Renovate (stage 6): edit, done, down (piece, x, y: room px), move (x, y), up, rot (deg), turn, size (d, ax),
// store, place (a piece type, ~ for :), ldown / lmove (x), lup, lsize (d), lstore, lback (id), lmid, rsurf (row id)
const OPS = script ? script.split(',').map((t) => t.split(':').map((a) => a.replace(/~/g, ':'))) : [];
const fixture = loadFixtures().find((f) => f.name === fxName);
const browser = await launch();
const H = await openHouse(browser, fixture, { room, split: true });
await H.ready();
await H.frames(60);
const snap = () => H.page.evaluate(() => {
  const sh = window.__sh, C = (c) => ({ seat: c.seat || null, seatItem: c.seatItem || null, useItem: c.useItem || null, wSt: c.wSt || null, napSt: c.napSt || null, useEnd: c.useEnd || 0, eatEnd: c.eatEnd || 0, sayText: c.say && c.say.current ? c.say.current.textContent : null, key: c.key, room: c.room, home: c.home, posRoom: c.posRoom, x: c.x, y: c.y, tx: c.tx, ty: c.ty, moving: c.moving, spin: c.spin, face: c.face, wk: c.wk, ph: c.ph, lift: c.lift, liftTo: c.liftTo, wanderAt: c.wanderAt, hold: c.hold, mode: c.mode, run: !!c.run, gv: c.gv || 1, needAt: c.needAt, N: c.N, gs: c.gs || {}, z: c.z, standUntil: c.standUntil || 0, turnAt: c.turnAt || 0, arrive: !!c.arrive, ext: Object.assign({}, c.ext) });
  const H = sh.H, ed = { eSel: sh.state.eSel || null, items: JSON.parse(JSON.stringify(sh.roomItems())), lx: H.lx || {}, lz: H.lz || {}, surf: H.surf || {}, rtex: H.rtex || {}, lOff: H.lOff || {}, uid: H.uid };
  return { ed, now: window.__clock.now, last: sh.last, sel: sh.state.sel, vis: sh.vis.map((c) => c.key), cs: sh.cs.map(C), rst: JSON.parse(JSON.stringify(sh.rst || {})), vars: Object.assign({}, sh.vars), tv: Object.assign({}, sh.tv) };
});
const start = await snap();
await H.page.evaluate(() => {
  const sh = window.__sh; window.__rngTrace = []; window.__fidg = []; window.__ticks = 0; window.__rig = []; window.__plays = [];
  const f0 = sh.fidg.bind(sh); sh.fidg = (c) => { const r = f0(c); window.__fidg.push(r); return r; };
  const t0 = sh.tick.bind(sh); sh.tick = (n) => { window.__ticks++; return t0(n); };
  // the rig's state events (onRig) with the tick count they came after; every ctrl.play the house makes
  const o0 = sh.onRig.bind(sh); sh.onRig = (c, n) => { window.__rig.push([window.__ticks, 'rig', c.key, n]); return o0(c, n); };
  sh.cs.forEach((c) => { if (c.ctrl && !c.ctrl.__w) { const p0 = c.ctrl.play; c.ctrl.play = (n) => { window.__plays.push([window.__ticks, c.key, n]); return p0(n); }; c.ctrl.__w = 1; } });
});
const frames = [];
const toasts = [];
for (let f = 0; f < +N; f++) {
  for (const op of OPS.filter((o) => +o[0] === f)) {
    const res = await H.page.evaluate((op) => {
      const sh = window.__sh, [, k, a, b, c] = op;
      sh.toLocal = (e) => ({ x: e.x, y: e.y });
      const said = []; const t0 = sh.toast.bind(sh); sh.toast = (t) => { said.push(t); return t0(t); };
      const ev = (x, y) => ({ stopPropagation() {}, preventDefault() {}, x: +x, y: +y, button: 0 });
      const win = (type, x) => window.dispatchEvent(new PointerEvent(type, { clientX: +x, clientY: 0 }));
      const E = { edit: () => sh.setState({ edit: true, sel: null, eSel: null, rTab: 'furn', rOpen: false, dr: false }), done: () => { sh.edBack(); sh.setState({ edit: false, eSel: null, txE: null }); },
        down: () => sh.itemDown(a, ev(b, c)), move: () => sh.dragMove(ev(a, b)), up: () => sh.dragEnd(), rot: () => { sh._rotMoved = false; sh.rotSet(sh.findItem(sh.state.eSel), +a); if (sh._rotMoved) sh.save(); },
        turn: () => sh.editRot(), size: () => sh.editSize(+a, b || undefined), store: () => sh.editStore(), place: () => sh.placeNew(a),
        ldown: () => sh.lightDown(ev(a, 0)), lmove: () => win('pointermove', a), lup: () => win('pointerup', 0), lsize: () => sh.lightSize(+a), lstore: () => sh.lightStore(), lback: () => sh.lightBack(a),
        lmid: () => { const H = sh.H, cur = sh.state.cur; if (H.lx && H.lx[cur] != null) { delete H.lx[cur]; sh.save(); sh.setState((s) => ({ ver: s.ver + 1 })); } }, rsurf: () => sh.useRSurf(a) };
      if (E[k]) { window.__rig.push([window.__ticks, 'op', k, a || null, b || null, c || null]); E[k](); sh.toast = t0; return said.join(' | ') || null; }
      sh.toast = t0;
      if (!E[k]) window.__rig.push([window.__ticks, 'op', k, a || null, b || null]);   // (one list with the rig's events: their order)
      if (k === 'sel') sh.setState({ sel: +a });
      else if (k === 'act') { const t0 = sh.toast.bind(sh); let said = null; sh.toast = (t) => { said = t; return t0(t); }; sh.act(a, b || undefined); sh.toast = t0; return said; }
      else if (k === 'floor') { const c = sh.selC(); if (c) sh.goTo(c, +a, +b); }
      else if (k === 'tap') { const t0 = sh.toast.bind(sh); let said = null; sh.toast = (t) => { said = t; return t0(t); }; sh.itemDown(a, { stopPropagation() {}, clientX: 0, clientY: 0 }); sh.toast = t0; return said; }
      return null;
    }, op);
    toasts.push([f, op.join(':'), res]);
  }
  await H.frames(1);
  frames.push(await snap());
}
const rng = await H.page.evaluate(() => window.__rngTrace), fidg = await H.page.evaluate(() => window.__fidg);
const rig = await H.page.evaluate(() => window.__rig), plays = await H.page.evaluate(() => window.__plays);
const out = { fixture: fxName, room, start, frames, rng, fidg, ops: OPS, rig, plays, toasts };
const f = path.join(REPO, 'tools/unity/house-test/out/creature-trace.json');
fs.writeFileSync(f, JSON.stringify(out));
const by = {}; for (const [k, fn] of rng) by[k + ':' + fn] = (by[k + ':' + fn] || 0) + 1;
console.log(`creature-trace: ${fxName} ${room}, ${frames.length} frames, ${start.vis.length} in the room; draws ${JSON.stringify(by)}; fidg calls ${fidg.length}`);
for (const e of [...new Set(H.errs)].slice(0, 5)) console.log('  page error:', String(e).slice(0, 160));
await browser.close();
