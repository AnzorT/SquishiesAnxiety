// Renders the v3 design's sounds and music (sfx.js, from the design zip) to
// audio files the app can play. The design makes every sound in code with
// the browser's Web Audio API, which React Native doesn't have — so Chrome
// renders each one once, offline (OfflineAudioContext: sample-exact, faster
// than real time), and encode.py turns them into the app's audio files.
//
// Music tracks are rendered as seamless loops: one full cycle of the
// track's pattern (24 bars — chords repeat every 4, the melody every 8, the
// random plucks every 12), with the ringing tail folded back onto the start.
//
// The Crib's music (the 2026-10-03 drop's sfx.js: a track per room and the
// dance room's club songs) comes from that drop's newer music engine, so it
// has its own mode: `--crib` renders just those tracks (the effects and the
// five moods above were rendered from the earlier drop's sfx.js, whose
// music code the new file no longer has — their WAVs stay in out/).
//
// Usage (from the repo root):
//   python -m zipfile -e "ASMR Creature Squash Game.zip" tools/plush-art/design
//   node tools/audio/render.mjs          → tools/audio/out/*.wav
//   node tools/audio/render.mjs --crib   → tools/audio/out/music-crib_*.wav, music-club_*.wav
//   python tools/audio/encode.py         → assets/audio/sfx, assets/audio/music, src/audio/effectFiles.js

import { spawn } from 'node:child_process';
import fs from 'node:fs';
import os from 'node:os';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const SFX_JS = path.join(HERE, '..', 'plush-art', 'design', 'sfx.js');
const OUT = path.join(HERE, 'out');
const SR = 44100;
const PORT = 9300 + Math.floor(Math.random() * 300);

// ---- what to render ------------------------------------------------------

// One-shots from the design's SOUNDS table (rendered, then trimmed).
const ONE_SHOTS = [
  'tap', 'bonk', 'swoosh', 'swipe', 'whoosh', 'popOpen', 'popClose', 'tick', 'coin', 'coinShower', 'spend',
  'win', 'jackpot', 'fail', 'boxOpen', 'unlock', 'achievement', 'boost', 'adStart', 'adDone', 'ready', 'blip', 'sparkle',
];
const MUSIC = ['dream', 'party', 'cozy', 'calm', 'mystery'];
const MUSIC_BARS = 24;
// the Crib's: one cycle of the new engine's pattern is 8 bars (the chords
// change every 2, the melody repeats every 8)
const CRIB_MUSIC = ['crib_living', 'crib_kitchen', 'crib_bath', 'crib_bed', 'crib_dance', 'crib_yard', 'club_disco', 'club_house', 'club_synth', 'club_bounce', 'club_turbo'];
const CRIB_BARS = 8;
const CRIB_ONLY = process.argv.includes('--crib');

// ---- the page --------------------------------------------------------------

// sfx.js keeps its building blocks private; expose them, and give it a
// seeded Math.random so every render comes out the same.
const sfx = fs
  .readFileSync(SFX_JS, 'utf8')
  .replace(
    /\}\)\(\);\s*$/,
    `window.__SFX = { ${['S', 'init', 'tone', 'noise', 'bell', 'sparkle', 'arp', 'SOUNDS', 'PRESETS', 'voice', 'lead', 'mtof', 'swell', 'keys', 'kalimba', 'motif'].map((k) => `${k}: typeof ${k} !== 'undefined' ? ${k} : null`).join(', ')} };\n})();`
  );

const PAGE_JS = `
(() => {
  let seed = 12345;
  Math.random = () => ((seed = (seed * 16807) % 2147483647) - 1) / 2147483646;
  const I = window.__SFX;
  const SR = ${SR};

  // A fresh offline graph, built by sfx.js's own init() (master, compressor,
  // reverb, sfx and music buses).
  function context(seconds, seedValue) {
    seed = seedValue || 12345;
    const ctx = new OfflineAudioContext(2, Math.ceil(seconds * SR), SR);
    window.AudioContext = function () { return ctx; };
    I.S.ctx = null;
    I.S.enabled = true;
    I.init();
    return ctx;
  }
  const pcm = async (ctx) => {
    const buf = await ctx.startRendering();
    const L = buf.getChannelData(0), R = buf.getChannelData(1);
    const out = new Int16Array(L.length * 2);
    for (let i = 0; i < L.length; i++) {
      out[2 * i] = Math.max(-1, Math.min(1, L[i])) * 32767;
      out[2 * i + 1] = Math.max(-1, Math.min(1, R[i])) * 32767;
    }
    let s = '';
    const bytes = new Uint8Array(out.buffer);
    for (let i = 0; i < bytes.length; i += 0x8000) s += String.fromCharCode.apply(null, bytes.subarray(i, i + 0x8000));
    return btoa(s);
  };

  const T0 = 0.01;
  window.render = {
    async oneShot(name) {
      const ctx = context(4.5);
      I.SOUNDS[name](T0);
      return pcm(ctx);
    },
    // The Mystery Box tap (SFX.boxTap) in two parts, at the first tap's
    // pitch: the thump and the bell. The app raises each with the playback
    // rate as the taps add up (the thump by 15 Hz a tap, the bell up the
    // scale), so ten taps need two players instead of ten.
    async boxThump() {
      const ctx = context(0.6);
      I.tone(165, T0, 0.16, { to: 90, vol: 0.35 });
      I.noise(T0, 0.06, { f: 1050, q: 2, vol: 0.18 });
      return pcm(ctx);
    },
    async boxBell() {
      const ctx = context(1.6);
      I.bell(I.mtof(72), T0, 0.5, 0.1);
      return pcm(ctx);
    },
    // The wheel slowing to a stop over T seconds (SFX.wheelSpin).
    async wheelSpin(T) {
      const ctx = context(T + 1);
      I.noise(T0, 0.4, { f: 600, fTo: 2400, q: 1, vol: 0.12, attack: 0.1 });
      let x = 0;
      while (x < T - 0.05) {
        const p = x / T;
        I.SOUNDS.tick(T0 + x);
        x += 0.035 + Math.pow(p, 2.6) * 0.42;
      }
      return pcm(ctx);
    },
    // The reel gliding to a stop (SFX.reelLand).
    async reelLand(T) {
      const ctx = context(T + 0.8);
      let x = 0, gap = 0.07;
      while (x < T) { I.SOUNDS.tick(T0 + x); gap *= 1.12; x += gap; }
      I.tone(I.mtof(72), T0 + T - 0.05, 0.3, { type: 'triangle', vol: 0.12 });
      return pcm(ctx);
    },
    // A loop of evenly spaced ticks (the reel while it spins: every 70ms).
    async tickLoop(gap, count) {
      const ctx = context(gap * count + 0.3);
      for (let i = 0; i < count; i++) I.SOUNDS.tick(i * gap);
      return pcm(ctx);
    },
    // The hold-to-unlock drone at its starting pitch (SFX.holdStart): one
    // second holds a whole number of cycles of both tones, so it loops
    // cleanly; the app raises its pitch with the rate.
    async holdLoop() {
      // 2 s rendered; Node keeps the second one (the first starts with the
      // compressor's look-ahead gap)
      const ctx = context(2);
      const g = ctx.createGain(); g.gain.value = 0.12; g.connect(I.S.sfx);
      [['triangle', 260], ['sine', 390]].forEach(([type, f]) => {
        const o = ctx.createOscillator(); o.type = type; o.frequency.value = f; o.connect(g); o.start(0);
      });
      return pcm(ctx);
    },
    // The little step note every 10% of the hold (at the starting pitch).
    async holdStep() {
      const ctx = context(0.3);
      I.tone(520, T0, 0.05, { vol: 0.05 });
      return pcm(ctx);
    },
    // One whole cycle of a music track, scheduled exactly like sfx.js's
    // startTrack, plus the tail (folded onto the start in Node).
    async music(name, bars, tail) {
      const P = I.PRESETS[name];
      const sixteenth = 60 / P.bpm / 4;
      const loop = bars * 16 * sixteenth;
      const ctx = context(loop + tail, 777);
      I.S.mus.gain.value = 0.25; // the design's default: musicVolume 0.5 × 0.5
      const bus = ctx.createGain();
      let out = bus;
      if (P.lp) { const f = ctx.createBiquadFilter(); f.type = 'lowpass'; f.frequency.value = P.lp; bus.connect(f); out = f; }
      out.connect(I.S.mus);
      let trSeed = 7;
      const rnd = () => ((trSeed = (trSeed * 9301 + 49297) % 233280) / 233280);
      for (let step = 0; step < bars * 16; step++) {
        const s = step % 16, bar = Math.floor(step / 16), ch = P.chords[bar % P.chords.length], t = step * sixteenth;
        if (s === 0) {
          const d = sixteenth * 16;
          ch.forEach((m, i) => I.tone(I.mtof(m + 12), t, d + 0.4, { type: i % 2 ? 'triangle' : 'sine', vol: P.pad, attack: d * 0.35, bus, detune: (i - 1.5) * 4 }));
          if (P.bass) I.tone(I.mtof(ch[0] - 12), t, sixteenth * 7, { type: 'sine', vol: 0.11, attack: 0.02, bus });
          if (bar % 4 === 0) trSeed = 7 + (bar / 4) % 3;
        }
        if (P.bass && s === 8) I.tone(I.mtof(ch[0] - 12 + (name === 'mystery' ? 0 : 7)), t, sixteenth * 5, { type: 'sine', vol: 0.08, attack: 0.02, bus });
        const phrase = Math.floor(bar / 2) % 4;
        const mi = P.mel[step % 32];
        if (mi != null && phrase !== 3) I.lead(P.lead, P.key + mi + (phrase === 2 ? 12 : 0), t, bus);
        if (P.hits.indexOf(s) >= 0 && rnd() > 0.3) I.voice(P.pluck, ch[Math.floor(rnd() * ch.length)] + P.oct - (rnd() > 0.6 ? 12 : 0), t, bus, P.lp);
        if (P.kick && P.kick.indexOf(s) >= 0) I.tone(120, t, 0.22, { to: 42, slide: 0.12, vol: name === 'party' ? 0.22 : 0.12, bus });
        if (P.clap && P.clap.indexOf(s) >= 0) I.noise(t, 0.12, { f: 1600, q: 0.8, vol: 0.07, bus, verb: 0.3 });
        if (P.shaker && s % 2 === 0) I.noise(t, 0.04, { ft: 'highpass', f: 7000, vol: s % 4 === 2 ? 0.03 : 0.015, bus });
      }
      return { loopSamples: Math.round(loop * SR), pcm: await pcm(ctx) };
    },
    // One cycle of a Crib track, scheduled exactly like the new sfx.js's
    // startTrack (its swing, pads, bass, arps, two melodies and the room's
    // extras: snaps, plucks, drips, music box, birds), plus the tail.
    async cribMusic(name, bars, tail) {
      const P = I.PRESETS[name];
      const six = 60 / P.bpm / 4;
      const loop = bars * 16 * six;
      const ctx = context(loop + tail, 777);
      I.S.mus.gain.value = 0.25; // the design's default: musicVol 0.5 × 0.5
      const bus = ctx.createGain();
      const lp = ctx.createBiquadFilter(); lp.type = 'lowpass'; lp.frequency.value = 3200; bus.connect(lp); lp.connect(I.S.mus);
      const A = I.motif(P, 11), B = I.motif(P, 23);
      const { swell, tone, noise, bell, keys, kalimba, mtof } = I;
      for (let step = 0; step < bars * 16; step++) {
        const s = step % 16, bar = Math.floor(step / 16), ci = Math.floor(bar / 2) % 4, ch = P.chords[ci];
        const t = step * six + (P.swing && s % 4 === 2 ? six * 0.33 : 0);
        if (s === 0 && bar % 2 === 0) {
          const d = six * 32 + 1.2;
          ch.forEach((m, i) => { swell(mtof(m + 12), t, d, { vol: P.pad, attack: 1.4, release: 1.6, lp: 1100, bus, detune: (i - 1.5) * 5 }); });
          swell(mtof(ch[0] + 24), t, d, { vol: P.pad * 0.35, type: 'triangle', attack: 2, release: 1.6, lp: 1600, bus });
        }
        if (s === 0) tone(mtof(ch[0] - 12), t, six * 10, { vol: P.bass, attack: 0.03, bus, lp: 500 });
        if (s === 8) tone(mtof(ch[0] - 12 + 7), t, six * 6, { vol: P.bass * 0.7, attack: 0.03, bus, lp: 500 });
        P.arp.forEach(([st, ni]) => { if (st === s) keys(mtof(ch[ni % ch.length] + 12), t, six * 6, 0.03, bus); });
        const sec = bar % 8, mot = sec < 2 || sec === 4 || sec === 5 ? A : sec < 4 ? B : null;
        const mi = mot && mot[step % 32];
        if (mi != null) kalimba(mtof(P.key + mi), t, 0.045, bus);
        if (P.kick && P.kick.indexOf(s) >= 0) tone(95, t, 0.28, { to: 48, slide: 0.12, vol: 0.09, attack: 0.004, bus, lp: 600 });
        if (P.hat && s % 4 === 2) noise(t, 0.025, { ft: 'highpass', f: 8000, vol: 0.012, bus });
        if (P.snap && (s === 4 || s === 12)) noise(t, 0.04, { f: 2200, q: 3, vol: 0.03, bus });
        if (P.clap && (s === 4 || s === 12)) { noise(t, 0.09, { f: 1500, q: 1, vol: 0.05, bus }); noise(t + 0.012, 0.06, { f: 1800, q: 1.2, vol: 0.03, bus }); }
        if (P.octBass && s % 2 === 1) tone(mtof(ch[0] + (s % 4 === 1 ? 0 : 12) - 12), t, six * 0.8, { vol: P.bass * 0.55, attack: 0.01, bus, lp: 900 });
        if (P.pluck && s % 4 === 3) tone(mtof(ch[2] + 24), t, 0.12, { type: 'triangle', vol: 0.02, attack: 0.003, bus, lp: 2600 });
        if (P.drip && s % 8 === 5 && Math.random() < 0.6) tone(900 + Math.random() * 700, t, 0.12, { to: 1800 + Math.random() * 600, slide: 0.06, vol: 0.03, attack: 0.005, bus, lp: 2600, verb: 0.5, vbus: I.S.mverbIn });
        if (P.musicbox && s % 4 === 0 && Math.random() < 0.5) bell(mtof(P.key + 12 + P.scale[Math.floor(Math.random() * 5)]), t, 1.4, 0.03, bus);
        if (P.birds && s === 6 && bar % 3 === 1) { const f0 = 2600 + Math.random() * 900; for (let k = 0; k < 3; k++) tone(f0 * (1 + k * 0.06), t + k * 0.07, 0.06, { to: f0 * 1.25, slide: 0.04, vol: 0.018, attack: 0.004, bus }); }
      }
      return { loopSamples: Math.round(loop * SR), pcm: await pcm(ctx) };
    },
  };
})();`;

// ---- Chrome --------------------------------------------------------------

function findChrome() {
  const c = [process.env.CHROME_PATH, path.join(os.homedir(), 'AppData/Local/Google/Chrome/Application/chrome.exe'), 'C:/Program Files/Google/Chrome/Application/chrome.exe', '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome', '/usr/bin/google-chrome'].filter(Boolean);
  const hit = c.find((p) => fs.existsSync(p));
  if (!hit) throw new Error('Chrome not found — set CHROME_PATH');
  return hit;
}

async function connect() {
  const profile = fs.mkdtempSync(path.join(os.tmpdir(), 'sfx-render-'));
  const chrome = spawn(findChrome(), ['--headless=new', '--no-sandbox', `--remote-debugging-port=${PORT}`, `--user-data-dir=${profile}`, 'about:blank'], { stdio: 'ignore' });
  let target;
  for (let i = 0; i < 50 && !target; i++) {
    await new Promise((r) => setTimeout(r, 200));
    try {
      target = (await (await fetch(`http://127.0.0.1:${PORT}/json/list`)).json()).find((t) => t.type === 'page');
    } catch {
      // not up yet
    }
  }
  if (!target) throw new Error('Chrome did not start');
  const ws = new WebSocket(target.webSocketDebuggerUrl);
  await new Promise((r) => (ws.onopen = r));
  let id = 0;
  const pending = new Map();
  ws.onmessage = (m) => {
    const d = JSON.parse(m.data);
    if (d.id && pending.has(d.id)) {
      pending.get(d.id)(d);
      pending.delete(d.id);
    }
  };
  const send = (method, params = {}) =>
    new Promise((res, rej) => {
      const i = ++id;
      pending.set(i, (d) => (d.error ? rej(new Error(`${method}: ${d.error.message}`)) : res(d.result)));
      ws.send(JSON.stringify({ id: i, method, params }));
    });
  return { send, close: () => (ws.close(), chrome.kill()) };
}

// ---- WAV out -----------------------------------------------------------------

function writeWav(file, int16Stereo) {
  const data = Buffer.from(int16Stereo.buffer, int16Stereo.byteOffset, int16Stereo.byteLength);
  const h = Buffer.alloc(44);
  h.write('RIFF', 0);
  h.writeUInt32LE(36 + data.length, 4);
  h.write('WAVEfmt ', 8);
  h.writeUInt32LE(16, 16);
  h.writeUInt16LE(1, 20);
  h.writeUInt16LE(2, 22);
  h.writeUInt32LE(SR, 24);
  h.writeUInt32LE(SR * 4, 28);
  h.writeUInt16LE(4, 32);
  h.writeUInt16LE(16, 34);
  h.write('data', 36);
  h.writeUInt32LE(data.length, 40);
  fs.writeFileSync(file, Buffer.concat([h, data]));
}
const decode = (b64) => {
  const buf = Buffer.from(b64, 'base64');
  return new Int16Array(buf.buffer, buf.byteOffset, buf.length / 2);
};

// Cut the silence after a one-shot (with a short fade so it never clicks).
function trim(pcm) {
  const floor = 16; // about -66 dB
  let end = pcm.length / 2;
  while (end > 1 && Math.abs(pcm[2 * end - 2]) < floor && Math.abs(pcm[2 * end - 1]) < floor) end--;
  end = Math.min(pcm.length / 2, end + Math.round(0.02 * SR));
  const out = pcm.slice(0, end * 2);
  const fade = Math.min(end, Math.round(0.02 * SR));
  for (let i = 0; i < fade; i++) {
    const k = i / fade;
    out[2 * (end - 1 - i)] *= k;
    out[2 * (end - 1 - i) + 1] *= k;
  }
  return out;
}

// A seamless loop: add everything after the loop point back onto its start.
function fold(pcm, loopSamples) {
  const out = pcm.slice(0, loopSamples * 2);
  for (let i = loopSamples * 2; i < pcm.length; i++) {
    const j = (i - loopSamples * 2) % out.length;
    out[j] = Math.max(-32768, Math.min(32767, out[j] + pcm[i]));
  }
  return out;
}

// ---- go ------------------------------------------------------------------------

fs.mkdirSync(OUT, { recursive: true });
const { send, close } = await connect();
try {
  await send('Page.enable');
  const frame = (await send('Page.getFrameTree')).frameTree.frame.id;
  await send('Page.setDocumentContent', { frameId: frame, html: '<!DOCTYPE html><html><body></body></html>' });
  const load = async (src) => {
    const r = await send('Runtime.evaluate', { expression: src });
    if (r.exceptionDetails) throw new Error(JSON.stringify(r.exceptionDetails).slice(0, 400));
  };
  await load(sfx);
  await load(PAGE_JS);
  const call = async (expr) => {
    const r = await send('Runtime.evaluate', { expression: expr, awaitPromise: true, returnByValue: true, timeout: 600000 });
    if (r.exceptionDetails) throw new Error(`${expr}: ${JSON.stringify(r.exceptionDetails).slice(0, 400)}`);
    return r.result.value;
  };
  const save = (name, pcm) => {
    writeWav(path.join(OUT, `${name}.wav`), pcm);
    process.stdout.write(`${name} `);
  };

  if (CRIB_ONLY) {
    for (const name of CRIB_MUSIC) {
      const r = await call(`render.cribMusic(${JSON.stringify(name)}, ${CRIB_BARS}, 5)`);
      save(`music-${name}`, fold(decode(r.pcm), r.loopSamples));
    }
    console.log('\nrendered to', OUT);
    close();
    process.exit(0);
  }
  for (const name of ONE_SHOTS) save(name, trim(decode(await call(`render.oneShot(${JSON.stringify(name)})`))));
  save('boxThump', trim(decode(await call('render.boxThump()'))));
  save('boxBell', trim(decode(await call('render.boxBell()'))));
  save('wheelSpin', trim(decode(await call('render.wheelSpin(4.5)'))));
  save('reelLand', trim(decode(await call('render.reelLand(2.8)'))));
  // loops: 14 ticks every 70 ms (the reel); 28 every 35 ms (the wheel's whirl)
  save('reelLoop', fold(decode(await call('render.tickLoop(0.07, 14)')), Math.round(0.07 * 14 * SR)));
  save('whirlLoop', fold(decode(await call('render.tickLoop(0.035, 28)')), Math.round(0.035 * 28 * SR)));
  save('holdLoop', decode(await call('render.holdLoop()')).slice(SR * 2, SR * 4));
  save('holdStep', trim(decode(await call('render.holdStep()'))));
  for (const name of MUSIC) {
    const r = await call(`render.music(${JSON.stringify(name)}, ${MUSIC_BARS}, 5)`);
    save(`music-${name}`, fold(decode(r.pcm), r.loopSamples));
  }
  console.log('\nrendered to', OUT);
} finally {
  close();
}
