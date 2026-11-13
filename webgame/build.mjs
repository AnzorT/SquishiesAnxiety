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
import fs from 'node:fs';
import path from 'node:path';
import { extractPrototype, WEBGAME, REPO, PROTOTYPE_ZIP } from './lib/prototype.mjs';
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
  'music/**',
  'assets/**',
  'uploads/*.csv',
];
// Left out on purpose (nothing the shipped pages run loads them; webgame/test/smoke.mjs would catch it if that changed):
// export/creature-sounds (28 MB of WAVs: the pages synthesize their sounds with WebAudio), export/creatures (the old
// 20-creature art), export/tripo/*/*.jpg (reference photos for rig work), the card-making tools and letter sheets.
const EXCLUDE = [/^export\/cards4\/(abc|tools)\//];

const REACT_SWAP = [
  ['"https://unpkg.com/react@18.3.1/umd/react.production.min.js"', '"vendor/react.production.min.js"'],
  ['"https://unpkg.com/react-dom@18.3.1/umd/react-dom.production.min.js"', '"vendor/react-dom.production.min.js"'],
  // same bytes, but file:// scripts can't pass a crossorigin integrity check, so drop the SRI hashes
  ['var REACT_SRI = "sha384-DGyLxAyjq0f9SPpVevD6IgztCFlnMF6oW/XQGmfe+IsZ8TqEiDrcHkMLKI6fiB/Z";', 'var REACT_SRI = "";'],
  ['var REACT_DOM_SRI = "sha384-gTGxhz21lVGYNMcdJOyq01Edg0jhn/c22nsx0kyqP0TxaV5WVdsSH1fSDUf5YJj1";', 'var REACT_DOM_SRI = "";'],
];

// loaded by every page, in this order, before support.js (roster.js is written by the build from webgame/data)
const APP_SCRIPTS = ['boot.js', 'roster.js', 'bridge.js', 'config.js'];

const clean = s => s.split('?')[0].split('#')[0].replace(/^\.\//, '');

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
  const proto = await extractPrototype();
  const fonts = Object.entries(JSON.parse(fs.readFileSync(path.join(VENDOR, 'fonts.json'), 'utf8')));
  const src = rel => fs.existsSync(path.join(APP_DIR, rel)) ? path.join(APP_DIR, rel) : path.join(proto, rel);

  // 1. pages + scripts, following <helmet> scripts and <dc-import>s
  const files = new Set(['support.js']), queue = [...ENTRY_PAGES];
  while (queue.length) {
    const rel = queue.shift();
    if (files.has(rel)) continue;
    const f = src(rel);
    if (!fs.existsSync(f)) throw new Error('missing ' + rel + ' (needed by a shipped page)');
    files.add(rel);
    if (rel.endsWith('.html')) for (const d of pageDeps(fs.readFileSync(f, 'utf8'))) if (!files.has(d)) queue.push(d);
  }
  // 2. assets the engines load by path
  for (const g of ASSETS) for (const rel of glob(proto, g)) if (!EXCLUDE.some(re => re.test(rel))) files.add(rel);

  // 3. write
  fs.rmSync(out, { recursive: true, force: true });
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
        t = t.replace(tag, m => APP_SCRIPTS.map(f => `<script src="app/${f}"></script>\n`).join('') + m);
      }
      fs.writeFileSync(to, t);
    } else fs.copyFileSync(from, to);
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
