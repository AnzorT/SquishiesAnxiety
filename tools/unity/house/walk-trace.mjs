// house-walk.js's own answers for tools/unity/house-test `walk`: HouseWalk.step over 90 frames for a spread of
// creatures (every gait, wings, runs), Math.random fixed at 0.5 -> tools/unity/house-test/out/walk-trace.json
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import zlib from 'node:zlib';
import { REPO } from './harness.mjs';

const scripts = JSON.parse(zlib.gunzipSync(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/Rig/scripts.bytes'))));
const ctx = vm.createContext({ console: { log() {}, warn() {}, error() {} } });
for (const [name, code] of scripts) {
  try { vm.runInContext(code, ctx, { filename: name }); } catch (e) {}
  if (name === 'live-host.js') vm.runInContext('__live.install(function () { return null; })', ctx);
}
const out = vm.runInContext(`(() => {
  Math.random = () => 0.5;
  const P = HouseWalk.PROF, byG = {};
  for (const k in P) { const g = P[k].g || 'trot'; (byG[g] = byG[g] || []).push(k); }
  const keys = [].concat(...Object.values(byG).map(l => l.slice(0, 2))).concat(['nobody']);
  const runs = Object.keys(window.HouseWalkRUN || {}).slice(0, 3);
  const res = [];
  for (const key of keys.concat(runs)) {
    const st = { run: runs.includes(key) ? 1 : 0 }, frames = [];
    for (let f = 0; f < 90; f++) {
      const E = {}, w = Math.min(1, f / 20), spin = (f * 7) % 360 - 180;
      const r = HouseWalk.step(key, st, E, w, 0.016, f < 70 ? 1 : 0, spin);
      frames.push({ E, v: r.v, fx: r.fx });
    }
    res.push({ key, run: st.run, frames });
  }
  return JSON.stringify(res);
})()`, ctx);
const f = path.join(REPO, 'tools/unity/house-test/out/walk-trace.json');
fs.mkdirSync(path.dirname(f), { recursive: true });
fs.writeFileSync(f, out);
console.log('walk-trace:', JSON.parse(out).length, 'creatures x 90 frames');
