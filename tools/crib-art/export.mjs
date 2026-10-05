// Exports the Crib's catalogue from the design's own scripts
// (tools/plush-art/design/crib-home.js + foods.js), by running them in Node
// with a stand-in window/localStorage: the room slots and their 5 tiers, the
// bath stations, the yard games, the decor, the theme names, the songs, the
// rates, and every piece of art they draw (SVG strings, decoded from the
// design's data: URIs), plus the foods. Written to src/crib/catalog.js (a
// module around a JSON string: Hermes parses that faster than object
// literals, and Node imports it without JSON import attributes), which the
// app bundles — it's the design's static data, like its sfx.js.
//
// The design draws a room from its whole state (SquishHome.visuals(room));
// the app composes it from parts, so each slot tier, bath station and game
// carries only its own pieces. They're found by difference: the room drawn
// with the slot at this tier, minus the room with the slot at another tier
// (everything else stays at tier 0, so it cancels out).
//
//   node tools/crib-art/export.mjs

import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const DESIGN = path.resolve(HERE, '../plush-art/design');
const OUT = path.resolve(HERE, '../../src/crib/catalog.js');

const storage = {};
const window = {
  localStorage: { getItem: (k) => (k in storage ? storage[k] : null), setItem: (k, v) => (storage[k] = String(v)), removeItem: (k) => delete storage[k] },
  dispatchEvent() {},
  addEventListener() {},
};
const ctx = vm.createContext({ window, localStorage: window.localStorage, encodeURIComponent, decodeURIComponent, Math, Array, Object, JSON, String, Number });
for (const f of ['foods.js', 'crib-home.js']) vm.runInContext(fs.readFileSync(path.join(DESIGN, f), 'utf8'), ctx, { filename: f });

const H = window.SquishHome;
const F = window.SquishFoods;
const PREFIX = 'data:image/svg+xml;utf8,';
// Some icons draw other pictures as <image href="data:image/svg+xml…">,
// which react-native-svg can't load: they become nested <svg> elements.
const inline = (s) =>
  s.replace(/<image href="([^"]+)"([^>]*?)\/>/g, (m, href, attrs) => {
    if (!href.startsWith(PREFIX)) return m;
    const inner = decodeURIComponent(href.slice(PREFIX.length));
    const vb = (inner.match(/viewBox="([^"]+)"/) || [])[1];
    const body = inner.replace(/^<svg[^>]*>/, '').replace(/<\/svg>\s*$/, '');
    return `<svg${attrs}${vb ? ` viewBox="${vb}"` : ''}>${inline(body)}</svg>`;
  });
const svg = (uri) => (uri && uri.startsWith(PREFIX) ? inline(decodeURIComponent(uri.slice(PREFIX.length))) : uri || null);
const art = (a) => ({ svg: svg(a.img), x: a.x, y: a.y, w: a.w, h: a.h, tf: a.tf || 'none' });

const ST = H.state();
const base = JSON.parse(JSON.stringify(ST));
const reset = () => {
  Object.keys(ST).forEach((k) => delete ST[k]);
  Object.assign(ST, JSON.parse(JSON.stringify(base)));
};
const key = (p) => JSON.stringify(p);
// the pieces of `room` drawn now that aren't in `other` (another drawing)
const minus = (v, other) => {
  const set = new Set([...other.back, ...other.front].map(key));
  return { back: v.back.map(art).filter((p) => !set.has(key(p))), front: v.front.map(art).filter((p) => !set.has(key(p))) };
};
const draw = (room) => {
  const v = H.visuals(room);
  return { back: v.back.map(art), front: v.front.map(art), flags: v.flags };
};

const slots = {};
for (const sl of H.SLOTS) {
  slots[sl.key] = { key: sl.key, room: sl.room, name: sl.name, tiers: [] };
  for (const t of sl.tiers) {
    const other = sl.tiers[t.tier === 0 ? 1 : 0];
    reset();
    ST.eq[sl.key] = other.id;
    const without = draw(sl.room);
    reset();
    ST.eq[sl.key] = t.id;
    const v = draw(sl.room);
    const L = H.layout();
    const own = minus(H.visuals(sl.room), without);
    const tier = { id: t.id, tier: t.tier, name: t.name, lvl: t.lvl, coins: t.coins, usd: t.usd, effect: t.effect, icon: svg(H.itemImg(t.id)), back: own.back, front: own.front };
    // what the tier decides besides its pictures
    if (sl.key === 'sofa') tier.seats = L.tv;
    if (sl.key === 'tub') tier.seats = L.bath;
    if (sl.key === 'floor') {
      tier.seats = L.dance;
      tier.floor = { l: v.flags.floorL, w: v.flags.floorW };
    }
    if (sl.key === 'ball') tier.classicBall = !!v.flags.classicBall;
    if (sl.key === 'lights') tier.lights = { spots: !!v.flags.spots, beams: !!v.flags.beams, lasers: !!v.flags.lasers, show: !!v.flags.show };
    slots[sl.key].tiers.push(tier);
  }
}

const extras = H.EXTRAS.map((e) => {
  reset();
  const without = draw('bath');
  const tub = H.layout().bath.length;
  ST.own[e.id] = true;
  const own = minus(H.visuals('bath'), without);
  return { ...e, icon: svg(H.itemImg(e.id)), back: own.back, front: own.front, seats: H.layout().bath.slice(tub) };
});

// The games: the starter four (swing, trampoline, seesaw, ball field) are
// the design's CSS and have their own pad — the app draws them. The others
// fit any pad: their pieces, play spots and edit box are kept relative to
// the pad's centre (cx), which the player can drag.
const games = H.GAMES.map((g) => {
  reset();
  const id = `g_${g.id}`;
  ST.own[id] = true;
  const pad = g.pad || 'B';
  const cx = H.PADS.find((p) => p.k === pad).cx;
  ST.pads = { A: null, B: null, C: null, D: null };
  const without = draw('yard');
  ST.pads[pad] = g.id;
  const own = minus(H.visuals('yard'), without);
  const box = H.padBox(pad);
  const out = { id: g.id, itemId: id, name: g.name, lvl: g.lvl, coins: g.coins, usd: g.usd, pad: g.pad || null, effect: g.effect, icon: svg(H.itemImg(id)) };
  if (g.pad) return { ...out, spots: H.layout().yard, box };
  const rel = (p) => ({ ...p, x: p.x - cx });
  return { ...out, back: own.back.map(rel), front: own.front.map(rel), spots: H.layout().yard.map((s) => ({ dx: s.x - cx, y: s.y, g: s.g, side: s.side || 0 })), box: { ...box, x: box.x - cx } };
});
reset();

const decor = H.DECOR.map((d) => ({ id: d.id, room: d.room, name: d.name, perk: d.perk, perkText: d.perkText, lvl: d.lvl, coins: d.coins, usd: d.usd, x: d.x, y: d.y, w: d.w, h: d.h, svg: svg(d.img), light: d.light || null }));

// the theme names and levels (the pictures are render.mjs's)
const themes = {};
Object.entries(H.THEMES).forEach(([room, T]) => {
  themes[room] = {};
  Object.entries(T).forEach(([kind, list]) => {
    themes[room][kind] = list.map(([name, , lvl]) => ({ name, lvl }));
  });
});

const foods = F.LIST.map((f) => ({ k: f.k, name: f.name, price: f.price, fill: f.fill, sec: f.sec, style: f.style, fx: f.fx, crumb: f.crumb || null, bites: f.bites, svg: svg(f.img) }));

// the numbers crib-home.js keeps to itself (read back through its API)
const tv = [], beds = [], fridge = [], songsN = [];
for (let t = 0; t < 5; t++) {
  reset();
  ST.eq.tv = `tv${t}`;
  ST.eq.bed = `bed${t}`;
  ST.eq.fridge = `fridge${t}`;
  ST.eq.dj = `dj${t}`;
  tv.push(H.tvRate());
  beds.push(H.sleepCount());
  fridge.push(H.fridgeFoods());
  songsN.push(H.songs().length);
}
reset();
const bath = {};
['tub', 'bubble', 'hottub', 'spa', 'duck', 'shower', 'mud', 'sauna'].forEach((s) => (bath[s] = H.bath(s)));
// the dance room's furniture slows the draining (on top of its decor)
const drain = {};
['speakers', 'ball', 'lights'].forEach((k) => {
  drain[k] = [];
  for (let t = 0; t < 5; t++) {
    reset();
    ST.eq[k] = `${k}${t}`;
    drain[k].push(+H.perk('dance').toFixed(3));
  }
});
reset();

const catalog = {
  rooms: H.ROOMS,
  slots,
  extras,
  games,
  pads: H.PADS,
  decor,
  themes,
  songs: H.SONGS,
  rates: { tv, beds, fridge, songsN, bath, drain },
  foods,
  fresh: base,
};
fs.mkdirSync(path.dirname(OUT), { recursive: true });
fs.writeFileSync(OUT, `// Generated by tools/crib-art/export.mjs from the design's crib-home.js and foods.js — don't edit.
// eslint-disable-next-line
export default JSON.parse(${JSON.stringify(JSON.stringify(catalog))});
`);
const pieces = Object.values(slots).reduce((n, s) => n + s.tiers.reduce((m, t) => m + t.back.length + t.front.length, 0), 0);
console.log(`wrote ${OUT} (${(fs.statSync(OUT).size / 1024).toFixed(0)} KB): ${Object.keys(slots).length} slots (${pieces} pieces), ${extras.length} extras, ${games.length} games, ${decor.length} decor, ${foods.length} foods`);
