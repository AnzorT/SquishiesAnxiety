// The yard games' sounds (HOUSE_PORT_PLAN.md stage 11): yard-games.js's SFX (little synth pops: tone / noise, no
// files) rendered offline with its own code into an OfflineAudioContext each -> unity/Assets/Resources/Yard/sfx/<name>.wav
//
//   node tools/unity/house/export-yard.mjs
import fs from 'node:fs'; import path from 'node:path';
import { launch, REPO } from './harness.mjs';
const dir = fs.readdirSync(path.join(REPO, 'webgame/.cache')).find((d) => d.startsWith('Squish-Squad-Prototype'));
const L = fs.readFileSync(path.join(REPO, 'webgame/.cache', dir, 'squish-squad/yard-games.js'), 'utf8').split('\n');
const a = L.findIndex((l) => l.startsWith('  function tone(')), b = L.findIndex((l) => l.includes('YG.SFX = SFX;'));
const SRC = L.slice(a, b).join('\n');
const OUT = path.join(REPO, 'unity/Assets/Resources/Yard/sfx'); fs.mkdirSync(OUT, { recursive: true });
const browser = await launch(); const page = await (await browser.newContext()).newPage();
await page.setContent('<html><body></body></html>');
const names = await page.evaluate((src) => { let AC = null; const ac = () => AC; window.__mk = (secs) => { AC = new OfflineAudioContext(1, Math.ceil(secs * 44100), 44100); return AC; };
  window.__S = new Function('ac', src + '\nreturn SFX;')(ac); return Object.keys(window.__S); }, SRC);
for (const n of names) {
  const b64 = await page.evaluate(async (n) => { const c = window.__mk(1.2); window.__S[n](); const buf = await c.startRendering(); const d = buf.getChannelData(0);
    let end = d.length; while (end > 0 && Math.abs(d[end - 1]) < 1e-4) end--; end = Math.min(d.length, end + 441);
    const o = new Int16Array(end); for (let i = 0; i < end; i++) o[i] = Math.max(-32768, Math.min(32767, Math.round(d[i] * 32767)));
    let s = ''; const u = new Uint8Array(o.buffer); for (let i = 0; i < u.length; i++) s += String.fromCharCode(u[i]); return btoa(s); }, n);
  const pcm = Buffer.from(b64, 'base64'), h = Buffer.alloc(44);
  h.write('RIFF', 0); h.writeUInt32LE(36 + pcm.length, 4); h.write('WAVEfmt ', 8); h.writeUInt32LE(16, 16); h.writeUInt16LE(1, 20); h.writeUInt16LE(1, 22); h.writeUInt32LE(44100, 24); h.writeUInt32LE(88200, 28); h.writeUInt16LE(2, 32); h.writeUInt16LE(16, 34); h.write('data', 36); h.writeUInt32LE(pcm.length, 40);
  fs.writeFileSync(path.join(OUT, n + '.wav'), Buffer.concat([h, pcm]));
}
console.log('yard sfx:', names.join(' '));
await browser.close();
