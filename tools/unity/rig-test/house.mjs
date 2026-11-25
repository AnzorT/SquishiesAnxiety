// The house's runtime drawings (House/HouseDraw.cs's Eval) compiled to C# against the JS: the same calls on both.
//   node tools/unity/rig-test/house.mjs [--no-build]
// The calls: __house.init, the rooms' geo, every exported variant and render key (unity/Assets/Resources/House/
// house-pieces.json), the rooms' shells, a few textures, the beach in every season by day and night, the house map
// for a few states. The JS side runs the Rig bundle (unity/Assets/Resources/Rig/scripts.bytes) in Node as
// tools/unity/house/draw-server.mjs does; the C# side is RigTest's `house` mode (RigHost.HouseEval). Every answer must
// be the same text.
import fs from 'node:fs'; import path from 'node:path'; import vm from 'node:vm'; import zlib from 'node:zlib';
import { execFileSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const OUT = process.env.RIG_TEST_OUT || path.join(HERE, 'out');
fs.mkdirSync(OUT, { recursive: true });
const Q = (s) => JSON.stringify(s);

// ---- the calls
const pieces = JSON.parse(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/House/house-pieces.json'), 'utf8'));
const ROOMS = ['living', 'bedroom', 'bathroom', 'kitchen', 'movie', 'dance', 'yard', 'beach'];
const calls = ['String(__house.init())'];
for (const r of ROOMS) calls.push(`String(__house.geo(${Q(r)}))`);
calls.push(`String(__house.geo("living"))`);
for (const k of Object.keys(pieces.variants)) {
  const [id, st, txt, rot] = k.split('|');
  calls.push(`__house.variant(${Q(id)}, ${Q(st)}, ${Q(txt)}, ${rot === '' ? 'null' : Number(rot)})`);
}
for (const k of Object.keys(pieces.renders)) {
  const [t, r, c, v] = k.split('|');
  calls.push(`__house.render(${Q(t)}, ${Number(r)}, ${Number(c)}, ${Q(v || '')})`);
}
// a sign with its own writing (Renovate's Aa), if the catalog has one: the first ids that answer with a `txt`
for (const id of Object.keys(pieces.variants).map((k) => k.split('|')[0]).slice(0, 6)) calls.push(`__house.variant(${Q(id)}, "", "HELLO", null)`);
for (const r of ROOMS.slice(0, 6)) calls.push(`__house.shell(${Q(r)}, "{}", "{}")`);
for (const id of [...new Set(Object.keys(pieces.variants).map((k) => k.split('|')[0]))].slice(0, 10)) calls.push(`__house.tex(${Q(id)})`);
for (const season of ['sunny', 'rainy', 'snowy']) for (const night of [false, true]) calls.push(`__house.beach(${Q(JSON.stringify({ season, night, sand: null, pier: null, light: null }))})`);
for (const st of [
  { lvl: 1, cur: 'living', open: ['living'], b0: {}, cs: [], season: 'sunny' },
  { lvl: 7, cur: 'bedroom', open: ['living', 'bedroom', 'bathroom', 'kitchen'], b0: {}, cs: [{ key: 'mittens', name: 'Mittens', room: 'living', N: { h: 80, c: 60, e: 70, f: 50 }, id: 1 }], season: 'rainy' },
  { lvl: 20, cur: 'dance', open: ['living', 'bedroom', 'bathroom', 'kitchen', 'movie', 'dance'], b0: {}, cs: [], season: 'snowy', mapIn: true },
]) calls.push(`__house.map(${Q(JSON.stringify(st))})`);
fs.writeFileSync(path.join(OUT, 'house-calls.json'), JSON.stringify(calls));

// ---- the JS side (as draw-server.mjs)
const R = (f) => JSON.parse(zlib.gunzipSync(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/Rig', f))));
const scripts = R('scripts.bytes'), files = R('files.bytes');
const ctx = vm.createContext({ console: { log() {}, warn() {}, error() {} } });
for (const [n, c] of scripts) { try { vm.runInContext(c, ctx, { filename: n }); } catch (e) { if (n === 'house-draw.js') throw e; } if (n === 'live-host.js') { ctx.__f = files; vm.runInContext('__live.install(function (p) { return Object.prototype.hasOwnProperty.call(__f, p) ? __f[p] : null; })', ctx); } }
for (let i = 0; i < 20; i++) vm.runInContext('__clock.frame(40)', ctx);
const js = calls.map((c) => { try { return String(vm.runInContext(c, ctx)); } catch (e) { return null; } });

// ---- the C# side
const proj = path.join(HERE, 'RigTest.csproj');
if (!process.argv.includes('--no-build')) execFileSync('dotnet', ['build', '-c', 'Release', proj, '-v', 'q', '-nologo'], { stdio: 'inherit' });
const dll = path.join(HERE, 'bin/Release/net8.0/RigTest.dll');
execFileSync('dotnet', [dll, 'house', path.join(OUT, 'house-calls.json'), path.join(OUT, 'house-cs.json')], { stdio: 'inherit', env: { ...process.env, DOTNET_ROLL_FORWARD: 'Major' }, maxBuffer: 1 << 30 });
const cs = JSON.parse(fs.readFileSync(path.join(OUT, 'house-cs.json'), 'utf8'));

// (a creature picture's version, ?v=N: the C# realm also runs the menu's look scripts, app/rig-look.js, which bump a
// few creatures' picture versions as the menu page does; draw-server.mjs's bundle doesn't)
const unver = (t) => (t == null ? t : t.replace(/\?v=\d+/g, ''));
let same = 0, bad = 0, nulls = 0;
calls.forEach((c, i) => {
  if (js[i] === 'null' || js[i] == null) nulls++;
  if (unver(js[i]) === unver(cs[i])) { same++; return; }
  bad++;
  if (bad <= 8) {
    const a = js[i] || '', b = cs[i] || ''; let k = 0; while (k < a.length && a[k] === b[k]) k++;
    console.log(`differs: ${c.slice(0, 90)}\n   js: ${a.length} chars, cs: ${b.length} chars, first difference at ${k}: js …${a.slice(Math.max(0, k - 40), k + 60)}…\n   cs …${b.slice(Math.max(0, k - 40), k + 60)}…`);
  }
});
console.log(`house draw: ${same} / ${calls.length} answers the same as the JS (${nulls} of them null in the JS)`);
process.exit(bad ? 1 : 0);
