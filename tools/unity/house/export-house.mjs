// The Squad House's data and pictures for the Unity port (HOUSE_PORT_PLAN.md stage 1), and the page's own answers the
// C# port is checked against (tools/unity/house-test).
//
//   node tools/unity/house/export-house.mjs            fixtures from tools/unity/house/fixtures (fixtures.mjs makes them)
//   node tools/unity/house/export-house.mjs --only decorated
//
// Writes unity/Assets/Resources/House/:
//   catalog.json     the renovation catalog rows as the page has them (CSV + RD.edit + the app's config, minus code)
//   house-cat.json   rooms, slots, defaults, the roster order, the piece table: every renovation piece as rnReg
//                    registers it (size, mount, layer, seats, use spot...), its default drawing's box / top / screen /
//                    tight box, topOf
//   house-pieces.json  the drawings the fixtures' rooms use: RenoDraw variants (id|state|text|angle -> pictures and
//                    boxes), house4 renders (type|angle|colour|state -> box, gradients, legacy paths), gradients
//   shells.json      room shells (X.shell output) by the shell's own key
//   tex.json         renovated surfaces (walls, floors, ceilings, fences, ground, yard lights) -> their pictures
//   pics/<hash>.xml  each picture as SVG (SMIL removed), or pics/<hash>.png when it uses what the vector renderer can't
//                    draw yet (text, blend modes): rendered by Chrome at PNG_K px per room unit
// and tools/unity/house/captures/<fixture>/ (gitignored): saved.json (the save after load), <room>-<day|night>.json (the
// room's markup: every item's box, scale, z, pictures; the shell), .png (Chrome's room with creatures and HUD hidden).
import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
import { fileURLToPath } from 'node:url';
import { openHouse, launch, REPO } from './harness.mjs';
import { loadFixtures } from './fixtures.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const OUT = path.join(REPO, 'unity/Assets/Resources/House');
const CAP = path.join(HERE, 'captures');
const PNG_K = 3;   // px per room unit for PNG pictures (the A15 shows the room at ~2.75 px per unit, camera 1)
const arg = k => { const i = process.argv.indexOf('--' + k); return i > 0 ? process.argv[i + 1] : null; };
const ONLY = arg('only');
export const MENU_K = (832 / 852).toFixed(4);
const NOPIX = process.argv.includes('--no-shots');

const sha = s => crypto.createHash('sha1').update(s).digest('hex').slice(0, 16);
const GIF = 'data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==';
// what the vector renderer (unity/Assets/Scripts/Vector) can't draw yet: those pictures ship as PNG
const UNSUPPORTED = [['<text', 'text'], ['mix-blend-mode', 'blend'], ['<foreignObject', 'foreignObject'], ['feBlend', 'feBlend'], ['feComposite', 'feComposite'], ['feMorphology', 'feMorphology'], ['feMerge', 'feMerge'], ['feOffset', 'feOffset'], ['feFlood', 'feFlood'], ['feComponentTransfer', 'feComponentTransfer']];
const stripSmil = s => s.replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*\/>/g, '').replace(/<(animate|animateTransform|animateMotion|set|animateColor)\b[^>]*>[\s\S]*?<\/\1>/g, '');
// ids renamed in order of appearance: RenoDraw numbers some gradients from a page-wide counter (q13_c1, q71_c1), so the
// same drawing made at another moment differs only in its ids
const canonIds = s => { const m = new Map(); for (const x of s.matchAll(/\bid="([^"]+)"/g)) if (!m.has(x[1])) m.set(x[1], 'k' + m.size);
  return s.replace(/(\bid=")([^"]+)(")|(url\(#)([^)]+)(\))|(href="#)([^"]+)(")/g, (all, a1, a2, a3, b1, b2, b3, c1, c2, c3) => a1 ? a1 + (m.get(a2) || a2) + a3 : b1 ? b1 + (m.get(b2) || b2) + b3 : c1 + (m.get(c2) || c2) + c3); };
const svgOfUri = u => { const i = u.indexOf(','); const head = u.slice(0, i + 1), body = u.slice(i + 1); return /;base64,$/.test(head) ? Buffer.from(body, 'base64').toString('utf8') : decodeURIComponent(body); };

// ---- what runs in the page --------------------------------------------------------------------------------------
// the static tables and the piece table (once)
function pageTables() {
  const sh = window.__sh, X = sh.X, Q = window.SquishSquad;
  const clean = o => JSON.parse(JSON.stringify(o, (k, v) => typeof v === 'function' ? undefined : v));
  const rows = sh.rows.map(r => { const o = {}; for (const k in r) if (k !== '__orig' && typeof r[k] !== 'function') o[k] = r[k]; return clean(o); });
  const pieces = {};
  for (const r of sh.rows) {
    const D = sh.rnDraw(r, 0); if (!D || D.surf) continue;
    const A = sh.rnReg(r.id); if (!A) continue;
    const t = 'R:' + r.id, a = clean(A);
    a.topOf = X.topOf(t);
    a.draw = { bb: D.bb, top: D.top || null, screen: D.screen || null, mount: D.mount || '', split: !!(D.srcF && D.srcB), tb: sh.tightBB(D, 1), arch: D.arch };
    pieces[t] = a;
  }
  const surf = {}; Object.values(X.SURF).forEach(m => surf[m.id] = { arch: m.arch, room: m.room, start: !!m.start, hidden: !!m.hidden });
  const ir = Object.keys(X.SPEC).filter(k => X.SPEC[k] && X.SPEC[k].ir);
  const roster = Q.ROSTER.map(c => ({ key: c.key, name: c.name, art: !!c.art }));
  const legacy = {}; ['dentedBowl'].forEach(t => { const D = X.CAT[t]; if (D) legacy[t] = clean(Object.assign({}, D, { topOf: X.topOf(t) })); });
  return { rows, cat: { consts: { FS: X.FS, SA: X.SA, CA: X.CA, VW: X.VW, FY0: X.FY0, FY1: X.FY1 }, rooms: clean(X.ROOMS), rkeys: X.RKEYS, slotsIn: X.SLOTS_IN, slotsOut: X.SLOTS_OUT, def: X.DEF, winIr: ir, surf, roster, pieces, legacy, bands: X.BANDS.map(b => ({ k: b.k, n: b.n, lv: b.lv })) } };
}

// one room as it is drawn now: the drawing data the C# needs (variants, renders, shell, surfaces) and the page's markup
function pageRoom() {
  const sh = window.__sh, X = sh.X, S = sh.state, rk = S.cur, H = sh.H;
  const uris = {}; const U = u => { if (!u || typeof u !== 'string') return u; if (!u.startsWith('data:')) return u; if (u === 'data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==') return 'gif:empty'; let h = 0x811c9dc5, h2 = 0; for (let i = 0; i < u.length; i++) { h = Math.imul(h ^ u.charCodeAt(i), 0x01000193) >>> 0; h2 = (h2 * 31 + u.charCodeAt(i)) >>> 0; } const k = 'u' + h.toString(16).padStart(8, '0') + h2.toString(16).padStart(8, '0'); uris[k] = u; return k; };
  const clean = o => JSON.parse(JSON.stringify(o, (k, v) => typeof v === 'function' ? undefined : v));
  // the drawing variants the room's pieces use, keyed the way the C# asks for them
  const variants = {}, renders = {}, grads = {};
  const isNight = rk === 'beach' ? !!H.night.bedroom : !!H.night[rk];
  for (const it of sh.roomItems()) {
    const D = X.CAT[it.t]; if (!D) continue;
    let v = sh.vars[it.id] || ''; if (D.arch === 'nightstand' && isNight) v = 'on'; if (D.party && S.party) v = 'on';
    const rkey = it.t + '|' + it.r + '|' + it.c + '|' + v, R = X.render(it.t, it.r, it.c, v);
    renders[rkey] = { bb: R.bb, vb: R.vb, gids: R.gids, back: D.reno ? [] : R.back, part: D.reno ? [] : R.part, front: D.reno ? [] : R.front, glow: R.glow, face: R.face, shadow: R.shadow, contact: R.contact, foot: R.foot };
    R.gids.forEach(g => { const G = X._GR.get(g); if (G) grads[g] = G; });
    if (!D.reno) continue;
    const r = sh.byId.get(D.reno), sp = sh.canSpin(it), rot = sp ? it.r : D.mount ? (it.w ? it.r : 0) : null, st = r ? sh.rStOf(it, r) : null;
    let ra = rot == null ? -30 : (((+rot || 0) % 360) + 360) % 360; if (ra === 330) ra = -30;
    const Dr = sh.rnDraw(r, it.c, rot, st, it.txt);
    const vkey = D.reno + '|' + (st || '') + '|' + (it.txt || '') + '|' + ra;
    const sF = Dr && Dr.srcF && Dr.srcB ? 1 : 0;
    variants[vkey] = { src: U(Dr ? (sF ? Dr.srcB : Dr.src || '') : ''), srcF: sF ? U(Dr.srcF) : '', whole: U(Dr && Dr.src || ''), bb: Dr && Dr.bb, tb: D.mount ? sh.tightBB(Dr, 1) : null, top: Dr && Dr.top || null };
  }
  const shell = sh.shellOf(rk), rt = sh.rtVals(shell), cl = sh.clVals(shell, rk);
  // the surfaces (renovated wall / floor / ...) this room shows, as rtVals reads them
  const tex = {};
  const RT = shell.beach ? {} : (H.rtex || {})[rk] || {}, sw = (H.surf || {})[rk] || {};
  const ids = new Set(Object.values(RT)); ['win', 'ylight', 'light'].forEach(k => { const v = String(sw[k] || ''); if (v.startsWith('rv_')) ids.add(v.slice(3)); });
  for (const id of ids) { const r = sh.byId.get(id); if (!r) continue; const D0 = sh.rnDraw(r, 0) || {};
    tex[id] = { wall: U(sh.rnTex(id, 'wall')), wallS: U(sh.rnTex(id, 'wallS')), board: U(sh.rnTex(id, 'board')), floor: U(sh.rnTex(id, 'floor')), ceil: U(sh.rnTex(id, 'ceil')), fence: U(sh.rnTex(id, 'fence')), fenceR: U(sh.rnTex(id, 'fenceR')),
      fW: D0.fW || 0, fWR: D0.fWR || 0, ceilRoom: !!D0.ceilRoom, ceilBase: D0.ceilBase || '', ceilTrim: D0.ceilTrim || '', wallOne: U(D0.wallOne || ''), wallOneR: U(D0.wallOneR || ''), wallOneFull: !!D0.wallOneFull, wallRnd: U(D0.wallRnd || ''),
      floorRoom: D0.floorRoom ? clean({ bg: D0.floorRoom.bg, layers: D0.floorRoom.layers.map(l => Object.assign({}, l, { url: U(l.url) })) }) : null, ylRoom: U(D0.ylRoom || ''), win19: !!D0.win19, src: U(D0.src || ''),
      wallL: D0.wallL || '', wallR: D0.wallR || '', wallRoom: D0.wallRoom || '', fH: D0.fH || 0 }; }
  // the page's markup: the room box, the shell's svg, every item (its div, svg, children), toys, texts, overlays
  const frame = sh.frameRef.current, room = frame.querySelector(':scope > div'), fr = frame.getBoundingClientRect();
  const attrs = el => { const o = {}; for (const a of el.attributes) o[a.name] = /^(href|xlink:href)$/.test(a.name) ? U(a.value) : a.value; return o; };
  const tree = el => ({ tag: el.tagName.toLowerCase(), a: attrs(el), c: [...el.children].map(tree) });
  const items = [...room.querySelectorAll(':scope > div[style*="z-index: 3"] > div[data-u], :scope > div[style*="z-index: 3"] > div[data-uf]')].map(tree);
  const toys = [...room.querySelectorAll(':scope > div[style*="z-index: 3"] > div[style*="width: 40px"]')].map(tree);
  const svg = room.querySelector(':scope > svg');
  const texts = [...room.querySelectorAll(':scope > div[style*="inset: 0px; pointer-events: none;"] > div')].map(e => ({ style: e.getAttribute('style'), t: e.textContent }));
  const extra = [...frame.children].filter(e => e !== room).map(e => e.getAttribute('style') || '').filter(s => /z-index: 860/.test(s));
  const roomDivs = [...room.children].filter(e => e.tagName === 'DIV' && /-220px/.test(e.getAttribute('style') || '')).map(tree);
  const foods = window.RenoDraw.food ? [0, 1, 2, 3, 4].map(i => { const F = window.RenoDraw.food(i); return F ? { src: U(F.src), w: F.w, h: F.h } : null; }) : [];
  const sgs = [...room.querySelectorAll('div[data-u] > div')].map(e => ({ id: e.parentElement.getAttribute('data-u'), style: e.getAttribute('style'), t: e.textContent, span: e.firstElementChild && e.firstElementChild.getAttribute('style') }));
  return {
    rk, night: isNight, frame: { x: fr.left, y: fr.top, w: fr.width, h: fr.height }, roomStyle: room.getAttribute('style'),
    shellKey: Object.keys(window.__shellKeys || {}).length, shell: clean(shell), rt: clean(Object.assign({}, rt, { wall: U(rt.wall), wallS: U(rt.wallS), floor: U(rt.floor), ceil: U(rt.ceil), fence: U(rt.fence), fenceR: U(rt.fenceR), win: U(rt.win), wallOne: U(rt.wallOne), wallOneR: U(rt.wallOneR), wallRnd: U(rt.wallRnd), floorC: U(rt.floorC), ceilC: U(rt.ceilC), yl: U(rt.yl) })), cl,
    gls: rk === 'dance' ? U(sh.glassSky()) : '', glsKey: sh.seasonNow() + '|' + !!(H.night && H.night.bedroom), camK: sh.camK, variants, renders, grads, tex,
    dom: { svg: svg ? tree(svg) : null, items, toys, texts, extra, roomDivs, sgs }, uris, foods,
  };
}

// the room's markup from the page itself: the room box (the shell's svg, the items, toys, creatures) and the night
// overlay, as the template has them (unity/Assets/Scripts/House/HouseTemplate.cs evaluates it)
function roomTemplate() {
  const f = path.join(REPO, 'webgame/.cache'), dir = fs.readdirSync(f).find(d => d.startsWith('Squish-Squad-Prototype'));
  const L = fs.readFileSync(path.join(f, dir, 'squish-squad/Squad House v6.dc.html'), 'utf8').split('\n');
  const a = L.findIndex(l => l.includes('<div style="position:absolute; left:0; top:50px; width:852px; height:393px; transform:scale({{ camK }})'));
  const b = L.findIndex((l, i) => i > a && l.includes('<sc-if value="{{ night.on }}"'));
  if (a < 0 || b < 0) throw new Error('room template not found in Squad House v6.dc.html (the design changed?)');
  return '<!-- Squad House v6.dc.html lines ' + (a + 1) + '-' + (b + 1) + ' (tools/unity/house/export-house.mjs) -->\n' + L.slice(a, b + 1).join('\n') + '\n';
}

// ---- node side ---------------------------------------------------------------------------------------------------
const pics = new Map();   // name -> { kind: 'xml' | 'png', why, svg }
function picture(uri) {
  if (!uri || uri === 'gif:empty') return '';
  if (!uri.startsWith('data:image/svg+xml')) { const n0 = sha(uri); if (!pics.has(n0)) pics.set(n0, { kind: 'raw', uri }); return n0; }
  // named by the picture without its SMIL: drawings that differ only in their animations' start times are one still
  const svg = canonIds(stripSmil(svgOfUri(uri))), name = sha(svg);
  if (pics.has(name)) return name;
  const why = UNSUPPORTED.filter(([k]) => svg.includes(k)).map(([, w]) => w);
  pics.set(name, { kind: why.length ? 'png' : 'xml', why, svg });
  return name;
}

async function main() {
  const fixtures = loadFixtures().filter(f => !ONLY || f.name === ONLY);
  const b = await launch();
  fs.rmSync(path.join(OUT, 'pics'), { recursive: true, force: true });
  fs.mkdirSync(path.join(OUT, 'pics'), { recursive: true });
  let tables = null;
  let foods = [];
  const gls = {}, shells = {}, variants = {}, renders = {}, grads = {}, tex = {};
    for (const fx of fixtures) {
    const H = await openHouse(b, fx, { room: fx.room || 'living' });
    // every write of the save, with the virtual time (the first one is the house as loaded)
    await H.ready();
    await H.frames(1, 0);
    // the menu's framing (Main Menu.dc.html .mm-house-in): the 852 x 393 house box scaled to the menu frame's width
    // (bare menu frame = the whole screen, 832 x 384 on the A15): scale((832 / 852).toFixed(4)) from the top-left
    await H.page.evaluate(k => { const f = window.__sh.frameRef.current; f.style.transform = 'scale(' + k + ')'; f.style.transformOrigin = '0 0'; }, MENU_K);
    const saved = await H.page.evaluate(() => localStorage.getItem('ssHouse5b'));
    const dir = path.join(CAP, fx.name); fs.mkdirSync(dir, { recursive: true });
    fs.writeFileSync(path.join(dir, 'saved.json'), saved || 'null');
    // what the C# load needs besides the save: the level, the creatures owned (roster ids, SquishSquad.ownedIds()), the room asked for
    const meta = await H.page.evaluate(() => ({ owned: window.SquishSquad.ownedIds(), level: window.__sh.lvl(), cur: window.__sh.state.cur }));
    fs.writeFileSync(path.join(dir, 'meta.json'), JSON.stringify({ ...meta, startRoom: fx.room || 'living', input: fx.house }));
    if (!tables) {
      const t0 = Date.now();
      tables = await H.page.evaluate(pageTables);
      console.log('tables', Date.now() - t0, 'ms:', tables.rows.length, 'rows,', Object.keys(tables.cat.pieces).length, 'pieces');
    }
    const open = await H.page.evaluate(() => ['living', 'kitchen', 'bathroom', 'bedroom', 'backyard', 'dance', 'movie', 'beach'].filter(r => window.__sh.isOpen(r)));
    for (const rk of open) {
      for (const night of [false, true]) {
        await H.page.evaluate(({ rk, night }) => { const sh = window.__sh; if (sh.state.cur !== rk) sh.enterRoom(rk, null, null); const k = rk === 'beach' ? 'bedroom' : rk; if (night) sh.H.night[k] = 1; else delete sh.H.night[k]; sh.setState(s => ({ ver: s.ver + 1 })); }, { rk, night });
        await H.frames(3);
        const R = await H.page.evaluate(pageRoom);
        // pictures: the page's data URIs -> named pictures
        const name = k => (k && R.uris[k] ? picture(R.uris[k]) : k === 'gif:empty' ? '' : k);
        const walk = o => { if (Array.isArray(o)) return o.map(walk); if (o && typeof o === 'object') { const n = {}; for (const k in o) n[k] = walk(o[k]); return n; } return typeof o === 'string' && /^u[0-9a-f]{16}$/.test(o) ? name(o) : o; };
        const W = walk({ variants: R.variants, tex: R.tex, rt: R.rt, gls: R.gls, dom: R.dom, foods: R.foods });
        foods = W.foods;
        if (R.rk === 'dance') gls[R.glsKey] = W.gls;
        Object.assign(variants, W.variants); Object.assign(renders, R.renders); Object.assign(grads, R.grads); Object.assign(tex, W.tex);
        const key = R.shell && (await H.page.evaluate(rk => { const sh = window.__sh, X = sh.X, RT = (sh.H.rtex || {})[rk] || {}, sf = Object.assign({}, sh.H.surf[rk] || {}); if (RT.wall) sf.wall = 'w_plaster'; if (RT.floor) sf.floor = 'f_oak'; if (RT.fence && rk === 'backyard') sf.fence = 'y_hedge'; const lx = (sh.H.lx || {})[rk]; if (lx != null) sf.lx = lx; const lz = (sh.H.lz || {})[rk]; if (lz && lz !== 1) sf.lz = lz; const R0 = X.ROOMS[rk], locks = R0.doors.map(d => sh.lockLv(d.to)); const kf = (X.BIG && X.BIG[rk]) || 1; return rk + '|' + X.slotsOf(rk).map(s => sf[s] || X.DEF[s]).join(',') + '|' + locks.join(',') + '|' + kf + '|' + (sf.lx != null ? sf.lx : '') + '|' + (sf.lz || 1) + '|' + (X.SPEC[sf.win] && X.SPEC[sf.win].ir ? 'ir' : ''); }, rk));
        shells[key] = R.shell;
        const cap = { rk, night, frame: R.frame, roomStyle: R.roomStyle, camK: R.camK, shellKey: key, rt: W.rt, cl: R.cl, gls: W.gls, dom: W.dom };
        const base = path.join(dir, rk + '-' + (night ? 'night' : 'day'));
        fs.writeFileSync(base + '.json', JSON.stringify(cap));
        if (!NOPIX) {
          await H.still();
          await H.page.evaluate(() => {
            const sh = window.__sh, frame = sh.frameRef.current, room = frame.querySelector(':scope > div');
            let st = document.getElementById('__room_only'); if (!st) { st = document.createElement('style'); st.id = '__room_only'; document.head.appendChild(st); }
            [...frame.children].forEach(e => { if (e === room || /z-index: 860/.test(e.getAttribute('style') || '')) e.setAttribute('data-keep', ''); else e.removeAttribute('data-keep'); });
            st.textContent = '[data-house-crs],[data-house-fx]{visibility:hidden!important} [data-house-frame] > :not([data-keep]){visibility:hidden!important}';
            frame.setAttribute('data-house-frame', '');
          });
          await H.page.screenshot({ path: base + '.png' });
        }
        console.log(fx.name, rk, night ? 'night' : 'day', Object.keys(R.variants).length, 'variants', H.errs.length ? H.errs.slice(0, 2) : '');
      }
    }
    await H.close();
  }
  // pictures: SVG as is, or PNG from Chrome for the ones the vector renderer can't draw
  const ctx = await b.newContext({ viewport: { width: 64, height: 64 }, deviceScaleFactor: 1 });
  const pg = await ctx.newPage();
  let nx = 0, np = 0, bx = 0, bp = 0; const whyN = {};
  for (const [name, p] of pics) {
    if (p.kind === 'xml') { fs.writeFileSync(path.join(OUT, 'pics', name + '.xml'), p.svg); nx++; bx += p.svg.length; }
    else if (p.kind === 'png') {
      const vb = (/viewBox="([^"]+)"/.exec(p.svg) || [])[1] || '0 0 100 100', [, , w, h] = vb.split(/[\s,]+/).map(Number);
      const W = Math.max(1, Math.ceil(w * PNG_K)), Hh = Math.max(1, Math.ceil(h * PNG_K));
      await pg.setViewportSize({ width: Math.min(4000, W), height: Math.min(4000, Hh) });
      await pg.setContent('<html><body style="margin:0;background:transparent"><img id="i" style="display:block;width:' + W + 'px;height:' + Hh + 'px"></body></html>');
      await pg.evaluate(async s => { const i = document.getElementById('i'); i.src = 'data:image/svg+xml,' + encodeURIComponent(s.includes('preserveAspectRatio') ? s : s.replace('<svg ', '<svg preserveAspectRatio="none" ')); await i.decode(); await document.fonts.ready; }, p.svg);
      const buf = await pg.screenshot({ omitBackground: true, clip: { x: 0, y: 0, width: Math.min(4000, W), height: Math.min(4000, Hh) } });
      fs.writeFileSync(path.join(OUT, 'pics', name + '.png'), buf); np++; bp += buf.length; p.why.forEach(w => whyN[w] = (whyN[w] || 0) + 1);
    }
  }
  await b.close();
  const picIndex = {}; for (const [name, p] of pics) picIndex[name] = { kind: p.kind, why: p.why || [], vb: p.svg ? ((/viewBox="([^"]+)"/.exec(p.svg) || [])[1] || '') : '', pngK: p.kind === 'png' ? PNG_K : 0 };
  fs.writeFileSync(path.join(OUT, 'catalog.json'), JSON.stringify(tables.rows));
  fs.writeFileSync(path.join(OUT, 'room-template.html'), roomTemplate());
  fs.writeFileSync(path.join(OUT, 'house-cat.json'), JSON.stringify(tables.cat));
  fs.writeFileSync(path.join(OUT, 'house-pieces.json'), JSON.stringify({ variants, renders, grads, gls, foods, pics: picIndex }));
  fs.writeFileSync(path.join(OUT, 'shells.json'), JSON.stringify(shells));
  fs.writeFileSync(path.join(OUT, 'tex.json'), JSON.stringify(tex));
  console.log(`pictures: ${nx} SVG (${(bx / 1024).toFixed(0)} KB), ${np} PNG (${(bp / 1024).toFixed(0)} KB) ${JSON.stringify(whyN)}`);
}
await main();
