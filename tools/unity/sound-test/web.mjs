// The page's own chest sounds (android/app/src/main/assets/chest/chest-sfx.js) rendered in Chrome's OfflineAudioContext,
// for sound-test to compare against: node tools/unity/sound-test/web.mjs <dir>  (writes <dir>/web-<name>.json: the
// 10 ms RMS envelope of the left channel; note its DC floor near -34.5 dB, the WaveShaper curve's offset at 0)
import { createRequire } from 'module'; const require = createRequire(import.meta.url);
const { chromium } = require('playwright'); const fs = require('fs');
const sfx = fs.readFileSync(new URL('../../../android/app/src/main/assets/chest/chest-sfx.js', import.meta.url), 'utf8');
// host.html's unlock sounds (its SND, cut out of the page)
const host = fs.readFileSync(new URL('../../chest/host.html', import.meta.url), 'utf8');
const snd = host.slice(host.indexOf('const AU = { c: null };'), host.indexOf('  function ev(e)'));
// movie-night.js's own sound functions (its env and noise, cut out of the page's script) for the house's sounds
const mn = fs.readFileSync(new URL('../../../webgame/test/out/unity-house/movie-night.js', import.meta.url), 'utf8');
const mnFns = mn.slice(mn.indexOf('  function env('), mn.indexOf('  const kick'));
const dir = process.argv[2] || "sound-test"; fs.mkdirSync(dir, { recursive: true });
const b = await chromium.launch(); const p = await b.newPage();
await p.setContent('<html><body></body></html>');
const cases = [
 ['hit-wood', `X.hit({kind:'poke',heavy:false,group:'fruit',lv:0,dmg:0.1,ko:false,mat:{m:'wood',p:1}})`],
 ['hit-wood-hv', `X.hit({kind:'poke',heavy:true,group:'fruit',lv:0,dmg:0.6,ko:false,mat:{m:'wood',p:1}})`],
 ['hit-steel', `X.hit({kind:'poke',heavy:false,group:'heroes',lv:3,dmg:0.4,ko:false,mat:{m:'steel',p:1.05,x:['iron']}})`],
 ['hit-gem-ko', `X.hit({kind:'poke',heavy:true,group:'fruit',lv:4,dmg:1,ko:true,mat:{m:'crystal',p:1,x:['rainbow','juice']}})`],
 ['bounce', `X.bounce(900,'fruit',0,{m:'wood',p:1})`],
 ['charge', `X.charge(1.2)`], ['poof3', `X.poof(3)`], ['burst4', `X.burst(4,'fruit',{m:'crystal',p:1,x:['rainbow','juice']})`],
 ['house-show', `M.show()`], ['house-whoosh-in', `M.whoosh(true)`], ['house-whoosh-out', `M.whoosh(false)`],
 ['card0', `U.card(0)`], ['card6', `U.card(6)`], ['fly', `U.fly()`], ['full', `U.full()`], ['gather', `U.gather(1.43)`], ['bam', `U.bam()`], ['land', `U.land()`],
];
for (const [name, call] of cases) {
  const r = await p.evaluate(async ({ sfx, snd, mnFns, call }) => {
    let oc; window.AudioContext = function () { oc = new OfflineAudioContext(2, 44100 * 4, 44100); oc.resume = () => Promise.resolve(); return oc; };
    eval(sfx); const X = window.ChestSFX;
    const U = new Function('S', snd + '; return SND;')({ sound: true });
    // (movie-night.js: its context, out gain 0.5 into a compressor at -14 dB, ratio 4; noise from a 1 s buffer)
    const M = (() => { const A = {}; let CUR = null; const c = new AudioContext(); const comp = c.createDynamicsCompressor(); comp.threshold.value = -14; comp.ratio.value = 4; comp.connect(c.destination);
      A.ctx = c; A.out = c.createGain(); A.out.gain.value = 0.5; A.out.connect(comp); const n = c.sampleRate, b = c.createBuffer(1, n, n), d = b.getChannelData(0); for (let i = 0; i < n; i++) d[i] = Math.random() * 2 - 1; A.nb = b;
      const f = new Function('A', 'CUR', mnFns + '; return { noise };')(A, CUR);
      return { show: () => { f.noise(0, 1.1, { ft: 'lowpass', f: 1400, fTo: 160, vol: 0.06, at: 0.3 }); f.noise(1.2 - 0.18, 0.03, { ft: 'bandpass', f: 3200, q: 2, vol: 0.25 }); },
        whoosh: on => f.noise(0, 0.5, { ft: 'bandpass', f: on ? 500 : 2600, fTo: on ? 3000 : 420, q: 1.1, vol: 0.05, at: 0.22 }) }; })();
    eval(call);
    const buf = await oc.startRendering(); const d = buf.getChannelData(0);
    let pk = 0, e = 0, last = 0; for (let i = 0; i < d.length; i++) { const a = Math.abs(d[i]); pk = Math.max(pk, a); e += d[i] * d[i]; if (a > 0.001) last = i; }
    // a 10 ms RMS envelope, for comparing shapes
    const env = []; for (let i = 0; i < d.length; i += 441) { let s = 0; for (let j = i; j < i + 441 && j < d.length; j++) s += d[j] * d[j]; env.push(Math.sqrt(s / 441)); }
    return { pk, rms: Math.sqrt(e / (last + 1)), len: last / 44100, env };
  }, { sfx, snd, mnFns, call });
  console.log(name.padEnd(14), r.len.toFixed(2) + 's', 'peak', r.pk.toFixed(3), 'rms', r.rms.toFixed(4));
  fs.writeFileSync(`${dir}/web-${name}.json`, JSON.stringify(r.env));
}
await b.close();
