// getBBox on the browser stand-in (dom-shim.js) against Chrome's, bit for bit, on random shapes and paths using
// every command (M L H V C S Q T A Z, absolute and relative), random transforms and nested groups. The creature rigs
// size and place parts from these numbers, so a last-bit difference can change a drawn shape.
//
//   node tools/unity/rig/bbox-fuzz.mjs [count=3000] [seed=1]
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const COUNT = +(process.argv[2] || 3000);
let seed = +(process.argv[3] || 1);
const rnd = () => { seed = (seed * 16807) % 2147483647; return seed / 2147483647; };
const num = (a, b, dp) => +(a + rnd() * (b - a)).toFixed(dp == null ? (rnd() < 0.5 ? 1 : 2) : dp);

function randomPath() {
  let d = 'M' + num(0, 100) + ' ' + num(0, 100);
  const n = 1 + Math.floor(rnd() * 8);
  for (let i = 0; i < n; i++) {
    const c = 'LHVCSQTAZ'[Math.floor(rnd() * 9)], rel = rnd() < 0.4, k = rel ? c.toLowerCase() : c, P = () => rel ? num(-30, 30) : num(0, 100);
    if (c === 'L' || c === 'T') d += ` ${k}${P()} ${P()}`;
    else if (c === 'H' || c === 'V') d += ` ${k}${P()}`;
    else if (c === 'C') d += ` ${k}${P()} ${P()} ${P()} ${P()} ${P()} ${P()}`;
    else if (c === 'S' || c === 'Q') d += ` ${k}${P()} ${P()} ${P()} ${P()}`;
    else if (c === 'A') d += ` ${k}${num(0.2, 40)} ${num(0.2, 40)} ${rnd() < 0.6 ? 0 : num(-90, 90, 0)} ${rnd() < 0.5 ? 1 : 0} ${rnd() < 0.5 ? 1 : 0} ${P()} ${P()}`;
    else { d += ' Z'; if (rnd() < 0.5) d += ` M${num(0, 100)} ${num(0, 100)}`; }
  }
  return d;
}
function randomTransform() {
  const r = rnd();
  if (r < 0.5) return '';
  if (r < 0.65) return `translate(${num(-20, 20)} ${num(-20, 20)})`;
  if (r < 0.8) return `rotate(${num(-180, 180)}${rnd() < 0.5 ? ` ${num(0, 100)} ${num(0, 100)}` : ''})`;
  if (r < 0.9) return `scale(${num(0.2, 2)}${rnd() < 0.5 ? ' ' + num(0.2, 2) : ''})`;
  return `matrix(${num(-1, 1)} ${num(-1, 1)} ${num(-1, 1)} ${num(-1, 1)} ${num(-20, 20)} ${num(-20, 20)})`;
}
function randomShape() {
  const r = rnd(), t = randomTransform(), tf = t ? ` transform="${t}"` : '';
  if (r < 0.55) return `<path d="${randomPath()}"${tf}/>`;
  if (r < 0.7) return `<ellipse cx="${num(0, 100)}" cy="${num(0, 100)}" rx="${num(0.1, 30)}" ry="${num(0.1, 30)}"${tf}/>`;
  if (r < 0.8) return `<circle cx="${num(0, 100)}" cy="${num(0, 100)}" r="${num(0.1, 30)}"${tf}/>`;
  if (r < 0.9) return `<rect x="${num(0, 100)}" y="${num(0, 100)}" width="${num(0.1, 50)}" height="${num(0.1, 50)}"${tf}/>`;
  return `<g${tf}>${randomShape()}${randomShape()}</g>`;
}
const cases = Array.from({ length: COUNT }, () => rnd() < 0.6 ? randomShape() : `<g>${randomShape()}${randomShape()}${randomShape()}</g>`);

const measure = `(markup) => { const NS = 'http://www.w3.org/2000/svg'; const s = document.createElementNS(NS, 'svg'); document.body.appendChild(s);
  return markup.map(m => { s.innerHTML = m; const e = s.firstChild; const b = e.getBBox(); return [b.x, b.y, b.width, b.height]; }); }`;

const ctx = vm.createContext({});
vm.runInContext(fs.readFileSync(path.join(HERE, 'dom-shim.js'), 'utf8'), ctx);
vm.runInContext('RigDomShim.install(globalThis, {})', ctx);
ctx.__cases = cases;
const shim = vm.runInContext(`(${measure})(__cases)`, ctx);
const browser = await chromium.launch();
const page = await browser.newPage();
const chrome = await page.evaluate(`(${measure})(${JSON.stringify(cases)})`);
await browser.close();

let bad = 0, shown = 0;
const kinds = {};
for (let i = 0; i < cases.length; i++) {
  const same = chrome[i].every((v, k) => Object.is(v, shim[i][k]));
  if (!same) {
    bad++;
    const kind = (cases[i].match(/[a-zA-Z](?=[\d\s-])/g) || []).join('');
    kinds[kind] = (kinds[kind] || 0) + 1;
    if (shown++ < 6) console.log(`#${i} ${cases[i].slice(0, 220)}\n   chrome ${chrome[i].join(', ')}\n   shim   ${shim[i].join(', ')}`);
  }
}
console.log(`${bad ? 'DIFFERENT' : 'SAME'}: ${COUNT - bad}/${COUNT} boxes identical to the bit`);
process.exit(bad ? 1 : 0);
