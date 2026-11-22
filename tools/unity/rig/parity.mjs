// Do the creature rigs draw the same thing on the browser stand-in (dom-shim.js) as in Chrome?
//
//   node tools/unity/rig/parity.mjs [mittens biscuit lumi ...] [--frames 400] [--every 10]
//
// Both sides load the rig scripts the app's menu loads, from the built in-app game, behind the same virtual clock
// (virtual-clock.js: same frames, same seeded Math.random). Each creature is mounted, a script of moves is played
// (idle, then dance, hop, squish, wave...), and every few frames its whole SVG tree is written out in one canonical
// form (sorted attributes, style.display only, the fabric tile's data URL as a token) and compared. A snapshot that
// isn't identical as text is drawn both ways by Chrome and compared by pixels: float noise (the JS engines' last bits)
// is invisible, a real difference isn't. Exit 1 on a visible difference (--px: how many pixels count as visible).
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const arg = (k, d) => { const i = process.argv.indexOf('--' + k); return i > 0 ? process.argv[i + 1] : d; };
const KEYS = process.argv.slice(2).filter((a, i, all) => !a.startsWith('--') && !(i > 0 && all[i - 1].startsWith('--')));
const CREATURES = KEYS.length ? KEYS : ['mittens'];
const FRAMES = +arg('frames', 420), EVERY = +arg('every', 10), DT = 16, LOG_BB = process.argv.includes('--log-bbox');

// the rig scripts, in the order the Main Menu page lists them (Main Menu.dc.html), plus app/boot.js (fetch() of files
// next to the page) and app/perf.js (the app's patches of rive-rig.js call into it)
export const RIG_SCRIPTS = ['app/boot.js', 'app/perf.js', 'creatures-v2.js', 'squad-store.js', 'rive-rig.js', 'snack-3d.js', 'fruit-3d.js', 'rive-generic.js',
  'pet-defs.js', 'pet2-defs.js', 'mittens-moves.js', 'house-moves.js', 'house-moves-c.js', 'house-bed-c.js', 'house-water-c.js',
  'house-play-c.js', 'house-b-c.js', 'house-cx.js', 'house-cx-c.js', 'house-walk.js', 'house-walk-c.js', 'house-idle.js', 'house-idle-c.js',
  'snack2-house.js', 'pet2-house.js', 'fruit-house.js', 'pet-anims.js', 'pet-pokes.js', 'pet-eats.js', 'snack-anims.js', 'snack-pokes.js',
  'snack-eats.js', 'snack2-anims.js', 'ocean-anims.js', 'pet2-anims.js', 'fruit-anims.js', 'whip-spin.js'];
// what each creature does, by frame (16 ms each)
const SCRIPT = [[0, 'idle'], [90, 'dance'], [190, 'hop'], [250, 'squish'], [310, 'idle_waveL'], [370, 'happy']];

// one canonical text for a tree: the same function runs in Chrome and in Node
const CANON = `function __canon(n) {
  if (n.nodeType === 3) { const t = n.data.trim(); return t ? JSON.stringify(t) : ''; }
  if (n.nodeType !== 1) return '';
  const a = [];
  for (const at of Array.from(n.attributes)) { if (at.name === 'style') continue; let v = at.value; if (/^(data:image|shim-canvas:)/.test(v)) v = 'CANVAS'; a.push(at.name + '=' + JSON.stringify(v)); }
  a.sort();
  const d = n.style && n.style.display; if (d) a.push('display=' + d);
  const op = n.style && n.style.opacity; if (op) a.push('opacity=' + op);
  const tf = n.style && n.style.transform; if (tf) a.push('transform=' + tf);
  return '<' + n.tagName + (a.length ? ' ' + a.join(' ') : '') + '>' + Array.from(n.childNodes).map(__canon).join('') + '</' + n.tagName + '>';
}`;
const DRIVE = `async function __drive(key, frames, every, script, dt) {
  // --log-bbox: every getBBox the rig asks for, to find where the two sides first measure differently
  window.__bbl = [];
  if (window.__logBB) { const P = (window.SVGGraphicsElement || window.Element).prototype, orig = P.getBBox;
    P.getBBox = function () { const b = orig.call(this); window.__bbl.push(this.tagName + ' ' + [b.x, b.y, b.width, b.height].join(',')); return b; }; }
  const host = document.createElement('div'); document.body.appendChild(host);
  host.__rect = { left: 0, top: 0, width: 475, height: 475 };
  if (host.style) host.style.cssText = 'position:absolute;left:0;top:0;width:475px;height:475px';
  const ctl = window.RiveRig.mount(host, key, {});
  // a generic creature's art arrives by fetch: wait (in real time, the virtual clock stays put) until it's drawn
  const wait = ms => new Promise(r => (window.__realSetTimeout || setTimeout)(r, ms));
  for (let k = 0, last = ''; k < 100; k++) { await wait(30); const c = __canon(host); if (c === last && (c.match(/<path/g) || []).length > 3) break; last = c; }
  const out = [], raw = [];
  for (let f = 0; f <= frames; f++) {
    for (const [at, name] of script) if (at === f) ctl.play(name);
    if (f % every === 0) { out.push(__canon(host)); raw.push(host.innerHTML); }
    __clock.frame(dt);
    for (let k = 0; k < 4; k++) await Promise.resolve();
  }
  ctl.destroy && ctl.destroy();
  host.remove();
  if (window.__logBB) out.push('BBOX ' + window.__bbl.join(' | '));
  return { out, raw };
}`;

async function inNode(key) {
  const read = rel => fs.readFileSync(path.join(WORK, rel), 'utf8');
  const ctx = vm.createContext({ __realSetTimeout: setTimeout, console, Promise, Uint8ClampedArray, Float32Array, Float64Array, Int32Array, Uint8Array, Map, Set, WeakMap, JSON, Symbol });
  const run = (code, filename) => vm.runInContext(code, ctx, { filename });
  run(fs.readFileSync(path.join(HERE, 'dom-shim.js'), 'utf8'), 'dom-shim.js');
  ctx.__readFile = rel => read(rel);
  run('RigDomShim.install(globalThis, { readFile: __readFile });', 'install');
  run(fs.readFileSync(path.join(HERE, 'virtual-clock.js'), 'utf8'), 'virtual-clock.js');
  const errors = [];
  ctx.console = { log() {}, warn() {}, error: (...a) => errors.push(a.map(String).join(' ')) };
  for (const s of RIG_SCRIPTS) {
    try { run(read(s), s); } catch (e) { errors.push(s + ': ' + e.message); }
  }
  if (LOG_BB) run('window.__logBB = 1', 'log');
  run(CANON + '\n' + DRIVE, 'harness');
  const r = await run(`__drive(${JSON.stringify(key)}, ${FRAMES}, ${EVERY}, ${JSON.stringify(SCRIPT)}, ${DT})`, 'drive');
  return { frames: r.out, raw: r.raw, errors };
}

async function inChrome(browser, key) {
  const page = await browser.newPage();
  const errors = [];
  page.on('pageerror', e => errors.push(e.message));
  page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
  await page.route(/^https?:/, r => r.abort());
  await page.addInitScript({ path: path.join(HERE, 'virtual-clock.js') });
  const html = '<!doctype html><meta charset="utf-8"><body>' + (LOG_BB ? '<script>window.__logBB = 1</script>' : '') + RIG_SCRIPTS.map(s => `<script src="${s}"></script>`).join('') + `<script>${CANON}\n${DRIVE}</script></body>`;
  fs.writeFileSync(path.join(WORK, '__rigparity.html'), html);
  await page.goto(pathToFileURL(path.join(WORK, '__rigparity.html')).href);
  await page.waitForFunction(() => window.RiveRig && window.__drive, null, { timeout: 60000 });
  const r = await page.evaluate(([key, F, E, S, dt]) => window.__drive(key, F, E, S, dt), [key, FRAMES, EVERY, SCRIPT, DT]);
  await page.close();
  return { frames: r.out, raw: r.raw, errors };
}

// Snapshots that aren't identical as text: does it show? Chrome draws both (the creature at the menu's size, 475 px,
// the fabric tile the same on both) and counts the pixels that differ by more than 24 in a channel.
async function looks(browser, pairs) {
  if (!pairs.length) return [];
  const page = await browser.newPage({ viewport: { width: 475, height: 475 } });
  await page.goto(pathToFileURL(path.join(WORK, '__rigparity.html')).href.replace('__rigparity.html', '__unity_canvas.html'));
  const shot = async html => { await page.evaluate(h => { document.body.innerHTML = '<div style="position:absolute;left:0;top:0;width:475px;height:475px;background:#fff">' + h + '</div>'; }, html); await page.waitForTimeout(30); return page.screenshot(); };
  const { PNG } = require('pngjs');
  const out = [];
  for (const [a, b] of pairs) {
    const tile = (a.match(/href="(data:image\/png[^"]+)"/) || [])[1] || '';
    const fix = h => h.replace(/href="(data:image\/png[^"]+|shim-canvas:[^"]+)"/g, 'href="' + tile + '"');
    const A = PNG.sync.read(await shot(fix(a))), B = PNG.sync.read(await shot(fix(b)));
    let n = 0; for (let i = 0; i < A.data.length; i += 4) if (Math.max(Math.abs(A.data[i] - B.data[i]), Math.abs(A.data[i + 1] - B.data[i + 1]), Math.abs(A.data[i + 2] - B.data[i + 2])) > 24) n++;
    out.push(n);
  }
  await page.close();
  return out;
}

function firstDiff(a, b) {
  let i = 0; while (i < a.length && a[i] === b[i]) i++;
  return { at: i, a: a.slice(Math.max(0, i - 120), i + 160), b: b.slice(Math.max(0, i - 120), i + 160) };
}

if (!fs.existsSync(path.join(WORK, 'rive-rig.js'))) {
  const { build } = await import('../../../webgame/build.mjs');
  await build(WORK);
}
const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
let bad = 0, looksSame = 0;
const PX_LIMIT = +arg('px', 40);   // more pixels than this differing in any snapshot = a visible difference
for (const key of CREATURES) {
  const [c, n] = [await inChrome(browser, key), await inNode(key)];
  let same = 0, firstBad = -1;
  for (let i = 0; i < c.frames.length; i++) { if (c.frames[i] === n.frames[i]) same++; else if (firstBad < 0) firstBad = i; }
  const ok = same === c.frames.length && c.frames.length === n.frames.length;
  if (process.argv.includes('--which')) console.log('  per snapshot: ' + c.frames.map((f, i) => f === n.frames[i] ? '=' : 'x').join(''));
  const bytes = c.frames.reduce((s, f) => s + f.length, 0);
  const diffIdx = c.frames.map((f, i) => f === n.frames[i] ? -1 : i).filter(i => i >= 0 && c.raw[i] != null && n.raw[i] != null);
  const px = await looks(browser, diffIdx.map(i => [c.raw[i], n.raw[i]]));
  const worst = px.length ? Math.max(...px) : 0;
  const visible = worst > PX_LIMIT;
  if (!ok && !visible) looksSame++;
  if (visible) bad++;
  console.log(`${ok ? 'SAME' : visible ? 'DIFFERENT' : 'LOOKS SAME'} ${key}: ${same}/${c.frames.length} snapshots identical${ok ? '' : `, the others differ by at most ${worst} pixels of 475x475`} (${FRAMES} frames, every ${EVERY}; ${(bytes / c.frames.length / 1024).toFixed(1)} KB of SVG per snapshot)`);
  const showAt = process.argv.includes('--at') ? +arg('at', 0) : firstBad;
  if (firstBad >= 0 && (visible || process.argv.includes('--show'))) {
    firstBad = showAt;
    const d = firstDiff(c.frames[firstBad], n.frames[firstBad] || '');
    console.log(`  first difference at frame ${firstBad * EVERY}, char ${d.at}:\n    chrome: ${d.a}\n    shim:   ${d.b}`);
  }
  if (LOG_BB) {
    const A = c.frames[c.frames.length - 1].split(' | '), B = n.frames[n.frames.length - 1].split(' | ');
    let i = 0; while (i < A.length && A[i] === B[i]) i++;
    console.log(`  getBBox calls: chrome ${A.length}, shim ${B.length}; first different call #${i}:\n    chrome: ${A.slice(Math.max(0, i - 2), i + 3).join(' | ')}\n    shim:   ${B.slice(Math.max(0, i - 2), i + 3).join(' | ')}`);
  }
  for (const e of [...new Set(c.errors)].slice(0, 5)) console.log('  chrome error:', e.slice(0, 300));
  for (const e of [...new Set(n.errors)].slice(0, 5)) console.log('  shim error:', e.slice(0, 300));
}
await browser.close();
console.log(`\n${CREATURES.length - bad - looksSame} identical, ${looksSame} identical to the eye (a few pixels of anti-aliasing at most), ${bad} visibly different`);
process.exit(bad ? 1 : 0);
