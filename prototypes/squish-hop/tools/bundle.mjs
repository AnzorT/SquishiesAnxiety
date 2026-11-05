// Makes one self-contained copy of the page: engine.js and levels.js
// inlined, and every ../../assets/… file (creature heads, cushions, sounds)
// turned into a data: URI, so it opens anywhere with nothing beside it.
// --artifact also drops the <html>/<head>/<body> wrapper, for a claude.ai
// Artifact (which adds its own).
// Run: node prototypes/squish-hop/tools/bundle.mjs <out.html> [--artifact]
import { readFileSync, writeFileSync } from 'node:fs';
import { dirname, extname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..');
const out = process.argv[2];
if (!out) {
  console.error('usage: node bundle.mjs <out.html> [--artifact]');
  process.exit(1);
}
const MIME = { '.webp': 'image/webp', '.png': 'image/png', '.wav': 'audio/wav', '.ogg': 'audio/ogg', '.mp3': 'audio/mpeg' };

let html = readFileSync(resolve(root, 'index.html'), 'utf8');
for (const f of ['engine.js', 'levels.js']) {
  const code = readFileSync(resolve(root, f), 'utf8');
  html = html.replace(`<script src="${f}"></script>`, () => `<script>\n${code}</script>`);
}
let n = 0;
let bytes = 0;
html = html.replace(/\.\.\/\.\.\/assets\/[\w\-./]+\.(webp|png|wav|ogg|mp3)/g, (p) => {
  const data = readFileSync(resolve(root, p));
  n++;
  bytes += data.length;
  return `data:${MIME[extname(p)]};base64,${data.toString('base64')}`;
});
if (process.argv.includes('--artifact')) {
  html = html
    .replace(/<!doctype html>\s*/i, '')
    .replace(/<html[^>]*>\s*/i, '')
    .replace(/<\/html>\s*/i, '')
    .replace(/<head>\s*/i, '')
    .replace(/<\/head>\s*/i, '')
    .replace(/<body>\s*/i, '')
    .replace(/<\/body>\s*/i, '')
    .replace(/<meta charset="utf-8">\s*/i, '')
    .replace(/<meta name="viewport"[^>]*>\s*/i, '');
}
writeFileSync(out, html);
console.log(`wrote ${out}: ${n} assets (${(bytes / 1024).toFixed(0)} KB) inlined, ${(html.length / 1024 / 1024).toFixed(2)} MB`);
