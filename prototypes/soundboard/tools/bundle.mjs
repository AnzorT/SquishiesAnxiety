// Makes one self-contained copy of the page: its scripts (art/items.js,
// voices.js, art/dj-crew.js, art/club-fx.js) inlined, and every art/… and
// ../../assets/… file (the room, the club items, the creatures, the sounds)
// turned into a data: URI, so it opens anywhere with nothing beside it.
// dj-crew.js fetches the DJ's picture itself, so the bundle answers that
// fetch from an inlined copy. --artifact also drops the <html>/<head>/<body>
// wrapper, for a claude.ai Artifact (which adds its own).
// Run: node prototypes/soundboard/tools/bundle.mjs <out.html> [--artifact]
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
const MIME = { '.webp': 'image/webp', '.png': 'image/png', '.svg': 'image/svg+xml', '.wav': 'audio/wav', '.ogg': 'audio/ogg', '.mp3': 'audio/mpeg' };
// the creature pictures carry a provenance manifest the page doesn't need
const svgText = (p) => readFileSync(resolve(root, p), 'utf8').replace(/<metadata>[\s\S]*?<\/metadata>/, '');

let html = readFileSync(resolve(root, 'index.html'), 'utf8');
let n = 0;
let bytes = 0;
html = html.replace(/(?:\.\.\/\.\.\/assets|art)\/[\w\-./]+\.(webp|png|svg|wav|ogg|mp3)/g, (p) => {
  const data = extname(p) === '.svg' ? Buffer.from(svgText(p)) : readFileSync(resolve(root, p));
  n++;
  bytes += data.length;
  return `data:${MIME[extname(p)]};base64,${data.toString('base64')}`;
});
for (const f of ['art/items.js', 'voices.js', 'art/dj-crew.js', 'art/club-fx.js']) {
  const code = readFileSync(resolve(root, f), 'utf8');
  html = html.replace(`<script src="${f}"></script>`, () => `<script>\n${code}</script>`);
}
// the DJ's picture, for dj-crew.js's fetch
const dj = (html.match(/const DJ_KEY = '(\w+)'/) || [])[1];
const djPath = `art/export/tripo/${dj}/${dj}-front.svg`;
const shim = `<script>
(function () {
  var T = ${JSON.stringify({ [djPath]: svgText(djPath) })};
  var f = window.fetch;
  window.fetch = function (u) {
    if (typeof u === 'string' && Object.prototype.hasOwnProperty.call(T, u)) return Promise.resolve(new Response(T[u], { headers: { 'content-type': 'image/svg+xml' } }));
    return f.apply(this, arguments);
  };
})();
</script>`;
html = html.replace('<script>window.DJ_BASE', () => `${shim}\n<script>window.DJ_BASE`);
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
console.log(`wrote ${out}: ${n} files (${(bytes / 1024).toFixed(0)} KB) inlined, ${(html.length / 1024 / 1024).toFixed(2)} MB`);
