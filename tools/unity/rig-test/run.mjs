// The native rig's parity test: the compiled C# rig (Creatures/Js, built here with plain dotnet) against the app's JS
// rig in Node on the browser stand-in, the same scripts in the same order on the same virtual clock and seeded
// Math.random, for every creature and every move / state the app uses (scenarios.js). Each snapshot is the creature's
// <svg> markup; equal text counts as equal, else Chrome draws both and counts the pixels that differ (> 24 in a channel)
// in the 475 px creature box.
//
//   node tools/unity/rig-test/run.mjs [keys...] [--scn idle,moves] [--all] [--no-build] [--px 0.5]
//   (default: three creatures; --all: every roster creature. Exit 1 when a snapshot differs by more than --px %.)
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import { execFileSync } from 'node:child_process';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { scriptList, scriptSource } from '../rig/jsc.mjs';

const require = createRequire(import.meta.url);
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const SCRATCH = process.env.RIG_TEST_OUT || path.join(HERE, 'out');
const argv = process.argv.slice(2);
const arg = (k, d) => { const i = argv.indexOf('--' + k); return i >= 0 ? argv[i + 1] : d; };
const flags = new Set(['--all', '--no-build', '--keep']);
const KEYS0 = argv.filter((a, i) => !a.startsWith('--') && !(i > 0 && argv[i - 1].startsWith('--') && !flags.has(argv[i - 1])));
const ROSTER = JSON.parse(fs.readFileSync(path.join(WORK, 'app/roster.js'), 'utf8').match(/__SQUISH_ROSTER_KEYS = (\[[^\]]*\])/)[1]);
const KEYS = argv.includes('--all') ? ROSTER : KEYS0.length ? KEYS0 : ['mittens', 'lumi', 'biscuit'];
fs.mkdirSync(SCRATCH, { recursive: true });

// ---- the JS side
function jsRealm() {
  const ctx = vm.createContext({ __realSetTimeout: setTimeout, console: { log() {}, warn() {}, error() {} }, Promise, Uint8ClampedArray, Float32Array, Float64Array, Int32Array, Uint32Array, Uint8Array, Map, Set, WeakMap, JSON, Symbol, Proxy });
  const run = (code, filename) => vm.runInContext(code, ctx, { filename });
  const errors = [];
  for (const [name, file] of scriptList(true)) {
    const src = scriptSource(name, file);
    try { run(src, name); } catch (e) { errors.push(name + ': ' + e.message); if (['dom-shim.js', 'live-host.js', 'virtual-clock.js', 'native-host.js', 'scenarios.js'].includes(name)) throw e; }
    if (name === 'live-host.js') {
      ctx.__rf = (p) => { const f = path.join(WORK, p); return fs.existsSync(f) ? fs.readFileSync(f, 'utf8') : null; };
      run('__live.install(__rf)', 'install');
    }
  }
  return { run, errors, ctx };
}
const settle = () => new Promise((r) => setTimeout(r, 0));

const list = [];
const SCN = arg('scn', null);
const js = jsRealm();
const names = SCN ? SCN.split(',') : js.run('__scn.names');
for (const k of KEYS) for (const n of names) list.push([k, n]);
fs.writeFileSync(path.join(SCRATCH, 'list.json'), JSON.stringify(list));

// ---- the C# side (built and run in a child process while Node runs the JS)
const GEN = path.join(SCRATCH, 'gen');
const BIN = process.env.RIG_TEST_BIN || path.join(HERE, 'bin/Release/net8.0');   // (another one to run two tests at once)
if (!argv.includes('--no-build')) {
  execFileSync('node', [path.join(REPO, 'tools/unity/rig/jsc.mjs'), '--test', '--out', GEN], { stdio: ['ignore', 'ignore', 'inherit'] });
  execFileSync('dotnet', ['build', '-c', 'Release', '-v', 'q', '-nologo', '-p:GEN=' + GEN, '-o', BIN], { cwd: HERE, stdio: ['ignore', 'ignore', 'inherit'] });
}
// the C# side runs in a child process alongside: one JSON line per run on its stdout, compared as they come
const { spawn } = await import('node:child_process');
const readline = await import('node:readline');
const t0 = Date.now();
const cs = spawn('dotnet', [path.join(BIN, 'RigTest.dll'), 'run', path.join(SCRATCH, 'list.json'), '-'], { stdio: ['ignore', 'pipe', 'inherit'] });
const csLines = readline.createInterface({ input: cs.stdout, crlfDelay: Infinity })[Symbol.asyncIterator]();

// Chrome draws both and counts the pixels that differ (> 24 in a channel), as parity.mjs
const { chromium } = require('playwright');
let browser = null, page = null;
async function pixels(a, b) {
  if (!browser) {
    browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
    page = await browser.newPage({ viewport: { width: 475, height: 475 } });
    await page.goto(pathToFileURL(path.join(WORK, '__unity_canvas.html')).href);
  }
  const { PNG } = require('pngjs');
  const shot = async (h) => { await page.evaluate((x) => { document.body.innerHTML = '<div style="position:absolute;left:0;top:0;width:475px;height:475px;background:#fff">' + x + '</div>'; }, h); return PNG.sync.read(await page.screenshot()); };
  const fix = (h) => h.replace(/href="grain"/g, 'href=""');
  const A = await shot(fix(a)), B = await shot(fix(b));
  let n = 0; for (let i = 0; i < A.data.length; i += 4) if (Math.max(Math.abs(A.data[i] - B.data[i]), Math.abs(A.data[i + 1] - B.data[i + 1]), Math.abs(A.data[i + 2] - B.data[i + 2])) > 24) n++;
  return n / (475 * 475) * 100;
}
const firstDiff = (a, b) => { let i = 0; while (i < a.length && a[i] === b[i]) i++; return i; };

const PX = +arg('px', 0.5);
const byKey = {};
let bad = 0, totalShots = 0, equalShots = 0, worstAll = 0;
if (js.errors.length) console.log('JS script errors: ' + js.errors.join('; '));
for (let i = 0; i < list.length; i++) {
  const [k, nm] = list[i];
  let frames = [], error;
  try {
    js.run(`__scn.start(${JSON.stringify(k)}, ${JSON.stringify(nm)})`, 'start');
    await settle();
    frames = js.run('__scn.run()', 'run');
    await settle();
    js.run('__scn.stop()', 'stop');
  } catch (e) { error = e.message; try { js.run('__scn.stop()', 'stop'); } catch (e2) { /* gone */ } }
  const J = { key: k, name: nm, frames: Array.from(frames), error };
  const nx = await csLines.next();
  if (nx.done) { console.log('the C# side stopped early'); process.exit(2); }
  const C = JSON.parse(nx.value);
  if (C.key !== k || C.name !== nm) { console.log('out of step: ' + C.key + ' ' + C.name); process.exit(2); }
  const r = byKey[k] || (byKey[k] = {});
  let eq = 0, worst = 0, detail = '', checked = 0;
  if (J.error || C.error) detail = `errors: js ${J.error || '-'} / c# ${C.error || '-'}`;
  const n = Math.max(J.frames.length, C.frames.length);
  for (let f = 0; f < n; f++) {
    const a = J.frames[f], b = C.frames[f];
    if (a === b) { eq++; continue; }
    if (!detail) {
      const at = firstDiff(a || '', b || '');
      fs.writeFileSync(path.join(SCRATCH, `diff-${k}-${nm}-js.svg`), a || ''); fs.writeFileSync(path.join(SCRATCH, `diff-${k}-${nm}-cs.svg`), b || '');       detail = `#${f} at ${at}: js …${(a || '').slice(Math.max(0, at - 60), at + 80)}… c# …${(b || '').slice(Math.max(0, at - 60), at + 80)}…`;
    }
    if (a == null || b == null) { worst = 100; continue; }
    if (checked++ < 6) worst = Math.max(worst, await pixels(a, b));   // (the first six that differ)
  }
  totalShots += n; equalShots += eq; worstAll = Math.max(worstAll, worst);
  const ok = !J.error === !C.error && worst <= PX && J.frames.length === C.frames.length;
  if (!ok) bad++;
  r[nm] = { shots: n, equal: eq, worst: +worst.toFixed(3), ok };
  if (eq < n || !ok) console.log(`${ok ? '  ' : 'X '}${k} ${nm}: ${eq}/${n} equal markup, worst ${worst.toFixed(3)} % of pixels${detail ? '\n     ' + detail : ''}`);
  if (i % 50 === 49) console.log(`  ... ${i + 1}/${list.length} runs, ${((Date.now() - t0) / 1000).toFixed(0)} s`);
}
if (browser) await browser.close();
cs.kill();
console.log(`\n${list.length} runs (${KEYS.length} creatures x ${names.length} scenarios): ${equalShots}/${totalShots} snapshots equal as markup, worst ${worstAll.toFixed(3)} % of pixels; ${bad} run(s) over ${PX} % (${((Date.now() - t0) / 1000).toFixed(0)} s)`);
fs.writeFileSync(path.join(SCRATCH, 'report.json'), JSON.stringify(byKey, null, 1));
process.exit(bad ? 1 : 0);
