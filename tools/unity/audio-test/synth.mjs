// node tools/unity/audio-test/synth.mjs — renders the menu's synth sounds (yard-games.js SFX, run as written) in
// Chromium's OfflineAudioContext at 48 kHz, for Program.cs to compare with MenuSynth's renderings:
// out/synth-chrome.json (sound -> base64 float32 samples). The noise sounds are random in the page; Chromium's are
// rendered with Math.random seeded the same each time, so only their level and length are compared.
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const { extractPrototype } = await import(pathToFileURL(path.join(REPO, 'webgame/lib/prototype.mjs')).href);
const yg = fs.readFileSync(path.join(await extractPrototype(), 'yard-games.js'), 'utf8');
// the page's own tone / noise / SFX, out of its closure
const from = yg.indexOf('function tone(');
const to = yg.indexOf('YG.SFX = SFX;');
if (from < 0 || to < 0) throw new Error('yard-games.js: tone / SFX not found');
const code = yg.slice(from, to);

const browser = await chromium.launch();
const page = await browser.newPage();
await page.goto('about:blank');
const out = await page.evaluate(async (code) => {
  const res = {};
  const names = new Function('return Object.keys(' + code.slice(code.indexOf('const SFX = ') + 12, code.lastIndexOf('};') + 1) + ')')();
  for (const name of names) {
    let seed = 1;
    Math.random = () => ((seed = (seed * 16807) % 2147483647) - 1) / 2147483646;
    const ctx = new OfflineAudioContext(1, 48000, 48000);
    const ac = () => ctx;
    new Function('ac', code + '\nSFX[' + JSON.stringify(name) + ']();')(ac);
    const buf = await ctx.startRendering();
    const d = buf.getChannelData(0);
    let n = d.length;
    while (n > 0 && Math.abs(d[n - 1]) < 1e-6) n--;
    const bytes = new Uint8Array(d.slice(0, n).buffer);
    let s = '';
    for (let i = 0; i < bytes.length; i++) s += String.fromCharCode(bytes[i]);
    res[name] = btoa(s);
  }
  return res;
}, code);
await browser.close();
fs.writeFileSync(path.join(HERE, 'out/synth-chrome.json'), JSON.stringify(out));
console.log('rendered ' + Object.keys(out).length + ' sounds in Chromium');
