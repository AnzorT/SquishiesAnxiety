// The house walks' and moves' data for House/HouseWalk.cs and House/HouseActions.cs (the C# port of house-walk.js): every creature's gait profile
// (HouseWalk.def calls in house-walk-c.js and friends), the run extras (window.HouseWalkRUN) and the creature aliases
// (window.SQ_ALIAS), read after the rig scripts have run exactly as the app loads them (Resources/Rig/scripts.bytes,
// tools/unity/rig/bundle.mjs).
//
//   node tools/unity/rig/bundle.mjs && node tools/unity/house/export-walk.mjs   -> unity/Assets/Resources/House/walk.json
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import zlib from 'node:zlib';
import { REPO } from './harness.mjs';

const scripts = JSON.parse(zlib.gunzipSync(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/Rig/scripts.bytes'))));
const ctx = vm.createContext({ console: { log() {}, warn() {}, error() {} } });
for (const [name, code] of scripts) {
  try { vm.runInContext(code, ctx, { filename: name }); } catch (e) { /* as the app */ }
  if (name === 'live-host.js') vm.runInContext('__live.install(function () { return null; })', ctx);
}
// the house moves the house logic asks about (RiveRig.HS: hsGet): only what it reads (dur, loop, hop, turn, sync, catchEnd),
// not the keyframes; and whether the rigs have 'eat_cookie' (eatS)
const out = vm.runInContext(`JSON.stringify({ prof: HouseWalk.PROF, run: window.HouseWalkRUN || {}, alias: window.SQ_ALIAS || {}, gaits: Object.keys(HouseWalk.G),
  hs: Object.fromEntries(Object.entries(RiveRig.HS || {}).map(([k, v]) => [k, Object.fromEntries(['dur', 'loop', 'hop', 'turn', 'sync', 'catchEnd'].filter((f) => v[f] != null).map((f) => [f, v[f]]))])),
  eatCookie: !!(RiveRig.STATES && RiveRig.STATES.eat_cookie) })`, ctx);
const d = JSON.parse(out);
fs.writeFileSync(path.join(REPO, 'unity/Assets/Resources/House/walk.json'), JSON.stringify(d));
console.log(`walk.json: ${Object.keys(d.hs).length} house moves, ${Object.keys(d.prof).length} profiles, ${Object.keys(d.run).length} run extras, ${Object.keys(d.alias).length} aliases, gaits ${d.gaits.join(' ')}`);
