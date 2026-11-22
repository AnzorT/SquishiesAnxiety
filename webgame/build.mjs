// Builds the in-app game: the design prototype's own pages and engines, unchanged, plus what the app needs to run them
// offline inside a WebView. The pixels come from the prototype's code itself, so the app looks exactly like the design.
//
//   node webgame/build.mjs                 -> android/app/src/main/assets/webgame/  (what the Android app loads)
//   node webgame/build.mjs --out <dir>     -> somewhere else (tests)
//
// What it does to the prototype (nothing that changes a pixel):
//   - copies only what the shipped pages use (the pages, the scripts in their <helmet>, the art and sounds they load)
//   - React/ReactDOM come from webgame/vendor instead of unpkg.com (same files, byte for byte)
//   - Google Fonts stylesheets come from webgame/vendor/css (the same .woff2 files Google serves to Chrome)
//   - every page loads app/boot.js, app/roster.js, app/bridge.js and app/config.js before support.js (file:// fetch,
//     scripts in the listed order, the link to the app, the Firebase config)
//   - webgame/patches.mjs: one call into app/config.js at each spot where the engines pick an animation or price an item
//   - adds the app layer: app/*.js (bridge to the React Native app, remote config) and App.dc.html (the app's root page)
//   - the yard games' zip (YARD_ZIP, lib/prototype.mjs) is laid over the prototype: its newer files win
import fs from 'node:fs';
import path from 'node:path';
import { extractPrototype, extractYard, WEBGAME, REPO, PROTOTYPE_ZIP } from './lib/prototype.mjs';
import { applyPatches, PATCHES } from './patches.mjs';

const args = process.argv.slice(2);
const OUT = path.resolve(args.includes('--out') ? args[args.indexOf('--out') + 1] : path.join(REPO, 'android/app/src/main/assets/webgame'));
const APP_DIR = path.join(WEBGAME, 'app');
const VENDOR = path.join(WEBGAME, 'vendor');

// The pages the app opens. App.dc.html (ours) embeds the prototype's pages with <dc-import>; the closure below follows those.
const ENTRY_PAGES = ['App.dc.html'];
// Art, sounds and data the engines load by building paths at runtime (not visible as <script>/<link> tags).
// Checked by webgame/test/smoke.mjs, which fails on any file the pages ask for that isn't shipped.
const ASSETS = [
  'export/tripo/*/*.svg',
  'export/tripo/*/*.png',
  'export/thumbs/**',
  'export/cards4/**',
  'export/creatures-v2/**',
  'assets/**',
  'uploads/*.csv',
];
// Left out on purpose (nothing the shipped pages run loads them; webgame/test/smoke.mjs would catch it if that changed):
// export/creature-sounds (28 MB of WAVs: the pages synthesize their sounds with WebAudio), export/creatures (the old
// 20-creature art), export/tripo/*/*.jpg (reference photos for rig work), the card-making tools and letter sheets,
// music/ (the Dance Room's song: the user kept only Velvet Map Study, 2026-11-16; patches.mjs turns the song off).
const EXCLUDE = [/^export\/cards4\/(abc|tools)\//];

const REACT_SWAP = [
  ['"https://unpkg.com/react@18.3.1/umd/react.production.min.js"', '"vendor/react.production.min.js"'],
  ['"https://unpkg.com/react-dom@18.3.1/umd/react-dom.production.min.js"', '"vendor/react-dom.production.min.js"'],
  // same bytes, but file:// scripts can't pass a crossorigin integrity check, so drop the SRI hashes
  ['var REACT_SRI = "sha384-DGyLxAyjq0f9SPpVevD6IgztCFlnMF6oW/XQGmfe+IsZ8TqEiDrcHkMLKI6fiB/Z";', 'var REACT_SRI = "";'],
  ['var REACT_DOM_SRI = "sha384-gTGxhz21lVGYNMcdJOyq01Edg0jhn/c22nsx0kyqP0TxaV5WVdsSH1fSDUf5YJj1";', 'var REACT_DOM_SRI = "";'],
];

// loaded by every page, in this order, before support.js (roster.js is written by the build from webgame/data)
// (look-lines.js + rig-look.js: the border look's outline on every live rig, 2026-11-16; after bridge.js, before the
// page's own scripts bring RiveRig)
// (intro.js: the game intro, the designer's squad-intro.js, 2026-11-16; app/menu.js starts it)
const APP_SCRIPTS = ['perf.js', 'boot.js', 'roster.js', 'bridge.js', 'look-lines.js', 'rig-look.js', 'config.js', 'games.js', 'intro.js', 'menu.js'];

const clean = s => s.split('?')[0].split('#')[0].replace(/^\.\//, '');

// PERF 2026-11-20: the creatures' art (export/tripo/<key>/*.svg) wraps each body in a fine noise grain, an feTurbulence
// filter (22% multiply). A creature is drawn again every frame it moves, and the WebView computed that noise again each
// time, for every creature: the GPU thread 89% busy in a room with four creatures on the Galaxy A16 (63% without; 54-58
// fps -> 60). At a creature's size on a phone the grain can't be seen (compared side by side at 2.8x). The group keeps
// its contents; only the filter goes. (export: also run on android/app/src/main/assets/rig, the games' rig pages' copy)
// It becomes filter="none", NOT a bare <g> (2026-11-21, the user: every creature but Mittens had lost its face): the rigs
// find the body by that group's filter attribute (rive-generic.js, plush-motion.js, plush-rig25.js: g[filter] and
// closest('g[filter]')); without it nothing was "body", no head was found, and the eyes and mouth had nowhere to go.
// "none" keeps the attribute for them and draws no filter at all (rig-look.js skips it when it adds its outline).
export const noGrain = s => s.replace(/<g filter="url\(#ft\)">/g, '<g filter="none">');

function pageDeps(text) {
  const deps = new Set();
  for (const m of text.matchAll(/<script\b[^>]*\bsrc="([^"]+)"/g)) if (!/^(https?:)?\/\//.test(m[1])) deps.add(clean(m[1]));
  for (const m of text.matchAll(/<link\b[^>]*\bhref="([^"]+)"/g)) if (!/^(https?:)?\/\//.test(m[1]) && /\.css(\?|$)/.test(m[1])) deps.add(clean(m[1]));
  for (const m of text.matchAll(/<dc-import\b[^>]*\bname="([^"]+)"/g)) deps.add(m[1] + '.dc.html');
  return deps;
}

function glob(root, pattern) {
  const parts = pattern.split('/');
  const out = [];
  const walk = (dir, i) => {
    if (i === parts.length) return;
    const p = parts[i];
    if (!fs.existsSync(dir)) return;
    if (p === '**') {
      for (const e of fs.readdirSync(dir, { withFileTypes: true })) {
        const f = path.join(dir, e.name);
        if (e.isDirectory()) walk(f, i); else if (e.name !== '.DS_Store') out.push(f);
      }
      return;
    }
    const re = new RegExp('^' + p.replace(/[.+^${}()|[\]\\]/g, '\\$&').replace(/\*/g, '[^/]*') + '$');
    for (const e of fs.readdirSync(dir, { withFileTypes: true })) {
      if (!re.test(e.name)) continue;
      const f = path.join(dir, e.name);
      if (i === parts.length - 1) { if (e.isFile()) out.push(f); } else if (e.isDirectory()) walk(f, i + 1);
    }
  };
  walk(root, 0);
  return out.map(f => path.relative(root, f).split(path.sep).join('/'));
}

function swapAll(text, pairs, file, required) {
  for (const [a, b] of pairs) {
    if (!text.includes(a)) { if (required) throw new Error(file + ': expected text not found (the prototype changed?): ' + a.slice(0, 80)); continue; }
    text = text.split(a).join(b);
  }
  return text;
}

export async function build(out = OUT) {
  const proto = await extractPrototype(), yard = await extractYard();
  const fonts = Object.entries(JSON.parse(fs.readFileSync(path.join(VENDOR, 'fonts.json'), 'utf8')));
  // where a file comes from: the app layer, else the yard games' zip (newer than the prototype), else the prototype
  const src = rel => fs.existsSync(path.join(APP_DIR, rel)) ? path.join(APP_DIR, rel) : yard && fs.existsSync(path.join(yard, rel)) ? path.join(yard, rel) : path.join(proto, rel);

  // 1. pages + scripts, following <helmet> scripts and <dc-import>s
  const files = new Set(['support.js']), queue = [...ENTRY_PAGES];
  while (queue.length) {
    const rel = queue.shift();
    if (files.has(rel)) continue;
    const f = src(rel);
    if (!fs.existsSync(f)) throw new Error('missing ' + rel + ' (needed by a shipped page)');
    files.add(rel);
    // (the patched page: a patch can add a script, e.g. the yard games' yg-intros.js)
    if (rel.endsWith('.html')) for (const d of pageDeps(applyPatches(rel, fs.readFileSync(f, 'utf8')))) if (!files.has(d)) queue.push(d);
  }
  // 2. assets the engines load by path
  for (const g of ASSETS) for (const root of yard ? [proto, yard] : [proto]) for (const rel of glob(root, g)) if (!EXCLUDE.some(re => re.test(rel))) files.add(rel);

  // 3. write
  // (Windows: a folder another program has open can't be removed, only emptied: empty it then)
  try { fs.rmSync(out, { recursive: true, force: true }); } catch (e) {
    if (e.code !== 'EBUSY' && e.code !== 'EPERM') throw e;
    for (const f of fs.readdirSync(out)) fs.rmSync(path.join(out, f), { recursive: true, force: true });
  }
  fs.mkdirSync(out, { recursive: true });
  let bytes = 0;
  const manifest = [];
  for (const rel of [...files].sort()) {
    const from = src(rel), to = path.join(out, rel);
    fs.mkdirSync(path.dirname(to), { recursive: true });
    if (/\.(html|js)$/.test(rel)) {
      let t = fs.readFileSync(from, 'utf8');
      t = swapAll(t, fonts, rel, false);
      if (rel === 'support.js') t = swapAll(t, REACT_SWAP, rel, true);
      t = applyPatches(rel, t);
      if (rel.endsWith('.html')) {
        const tag = /<script src="(\.\/)?support\.js"><\/script>/;
        if (!tag.test(t)) throw new Error(rel + ': no <script src="support.js"> to put app/boot.js in front of');
        // + the menu's pages (webgame/app/pages/*.js, REDESIGN_V7), after menu.js
        const pages = fs.existsSync(path.join(APP_DIR, 'pages')) ? fs.readdirSync(path.join(APP_DIR, 'pages')).filter(f => f.endsWith('.js')).sort().map(f => 'pages/' + f) : [];
        t = t.replace(tag, m => APP_SCRIPTS.concat(pages).map(f => `<script src="app/${f}"></script>\n`).join('') + m);
      }
      fs.writeFileSync(to, t);
    } else if (/^export\/tripo\/[^/]+\/[^/]+\.svg$/.test(rel)) fs.writeFileSync(to, noGrain(fs.readFileSync(from, 'utf8')));
    else fs.copyFileSync(from, to);
    const n = fs.statSync(to).size;
    bytes += n;
    manifest.push([rel, n]);
  }
  for (const p of PATCHES) if (!files.has(p.file)) throw new Error('patched file not shipped: ' + p.file);
  // 4. the app layer and the vendored libraries
  for (const [dir, dest] of [[APP_DIR, 'app'], [VENDOR, 'vendor']]) {
    for (const rel of glob(dir, '**')) {
      if (rel.endsWith('.dc.html') && dir === APP_DIR) continue; // pages are copied above
      const to = path.join(out, dest, rel);
      fs.mkdirSync(path.dirname(to), { recursive: true });
      fs.copyFileSync(path.join(dir, rel), to);
      bytes += fs.statSync(to).size;
    }
  }
  // the groups' chest pictures (the app's own, assets/squad/gchests) for the Level Pass's chest prizes, which show the
  // chest you'll get (REDESIGN_V9): app/gchests/<group>-<size>-grow.webp
  const GCH = path.join(REPO, 'assets/squad/gchests');
  fs.mkdirSync(path.join(out, 'app/gchests'), { recursive: true });
  for (const f of fs.readdirSync(GCH).filter(f => f.endsWith('-grow.webp'))) {
    fs.copyFileSync(path.join(GCH, f), path.join(out, 'app/gchests', f));
    bytes += fs.statSync(path.join(GCH, f)).size;
  }
  // roster id -> creature key, for app/bridge.js (the app knows creatures by key, the engines by roster id)
  const data = JSON.parse(fs.readFileSync(path.join(WEBGAME, 'data/game-config.json'), 'utf8'));
  if (data.prototype !== path.basename(PROTOTYPE_ZIP)) throw new Error('webgame/data/game-config.json is from ' + data.prototype + ': run node webgame/tools/dump-config.mjs');
  const keys = [];
  for (const c of data.creatures) keys[c.id] = c.key;
  fs.writeFileSync(path.join(out, 'app/roster.js'), '// written by webgame/build.mjs from webgame/data/game-config.json\nwindow.__SQUISH_ROSTER_KEYS = ' + JSON.stringify(keys) + ';\n');
  fs.writeFileSync(path.join(out, 'webgame-manifest.json'), JSON.stringify({ prototype: path.basename(PROTOTYPE_ZIP), built: new Date().toISOString(), files: manifest }, null, 1));
  return { out, count: files.size, bytes };
}

if (import.meta.url === 'file://' + process.argv[1] || process.argv[1]?.endsWith('build.mjs')) {
  const r = await build();
  console.log(`webgame: ${r.count} files, ${(r.bytes / 1048576).toFixed(1)} MB -> ${path.relative(REPO, r.out)}`);
}
