// The Movie Room's movies and the house's music loops (HOUSE_PORT_PLAN.md stage 9) for Unity:
//   movies   each Squad Movie (movies.js + movies-kit.js + movie-t2..t5.js: a pure function of time on a 320 x 180 stage)
//            drawn frame by frame by the page itself and screenshotted, its score (SquadMovies.record: timed tones and
//            noises) played through movie-night.js's own tone / noise / bus code into an OfflineAudioContext, muxed by
//            ffmpeg -> unity/Assets/StreamingAssets/Movies/<id>.mp4 (H.264 + AAC; Unity's VideoPlayer)
//   loops    the speakers' groove (movie-night.js groove: 4 bars, 8 s) and the TV's three channels (tv-sound.js, its own
//            scheduler stepped by hand) rendered offline, one steady-state period each (seamless) ->
//            unity/Assets/Resources/House/audio/{groove,tv1,tv2,tv3}.ogg
// The screen's tier look (grain, fuzz, widescreen bars) isn't in the files: Unity draws it over the picture (not yet).
//
//   node tools/unity/house/export-movies.mjs [--only <id>] [--fps 30] [--loops-only]
import fs from 'node:fs';
import path from 'node:path';
import { spawn } from 'node:child_process';
import { launch, openHouse, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';

const arg = (k, d) => { const i = process.argv.indexOf(k); return i > 0 ? process.argv[i + 1] : d; };
const ONLY = arg('--only', null), FPS = +arg('--fps', 30), LOOPS_ONLY = process.argv.includes('--loops-only');
const SR = 44100;
const MOV = path.join(REPO, 'unity/Assets/StreamingAssets/Movies'), AUD = path.join(REPO, 'unity/Assets/Resources/House/audio');
fs.mkdirSync(MOV, { recursive: true }); fs.mkdirSync(AUD, { recursive: true });
const dir = fs.readdirSync(path.join(REPO, 'webgame/.cache')).find((d) => d.startsWith('Squish-Squad-Prototype'));
const MN = fs.readFileSync(path.join(REPO, 'webgame/.cache', dir, 'squish-squad/movie-night.js'), 'utf8').split('\n');
// movie-night.js's audio: the state (line 'const A = '), then mtof .. groove (to the speaker jam's header), without ac()
const a0 = MN.findIndex((l) => l.includes('const A = { ctx: null')), m0 = MN.findIndex((l) => l.includes('const mtof = ')), j0 = MN.findIndex((l) => l.includes('// ---------- speaker jam'));
const AUDIO = [MN.find((l) => l.includes('const BEAT = ')), MN[a0], ...MN.slice(m0, j0)].join('\n')
  + `\nfunction mkOff(secs, sr) { const c = new OfflineAudioContext(1, Math.ceil(secs * sr), sr), comp = c.createDynamicsCompressor(); comp.threshold.value = -14; comp.ratio.value = 4; comp.connect(c.destination);
    A.ctx = c; A.out = c.createGain(); A.out.gain.value = 0.5; A.out.connect(comp); const n = c.sampleRate, b = c.createBuffer(1, n, n), d = b.getChannelData(0); for (let i = 0; i < n; i++) d[i] = Math.random() * 2 - 1; A.nb = b; return c; }
  return { A, mkOff, tone, noise, groove, STEP, setCur: (b) => { CUR = b; } };`;

const browser = await launch();
const H = await openHouse(browser, loadFixtures().find((f) => f.name === 'lv30-beach'), { room: 'movie' });
await H.ready(); await H.frames(30); await H.still();
await H.page.evaluate((src) => { window.__mnA = new Function(src)(); }, AUDIO);
// an AudioBuffer (mono) -> Int16 PCM, base64, in chunks back to node
await H.page.evaluate(() => {
  window.__pcm = (buf, from, to) => { const d = buf.getChannelData(0), a = Math.floor(from * buf.sampleRate), b = Math.min(d.length, Math.floor(to * buf.sampleRate)), o = new Int16Array(b - a);
    for (let i = a; i < b; i++) o[i - a] = Math.max(-32768, Math.min(32767, Math.round(d[i] * 32767))); window.__last = o; return o.length; };
  window.__chunk = (i, n) => { const u = new Uint8Array(window.__last.buffer, i * 2, Math.min(n, window.__last.length - i) * 2); let s = ''; for (let k = 0; k < u.length; k++) s += String.fromCharCode(u[k]); return btoa(s); };
});
async function pcm() {
  const n = await H.page.evaluate(() => window.__last.length), parts = [];
  for (let i = 0; i < n; i += 1 << 20) parts.push(Buffer.from(await H.page.evaluate(([i, k]) => window.__chunk(i, k), [i, 1 << 20]), 'base64'));
  return Buffer.concat(parts);
}
function wav(pcmBuf, file) {
  const h = Buffer.alloc(44); h.write('RIFF', 0); h.writeUInt32LE(36 + pcmBuf.length, 4); h.write('WAVEfmt ', 8); h.writeUInt32LE(16, 16); h.writeUInt16LE(1, 20); h.writeUInt16LE(1, 22);
  h.writeUInt32LE(SR, 24); h.writeUInt32LE(SR * 2, 28); h.writeUInt16LE(2, 32); h.writeUInt16LE(16, 34); h.write('data', 36); h.writeUInt32LE(pcmBuf.length, 40);
  fs.writeFileSync(file, Buffer.concat([h, pcmBuf]));
}
const run = (args) => new Promise((res, rej) => { const p = spawn('ffmpeg', ['-hide_banner', '-loglevel', 'error', '-y', ...args], { stdio: ['pipe', 'inherit', 'inherit'] }); p.on('exit', (c) => (c ? rej(new Error('ffmpeg ' + c)) : res())); });
const tmp = path.join(REPO, 'tools/unity/house-test/out'); fs.mkdirSync(tmp, { recursive: true });

// ---- the loops: the groove (8 s) and the TV's channels, one steady period after a warm-up period ----
{
  await H.page.evaluate(async (SR) => {
    const M = window.__mnA, L = 64 * M.STEP, c = M.mkOff(3 * L + 1, SR), bus = c.createGain(); bus.connect(M.A.out); M.setCur(bus);
    for (let s = 0; s < 64 * 3; s++) M.groove(0.06 + s * M.STEP, s);
    M.setCur(null); const b = await c.startRendering(); window.__pcm(b, 0.06 + L, 0.06 + 2 * L);
  }, SR);
  wav(await pcm(), path.join(tmp, 'groove.wav')); await run(['-i', path.join(tmp, 'groove.wav'), '-c:a', 'libvorbis', '-q:a', '4', path.join(AUD, 'groove.ogg')]);
  for (const ch of [1, 2, 3]) {
    const L = await H.page.evaluate(async ([ch, SR]) => {
      // tv-sound.js's own code on an offline context: its AudioContext and its scheduler's interval taken over
      const L = ch === 2 ? 8 : ch === 1 ? 32 * (60 / 132 / 2) : 32 * (60 / 96 / 2), secs = 3 * L + 1;
      const off = new OfflineAudioContext(1, Math.ceil(secs * SR), SR); let now = 0; Object.defineProperty(off, 'currentTime', { get: () => now });
      const AC0 = window.AudioContext, SI = window.setInterval; let tick = null;
      window.AudioContext = function () { return off; }; window.setInterval = (f) => { tick = f; return 0; };
      try { delete window.TvSound; } catch (e) { window.TvSound = undefined; }
      const src = await (await fetch('tv-sound.js')).text(); new Function(src)();
      window.TvSound.play('x', ch); now = secs - 0.3; tick(); now = 0;
      window.AudioContext = AC0; window.setInterval = SI;
      const b = await off.startRendering(); window.__pcm(b, 0.08 + L, 0.08 + 2 * L); return L;
    }, [ch, SR]);
    wav(await pcm(), path.join(tmp, 'tv' + ch + '.wav')); await run(['-i', path.join(tmp, 'tv' + ch + '.wav'), '-c:a', 'libvorbis', '-q:a', '4', path.join(AUD, 'tv' + ch + '.ogg')]);
    console.log(`tv${ch}: ${L.toFixed(2)} s loop`);
  }
  console.log('loops: groove, tv1-3 -> Resources/House/audio');
}
if (LOOPS_ONLY) { await browser.close(); process.exit(0); }

// ---- the movies ----
const list = await H.page.evaluate(() => window.SquadMovies.list.filter((m) => m.mk).map((m) => ({ id: m.id, dur: m.dur, title: m.title, tier: m.tier, old: !!m.old, cues: m.cues || [] })));
console.log('movies:', list.map((m) => m.id + ' ' + m.dur + 's').join(', '));
const info = [];
for (const mv of list) {
  if (ONLY && mv.id !== ONLY) continue;
  const t0 = Date.now();
  // the score
  await H.page.evaluate(async ([id, SR]) => {
    const M = window.__mnA, mv = window.SquadMovies.list.find((m) => m.id === id), c = M.mkOff(mv.dur + 1.5, SR), g = c.createGain();
    if (mv.old) { const hp = c.createBiquadFilter(), lp = c.createBiquadFilter(); hp.type = 'highpass'; hp.frequency.value = 180; lp.type = 'lowpass'; lp.frequency.value = 3400; g.connect(hp); hp.connect(lp); lp.connect(M.A.out); } else g.connect(M.A.out);
    M.setCur(g); for (const r of window.SquadMovies.record(mv)) { if (r[1] === 't') M.tone(r[0], r[2], r[3], r[4]); else M.noise(r[0], r[2], r[3]); } M.setCur(null);
    const b = await c.startRendering(); window.__pcm(b, 0, mv.dur);
  }, [mv.id, SR]);
  const aud = path.join(tmp, mv.id + '.wav'); wav(await pcm(), aud);
  // the picture: the movie on its stage, over everything, at the page's scale (CSS px 320 x 180)
  await H.page.evaluate((id) => {
    const sh = window.__sh, mv = window.SquadMovies.list.find((m) => m.id === id);
    const st = document.createElement('div'); st.id = 'mvx'; st.style.cssText = 'position:fixed;left:0;top:0;width:320px;height:180px;overflow:hidden;background:#05030a;z-index:2147483647;';
    document.body.appendChild(st); window.__F = mv.mk((sh && sh.adArt && sh.adArt()) || {}); st.appendChild(window.__F.root);
  }, mv.id);
  const out = path.join(MOV, mv.id + '.mp4');
  const ff = spawn('ffmpeg', ['-hide_banner', '-loglevel', 'error', '-y', '-f', 'image2pipe', '-c:v', 'mjpeg', '-framerate', String(FPS), '-i', '-', '-i', aud,
    '-vf', 'scale=480:270:flags=lanczos,format=yuv420p', '-c:v', 'libx264', '-preset', 'slow', '-crf', '28', '-c:a', 'aac', '-b:a', '80k', '-shortest', '-movflags', '+faststart', out], { stdio: ['pipe', 'inherit', 'inherit'] });
  const done = new Promise((r) => ff.on('exit', r));
  const n = Math.round(mv.dur * FPS), light = [];   // (the screen's light on the room, 10 a second: [r, g, b, lit])
  for (let i = 0; i < n; i++) {
    const o = await H.page.evaluate((t) => { const o = window.__F.upd(t); return o && o.rgb ? [o.rgb, o.lit] : null; }, i / FPS);
    if (i % Math.round(FPS / 10) === 0) light.push(o ? [...String(o[0]).split(',').map(Number), Math.round(o[1] * 1000) / 1000] : [200, 210, 255, 1]);
    const jpg = await H.page.screenshot({ clip: { x: 0, y: 0, width: 320, height: 180 }, type: 'jpeg', quality: 90, animations: 'allow' });
    if (!ff.stdin.write(jpg)) await new Promise((r) => ff.stdin.once('drain', r));
    if (i % (FPS * 30) === 0) console.log(`  ${mv.id}: ${(i / FPS).toFixed(0)} s of ${mv.dur} (${((Date.now() - t0) / 1000).toFixed(0)} s)`);
  }
  ff.stdin.end(); await done;
  await H.page.evaluate(() => { document.getElementById('mvx').remove(); window.__F = null; });
  const kb = Math.round(fs.statSync(out).size / 1024);
  info.push({ id: mv.id, tier: mv.tier, title: mv.title, dur: mv.dur, old: mv.old, kb, cues: mv.cues, light });
  console.log(`${mv.id}: ${mv.dur} s -> ${kb} KB in ${((Date.now() - t0) / 1000).toFixed(0)} s`);
}
{ // movies.json: merged with what's there (an --only run replaces its movie)
  const f = path.join(REPO, 'unity/Assets/Resources/House/movies.json'), had = fs.existsSync(f) ? JSON.parse(fs.readFileSync(f, 'utf8')).list : [];
  const all = list.map((m) => info.find((x) => x.id === m.id) || had.find((x) => x.id === m.id) || { id: m.id, tier: m.tier, title: m.title, dur: m.dur, old: m.old, cues: m.cues, light: null, kb: 0 });
  fs.writeFileSync(f, JSON.stringify({ note: 'Written by tools/unity/house/export-movies.mjs: StreamingAssets/Movies/<id>.mp4; light: the screen\'s light on the room 10 a second [r, g, b, lit].', list: all }));
}
for (const e of [...new Set(H.errs || [])].slice(0, 5)) console.log('  page error:', String(e).slice(0, 160));
await browser.close();
