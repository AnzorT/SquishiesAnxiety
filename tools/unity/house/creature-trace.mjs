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

const [fxName = 'lv12', room = 'living', N = '900'] = process.argv.slice(2);
const fixture = loadFixtures().find((f) => f.name === fxName);
const browser = await launch();
const H = await openHouse(browser, fixture, { room, split: true });
await H.ready();
await H.frames(60);
const snap = () => H.page.evaluate(() => {
  const sh = window.__sh, C = (c) => ({ key: c.key, room: c.room, home: c.home, posRoom: c.posRoom, x: c.x, y: c.y, tx: c.tx, ty: c.ty, moving: c.moving, spin: c.spin, face: c.face, wk: c.wk, ph: c.ph, lift: c.lift, liftTo: c.liftTo, wanderAt: c.wanderAt, hold: c.hold, mode: c.mode, run: !!c.run, gv: c.gv || 1, needAt: c.needAt, N: c.N, gs: c.gs || {}, z: c.z, standUntil: c.standUntil || 0, turnAt: c.turnAt || 0, arrive: !!c.arrive, ext: Object.assign({}, c.ext) });
  return { now: window.__clock.now, last: sh.last, sel: sh.state.sel, vis: sh.vis.map((c) => c.key), cs: sh.cs.map(C) };
});
const start = await snap();
await H.page.evaluate(() => {
  const sh = window.__sh; window.__rngTrace = []; window.__fidg = [];
  const f0 = sh.fidg.bind(sh); sh.fidg = (c) => { const r = f0(c); window.__fidg.push(r); return r; };
});
const frames = [];
for (let f = 0; f < +N; f++) {
  await H.frames(1);
  frames.push(await snap());
}
const rng = await H.page.evaluate(() => window.__rngTrace), fidg = await H.page.evaluate(() => window.__fidg);
const out = { fixture: fxName, room, start, frames, rng, fidg };
const f = path.join(REPO, 'tools/unity/house-test/out/creature-trace.json');
fs.writeFileSync(f, JSON.stringify(out));
const by = {}; for (const [k, fn] of rng) by[k + ':' + fn] = (by[k + ':' + fn] || 0) + 1;
console.log(`creature-trace: ${fxName} ${room}, ${frames.length} frames, ${start.vis.length} in the room; draws ${JSON.stringify(by)}; fidg calls ${fidg.length}`);
for (const e of [...new Set(H.errs)].slice(0, 5)) console.log('  page error:', String(e).slice(0, 160));
await browser.close();
