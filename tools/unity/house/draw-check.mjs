// The draw host (tools/unity/house/draw-host.js in Resources/Rig, House/HouseDraw.cs) against the stage-1 export: every
// drawing variant and render in house-pieces.json made again through __house and compared (pictures by the same
// canonical name: SMIL stripped, ids renumbered, sha1), in Node on the browser stand-in, as LiveRig loads it.
//
//   node tools/unity/rig/bundle.mjs && node tools/unity/house/draw-check.mjs
import fs from 'node:fs'; import path from 'node:path'; import vm from 'node:vm'; import zlib from 'node:zlib'; import crypto from 'node:crypto';
import { REPO } from './harness.mjs';
const R = (f) => JSON.parse(zlib.gunzipSync(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/Rig', f))));
const scripts = R('scripts.bytes'), files = R('files.bytes');
const ctx = vm.createContext({ console: { log() {}, warn() {}, error() {} } });
const t0 = Date.now();
for (const [n, c] of scripts) { try { vm.runInContext(c, ctx, { filename: n }); } catch (e) { if (n === 'house-draw.js') throw e; } if (n === 'live-host.js') { ctx.__f = files; vm.runInContext('__live.install(function (p) { return Object.prototype.hasOwnProperty.call(__f, p) ? __f[p] : null; })', ctx); } }
for (let i = 0; i < 20; i++) vm.runInContext('__clock.frame(40)', ctx);
const n = vm.runInContext('__house.init()', ctx);
console.log(`loaded in ${Date.now() - t0} ms; ${n} catalog rows`);
const sha = (s) => crypto.createHash('sha1').update(s).digest('hex').slice(0, 16);
const stripSmil = (s) => s.replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*\/>/g, '').replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*>[\s\S]*?<\/\1>/g, '');
const canonIds = (s) => { const m = new Map(); for (const x of s.matchAll(/\bid="([^"]+)"/g)) if (!m.has(x[1])) m.set(x[1], 'k' + m.size); return s.replace(/(\bid=")([^"]+)(")|(url\(#)([^)]+)(\))|(href="#)([^"]+)(")/g, (all, a1, a2, a3, b1, b2, b3, c1, c2, c3) => a1 ? a1 + (m.get(a2) || a2) + a3 : b1 ? b1 + (m.get(b2) || b2) + b3 : c1 + (m.get(c2) || c2) + c3); };
const name = (svg) => !svg ? '' : svg.startsWith('<') ? sha(canonIds(stripSmil(svg))) : sha(svg);
const P = JSON.parse(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/House/house-pieces.json'), 'utf8'));
const ROOM = { LIV: 'living', KIT: 'kitchen', BED: 'bedroom', BTH: 'bathroom', YRD: 'backyard', CLB: 'dance', MOV: 'movie', BCH: 'beach' };
const call = (js) => JSON.parse(vm.runInContext(js, ctx));
let vs = 0, vd = [], t1 = Date.now();
for (const [key, v] of Object.entries(P.variants)) {
  const [id, st, txt, ang] = key.split('|');
  vm.runInContext(`__house.geo(${JSON.stringify(ROOM[id.slice(0, 3)] || 'living')})`, ctx);
  const D = call(`__house.variant(${JSON.stringify(id)}, ${JSON.stringify(st || null)}, ${JSON.stringify(txt)}, ${+ang === -30 ? 'null' : +ang})`);
  const ok = D && name(D.src) === v.src && name(D.srcF) === (v.srcF || '') && JSON.stringify(D.bb) === JSON.stringify(v.bb);
  if (ok) vs++; else vd.push(key);
}
console.log(`variants: ${vs} of ${Object.keys(P.variants).length} equal (${Date.now() - t1} ms)` + (vd.length ? '; differ: ' + vd.slice(0, 8).join(', ') : ''));
let rs = 0, rd = [];
for (const [key, R0] of Object.entries(P.renders)) {
  const [t, r, c, v] = key.split('|'), id = t.startsWith('R:') ? t.slice(2) : '';
  vm.runInContext(`__house.geo(${JSON.stringify(ROOM[id.slice(0, 3)] || 'living')})`, ctx);
  const R1 = call(`__house.render(${JSON.stringify(t)}, ${+r}, ${+c}, ${JSON.stringify(v)})`);
  const pick = (o) => o && JSON.stringify({ bb: o.bb, vb: o.vb, shadow: o.shadow, contact: o.contact, foot: o.foot, back: o.back, part: o.part, front: o.front });
  if (pick(R1) === pick(R0)) rs++; else rd.push(key);
}
console.log(`renders: ${rs} of ${Object.keys(P.renders).length} equal` + (rd.length ? '; differ: ' + rd.slice(0, 8).join(', ') : ''));
if (process.argv[2]) {
  const key = process.argv[2], [t, r, c, v] = key.split('|');
  vm.runInContext(`__house.geo('living')`, ctx);
  const R1 = call(`__house.render(${JSON.stringify(t)}, ${+r}, ${+c}, ${JSON.stringify(v)})`), R0 = P.renders[key];
  for (const k of ['bb', 'vb', 'shadow', 'contact', 'foot', 'back', 'part', 'front']) if (JSON.stringify(R1[k]) !== JSON.stringify(R0[k])) console.log(k, JSON.stringify(R1[k]).slice(0, 200), ' VS ', JSON.stringify(R0[k]).slice(0, 200));
}
