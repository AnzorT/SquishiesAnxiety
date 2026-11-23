// Bundles the creature rig code for the live host inside Unity (Creatures/LiveRig.cs, PuerTS): the browser stand-in
// (dom-shim.js), the host's side (live-host.js), the virtual clock and the app's rig scripts in the order parity.mjs loads them, and the creature art
// they fetch() (export/tripo/<key>/<key>-front.svg: the Tripo creatures' outlines; the built-in pets need none).
//
//   node tools/unity/rig/bundle.mjs
//
// -> unity/Assets/Resources/Rig/scripts.bytes  gzip of JSON [[name, code], ...]   (run in this order)
//    unity/Assets/Resources/Rig/files.bytes    gzip of JSON { path: text }         (what the rig's fetch() reads)
import fs from 'node:fs';
import path from 'node:path';
import zlib from 'node:zlib';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const OUT = path.join(REPO, 'unity/Assets/Resources/Rig');
const RIG = eval(fs.readFileSync(path.join(HERE, 'parity.mjs'), 'utf8').match(/export const RIG_SCRIPTS = (\[[\s\S]*?\]);/)[1]);
if (!fs.existsSync(path.join(WORK, 'rive-rig.js'))) { const { build } = await import('../../../webgame/build.mjs'); await build(WORK); }

const scripts = [
  ['dom-shim.js', fs.readFileSync(path.join(HERE, 'dom-shim.js'), 'utf8')],
  ['live-host.js', fs.readFileSync(path.join(HERE, 'live-host.js'), 'utf8')],   // (then the host calls __live.install)
  ['virtual-clock.js', fs.readFileSync(path.join(HERE, 'virtual-clock.js'), 'utf8')],
  ...RIG.map(s => [s, fs.readFileSync(path.join(WORK, s), 'utf8')]),
];
// the house's piece drawings (House/HouseDraw.cs): the page's scripts from house4.js on, in its order (the drawings,
// movies, club fx, vacuum bot, TV sound, beach), then tools/unity/house/draw-host.js with the page's own methods and constants it needs copied in
const PAGE = fs.readFileSync(fs.readdirSync(path.join(REPO, 'webgame/.cache')).map((d) => path.join(REPO, 'webgame/.cache', d, 'squish-squad/Squad House v6.dc.html')).find((f) => fs.existsSync(f)), 'utf8');
const order = [...PAGE.matchAll(/<script src="([^"?]*)/g)].map((m) => m[1].replace(/^\.\//, ''));
for (const f of order.slice(order.indexOf('house4.js'))) scripts.push([f, fs.readFileSync(path.join(WORK, f), 'utf8')]);
const method = (n) => { const m = new RegExp('\\n  ' + n + '\\([^)]*\\) \\{').exec(PAGE); const nx = /\n  [a-zA-Z_]\w*(?:\([^)]*\) \{| = )/g; nx.lastIndex = m.index + m[0].length; const e = nx.exec(PAGE); return PAGE.slice(m.index + 1, e.index).trim().replace(/(\n\s*\/\/[^\n]*)+$/, ''); };
// a top-level const / function of the page, whole (to the line ending its statement: ';' at the end of a line)
const constant = (n) => { const m = new RegExp('\\n(const|function) ' + n + '\\b').exec(PAGE); const e = /;[ \t]*(\/\/[^\n]*)?\n/g; e.lastIndex = m.index + 1; const x = e.exec(PAGE); return PAGE.slice(m.index + 1, x.index + 1).trim(); };
let host = fs.readFileSync(path.join(REPO, 'tools/unity/house/draw-host.js'), 'utf8');
host = host.replace('/* PAGE */', ['RCSV', 'RMAP', 'SLOTCAT', 'roleOf', 'CEILS', 'catOf', 'BIGR', 'edgeR'].map(constant).join('\n  '));
host = host.replace('/* PAGE-METHODS */', ['rnReg', 'rnDraw', 'rnOpt', 'rnLayer', 'tightBB'].map((n) => method(n) + ',').join('\n    '));
scripts.push(['house-draw.js', host]);
const files = {};
for (const f of fs.readdirSync(path.join(WORK, 'uploads')).filter((f) => f.endsWith('.csv'))) files['uploads/' + f] = fs.readFileSync(path.join(WORK, 'uploads', f), 'utf8');
const tripo = path.join(WORK, 'export/tripo');
for (const k of fs.readdirSync(tripo)) {
  const f = path.join(tripo, k, k + '-front.svg');
  if (fs.existsSync(f)) files[`export/tripo/${k}/${k}-front.svg`] = fs.readFileSync(f, 'utf8');
}
fs.mkdirSync(OUT, { recursive: true });
const write = (name, data) => {
  const gz = zlib.gzipSync(JSON.stringify(data), { level: 9 });
  fs.writeFileSync(path.join(OUT, name), gz);
  return (gz.length / 1024).toFixed(0) + ' KB';
};
console.log(`scripts.bytes: ${scripts.length} scripts, ${write('scripts.bytes', scripts)}; files.bytes: ${Object.keys(files).length} files, ${write('files.bytes', files)}`);
