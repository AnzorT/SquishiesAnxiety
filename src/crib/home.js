// The Crib's furniture: what the player owns and where it stands — the
// design's crib-home.js (SquishHome) as pure functions over the `home` part
// of the Crib's state, so it saves with the rest (users/{uid}/crib/state)
// and runs in Node (model.test.js).
//
// home = {
//   own: { [itemId]: true },          — bought (tiers, bath stations, games, decor,
//                                       walls / floors / ceilings)
//   eq: { [slot]: tierId },           — the tier in use per slot
//   pads: { A|B|C|D: gameId | null }, — the yard's four play spots
//   padX, padY: { [pad]: offset },    — where the player dragged them
//   pos: { [decorId]: { x, y } },     — where the player dragged the decor
//   spos: { [unit]: { dx, dy } },     — where the player dragged the furniture
//                                       (a slot, a bath station, or one bed /
//                                       speaker: 'bed.2', 'speakers.1')
//   stored: { [decorId]: true },      — decor put away
//   th: { [room]: { wall, floor, ceil: index } },
//   song: index, off: { [decorId]: true } — the dance room's song; lamps off
// }
//
// The catalogue is the design's (catalog.js) with this app's additions
// (extra.js): a cheap first tier for every slot (the design's tiers move up
// one), the kitchen's table, a rug and a ceiling lamp per room, priced
// walls / floors / ceilings from bare to luxurious, and the rooms' built-in
// fixtures as decor. Everything can be moved; a piece of furniture takes its
// seats with it, so creatures use it wherever it stands.

import catalog from './catalog.js';
import { CHEAP, CHEAP_RATES, FIXTURE_DECOR, NEW_SLOTS, SLEEPER_Y, TABLE_TOPS, THEME_EXTRA, blanketAt, blanketSvg, blanketTop } from './extra.js';

const clone = (o) => JSON.parse(JSON.stringify(o));
export const PADS = catalog.pads; // [{ k, cx }]
export const GAMES = catalog.games;
export const EXTRAS = catalog.extras;
export const SONGS = catalog.songs;
const BUILTIN_GAMES = ['swing', 'tramp', 'seesaw', 'ball']; // drawn by the app (the design's CSS)
// the dance floor the app draws (Dance.js): its top and height
export const DANCE_FLOOR = { top: 210, h: 172 };
// the bedroom's spots: two creatures per bed, beds at 130 / 330 / 530 / 730
// (how high depends on the bed: SLEEPER_Y)
const BED_SPOTS = [130, 330, 530, 730].flatMap((x) => [
  { x: x - 42, y: 300 },
  { x: x + 42, y: 300 },
]);
// what the design's first tier costs now that a cheaper one comes before it
const OLD_FIRST_COINS = 150;

// ---- the merged catalogue ---------------------------------------------------------------

export const SLOTS = {};
Object.values(catalog.slots).forEach((s) => {
  const cheap = CHEAP[s.key];
  if (!cheap) {
    SLOTS[s.key] = s;
    return;
  }
  let up = s.tiers.map((t) => ({ ...t, id: `${s.key}${t.tier + 1}`, tier: t.tier + 1, coins: t.tier === 0 ? OLD_FIRST_COINS : t.coins }));
  // the beds get blankets that tuck their sleepers in (extra.js)
  if (s.key === 'bed') up = up.map((t) => ({ ...t, front: t.back.map((b) => ({ svg: blanketSvg(t.tier), ...blanketAt(b, t.tier) })) }));
  SLOTS[s.key] = { ...s, tiers: [cheap, ...up] };
});
Object.assign(SLOTS, NEW_SLOTS);

// the tiers' rates, with the cheap tiers' in front
const RATES = {
  ...catalog.rates,
  tv: [CHEAP_RATES.tv, ...catalog.rates.tv],
  beds: [CHEAP_RATES.beds, ...catalog.rates.beds],
  fridge: [CHEAP_RATES.fridge, ...catalog.rates.fridge],
  songsN: [CHEAP_RATES.songsN, ...catalog.rates.songsN],
  bath: { ...catalog.rates.bath, ...CHEAP_RATES.bath },
  drain: {
    ...catalog.rates.drain,
    speakers: [CHEAP_RATES.drain.speakers, ...catalog.rates.drain.speakers],
    ball: [CHEAP_RATES.drain.ball, ...catalog.rates.drain.ball],
  },
};

export const DECOR = [...catalog.decor, ...FIXTURE_DECOR];

// Walls, floors, ceilings per room: the bare one first (free), the design's
// (from the second on, at a price), a luxurious one last. The yard keeps the
// design's grounds. { name, lvl, coins, svg?: (w, h) → string, design?: index
// into the design's list (art.js draws it; 0 is the room's own) }.
export const THEMES = {};
Object.entries(catalog.themes).forEach(([room, kinds]) => {
  THEMES[room] = {};
  Object.entries(kinds).forEach(([kind, list]) => {
    const X = THEME_EXTRA[kind];
    const design = list.map((t, i) => ({ name: t.name, lvl: t.lvl, coins: i === 0 && room === 'yard' ? 0 : X ? X.prices[Math.min(i, X.prices.length - 1)] : 150 * i, design: i }));
    THEMES[room][kind] = room === 'yard' || !X ? design : [X.first(room), ...design, X.last];
  });
});
export const themeId = (room, kind, i) => `th:${room}:${kind}:${i}`;

// every item the shop sells, by id
export const ITEMS = {};
Object.values(SLOTS).forEach((s) => s.tiers.forEach((t) => (ITEMS[t.id] = { ...t, kind: 'tier', slot: s.key, room: s.room })));
EXTRAS.forEach((e) => (ITEMS[e.id] = { ...e, kind: 'extra' }));
GAMES.forEach((g) => (ITEMS[g.itemId] = { ...g, id: g.itemId, game: g.id, room: 'yard', kind: 'game' }));
DECOR.forEach((d) => (ITEMS[d.id] = { ...d, kind: 'decor' }));
Object.entries(THEMES).forEach(([room, kinds]) =>
  Object.entries(kinds).forEach(([kind, list]) =>
    list.forEach((t, i) => {
      const id = themeId(room, kind, i);
      ITEMS[id] = { ...t, id, kind: 'theme', room, themeKind: kind, index: i };
    })
  )
);
export const itemOf = (id) => ITEMS[id] || null;
export const gameOf = (id) => GAMES.find((g) => g.id === id) || null;
export const isBuiltinGame = (id) => BUILTIN_GAMES.includes(id);
// the furniture slots of a room, in order
export const slotsIn = (room) => Object.values(SLOTS).filter((s) => s.room === room);

// A new home: every slot on its (free) first tier, the starter swing and
// ball field in the yard, the bare walls.
export const freshHome = () => {
  const h = clone(catalog.fresh);
  Object.values(SLOTS).forEach((s) => {
    const first = s.tiers[0].id;
    h.own[first] = true;
    h.eq[s.key] = first;
  });
  h.spos = {};
  return h;
};

// What a saved home needs to be a home: the fresh one's fields, ids that
// still exist, every slot equipped with something owned.
export function normalizeHome(h) {
  const f = freshHome();
  if (!h || typeof h !== 'object') return f;
  const home = { ...f, ...h };
  ['own', 'eq', 'pads', 'padX', 'padY', 'pos', 'spos', 'stored', 'th', 'off'].forEach((k) => {
    if (!home[k] || typeof home[k] !== 'object') home[k] = f[k];
  });
  home.own = { ...f.own, ...Object.fromEntries(Object.keys(home.own).filter((id) => ITEMS[id]).map((id) => [id, true])) };
  Object.keys(SLOTS).forEach((k) => {
    const id = home.eq[k];
    if (!id || !ITEMS[id] || ITEMS[id].slot !== k || !home.own[id]) home.eq[k] = f.eq[k];
  });
  PADS.forEach(({ k }) => {
    const g = home.pads[k];
    if (g == null) home.pads[k] = null;
    else if (!gameOf(g) || !home.own[`g_${g}`] || (gameOf(g).pad && gameOf(g).pad !== k)) home.pads[k] = null;
  });
  // a wall / floor / ceiling that isn't owned (or no longer exists) goes bare
  Object.keys(home.th).forEach((room) => {
    const t = home.th[room];
    if (!t || typeof t !== 'object' || !THEMES[room]) {
      delete home.th[room];
      return;
    }
    Object.keys(t).forEach((kind) => {
      if (!THEMES[room][kind] || !themeOwned(home, room, kind, t[kind])) delete t[kind];
    });
  });
  if (!Number.isInteger(home.song) || home.song < 0) home.song = 0;
  return home;
}

export const owns = (home, id) => !!home.own[id];
export const tierOf = (home, slot) => {
  const id = home.eq[slot];
  return id ? Number(id.slice(slot.length)) || 0 : 0;
};
export const tierItem = (home, slot) => SLOTS[slot].tiers[tierOf(home, slot)] || SLOTS[slot].tiers[0];

// Can the player buy this with coins? { ok } or { ok: false, reason:
// 'owned' | 'level' | 'coins' | 'none' }.
export function canBuy(home, id, { level = 1, coins = 0 } = {}) {
  const it = ITEMS[id];
  if (!it) return { ok: false, reason: 'none' };
  if (home.own[id] || (it.kind === 'theme' && !it.coins)) return { ok: false, reason: 'owned' };
  if (level < it.lvl) return { ok: false, reason: 'level' };
  if (coins < (it.coins || 0)) return { ok: false, reason: 'coins' };
  return { ok: true, cost: it.coins || 0 };
}

// Takes it home: a tier or a wall / floor / ceiling goes straight into use,
// a game onto a free play spot (its own one, if it has one). Returns
// { placed } (false for a game with no free spot: the player swaps it in in
// Edit mode).
export function buy(home, id) {
  const it = ITEMS[id];
  if (!it) return { placed: false };
  home.own[id] = true;
  if (it.kind === 'tier') home.eq[it.slot] = id;
  if (it.kind === 'theme') setTheme(home, it.room, it.themeKind, it.index);
  if (it.kind === 'game') {
    const pads = it.pad ? [it.pad] : PADS.map((p) => p.k);
    const free = pads.find((k) => !home.pads[k]);
    if (free) placeGame(home, free, it.game);
    return { placed: !!free };
  }
  return { placed: true };
}

export function equip(home, slot, id) {
  if (!home.own[id] || !ITEMS[id] || ITEMS[id].slot !== slot) return false;
  home.eq[slot] = id;
  return true;
}

// Puts a game on a play spot (null empties it). A game is only ever on one.
export function placeGame(home, pad, game) {
  if (game) {
    const g = gameOf(game);
    if (!g || (g.pad && g.pad !== pad) || !home.own[`g_${game}`]) return false;
    Object.keys(home.pads).forEach((k) => {
      if (home.pads[k] === game) home.pads[k] = null;
    });
  }
  home.pads[pad] = game || null;
  return true;
}

export const padOffset = (home, k) => ({ dx: home.padX[k] || 0, dy: home.padY[k] || 0 });
export const padCx = (home, k) => PADS.find((p) => p.k === k).cx + (home.padX[k] || 0);

// a play spot's box (for dragging it in Edit mode), scene units
export function padBox(home, k) {
  const g = home.pads[k];
  if (!g) return null;
  const G = gameOf(g);
  const { dx, dy } = padOffset(home, k);
  const b = G.pad ? G.box : { ...G.box, x: G.box.x + PADS.find((p) => p.k === k).cx };
  return { x: b.x + dx, y: b.y + dy, w: b.w, h: b.h };
}

// How far a play spot can be dragged: across the yard, and up only until
// its bottom reaches the fence (the design's limits).
export function padLimits(home, k) {
  const cx = PADS.find((p) => p.k === k).cx;
  const b = padBox(home, k);
  const dy = home.padY[k] || 0;
  return { minX: 80 - cx, maxX: 772 - cx, minY: Math.round(dy - (b.y + b.h - 232)), maxY: 20 };
}

export function setPad(home, k, dx, dy) {
  home.padX[k] = Math.round(dx);
  home.padY[k] = Math.round(dy);
}

// ---- moving furniture -----------------------------------------------------------------------

// The parts of a slot that move together, and which of its seats each one
// carries: each bed and each speaker on its own, any other slot whole. A
// unit's key is where its offset is saved (home.spos).
export function unitsOf(home, slot) {
  const t = tierItem(home, slot);
  if (slot === 'bed') return t.back.map((p, u) => ({ key: `bed.${u}`, back: [p], front: t.front[u] ? [t.front[u]] : [], seats: [2 * u, 2 * u + 1] }));
  if (slot === 'speakers') return t.back.map((p, u) => ({ key: `speakers.${u}`, back: [p], front: [], seats: [] }));
  return [{ key: slot, back: t.back, front: t.front, seats: null, floor: t.floor || null, ball: !!t.classicBall }];
}
export const unitOffset = (home, key) => (home.spos && home.spos[key]) || { dx: 0, dy: 0 };
const shift = (a, dx, dy) => (dx || dy ? { ...a, x: a.x + dx, y: a.y + dy } : a);

// the box a unit's pieces cover, where they'd stand without its offset
function unitBox0(u) {
  const boxes = [...u.back, ...u.front].map((p) => ({ x0: p.x, y0: p.y, x1: p.x + p.w, y1: p.y + p.h }));
  if (u.floor) boxes.push({ x0: u.floor.l, y0: DANCE_FLOOR.top, x1: u.floor.l + u.floor.w, y1: DANCE_FLOOR.top + DANCE_FLOOR.h });
  if (u.ball) boxes.push({ x0: 384, y0: 0, x1: 468, y1: 110 }); // the app's classic disco ball (Dance.js)
  if (!boxes.length) return null;
  return { x0: Math.min(...boxes.map((b) => b.x0)), y0: Math.min(...boxes.map((b) => b.y0)), x1: Math.max(...boxes.map((b) => b.x1)), y1: Math.max(...boxes.map((b) => b.y1)) };
}

// Everything that can be dragged in a room, besides decor and the yard's
// play spots: its furniture units and its bath stations. [{ key, name, box:
// { x, y, w, h } (where it is now), lim: { minX, maxX, minY, maxY } (the
// offsets it may take: anywhere in the scene) }]
export function movables(home, room, sceneW = 852, sceneH = 393) {
  const out = [];
  const add = (key, name, b) => {
    if (!b) return;
    const { dx, dy } = unitOffset(home, key);
    out.push({ key, name, box: { x: b.x0 + dx, y: b.y0 + dy, w: b.x1 - b.x0, h: b.y1 - b.y0 }, lim: { minX: -b.x0, maxX: sceneW - b.x1, minY: -b.y0, maxY: sceneH - b.y1 } });
  };
  slotsIn(room).forEach((s) => {
    const name = tierItem(home, s.key).name;
    unitsOf(home, s.key).forEach((u) => add(u.key, name, unitBox0(u)));
  });
  if (room === 'bath') EXTRAS.forEach((e) => home.own[e.id] && add(e.id, e.name, unitBox0({ back: e.back, front: e.front })));
  return out;
}

export function setUnitPos(home, key, dx, dy) {
  home.spos = home.spos || {};
  home.spos[key] = { dx: Math.round(dx), dy: Math.round(dy) };
}

// ---- decor ------------------------------------------------------------------------------------

export const decorPos = (home, id) => {
  const d = ITEMS[id];
  const p = home.pos[id];
  return { x: p ? p.x : d.x, y: p ? p.y : d.y, w: d.w, h: d.h };
};
// the design keeps a dragged piece mostly inside the scene
export function setDecorPos(home, id, x, y, sceneW = 852, sceneH = 393) {
  const d = ITEMS[id];
  home.pos[id] = { x: Math.round(Math.max(-d.w * 0.3, Math.min(sceneW - d.w * 0.7, x))), y: Math.round(Math.max(0, Math.min(sceneH - d.h * 0.5, y))) };
}
export function toggleStore(home, id) {
  home.stored[id] = !home.stored[id];
}
export const placedDecor = (home, room) => DECOR.filter((d) => d.room === room && home.own[d.id] && !home.stored[d.id]);
export const ownedDecor = (home, room) => DECOR.filter((d) => d.room === room && home.own[d.id]);

export const lightOn = (home, id) => !(home.off || {})[id];
export function toggleLight(home, id) {
  home.off = home.off || {};
  home.off[id] = !home.off[id];
}
// the lamps lit in a room: where their light is, how far it reaches, its
// colour — the decor's lamps and the room's ceiling lamp
export function lights(home, room) {
  const out = placedDecor(home, room)
    .filter((d) => d.light && lightOn(home, d.id))
    .map((d) => {
      const p = decorPos(home, d.id);
      return { id: d.id, x: p.x + d.light.lx, y: p.y + d.light.ly, r: d.light.r, c: d.light.c };
    });
  slotsIn(room).forEach((s) => {
    const t = tierItem(home, s.key);
    if (!t.light || !t.back[0]) return;
    const { dx, dy } = unitOffset(home, s.key);
    out.push({ id: s.key, x: t.back[0].x + dx + t.light.lx, y: t.back[0].y + dy + t.light.ly, r: t.light.r, c: t.light.c });
  });
  return out;
}

// ---- walls, floors, ceilings ----------------------------------------------------------------

export const themeIdx = (home, room, kind) => ((home.th || {})[room] || {})[kind] || 0;
export const themeOwned = (home, room, kind, i) => {
  const t = THEMES[room] && THEMES[room][kind] && THEMES[room][kind][i];
  return !!t && (!t.coins || !!home.own[themeId(room, kind, i)]);
};
export function setTheme(home, room, kind, i) {
  if (!themeOwned(home, room, kind, i)) return false;
  home.th = home.th || {};
  home.th[room] = { ...(home.th[room] || {}), [kind]: i };
  return true;
}
export const themeOf = (home, room, kind) => (THEMES[room] && THEMES[room][kind] ? THEMES[room][kind][themeIdx(home, room, kind)] : null);

// ---- what the furniture does ------------------------------------------------------------------

// A room's perk from its decor and furniture (rugs, lamps, the snack table;
// in the dance room the speakers, ball and lights): living → more coins,
// kitchen → fuller meals, bath → faster cleaning, bed → faster energy,
// dance / yard → slower draining. A fraction (0.08 = 8%).
export function perk(home, room) {
  let p = 0;
  placedDecor(home, room).forEach((d) => (p += d.perk || 0));
  slotsIn(room).forEach((s) => (p += tierItem(home, s.key).perk || 0));
  if (room === 'dance') ['speakers', 'ball', 'lights'].forEach((k) => (p += RATES.drain[k][tierOf(home, k)] - RATES.drain[k][0]));
  return p;
}

// what the slots' tiers decide
export const tvRate = (home) => RATES.tv[tierOf(home, 'tv')];
export const sleepCount = (home) => RATES.beds[tierOf(home, 'bed')];
export const fridgeFoods = (home) => RATES.fridge[tierOf(home, 'fridge')];
export const bathOf = (style) => RATES.bath[style || 'tub'] || RATES.bath.tub;
export const songs = (home) => SONGS.slice(0, RATES.songsN[tierOf(home, 'dj')]);
export const song = (home) => {
  const L = songs(home);
  return L[Math.min(home.song || 0, L.length - 1)];
};
export function nextSong(home) {
  home.song = ((home.song || 0) + 1) % songs(home).length;
}

// Where creatures go in the rooms whose places come with the furniture:
// the sofa's seats (tv), the tub and bath stations (bath), the dance floor,
// the yard's games, the snack table (kitchen), the beds — each moved with
// its piece of furniture. { x, y } are feet in scene units, plus the bath
// style / the game and side.
export function layout(home) {
  const seats = (slot) => {
    const { dx, dy } = unitOffset(home, slot);
    return (tierItem(home, slot).seats || []).map((s) => shift(s, dx, dy));
  };
  const tv = seats('sofa');
  const bath = seats('tub');
  EXTRAS.forEach((e) => {
    if (!home.own[e.id]) return;
    const { dx, dy } = unitOffset(home, e.id);
    bath.push(...e.seats.map((s) => shift(s, dx, dy)));
  });
  const dance = seats('floor');
  const kitchen = seats('table');
  const bedY = SLEEPER_Y(tierOf(home, 'bed'));
  const bed = BED_SPOTS.map((s, k) => {
    const { dx, dy } = unitOffset(home, `bed.${Math.floor(k / 2)}`);
    return shift({ ...s, y: bedY }, dx, dy);
  });
  const yard = [];
  PADS.forEach((p) => {
    const g = home.pads[p.k];
    if (!g) return;
    const { dx: d, dy: e } = padOffset(home, p.k);
    const cx = p.cx + d;
    if (g === 'swing') yard.push({ x: 110 + d, y: 318 + e, dy: e, g, cx });
    else if (g === 'tramp') yard.push({ x: 290 + d, y: 322 + e, dy: e, g, cx });
    else if (g === 'seesaw') yard.push({ x: 412 + d, y: 318 + e, dy: e, g, side: -1, cx }, { x: 548 + d, y: 318 + e, dy: e, g, side: 1, cx });
    else if (g === 'ball') yard.push({ x: 660 + d, y: 360 + e, dy: e, g, side: 0, cx }, { x: 800 + d, y: 360 + e, dy: e, g, side: 1, cx });
    else {
      const G = gameOf(g);
      if (G) G.spots.forEach((s) => yard.push({ x: cx + s.dx, y: s.y + e, dy: e, g: s.g, side: s.side || 0, cx }));
    }
  });
  return { tv, bath, dance, yard, kitchen, bed };
}

// A sleeper's feet in bed: its spot moved so the blanket's hem sits just
// under its mouth (`mouthY`: the rig's, 0-100 of its box) — tucked in to
// the chin, whatever its shape. `size`: a creature's box in the scene.
export function sleeperY(home, spotY, mouthY = 64, size = 72) {
  const t = tierOf(home, 'bed');
  // (9: the sleeping sway settles them about 4 lower, and a little chin shows)
  return spotY - SLEEPER_Y(t) + (blanketTop(t) - 9 - (mouthY / 100) * size + size);
}

// A diner's feet at the table: its seat moved so its mouth is 16 above the
// table's top — the table hides its lower body, its face and its food show,
// whatever its shape.
export function dinerY(home, spotY, mouthY = 64, size = 72) {
  const top = TABLE_TOPS[Math.min(TABLE_TOPS.length - 1, tierOf(home, 'table'))];
  // (a mouth outside 50-75% is a rig that doesn't fit its art: clamped)
  const m = Math.max(50, Math.min(75, mouthY));
  return spotY - (top + 14) + (top - 16 - (m / 100) * size + size);
}

// The furniture a room draws, behind and in front of the creatures (pieces
// { svg | art, x, y, w, h, tf }, each where the player moved it), and what
// the app draws itself: the dance floor and lights, the yard's starter
// games. Rugs go first, under everything.
export function visuals(home, room) {
  const back = [];
  const front = [];
  const flags = {};
  slotsIn(room)
    .slice()
    .sort((a, b) => (a.key.startsWith('rug_') ? -1 : 0) - (b.key.startsWith('rug_') ? -1 : 0))
    .forEach((s) => {
      unitsOf(home, s.key).forEach((u) => {
        const { dx, dy } = unitOffset(home, u.key);
        back.push(...u.back.map((a) => shift(a, dx, dy)));
        front.push(...u.front.map((a) => shift(a, dx, dy)));
        if (u.floor) flags.floor = { ...u.floor, dx, dy };
      });
    });
  if (room === 'bath') {
    EXTRAS.forEach((e) => {
      if (!home.own[e.id]) return;
      const { dx, dy } = unitOffset(home, e.id);
      back.push(...e.back.map((a) => shift(a, dx, dy)));
      front.push(...e.front.map((a) => shift(a, dx, dy)));
    });
  } else if (room === 'dance') {
    const t = (slot) => tierItem(home, slot);
    flags.classicBall = t('ball').classicBall ? unitOffset(home, 'ball') : null;
    flags.lights = t('lights').lights;
  } else if (room === 'yard') {
    flags.games = {};
    PADS.forEach((p) => {
      const g = home.pads[p.k];
      if (!g) return;
      const { dx, dy } = padOffset(home, p.k);
      if (BUILTIN_GAMES.includes(g)) {
        flags.games[g] = { dx, dy, pad: p.k };
        return;
      }
      const G = gameOf(g);
      if (!G) return;
      const cx = p.cx + dx;
      back.push(...G.back.map((a) => shift(a, cx, dy)));
      front.push(...G.front.map((a) => shift(a, cx, dy)));
    });
  }
  return { back, front, flags };
}
