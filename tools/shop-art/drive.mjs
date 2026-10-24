// Step-by-step driver for a Chrome that is already running, so the page keeps its
// state (login, screen) between calls. Start Chrome once:
//   chrome.exe --headless=new --no-sandbox --remote-debugging-port=9333 --window-size=900,1000 --user-data-dir=<tmp>
// and serve the design: cd tools/design-v6 && python -m http.server 8765
// usage: OUT=<dir> node tools/shop-art/drive.mjs <step> [<step> ...]
//   nav:<url>  wait:<ms>  shot:<name>  click:<text>  xy:<x>,<y>  type:<text>  eval:<js>
import { writeFileSync } from 'node:fs';
const OUT = process.env.OUT;
const list = await (await fetch('http://127.0.0.1:' + (process.env.PORT || 9333) + '/json/list')).json();
const page = list.find(t => t.type === 'page');
const ws = new WebSocket(page.webSocketDebuggerUrl);
await new Promise(r => ws.addEventListener('open', r));
let id = 0; const pend = new Map();
ws.addEventListener('message', e => { const m = JSON.parse(e.data); if (m.id && pend.has(m.id)) { pend.get(m.id)(m); pend.delete(m.id); } });
const send = (method, params = {}) => new Promise(r => { const i = ++id; pend.set(i, r); ws.send(JSON.stringify({ id: i, method, params })); });
const sleep = ms => new Promise(r => setTimeout(r, ms));
const evalJs = async js => { const r = await send('Runtime.evaluate', { expression: js, returnByValue: true, awaitPromise: true }); return r.result?.result?.value ?? r.result?.exceptionDetails?.exception?.description; };
// find the smallest visible element whose text matches, searching shadow roots and same-origin iframes
const FIND = `(function(t){const hits=[];function walk(root,ox,oy){for(const el of root.querySelectorAll('*')){if(el.shadowRoot)walk(el.shadowRoot,ox,oy);if(el.tagName==='IFRAME'){try{const r=el.getBoundingClientRect();walk(el.contentDocument,ox+r.left,oy+r.top)}catch(e){}}const tx=(el.innerText||el.textContent||'').trim();if(tx&&tx.toLowerCase()===t.toLowerCase()){const r=el.getBoundingClientRect();if(r.width>0&&r.height>0)hits.push({x:ox+r.left+r.width/2,y:oy+r.top+r.height/2,a:r.width*r.height})}}}walk(document,0,0);hits.sort((a,b)=>a.a-b.a);return hits[0]||null})`;
const tap = async (x, y) => { for (const type of ['mousePressed', 'mouseReleased']) await send('Input.dispatchMouseEvent', { type, x, y, button: 'left', clickCount: 1 }); };
await send('Page.enable');
for (const step of process.argv.slice(2)) {
  const i = step.indexOf(':'), k = step.slice(0, i), v = step.slice(i + 1);
  if (k === 'nav') { await send('Page.navigate', { url: v }); await sleep(1500); }
  else if (k === 'wait') await sleep(+v);
  else if (k === 'shot') { const r = await send('Page.captureScreenshot', { format: 'png' }); writeFileSync(`${OUT}/${v}.png`, Buffer.from(r.result.data, 'base64')); console.log('shot', v); }
  else if (k === 'click') { const h = await evalJs(`${FIND}(${JSON.stringify(v)})`); if (!h) console.log('NOT FOUND', v); else { await tap(h.x, h.y); console.log('clicked', v, Math.round(h.x), Math.round(h.y)); } }
  else if (k === 'xy') { const [x, y] = v.split(',').map(Number); await tap(x, y); console.log('tapped', x, y); }
  else if (k === 'type') await send('Input.insertText', { text: v });
  else if (k === 'eval') console.log(JSON.stringify(await evalJs(v)).slice(0, 3000));
}
ws.close();
