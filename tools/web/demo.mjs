// The web demo (src/web/Demo.js): Squish Stack and Squish Hop on their own, playable from a static page with no
// account, e.g. a private claude.ai link. Builds the web version with EXPO_PUBLIC_DEMO=1 (metro.config.js then swaps in
// the demo's root, saves and server moves) and makes it work from any folder:
//   - the app's page becomes app.html, its script and every asset address relative (the build writes /_expo/… and
//     /assets/…, which only work at a site's root);
//   - of the creatures' heads and cut-outs only the demo's two dozen are kept (src/web/demo/cast.js), so the page stays
//     under 511 files;
//   - index.html is the phone frame around it (src/web/demo/frame.html), and page.html the same without the document
//     skeleton (what the claude.ai Artifact tool publishes as the page; it adds the skeleton itself).
//
//   node tools/web/demo.mjs [out folder, default dist-demo]
//   then serve the folder (python3 -m http.server -d dist-demo) and open index.html
import fs from 'node:fs';
import os from 'node:os';
import path from 'node:path';
import { execSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { DEMO_KEYS } from '../../src/web/demo/cast.js';

const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const OUT = path.resolve(process.argv[2] || path.join(REPO, 'dist-demo'));
const BUILD = fs.mkdtempSync(path.join(os.tmpdir(), 'demo-build-'));

// (through the shell, quoted, so npx runs on Windows too and paths with spaces survive)
const q = (a) => (/[\s"]/.test(a) ? `"${a.replace(/"/g, '\\"')}"` : a);
execSync(['npx', 'expo', 'export', '-p', 'web', '--clear', '--output-dir', BUILD].map(q).join(' '), {
  cwd: REPO,
  stdio: ['ignore', 'ignore', 'inherit'],
  env: { ...process.env, EXPO_PUBLIC_DEMO: '1' },
});

fs.rmSync(OUT, { recursive: true, force: true });
fs.mkdirSync(OUT, { recursive: true });
// the creatures' pictures: only the demo's (heads are <key>-<face>.<hash>.webp, cut-outs <key>.<hash>.webp)
const keep = new Set(DEMO_KEYS);
const keyOf = (f) => path.basename(f).split(/[.-]/)[0];
const wanted = (rel) => {
  if (/^assets\/assets\/squishdoku\/heads\//.test(rel) || /^assets\/assets\/stack\/[^/]+\.webp$/.test(rel)) return keep.has(keyOf(rel));
  return rel !== 'metadata.json';
};
let files = 0;
(function copy(dir) {
  for (const name of fs.readdirSync(path.join(BUILD, dir))) {
    const rel = dir ? `${dir}/${name}` : name;
    const from = path.join(BUILD, rel);
    if (fs.statSync(from).isDirectory()) {
      copy(rel);
      continue;
    }
    if (rel === 'index.html' || !wanted(rel)) continue;
    // the script goes to js/ (a claude.ai artifact keeps names starting with _ for itself)
    const to = rel.startsWith('_expo/') ? `js/${path.basename(rel)}` : rel;
    let data = fs.readFileSync(from);
    // every asset's address relative to the page: expo-asset's AssetSourceResolver resolves the path against a
    // placeholder origin and strips the origin, leaving /assets/…; strip the slash too. (And the registry's own paths,
    // which react-native-web's Image reads directly.)
    if (rel.endsWith('.js')) {
      let js = data.toString('utf8').replaceAll('httpServerLocation:"/assets', 'httpServerLocation:"./assets');
      const strip = /\.toString\(\)\.replace\((\w+)\.origin,''\)/g;
      if (!strip.test(js)) throw new Error("expo-asset's origin strip not found: the demo's assets would load from the site root");
      js = js.replace(strip, ".toString().replace($1.origin+'/','')");
      data = Buffer.from(js);
    }
    fs.mkdirSync(path.dirname(path.join(OUT, to)), { recursive: true });
    fs.writeFileSync(path.join(OUT, to), data);
    files++;
  }
})('');
const html = fs
  .readFileSync(path.join(BUILD, 'index.html'), 'utf8')
  .replace(/"\/_expo\/static\/js\/web\//g, '"js/')
  .replace(/(src|href)="\/(?!\/)/g, '$1="');
fs.writeFileSync(path.join(OUT, 'app.html'), html.replace('<title>PlushCrush</title>', '<title>Squish Squad</title>'));
const frame = fs.readFileSync(path.join(REPO, 'src/web/demo/frame.html'), 'utf8');
fs.writeFileSync(path.join(OUT, 'page.html'), frame);
fs.writeFileSync(path.join(OUT, 'index.html'), `<!doctype html>\n<html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1, viewport-fit=cover">\n</head><body>\n${frame}\n</body></html>\n`);
fs.rmSync(BUILD, { recursive: true, force: true });
console.log(`${OUT}: app.html, index.html, page.html and ${files} files`);
