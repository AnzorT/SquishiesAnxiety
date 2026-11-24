// node tools/unity/anim/fixtures.mjs
//
// The Animated port's differential test, JS side. Loads react-native-web's own Animated code (the CommonJS
// build of dist/vendor/react-native/Animated, which is the same code as the ES-module build line for line),
// runs it on a virtual clock, and writes what it does to ./fixtures/*.json. Program.cs (AnimDiff.csproj)
// replays the same inputs through unity/Assets/Scripts/Anim and must match every value and callback.
//
// The browser is stubbed with a virtual clock that has the same rules as SquishSquad.Anim.Ticker:
//   Date.now()            -> clock.now
//   requestAnimationFrame -> queued; tick(now) runs the callbacks queued before it, in order
//   setTimeout            -> fires inside tick(now) once due, in due order, with clock.now = its due time
// tick(now): due timers first, then the frame. The native animated module is missing (as on web), so
// useNativeDriver: true falls back to JS; the one place that still looks at the flag (Animated.loop's
// _isUsingNativeDriver, which on web would start a "native loop" that never loops) is stubbed to false, so
// useNativeDriver: true behaves as JS-driven everywhere. InteractionManager handles are stubbed out.
//
// Inputs are a small scenario language (values, derived nodes, animations, actions at frames, callbacks
// that run more actions); see scenario() below. Both sides interpret it the same way.
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const root = path.join(here, '../../..');
const require = createRequire(import.meta.url);
const VENDOR = path.join(root, 'node_modules/react-native-web/dist/cjs/vendor/react-native/Animated');
const outDir = path.join(here, 'fixtures');
fs.mkdirSync(outDir, { recursive: true });

// ------------------------------------------------------------------ environment stubs
console.warn = () => {};
console.error = () => {};
const InteractionManager = require(path.join(root, 'node_modules/react-native-web/dist/cjs/exports/InteractionManager/index.js'));
const IM = InteractionManager.default || InteractionManager;
IM.createInteractionHandle = () => 1;
IM.clearInteractionHandle = () => {};

const clock = { now: 0, queue: [], running: [], runIndex: -1, nextFrame: 1, timers: [], nextTimer: 1, onError: null };
globalThis.requestAnimationFrame = (cb) => {
  const id = clock.nextFrame++;
  clock.queue.push({ id, cb });
  return id;
};
globalThis.cancelAnimationFrame = (id) => {
  if (!(id > 0)) return;
  let i = clock.queue.findIndex((f) => f.id === id);
  if (i >= 0) { clock.queue.splice(i, 1); return; }
  for (i = clock.runIndex + 1; i < clock.running.length; i++) if (clock.running[i].id === id) { clock.running[i].cb = null; return; }
};
globalThis.setTimeout = (cb, ms) => {
  let d = ms | 0; // ToInt32, as a browser converts the delay
  if (d < 0) d = 0;
  const id = clock.nextTimer++;
  clock.timers.push({ id, due: clock.now + d, cb });
  return id;
};
globalThis.clearTimeout = (id) => {
  const i = clock.timers.findIndex((t) => t.id === id);
  if (i >= 0) clock.timers.splice(i, 1);
};
Date.now = () => clock.now;
function invoke(cb) {
  try { cb(); } catch (e) { if (clock.onError) clock.onError(e); else throw e; }
}
function tick(now) {
  if (!(now >= clock.now)) now = clock.now;
  for (;;) {
    let best = -1;
    clock.timers.forEach((t, i) => {
      if (t.due > now) return;
      if (best < 0 || t.due < clock.timers[best].due || (t.due === clock.timers[best].due && t.id < clock.timers[best].id)) best = i;
    });
    if (best < 0) break;
    const t = clock.timers.splice(best, 1)[0];
    if (t.due > clock.now) clock.now = t.due;
    invoke(t.cb);
  }
  clock.now = now;
  clock.running = clock.queue;
  clock.queue = [];
  for (clock.runIndex = 0; clock.runIndex < clock.running.length; clock.runIndex++) {
    const f = clock.running[clock.runIndex];
    if (f.cb) invoke(f.cb);
  }
  clock.runIndex = -1;
  clock.running = [];
}
function resetClock(t0) {
  Object.assign(clock, { now: t0, queue: [], running: [], runIndex: -1, timers: [], onError: null });
}
const idle = () => clock.queue.length === 0 && clock.timers.length === 0;

const def = (m) => m.default || m;
const Animated = def(require(path.join(VENDOR, 'AnimatedImplementation.js')));
const Easing = def(require(path.join(VENDOR, 'Easing.js')));
const AnimatedInterpolation = def(require(path.join(VENDOR, 'nodes/AnimatedInterpolation.js')));
const SpringAnimation = def(require(path.join(VENDOR, 'animations/SpringAnimation.js')));
const normalizeColor = def(require(path.join(root, 'node_modules/@react-native/normalize-colors/index.js')));

// ------------------------------------------------------------------ helpers
function mulberry32(a) {
  return function () {
    a |= 0; a = (a + 0x6d2b79f5) | 0;
    let t = Math.imul(a ^ (a >>> 15), 1 | a);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}
let rnd = mulberry32(20261123);
const pick = (a) => a[Math.floor(rnd() * a.length)];
const chance = (p) => rnd() < p;
const ri = (lo, hi) => lo + Math.floor(rnd() * (hi - lo + 1));
const rf = (lo, hi) => lo + rnd() * (hi - lo);

// JSON can't hold NaN, ±Infinity or -0: they're written as "~NaN", "~Inf", "~-Inf", "~-0".
function enc(k, v) {
  if (typeof v === 'number') {
    if (Number.isNaN(v)) return '~NaN';
    if (v === Infinity) return '~Inf';
    if (v === -Infinity) return '~-Inf';
    if (Object.is(v, -0)) return '~-0';
  }
  return v;
}
let totalBytes = 0;
function write(name, data) {
  const s = JSON.stringify(data, enc);
  fs.writeFileSync(path.join(outDir, name), s);
  totalBytes += s.length;
}

// ------------------------------------------------------------------ easing specs
// 'linear' | {f:'poly', n} | {f:'elastic', b?} | {f:'back', s?} | {f:'bezier', p:[x1,y1,x2,y2]} | {f:'in'|'out'|'inOut', e}
function easing(spec) {
  if (spec == null) return undefined;
  if (typeof spec === 'string') return Easing[spec];
  switch (spec.f) {
    case 'poly': return Easing.poly(spec.n);
    case 'elastic': return spec.b === undefined ? Easing.elastic() : Easing.elastic(spec.b);
    case 'back': return spec.s === undefined ? Easing.back() : Easing.back(spec.s);
    case 'bezier': return Easing.bezier(...spec.p);
    case 'in': return Easing.in(easing(spec.e));
    case 'out': return Easing.out(easing(spec.e));
    case 'inOut': return Easing.inOut(easing(spec.e));
  }
  throw new Error('easing ' + JSON.stringify(spec));
}
const BASE = ['linear', 'ease', 'quad', 'cubic', 'sin', 'circle', 'exp', 'bounce', 'step0', 'step1'];
const BEZIERS = [
  [0.55, 0, 1, 0.45], [0.42, 0, 1, 1], [0, 0, 1, 1], [0.25, 0.1, 0.25, 1], [0.68, -0.55, 0.265, 1.55], [0.3, 0.3, 0.7, 0.7],
  [1, 0, 0, 1], [0.1, 0.9, 0.9, 0.1], [0, 1, 1, 0], [0.99, 0, 0.01, 1], [0, 0, 0, 1], [1, 1, 1, 0], [0.5, -2, 0.5, 3],
  [0.2, 0.8, 0.3, 1.4], [0.85, 0, 0.15, 1], [0.4, 0, 0.2, 1], [0.34, 1.56, 0.64, 1], [0, 0.5, 0, 0.5],
];
for (let i = 0; i < 22; i++) BEZIERS.push([rnd(), rf(-1, 2), rnd(), rf(-1, 2)].map((v) => Math.round(v * 1e4) / 1e4));
const PARAM = [
  ...[0.5, 2, 3, 4, 5, 7.3].map((n) => ({ f: 'poly', n })),
  { f: 'elastic' }, ...[0, 0.5, 1, 2.7].map((b) => ({ f: 'elastic', b })),
  { f: 'back' }, ...[0, 1.6, 3].map((s) => ({ f: 'back', s })),
  ...BEZIERS.map((p) => ({ f: 'bezier', p })),
];
const LEAVES = [...BASE, ...PARAM];
const EASINGS = [];
for (const e of LEAVES) {
  EASINGS.push(e, { f: 'in', e }, { f: 'out', e }, { f: 'inOut', e });
}
EASINGS.push({ f: 'out', e: { f: 'inOut', e: { f: 'bezier', p: [0.55, 0, 1, 0.45] } } }, { f: 'inOut', e: { f: 'out', e: { f: 'back', s: 1.6 } } },
  { f: 'out', e: { f: 'out', e: 'quad' } }, { f: 'in', e: { f: 'inOut', e: { f: 'elastic', b: 2 } } });
// the ones the app uses most, weighted up for animation scenarios
const APP_EASINGS = [{ f: 'out', e: 'quad' }, { f: 'bezier', p: [0.55, 0, 1, 0.45] }, { f: 'out', e: { f: 'back', s: 1.6 } }, 'bounce',
  { f: 'inOut', e: 'sin' }, 'linear', { f: 'in', e: 'quad' }, { f: 'out', e: 'cubic' }, { f: 'inOut', e: 'quad' }, 'ease', null];

// ------------------------------------------------------------------ 1. easing functions
const XS = [];
for (let k = 0; k <= 1000; k++) XS.push(k / 1000);
XS.push(-1, -0.5, -0.25, -1e-9, 1 + 1e-9, 1.25, 1.5, 2, 3, 0.5 - 1e-12, 0.5 + 1e-12, NaN, Infinity, -Infinity, -0, 1e-300, 5e-324, 0.1 + 0.2);
for (let k = 0; k < 300; k++) XS.push(rf(-0.5, 1.5));
const easingCases = EASINGS.map((spec) => {
  const f = easing(spec);
  return { spec, ys: XS.map((x) => f(x)) };
});
let errorCases = [];
for (const p of [[-0.1, 0, 1, 1], [0, 0, 1.1, 1], [NaN, 0, 1, 1], [2, 0, 0, 1]]) {
  let threw = false;
  try { Easing.bezier(...p); } catch (e) { threw = true; }
  errorCases.push({ p, threw });
}
write('easing.json', { xs: XS, cases: easingCases, bezierErrors: errorCases });

// ------------------------------------------------------------------ 2. interpolation (pure)
const INTERP_CFGS = [];
const ranges = [
  [[0, 1], [0, 100]], [[0, 1], [100, 0]], [[-1, 0, 1], [-50, 0, 50]], [[0, 0.5, 0.5, 1], [0, 1, 2, 3]], [[0, 0.2, 0.8, 1], [1, 1.2, 1.2, 1]],
  [[0, 1], [5, 5]], [[0, 0], [1, 2]], [[-Infinity, 0], [0, 1]], [[0, Infinity], [0, 1]], [[-Infinity, 0, Infinity], [-1, 0, 1]],
  [[0, 1], [-Infinity, 0]], [[0, 1], [0, Infinity]], [[0, 1, 2, 3, 4], [0, 10, 5, 20, -3]], [[100, 300], [0.25, 1.75]],
  [[0, 0.33, 0.66, 1], [0, 1.15, 0.95, 1]], [[-200, -100], [3, 7]], [[1e-9, 2e-9], [0, 1]], [[0, 1e9], [-1e9, 1e9]],
];
const EXTRAP = [{}, { extrapolate: 'clamp' }, { extrapolate: 'identity' }, { extrapolate: 'extend' }, { extrapolateLeft: 'clamp' },
  { extrapolateRight: 'clamp' }, { extrapolateLeft: 'identity', extrapolateRight: 'clamp' }, { extrapolate: 'clamp', extrapolateRight: 'identity' },
  { extrapolate: 'identity', extrapolateLeft: 'extend' }];
for (const [inputRange, outputRange] of ranges) {
  for (const ex of EXTRAP) INTERP_CFGS.push({ inputRange, outputRange, ...ex });
  for (const e of [{ f: 'out', e: 'quad' }, 'bounce', { f: 'bezier', p: [0.55, 0, 1, 0.45] }, { f: 'inOut', e: 'sin' }])
    INTERP_CFGS.push({ inputRange, outputRange, easing: e, ...pick(EXTRAP) });
}
const STRS = [
  ['0deg', '6deg'], ['-45deg', '45deg'], ['0deg', '360deg'], ['0%', '100%'], ['#6b3fa0', '#c25e00'], ['rgba(255, 0, 0, 1)', 'rgba(0, 0, 255, 0.5)'],
  ['red', 'blue'], ['#fff', '#000'], ['#ff000080', '#00ff00'], ['hsl(120, 50%, 50%)', 'hsla(240, 100%, 25%, 0.3)'], ['transparent', 'white'],
  ['rgb(10,20,30)', 'rgb(200, 100, 0)'], ['0px 1px', '10px 20px'], ['1e3px', '2e-3px'], ['scale(1)', 'scale(1.5)'], ['0.5deg', '-0.25deg'],
  ['rgba(0,0,0,0)', 'rgba(255,255,255,1)'], ['#f0f8', '#0000'], ['hwb(90, 10%, 20%)', 'hwb(270, 60%, 70%)'], ['rgba(10, 20, 30 / 0.5)', 'rgba(1, 2, 3 / 1)'],
  ['skyblue', 'rebeccapurple'], ['.5em', '5.em'], ['+3px', '-3px'], ['0deg', '6deg', '-6deg'], ['#000000', '#ffffff', '#ff0000'],
];
for (const outputRange of STRS) {
  const n = outputRange.length;
  const inputRange = n === 2 ? [0, 1] : [0, 0.5, 1];
  for (const ex of [{}, { extrapolate: 'clamp' }, { extrapolate: 'identity' }]) INTERP_CFGS.push({ inputRange, outputRange, ...ex });
  INTERP_CFGS.push({ inputRange, outputRange, easing: { f: 'out', e: { f: 'back', s: 1.6 } } });
}
// error cases
INTERP_CFGS.push(
  { inputRange: [0, 1], outputRange: ['0deg', '1rad'] }, { inputRange: [0, 1, 2], outputRange: [0, 1] }, { inputRange: [1, 0], outputRange: [0, 1] },
  { inputRange: [-Infinity, Infinity], outputRange: [0, 1] }, { inputRange: [0], outputRange: [0] }, { inputRange: [0, 1], outputRange: [-Infinity, Infinity] },
  { inputRange: [0, NaN], outputRange: [0, 1] }, { inputRange: [0, 1], outputRange: ['5px'] }, { inputRange: [0, 1], outputRange: ['1px 2px', '3px'] },
);
const IXS = [];
for (let k = -40; k <= 140; k++) IXS.push(k / 100);
IXS.push(-1e3, -50, -2, 2, 3.5, 50, 150, 250, 301, 1e3, 1e10, -1e10, NaN, Infinity, -Infinity, -0, 1.5e-9, 0.333, 0.666, 5e8);
for (let k = 0; k < 100; k++) IXS.push(rf(-3, 4));
const interpCases = INTERP_CFGS.map((cfg) => {
  try {
    const f = AnimatedInterpolation.__createInterpolation({ ...cfg, easing: easing(cfg.easing) });
    return { cfg, ys: IXS.map((x) => f(x)) };
  } catch (e) {
    return { cfg, error: true };
  }
});
write('interp.json', { xs: IXS, cases: interpCases });

// ------------------------------------------------------------------ 3. String(number), colors, spring params, math
const nums = [0, -0, 1, -1, 0.1, 0.5, 1 / 3, 2 / 3, 100, 1e21, 1e21 - 65536, 999999999999999900000, 1e-6, 1e-7, 9.99e-7, 123e-20, 1.5e300, 5e-324, 2 ** 53, 2 ** 53 + 2, 2 ** 63, 2 ** 70,
  123456789012345680000, 0.000001234, 1.7976931348623157e308, NaN, Infinity, -Infinity, 4.35, 0.1 + 0.2, 1e16, 12345.678e10];
for (let i = 0; i < 6000; i++) nums.push((rnd() - 0.5) * Math.pow(10, ri(-30, 30)));
for (let i = 0; i < 3000; i++) nums.push(Math.round(rf(-1e4, 1e4)) / pick([1, 10, 100, 1000, 3, 7]));
const dv = new DataView(new ArrayBuffer(8));
for (let i = 0; i < 3000; i++) { dv.setUint32(0, (rnd() * 4294967296) >>> 0); dv.setUint32(4, (rnd() * 4294967296) >>> 0); const v = dv.getFloat64(0); if (Number.isFinite(v)) nums.push(v); }
const colors = ['#fff', '#FFFFFF', '#6b3fa0', '#c25e00', '#ff000080', '#f0f8', 'red', 'transparent', 'rebeccapurple', 'notacolor', 'rgb(1,2,3)', 'rgb(300, -5, 12.7)',
  'rgba(1, 2, 3, 0.5)', 'rgba(1 2 3 / 0.25)', 'rgba(1, 2, 3 / 0.25)', 'hsl(120, 50%, 50%)', 'hsl(-30, 150%, -5%)', 'hsla(240, 100%, 25%, 0.3)', 'hsla(240 100% 25% / 2)',
  'hwb(90, 10%, 20%)', 'hwb(270, 60%, 70%)', '#12', '#12345', 'rgb(.5, 1, 1)', 'xrgb(1,2,3)y', 'RED', 'rgba(0,0,0,0)', 'hsl(360, 100%, 100%)', 'hsl(0.5, 33.3%, 66.6%)'];
const springCfgs = [];
for (const friction of [1, 3, 5, 7, 10, 20, 40]) for (const tension of [10, 40, 100, 200, 400]) springCfgs.push({ friction, tension });
for (const speed of [0, 1, 6, 12, 20, 40]) for (const bounciness of [0, 4, 8, 12, 20, 30]) springCfgs.push({ speed, bounciness });
springCfgs.push({}, { speed: 5 }, { bounciness: 3 }, { tension: 300 }, { friction: 2 }, { stiffness: 50 }, { damping: 3 }, { mass: 2 }, { stiffness: 300, damping: 20, mass: 0.5 },
  { stiffness: 1, damping: 0.1, mass: 10 }, { stiffness: 0 }, { damping: -1 }, { mass: 0 }, { stiffness: 100, friction: 7 }, { speed: 10, tension: 40 }, { tension: 1, friction: 1 },
  { tension: 30, friction: 0 });
const springParams = springCfgs.map((cfg) => {
  try {
    const s = new SpringAnimation({ toValue: 1, useNativeDriver: false, ...cfg });
    return { cfg, stiffness: s._stiffness, damping: s._damping, mass: s._mass };
  } catch (e) {
    return { cfg, error: true };
  }
});
const math = [];
for (let i = 0; i < 4000; i++) {
  const x = pick([rf(-1, 1), rf(-30, 30), rf(-800, 800), (rnd() - 0.5) * 10 ** ri(-10, 12)]);
  const y = pick([ri(-3, 8), rf(-2, 6), rf(-50, 50)]);
  math.push([x, y, Math.exp(x), Math.sin(x), Math.cos(x), Math.pow(x, y), Math.pow(Math.abs(x), y)]);
}
write('misc.json', {
  numbers: nums.map((x) => [x, String(x)]),
  colors: colors.map((s) => { const n = normalizeColor(s); return [s, n === null ? null : n]; }),
  springParams,
  math,
});

// ------------------------------------------------------------------ 4. scenarios
// scenario = { name, times: [t0, t1, ...], values: [v0...], xys: [[x, y]...], nodes: [...], anims: [...],
//              listeners: [{v, when?: {op: 'ge'|'le', x, once, actions}}], cbs: {name: [actions]}, actions: [{f, ...}] }
// ref: {v: i} | {n: i} | {c: number} | {xy: i, axis: 'x'|'y'}
// anim: {t: 'timing'|'spring'|'decay', v: i | xy: i, cfg} | {t: 'seq', items} | {t: 'par', items, stopTogether?}
//       | {t: 'stagger', time, items} | {t: 'loop', item, iterations?, resetBeforeIteration?} | {t: 'delay', time}
//       | {ref: k} (the same object as top-level anim k) | null (parallel only)
// action: {do: 'start', a, cb?} | {do: 'stop', a} | {do: 'reset', a} | {do: 'set', v, x} | {do: 'stopAnim', v, cb?}
//       | {do: 'resetAnim', v, cb?} | {do: 'offset', v, x} | {do: 'flatten', v} | {do: 'extract', v}
//       | {do: 'setXY', xy, x, y} | {do: 'stopXY', xy, cb?} | {do: 'unlisten', l}
// events: [frame, 'cb', name, finished] | [frame, 'val', name, value] | [frame, 'xy', name, x, y]
//       | [frame, 'L', listener, value] | [frame, 'err', 'frame'|'action']
const T0S = [0, 1732350000123, 98765.4321];
function clockTimes(mode, t0, n) {
  const ts = [t0];
  let t = t0;
  for (let k = 1; k <= n; k++) {
    switch (mode) {
      case 'fixed60': t = t0 + (k * 1000) / 60; break;
      case 'acc16.67': t += 16.67; break;
      case 'acc8.33': t += 8.33; break;
      case 'int60': t = Math.floor(t0 + (k * 1000) / 60); break;
      case 'fixed120': t = t0 + (k * 1000) / 120; break;
      case 'fixed30': t = t0 + (k * 1000) / 30; break;
      case 'jitter': t += chance(0.03) ? rf(70, 400) : rf(4, 34); break;
      case 'intjitter': t = Math.floor(t + (chance(0.03) ? rf(70, 400) : rf(4, 34))); break;
      default: throw new Error(mode);
    }
    ts.push(t);
  }
  return ts;
}
const MODES = ['fixed60', 'acc16.67', 'acc8.33', 'int60', 'fixed120', 'fixed30', 'jitter', 'intjitter'];

function runScenario(sc, maxFrames, mode) {
  resetClock(sc.t0);
  const events = [];
  let frame = 0;
  const values = sc.values.map((v) => new Animated.Value(v));
  const xys = (sc.xys || []).map(([x, y]) => new Animated.ValueXY({ x, y }));
  const nodes = [];
  const R = (r) => (r.v !== undefined ? values[r.v] : r.n !== undefined ? nodes[r.n] : r.xy !== undefined ? xys[r.xy][r.axis] : r.c);
  for (const n of sc.nodes || []) {
    switch (n.k) {
      case 'interp': nodes.push(R(n.of).interpolate({ ...n.cfg, easing: easing(n.cfg.easing) })); break;
      case 'add': nodes.push(Animated.add(R(n.a), R(n.b))); break;
      case 'sub': nodes.push(Animated.subtract(R(n.a), R(n.b))); break;
      case 'mul': nodes.push(Animated.multiply(R(n.a), R(n.b))); break;
      case 'div': nodes.push(Animated.divide(R(n.a), R(n.b))); break;
      case 'mod': nodes.push(Animated.modulo(R(n.a), n.m)); break;
      case 'diffclamp': nodes.push(Animated.diffClamp(R(n.a), n.min, n.max)); break;
      default: throw new Error(n.k);
    }
  }
  const named = (name, f) => (name == null ? undefined : f);
  const endCb = (name) => named(name, ({ finished }) => { events.push([frame, 'cb', name, finished]); runActions(sc.cbs?.[name]); });
  const anims = [];
  const noNative = (a) => { if (a) a._isUsingNativeDriver = () => false; return a; };
  function build(spec) {
    if (spec === null) return null;
    if (spec.ref !== undefined) return anims[spec.ref];
    const cfgOf = (c) => {
      const o = { useNativeDriver: !!c.native };
      for (const k of Object.keys(c)) if (!['native', 'easing', 'onComplete', 'toX', 'toY', 'velocityX', 'velocityY'].includes(k)) o[k] = c[k];
      if (c.easing !== undefined) o.easing = easing(c.easing);
      if (c.onComplete !== undefined) o.onComplete = endCb(c.onComplete);
      if (c.toX !== undefined) o.toValue = { x: c.toX, y: c.toY };
      if (c.velocityX !== undefined) o.velocity = { x: c.velocityX, y: c.velocityY };
      return o;
    };
    switch (spec.t) {
      case 'timing': case 'spring': case 'decay': {
        const target = spec.xy !== undefined ? xys[spec.xy] : values[spec.v];
        const a = noNative(Animated[spec.t](target, cfgOf(spec.cfg)));
        return a;
      }
      case 'seq': return noNative(Animated.sequence(spec.items.map(build)));
      case 'par': return noNative(Animated.parallel(spec.items.map(build), spec.stopTogether === undefined ? undefined : { stopTogether: spec.stopTogether }));
      case 'stagger': return noNative(Animated.stagger(spec.time, spec.items.map(build)));
      case 'loop': {
        const o = {};
        if (spec.iterations !== undefined) o.iterations = spec.iterations;
        if (spec.resetBeforeIteration !== undefined) o.resetBeforeIteration = spec.resetBeforeIteration;
        return noNative(Animated.loop(build(spec.item), o));
      }
      case 'delay': return noNative(Animated.delay(spec.time));
    }
    throw new Error('anim ' + JSON.stringify(spec));
  }
  for (const spec of sc.anims) anims.push(build(spec));
  const listenerIds = [];
  (sc.listeners || []).forEach((l, idx) => {
    let fired = false;
    listenerIds.push(values[l.v].addListener(({ value }) => {
      events.push([frame, 'L', idx, value]);
      const w = l.when;
      if (w && !(w.once && fired) && (w.op === 'ge' ? value >= w.x : value <= w.x)) { fired = true; runActions(w.actions); }
    }));
  });
  function act(a) {
    switch (a.do) {
      case 'start': anims[a.a].start(endCb(a.cb)); break;
      case 'stop': anims[a.a].stop(); break;
      case 'reset': anims[a.a].reset(); break;
      case 'set': values[a.v].setValue(a.x); break;
      case 'stopAnim': values[a.v].stopAnimation(named(a.cb, (v) => events.push([frame, 'val', a.cb, v]))); break;
      case 'resetAnim': values[a.v].resetAnimation(named(a.cb, (v) => events.push([frame, 'val', a.cb, v]))); break;
      case 'offset': values[a.v].setOffset(a.x); break;
      case 'flatten': values[a.v].flattenOffset(); break;
      case 'extract': values[a.v].extractOffset(); break;
      case 'setXY': xys[a.xy].setValue({ x: a.x, y: a.y }); break;
      case 'stopXY': xys[a.xy].stopAnimation(named(a.cb, (v) => events.push([frame, 'xy', a.cb, v.x, v.y]))); break;
      case 'unlisten': { const l = sc.listeners[a.l]; values[l.v].removeListener(listenerIds[a.l]); break; }
      default: throw new Error(a.do);
    }
  }
  function runActions(list) {
    for (const a of list || []) {
      try { act(a); } catch (e) { events.push([frame, 'err', 'action']); }
    }
  }
  clock.onError = () => events.push([frame, 'err', 'frame']);
  const samples = [];
  const sample = () => {
    const s = [];
    for (const v of values) s.push(v.__getValue());
    for (const p of xys) s.push(p.x.__getValue(), p.y.__getValue());
    for (const n of nodes) { try { s.push(n.__getValue()); } catch (e) { s.push('!'); } }
    samples.push(s);
  };
  const byFrame = new Map();
  for (const a of sc.actions) { if (!byFrame.has(a.f)) byFrame.set(a.f, []); byFrame.get(a.f).push(a); }
  const lastAction = Math.max(0, ...sc.actions.map((a) => a.f));
  const times = clockTimes(mode, sc.t0, maxFrames);
  runActions(byFrame.get(0));
  sample();
  let n = 0;
  for (frame = 1; frame <= maxFrames; frame++) {
    tick(times[frame]);
    runActions(byFrame.get(frame));
    sample();
    n = frame;
    if (frame >= lastAction && idle()) break;
  }
  return { times: times.slice(0, n + 1), samples, events, idle: idle() };
}

// ---- generators
const scenarios = [];
let frames = 0;
function add(name, sc, maxFrames = 400, mode = pick(MODES)) {
  sc.t0 = sc.t0 ?? pick(T0S);
  const r = runScenario(sc, maxFrames, mode);
  frames += r.times.length - 1;
  delete sc.t0;
  scenarios.push({ name: name + ' @' + mode, ...sc, times: r.times, samples: r.samples, events: r.events, idle: r.idle });
}
const start = (a, cb = 'done', f = 0) => ({ f, do: 'start', a, cb });

// timing
const DURS = [0, 1, 16, 100, 250, 333.3, 500, 1000, 2400];
for (let i = 0; i < 360; i++) {
  const e = i < 180 ? EASINGS[i % EASINGS.length] : pick(APP_EASINGS);
  const cfg = { toValue: pick([1, 0, -1, 100, 0.5, 360]), duration: pick(DURS), native: chance(0.5) };
  if (e !== null) cfg.easing = e;
  if (chance(0.15)) delete cfg.duration; // default 500
  if (chance(0.3)) cfg.delay = pick([1, 16, 50, 120.7, 333, -5]);
  const from = chance(0.2) ? cfg.toValue : pick([0, 1, -3, 250]);
  add(`timing ${JSON.stringify(cfg)} from ${from}`, { values: [from], anims: [{ t: 'timing', v: 0, cfg }], actions: [start(0)] }, 400);
}
// springs
const springGrid = [];
for (const friction of [1, 3, 5, 7, 10, 20, 40]) for (const tension of [10, 40, 100, 200, 400]) springGrid.push({ friction, tension });
for (const speed of [1, 6, 12, 20, 40]) for (const bounciness of [0, 4, 8, 12, 20]) springGrid.push({ speed, bounciness });
for (const stiffness of [10, 100, 300, 1000]) for (const damping of [1, 5, 10, 26, 60]) for (const mass of [0.3, 1, 3]) springGrid.push({ stiffness, damping, mass });
springGrid.push({}, { stiffness: 100 }, { damping: 20 }, { mass: 2 }, { speed: 14 }, { bounciness: 10 }, { friction: 4 }, { tension: 90 });
for (const sp of springGrid) {
  const cfg = { toValue: pick([1, 0, 100, -40]), ...sp, native: chance(0.5) };
  if (chance(0.3)) cfg.velocity = pick([-20, -2, 0, 3, 15, 80]);
  if (chance(0.15)) cfg.overshootClamping = true;
  if (chance(0.15)) cfg.restDisplacementThreshold = pick([0.0001, 0.01, 0.5]);
  if (chance(0.15)) cfg.restSpeedThreshold = pick([0.0001, 0.01, 2]);
  if (chance(0.1)) cfg.delay = pick([20, 100, 300]);
  const from = chance(0.08) ? cfg.toValue : pick([0, 1, 0.5, -10, 250]);
  add(`spring ${JSON.stringify(cfg)} from ${from}`, { values: [from], anims: [{ t: 'spring', v: 0, cfg }], actions: [start(0)] }, 600);
}
// decay
for (const velocity of [-3, -0.5, 0, 0.05, 0.4, 1, 2.5, 8]) for (const deceleration of [undefined, 0.99, 0.995, 0.998, 0.9995]) {
  const cfg = { velocity };
  if (deceleration !== undefined) cfg.deceleration = deceleration;
  add(`decay ${JSON.stringify(cfg)}`, { values: [pick([0, 100])], anims: [{ t: 'decay', v: 0, cfg }], actions: [start(0)] }, 900);
}

// interruptions & value operations (hand-written)
const T = (v, toValue, duration, easing, extra = {}) => ({ t: 'timing', v, cfg: { toValue, duration, ...(easing ? { easing } : {}), ...extra } });
const S = (v, toValue, extra = {}) => ({ t: 'spring', v, cfg: { toValue, ...extra } });
for (const mode of MODES) {
  add('timing->timing replace', { values: [0], anims: [T(0, 1, 500), T(0, -1, 300, { f: 'out', e: 'quad' })], actions: [start(0, 'a'), start(1, 'b', 12)] }, 200, mode);
  add('spring->spring velocity carry', { values: [0], anims: [S(0, 1, { friction: 4, tension: 120 }), S(0, 0, { speed: 20, bounciness: 12 })], actions: [start(0, 'a'), start(1, 'b', 9)] }, 400, mode);
  add('timing->spring', { values: [10], anims: [T(0, 100, 800), S(0, 0, { stiffness: 200, damping: 10 })], actions: [start(0, 'a'), start(1, 'b', 20)] }, 400, mode);
  add('spring->timing', { values: [10], anims: [S(0, 100), T(0, 0, 300)], actions: [start(0, 'a'), start(1, 'b', 7)] }, 400, mode);
  add('stopAnimation mid', { values: [0], anims: [T(0, 1, 600, 'bounce')], actions: [start(0, 'a'), { f: 15, do: 'stopAnim', v: 0, cb: 'stopped' }] }, 100, mode);
  add('setValue mid', { values: [0], anims: [S(0, 1)], listeners: [{ v: 0 }], actions: [start(0, 'a'), { f: 6, do: 'set', v: 0, x: 0.25 }, start(0, 'again', 30)] }, 300, mode);
  add('listener stops spring', { values: [0], anims: [S(0, 1, { friction: 3, tension: 200 })], listeners: [{ v: 0, when: { op: 'ge', x: 1.02, once: true, actions: [{ do: 'stopAnim', v: 0, cb: 'byListener' }] } }], actions: [start(0, 'a')] }, 300, mode);
  add('listener stops timing', { values: [0], anims: [T(0, 1, 400)], listeners: [{ v: 0, when: { op: 'ge', x: 0.5, once: true, actions: [{ do: 'stop', a: 0 }] } }, { v: 0 }], actions: [start(0, 'a')] }, 100, mode);
  add('listener sets value at end', { values: [0], anims: [T(0, 1, 200)], listeners: [{ v: 0, when: { op: 'ge', x: 1, once: true, actions: [{ do: 'set', v: 0, x: 7 }] } }], actions: [start(0, 'a')] }, 100, mode);
  add('offsets', { values: [5], anims: [T(0, 10, 300), S(0, 0)], listeners: [{ v: 0 }], actions: [{ f: 0, do: 'offset', v: 0, x: 3 }, start(0, 'a'), { f: 8, do: 'extract', v: 0 }, { f: 9, do: 'offset', v: 0, x: -2 }, start(1, 'b', 10), { f: 40, do: 'flatten', v: 0 }, { f: 60, do: 'resetAnim', v: 0, cb: 'reset' }] }, 200, mode);
  add('delay stopped before start', { values: [0], anims: [T(0, 1, 300, null, { delay: 500 })], actions: [start(0, 'a'), { f: 5, do: 'stop', a: 0 }] }, 60, mode);
  add('spring delay', { values: [0], anims: [S(0, 1, { delay: 250, friction: 5 })], actions: [start(0, 'a')] }, 300, mode);
  add('restart same timing', { values: [0], anims: [T(0, 1, 200, { f: 'inOut', e: 'sin' })], actions: [start(0, 'a'), start(0, 'b', 5), start(0, 'c', 40)] }, 120, mode);
  add('callback chains', { values: [0, 0], anims: [T(0, 1, 150), S(1, 2, { bounciness: 15 }), T(0, 0, 0)], cbs: { a: [{ do: 'start', a: 1, cb: 'b' }], b: [{ do: 'start', a: 2, cb: 'c' }, { do: 'set', v: 1, x: -1 }] }, actions: [start(0, 'a')] }, 300, mode);
  add('callback restarts itself', { values: [0], anims: [T(0, 1, 90)], cbs: { a: [{ do: 'reset', a: 0 }, { do: 'start', a: 0, cb: 'b' }] }, actions: [start(0, 'a')] }, 60, mode);
  add('onComplete + callback', { values: [0], anims: [T(0, 1, 100, null, { onComplete: 'oc' })], actions: [start(0, 'a'), start(0, null, 30)] }, 60, mode);
  add('xy timing', { xys: [[0, 0]], values: [], anims: [{ t: 'timing', xy: 0, cfg: { toX: 100, toY: -50, duration: 400, easing: 'linear', onComplete: 'oc' } }], actions: [start(0, 'a'), { f: 10, do: 'stopXY', xy: 0, cb: 'xystop' }, start(0, 'b', 12)] }, 200, mode);
  add('xy spring', { xys: [[10, 20]], values: [], anims: [{ t: 'spring', xy: 0, cfg: { toX: 0, toY: 0, friction: 6, velocityX: 3, velocityY: -8 } }, { t: 'spring', xy: 0, cfg: { toX: 50, toY: 50, velocity: 1 } }], actions: [start(0, 'a'), start(1, 'b', 20), { f: 50, do: 'setXY', xy: 0, x: 1, y: 2 }] }, 400, mode);
  add('nodes', {
    values: [0, 2], xys: [[1, 1]],
    nodes: [
      { k: 'interp', of: { v: 0 }, cfg: { inputRange: [0, 1], outputRange: ['0deg', '6deg'] } },
      { k: 'interp', of: { v: 0 }, cfg: { inputRange: [0, 0.5, 1], outputRange: [1, 1.3, 1], extrapolate: 'clamp' } },
      { k: 'add', a: { v: 0 }, b: { c: 5 } }, { k: 'mul', a: { v: 0 }, b: { v: 1 } }, { k: 'sub', a: { n: 3 }, b: { v: 1 } },
      { k: 'div', a: { v: 1 }, b: { v: 0 } }, { k: 'mod', a: { n: 2 }, m: 0.7 }, { k: 'diffclamp', a: { v: 0 }, min: -0.3, max: 0.6 },
      { k: 'interp', of: { n: 4 }, cfg: { inputRange: [-2, 0], outputRange: ['#6b3fa0', '#c25e00'], easing: 'quad' } },
      { k: 'interp', of: { n: 1 }, cfg: { inputRange: [1, 1.3], outputRange: ['rgba(0, 0, 0, 0)', 'rgba(255, 128, 0, 0.75)'] } },
      { k: 'interp', of: { xy: 0, axis: 'y' }, cfg: { inputRange: [0, 1], outputRange: [0, -40], extrapolateLeft: 'identity' } },
      { k: 'interp', of: { n: 0 }, cfg: { inputRange: [0, 1], outputRange: [0, 1] } },
    ],
    anims: [{ t: 'loop', item: { t: 'seq', items: [T(0, 1, 300, { f: 'inOut', e: 'sin' }), T(0, -0.5, 300, 'bounce')] }, iterations: 3 },
      S(1, -2, { friction: 2 }), { t: 'timing', xy: 0, cfg: { toX: 3, toY: -3, duration: 250 } }],
    actions: [start(0, 'loop'), start(1, 's'), start(2, 'xy', 3)],
  }, 400, mode);
  add('loop(seq) no reset errors', { values: [0], anims: [{ t: 'loop', item: { t: 'seq', items: [T(0, 1, 50), T(0, 0, 50)] }, resetBeforeIteration: false, iterations: 3 }], actions: [start(0, 'a')] }, 60, mode);
  add('loop no reset', { values: [0], anims: [{ t: 'loop', item: T(0, 1, 100), resetBeforeIteration: false, iterations: 4 }, { t: 'loop', item: { t: 'par', items: [T(0, 1, 50)] }, resetBeforeIteration: false, iterations: 2 }], actions: [start(0, 'a'), start(1, 'b', 30)] }, 60, mode);
  add('loop forever stopped', { values: [0, 0], anims: [{ t: 'loop', item: { t: 'seq', items: [T(0, 1, 400, { f: 'out', e: 'quad' }), T(0, 0, 400, { f: 'in', e: 'quad' })] } }, { t: 'loop', item: S(1, 1, { tension: 300 }) }], actions: [start(0, 'a'), start(1, 'b'), { f: 150, do: 'stop', a: 0 }, { f: 200, do: 'stop', a: 1 }] }, 260, mode);
  add('loop iterations 0', { values: [0], anims: [{ t: 'loop', item: T(0, 1, 100), iterations: 0 }], actions: [start(0, 'a')] }, 10, mode);
  add('parallel stopTogether', { values: [0, 0, 0], anims: [{ t: 'par', items: [T(0, 1, 300), T(1, 1, 600), S(2, 1)] }, T(1, 5, 100)], actions: [start(0, 'p'), start(1, 'steal', 10)] }, 200, mode);
  add('parallel no stopTogether', { values: [0, 0, 0], anims: [{ t: 'par', stopTogether: false, items: [T(0, 1, 300), T(1, 1, 600), S(2, 1)] }, T(1, 5, 100)], actions: [start(0, 'p'), start(1, 'steal', 10)] }, 200, mode);
  add('parallel null + restart', { values: [0, 0], anims: [{ t: 'par', items: [null, T(0, 1, 100), T(1, 1, 50)] }], actions: [start(0, 'p'), start(0, 'q', 20), { f: 22, do: 'stop', a: 0 }, { f: 23, do: 'reset', a: 0 }, start(0, 'r', 24)] }, 100, mode);
  add('empty seq/par', { values: [0], anims: [{ t: 'seq', items: [] }, { t: 'par', items: [] }, { t: 'stagger', time: 50, items: [] }], actions: [start(0, 'a'), start(1, 'b'), start(2, 'c')] }, 5, mode);
  add('stagger', { values: [0, 0, 0, 0], anims: [{ t: 'stagger', time: 80, items: [0, 1, 2, 3].map((v) => S(v, 1, { friction: 5 })) }], actions: [start(0, 'st'), { f: 12, do: 'set', v: 2, x: 0.5 }] }, 300, mode);
  add('sequence stop & reset', { values: [0, 0], anims: [{ t: 'seq', items: [T(0, 1, 100), { t: 'delay', time: 100 }, T(1, 1, 100), S(0, 0)] }], actions: [start(0, 'a'), { f: 20, do: 'stop', a: 0 }, { f: 25, do: 'reset', a: 0 }, start(0, 'b', 26), start(0, 'c', 120)] }, 300, mode);
  add('delay only', { values: [], anims: [{ t: 'delay', time: 250 }, { t: 'delay', time: 0 }, { t: 'delay', time: 16.9 }], actions: [start(0, 'a'), start(1, 'b'), start(2, 'c')] }, 40, mode);
  add('timing zero duration with delay', { values: [0], listeners: [{ v: 0 }], anims: [T(0, 3, 0, null, { delay: 100 }), T(0, 4, 0)], actions: [start(0, 'a'), start(1, 'b', 2)] }, 30, mode);
  add('unlisten', { values: [0], listeners: [{ v: 0 }, { v: 0, when: { op: 'ge', x: 0.3, once: false, actions: [{ do: 'unlisten', l: 0 }] } }], anims: [T(0, 1, 200)], actions: [start(0, 'a')] }, 40, mode);
  add('long epoch spring hitch', { t0: 1732350000123, values: [0], anims: [S(0, 1, { stiffness: 1000, damping: 5, mass: 0.2 })], actions: [start(0, 'a')] }, 900, mode);
}

// random compositions
function randLeaf(nv) {
  const v = ri(0, nv - 1);
  const k = rnd();
  if (k < 0.62) {
    const cfg = { toValue: pick([0, 1, -1, 0.5, 2, 100]), duration: pick([0, 16, 50, 120, 200, 333, 500]), native: chance(0.4) };
    const e = pick(APP_EASINGS.concat(EASINGS.slice(0, 30)));
    if (e !== null) cfg.easing = e;
    if (chance(0.2)) cfg.delay = pick([10, 40, 100]);
    if (chance(0.08)) cfg.onComplete = 'oc' + ri(0, 3);
    return { t: 'timing', v, cfg };
  }
  if (k < 0.9) {
    const cfg = { toValue: pick([0, 1, -1, 0.5, 2]), ...pick(springGrid.slice(0, 60)) };
    if (chance(0.2)) cfg.velocity = pick([-5, 5, 12]);
    if (chance(0.1)) cfg.overshootClamping = true;
    if (chance(0.1)) cfg.delay = 50;
    return { t: 'spring', v, cfg };
  }
  if (k < 0.97) return { t: 'delay', time: pick([0, 16, 60, 150]) };
  return { t: 'decay', v, cfg: { velocity: pick([-1, 0.5, 2]), deceleration: pick([0.99, 0.997]) } };
}
function randAnim(depth, nv) {
  if (depth >= 3 || chance(0.35)) return randLeaf(nv);
  const k = rnd();
  const items = () => Array.from({ length: ri(1, 4) }, () => randAnim(depth + 1, nv));
  if (k < 0.35) return { t: 'seq', items: items() };
  if (k < 0.65) return { t: 'par', items: items(), ...(chance(0.4) ? { stopTogether: chance(0.5) } : {}) };
  if (k < 0.8) return { t: 'stagger', time: pick([0, 30, 70, 120.5]), items: items() };
  // (a forever loop ends each iteration with a timing that needs a frame, so it can't recurse synchronously)
  const forever = chance(0.3);
  if (forever) return { t: 'loop', item: { t: 'seq', items: [randAnim(depth + 1, nv), T(ri(0, nv - 1), 1, 100)] }, iterations: -1 };
  return { t: 'loop', item: randAnim(depth + 1, nv), iterations: ri(1, 4), resetBeforeIteration: chance(0.7) };
}
for (let i = 0; i < 520; i++) {
  const nv = ri(1, 4);
  const anims = Array.from({ length: ri(1, 3) }, () => randAnim(0, nv));
  if (chance(0.3)) anims.push({ t: 'seq', items: [{ ref: 0 }, randLeaf(nv)] });
  const actions = [start(0, 'a0')];
  for (let k = 1; k < anims.length; k++) actions.push(start(k, 'a' + k, ri(0, 60)));
  for (let k = 0; k < ri(0, 4); k++) {
    const f = ri(1, 150);
    const r = rnd();
    if (r < 0.25) actions.push({ f, do: 'stop', a: ri(0, anims.length - 1) });
    else if (r < 0.4) actions.push({ f, do: 'reset', a: ri(0, anims.length - 1) });
    else if (r < 0.55) actions.push(start(ri(0, anims.length - 1), 'r' + k, f));
    else if (r < 0.7) actions.push({ f, do: 'set', v: ri(0, nv - 1), x: rf(-1, 2) });
    else if (r < 0.85) actions.push({ f, do: 'stopAnim', v: ri(0, nv - 1), cb: 'sv' + k });
    else actions.push({ f, do: 'offset', v: ri(0, nv - 1), x: rf(-1, 1) });
  }
  // anything still looping forever is stopped eventually
  actions.push({ f: 300, do: 'stop', a: 0 });
  for (let k = 1; k < anims.length; k++) actions.push({ f: 300, do: 'stop', a: k });
  const listeners = chance(0.4) ? [{ v: 0 }] : [];
  const cbs = chance(0.3) ? { a0: [{ do: 'start', a: anims.length - 1, cb: 'chain' }] } : {};
  const nodes = chance(0.5) ? [{ k: 'interp', of: { v: 0 }, cfg: { inputRange: [-1, 0, 1, 2], outputRange: pick([[0, 1, 0.2, 3], ['0deg', '10deg', '-5deg', '360deg']]), extrapolate: pick(['clamp', 'extend', 'identity']) } }] : [];
  add(`random #${i}`, { values: Array.from({ length: nv }, () => pick([0, 1, 0.5])), anims, actions, listeners, cbs, nodes }, 420);
}

// split scenarios into files of ~1000 entries' worth of frames
let file = 0, batch = [], batchFrames = 0;
for (const s of scenarios) {
  batch.push(s);
  batchFrames += s.times.length;
  if (batchFrames > 40000) { write(`scenarios-${file++}.json`, batch); batch = []; batchFrames = 0; }
}
if (batch.length) write(`scenarios-${file++}.json`, batch);

const evCount = scenarios.reduce((n, s) => n + s.events.length, 0);
console.log(`easing: ${easingCases.length} functions x ${XS.length} inputs; interpolation: ${interpCases.length} configs x ${IXS.length} inputs;`
  + ` numbers: ${nums.length}; colors: ${colors.length}; spring params: ${springParams.length}; math: ${math.length}`);
console.log(`scenarios: ${scenarios.length} (${frames} frames, ${evCount} callback/listener events) in ${file} files; ${(totalBytes / 1e6).toFixed(1)} MB -> ${path.relative(root, outDir)}`);
