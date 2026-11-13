// How far each rig creature's drawing reaches outside its 0-100 box, over every showcase move
// (rig-shuffle.js) plus a tap and a squeeze, in headless Chrome. The lobby's RigCreature `bleed`
// comes from this (2026-10-28: Nimbo's "happy" spreads 23 % past each side, "surprised" 8 % over
// the top). Prints per creature the union bbox (viewBox units, the box is 0..100) and the move
// that reaches furthest on each side. Time runs 2x; about 50 s a creature.
//
//   node tools/rig/bounds.mjs <chrome.exe> <android/app/src/main/assets/rig/host.html> <empty profile dir> nimbo,mittens,...
import { spawn } from 'node:child_process';
const [chrome, host, prof, keyList] = process.argv.slice(2);
const KEYS = keyList.split(',');
const MOVES = ['dance', 'happy', 'hop', 'spin', 'look', 'love', 'cheer', 'surprised', 'turn'];
const MOVE_MS = 4500; // at 2x speed: 9 s of the move
const port = 9341;
const p = spawn(chrome, ['--headless=new', '--disable-gpu', '--no-sandbox', '--allow-file-access-from-files', '--window-size=310,310', `--remote-debugging-port=${port}`, `--user-data-dir=${prof}`, 'about:blank'], { stdio: 'ignore' });
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
let ws;
for (let i = 0; i < 50 && !ws; i++) {
  await sleep(300);
  try {
    const list = await (await fetch(`http://127.0.0.1:${port}/json/list`)).json();
    const page = list.find((t) => t.type === 'page');
    if (page) ws = new WebSocket(page.webSocketDebuggerUrl);
  } catch {}
}
await new Promise((r) => (ws.onopen = r));
let id = 0;
const pending = new Map();
ws.onmessage = (e) => { const m = JSON.parse(e.data); if (pending.has(m.id)) { pending.get(m.id)(m); pending.delete(m.id); } };
const cmd = (method, params = {}) => new Promise((r) => { const i = ++id; pending.set(i, r); ws.send(JSON.stringify({ id: i, method, params })); });
const ev = async (expr) => { const m = await cmd('Runtime.evaluate', { expression: expr, returnByValue: true, awaitPromise: true }); if (m.result.exceptionDetails) throw new Error(JSON.stringify(m.result.exceptionDetails).slice(0, 400)); return m.result.result.value; };

// time runs 2x so the run is shorter
await cmd('Page.addScriptToEvaluateOnNewDocument', { source: `(function(){const pn=performance.now.bind(performance);performance.now=()=>pn()*2;const raf=window.requestAnimationFrame.bind(window);window.requestAnimationFrame=cb=>raf(t=>cb(t*2));})();` });
await cmd('Page.navigate', { url: 'file:///' + host.replace(/\\/g, '/') });
for (let i = 0; i < 100; i++) { if (await ev('!!(window.__rigOut||[]).find(m=>m.type==="ready")').catch(() => false)) break; await sleep(200); }
// sampler: union bbox per "tag"
await ev(`(function(){
  const s=document.createElement('style');s.textContent='ellipse[fill="#6a1b9a"]{display:none!important}';document.head.appendChild(s);
  window.__bb={}; window.__tag='mount';
  const loop=()=>{ const svg=document.querySelector('#stage svg'); if(svg){ try{ const b=svg.getBBox(); if(b.width>0){ const o=window.__bb[window.__tag]||(window.__bb[window.__tag]={x0:1e9,y0:1e9,x1:-1e9,y1:-1e9});
    o.x0=Math.min(o.x0,b.x);o.y0=Math.min(o.y0,b.y);o.x1=Math.max(o.x1,b.x+b.width);o.y1=Math.max(o.y1,b.y+b.height);} }catch(e){} } requestAnimationFrame(loop); };
  loop(); rigHost.shuffle(false); return true; })()`);

const r1 = (v) => Math.round(v * 10) / 10;
for (const key of KEYS) {
  await ev(`(window.__rigOut=[], window.__bb={}, window.__tag='idle', rigHost.mount(${JSON.stringify(key)}), true)`);
  for (let i = 0; i < 60; i++) { if (await ev('!!window.__rigOut.find(m=>m.type==="mounted"||m.type==="error")')) break; await sleep(200); }
  const err = await ev('(window.__rigOut.find(m=>m.type==="error")||{}).message||""');
  if (err) { console.log(key, 'ERROR', err); continue; }
  await sleep(1500);
  for (const mv of MOVES) {
    await ev(`(window.__tag=${JSON.stringify(mv)}, window.RiveRig._last.play(${JSON.stringify(mv)}), true)`);
    await sleep(MOVE_MS);
  }
  // a tap on the belly, then a squeeze (hold, release)
  const ptr = (type, x, y) => `(function(){const w=document.querySelector('#stage > div');const r=w.getBoundingClientRect();w.dispatchEvent(new PointerEvent('${type}',{clientX:r.left+r.width*${x},clientY:r.top+r.height*${y},pointerId:1,bubbles:true,isPrimary:true}));return true;})()`;
  await ev(`(window.__tag='poke', window.RiveRig._last.play('idle'), true)`);
  await sleep(600);
  for (const [x, y] of [[0.5, 0.62], [0.5, 0.3], [0.35, 0.5]]) { await ev(ptr('pointerdown', x, y)); await sleep(60); await ev(ptr('pointerup', x, y)); await sleep(1500); }
  await ev(`(window.__tag='squeeze', true)`);
  await ev(ptr('pointerdown', 0.5, 0.6)); await sleep(1200); await ev(ptr('pointerup', 0.5, 0.6)); await sleep(2500);
  const bb = await ev('window.__bb');
  const all = Object.values(bb).reduce((a, o) => ({ x0: Math.min(a.x0, o.x0), y0: Math.min(a.y0, o.y0), x1: Math.max(a.x1, o.x1), y1: Math.max(a.y1, o.y1) }), { x0: 1e9, y0: 1e9, x1: -1e9, y1: -1e9 });
  const worst = (side, f) => Object.entries(bb).sort((a, b) => f(b[1]) - f(a[1]))[0][0];
  console.log(`${key}: x ${r1(all.x0)}..${r1(all.x1)}  y ${r1(all.y0)}..${r1(all.y1)}  | most left: ${worst('l', (o) => -o.x0)} right: ${worst('r', (o) => o.x1)} top: ${worst('t', (o) => -o.y0)} bottom: ${worst('b', (o) => o.y1)}`);
}
ws.close();
p.kill();
process.exit(0);
