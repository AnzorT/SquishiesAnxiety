// One-time: copy every outside file the design prototype loads from the internet into webgame/vendor/,
// so the game runs inside the app with no network and looks exactly like the prototype:
//   - React 18.3.1 + ReactDOM 18.3.1 (the exact UMD builds support.js asks unpkg.com for)
//   - every Google Fonts stylesheet the prototype links, with the exact .woff2 files Google serves to Chrome
//
//   node webgame/vendor.mjs            (needs internet; the result is committed, so the build never does)
//
// Behind a proxy, Node's fetch needs NODE_USE_ENV_PROXY=1.
import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
import { execSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { extractPrototype } from './lib/prototype.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const VENDOR = path.join(HERE, 'vendor');
// Android WebView is Chrome: ask Google for what it serves Chrome (woff2 + unicode-range subsets)
const CHROME_UA = 'Mozilla/5.0 (Linux; Android 14; Pixel 9) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/130.0.0.0 Mobile Safari/537.36';

const NPM_FILES = [
  ['react@18.3.1', 'umd/react.production.min.js', 'react.production.min.js'],
  ['react-dom@18.3.1', 'umd/react-dom.production.min.js', 'react-dom.production.min.js'],
];

export const fontCssName = url => 'g-' + crypto.createHash('sha1').update(url).digest('hex').slice(0, 12) + '.css';

async function vendorNpm() {
  const tmp = fs.mkdtempSync(path.join(HERE, '.cache-npm-'));
  try {
    for (const [spec, inner, out] of NPM_FILES) {
      const tgz = execSync(`npm pack ${spec} --silent`, { cwd: tmp }).toString().trim().split('\n').pop();
      const dir = path.join(tmp, spec.replace(/[@/]/g, '_'));
      fs.mkdirSync(dir);
      execSync(`tar -xzf "${path.join(tmp, tgz)}" -C "${dir}"`);
      fs.copyFileSync(path.join(dir, 'package', inner), path.join(VENDOR, out));
      console.log('vendored', spec, '->', out);
    }
  } finally {
    fs.rmSync(tmp, { recursive: true, force: true });
  }
}

// every Google Fonts css2 URL written anywhere in the prototype (HTML attributes use &amp;)
function fontUrlsIn(dir) {
  const urls = new Set();
  for (const f of fs.readdirSync(dir)) {
    if (!/\.(html|js|jsx)$/.test(f)) continue;
    const src = fs.readFileSync(path.join(dir, f), 'utf8');
    for (const m of src.matchAll(/https:\/\/fonts\.googleapis\.com\/css2\?[^"'`\s)]+/g)) urls.add(m[0]);
  }
  return [...urls].sort();
}

async function get(url, binary) {
  const r = await fetch(url, { headers: { 'user-agent': CHROME_UA } });
  if (!r.ok) throw new Error(url + ' -> HTTP ' + r.status);
  return binary ? Buffer.from(await r.arrayBuffer()) : r.text();
}

async function vendorFonts(protoDir) {
  const cssDir = path.join(VENDOR, 'css'), fontDir = path.join(VENDOR, 'fonts');
  fs.mkdirSync(cssDir, { recursive: true });
  fs.mkdirSync(fontDir, { recursive: true });
  const map = {};
  for (const written of fontUrlsIn(protoDir)) {
    const url = written.replace(/&amp;/g, '&');
    let css = await get(url);
    const files = [...css.matchAll(/url\((https:\/\/fonts\.gstatic\.com\/[^)]+)\)/g)].map(m => m[1]);
    for (const f of new Set(files)) {
      const name = f.replace('https://fonts.gstatic.com/s/', '').replace(/\//g, '_');
      const out = path.join(fontDir, name);
      if (!fs.existsSync(out)) fs.writeFileSync(out, await get(f, true));
      css = css.split(f).join('../fonts/' + name);
    }
    const name = fontCssName(url);
    fs.writeFileSync(path.join(cssDir, name), css);
    map[written] = 'vendor/css/' + name;
    console.log('fonts', name, files.length, 'files <-', url.slice(40, 120));
  }
  fs.writeFileSync(path.join(VENDOR, 'fonts.json'), JSON.stringify(map, null, 2) + '\n');
}

fs.mkdirSync(VENDOR, { recursive: true });
const proto = await extractPrototype();
await vendorNpm();
await vendorFonts(proto);
console.log('done ->', VENDOR);
