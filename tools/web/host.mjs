// The whole app as a website, for Firebase Hosting (firebase.json `hosting`; src/web/README.md "Putting it online").
//   node tools/web/host.mjs        -> dist/   then: firebase deploy --only hosting
// It builds the menu's pages (webgame/build.mjs) and the web version (expo export), then copies the pages the app
// opens from its APK (android/app/src/main/assets) to dist/android_asset/, each with the line that hands it to the
// app's web WebView (src/web/frameHook.js), as the dev server does.
import fs from 'node:fs';
import path from 'node:path';
import { execSync } from 'node:child_process';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const OUT = path.join(REPO, 'dist');
const ASSETS = path.join(REPO, 'android/app/src/main/assets');
const FRAME_HOOK = require('../../src/web/frameHook.js');
// (through the shell, quoted, so npx runs on Windows too and paths with spaces survive)
const q = (a) => (/[\s"]/.test(a) ? `"${a.replace(/"/g, '\\"')}"` : a);
const run = (cmd, args, env) => execSync([cmd, ...args].map(q).join(' '), { cwd: REPO, stdio: ['ignore', 'ignore', 'inherit'], env: { ...process.env, ...env } });

run('node', ['webgame/build.mjs']);
run('npx', ['expo', 'export', '-p', 'web', '--clear', '--output-dir', OUT]);

let pages = 0;
let files = 0;
(function copy(rel) {
  for (const name of fs.readdirSync(path.join(ASSETS, rel))) {
    const r = rel ? `${rel}/${name}` : name;
    const from = path.join(ASSETS, r);
    const to = path.join(OUT, 'android_asset', r);
    if (fs.statSync(from).isDirectory()) {
      copy(r);
      continue;
    }
    fs.mkdirSync(path.dirname(to), { recursive: true });
    if (name.toLowerCase().endsWith('.html')) {
      const html = fs.readFileSync(from, 'utf8');
      const m = /<head[^>]*>/i.exec(html);
      fs.writeFileSync(to, m ? html.slice(0, m.index + m[0].length) + FRAME_HOOK + html.slice(m.index + m[0].length) : FRAME_HOOK + html);
      pages++;
    } else fs.copyFileSync(from, to);
    files++;
  }
})('');
console.log(`dist/: the web app, and android_asset/ with ${files} files (${pages} pages)`);
