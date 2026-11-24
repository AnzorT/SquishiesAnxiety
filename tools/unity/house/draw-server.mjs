// The draw host for the .NET checks (tools/unity/house-test): the Rig bundle loaded as LiveRig loads it (draw-check.mjs),
// then one JS expression per stdin line (JSON-quoted), its String() value back per stdout line (JSON-quoted; null on
// error). House/HouseDraw.cs's Eval, as PuerTS gives it in Unity.
//
//   node tools/unity/house/draw-server.mjs
import fs from 'node:fs'; import path from 'node:path'; import vm from 'node:vm'; import zlib from 'node:zlib'; import readline from 'node:readline';
import { fileURLToPath } from 'node:url';
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../../..');
const R = (f) => JSON.parse(zlib.gunzipSync(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/Rig', f))));
const scripts = R('scripts.bytes'), files = R('files.bytes');
const ctx = vm.createContext({ console: { log() {}, warn() {}, error() {} } });
for (const [n, c] of scripts) { try { vm.runInContext(c, ctx, { filename: n }); } catch (e) { if (n === 'house-draw.js') throw e; } if (n === 'live-host.js') { ctx.__f = files; vm.runInContext('__live.install(function (p) { return Object.prototype.hasOwnProperty.call(__f, p) ? __f[p] : null; })', ctx); } }
for (let i = 0; i < 20; i++) vm.runInContext('__clock.frame(40)', ctx);
const rl = readline.createInterface({ input: process.stdin });
process.stdout.write('"ready"\n');
rl.on('line', (l) => { let out = null; try { out = String(vm.runInContext(JSON.parse(l), ctx)); } catch (e) { out = null; } process.stdout.write(JSON.stringify(out) + '\n'); });
