// The Crib's simulation (the design's tick/sendTo/landed/startMeal in "Squad
// Crib v5.dc.html"), as pure functions over a plain state object so it can
// run in Node (model.test.js) and be saved as it is to Firestore
// (users/{uid}/crib/state). The screen owns one state, ticks it while open,
// draws from it and saves it; no React in here.
//
// State:
//   {
//     v: 1, t: <ms, last tick>, room, landscape,
//     pets: { [creatureId]: {
//       room, spot, act, since,            — where, what, since when (ms)
//       stats: { clean, energy, tummy },   — 0-100
//       sleepEnd, sleepRate, sleepGain,    — while sleeping
//       meal: { k, t0, ms, base, gain, done } | null — while eating
//       done, cleanUntil, until,           — bath finished; fresh-from-bath
//                                             sparkle; the yard's next wander
//       from: { room, spot, at } | null    — where it teleported from (for
//                                             the scene's leaving animation)
//     } },
//     members: [creatureId],               — who lives in the Crib (at most
//                                             CRIB_MAX, picked in the hatchery)
//     away: { [creatureId]: true },        — moved out by the player
//     known: [creatureId],                 — the owned creatures at the last
//                                             sync: one unlocked since moves
//                                             in by itself while there's room
//     home,                                — the furniture (home.js)
//     pantry, gift, coinAcc
//   }

import { ACTS, FRESH_PANTRY, NEED_AT, RATE, SEC_PER_HR, START_STAT, STATS, foodOf, spotsFor } from './data.js';
import { bathOf as bathStyle, fridgeFoods, freshHome, normalizeHome, perk, tvRate } from './home.js';

export const VERSION = 1;
// how many creatures can live in the Crib at once (the user's number)
export const CRIB_MAX = 10;
// how much of the time away is simulated when the Crib reopens: enough that
// the squad has needs again, not so much that everyone is at zero
export const OFFLINE_CAP_MS = 10 * 60 * 1000;
const TELEPORT_MS = 1040; // out + in, the scene's animation
const MEAL_LINGER_MS = 3200;

const clamp = (v) => Math.max(0, Math.min(100, v));
// every new creature starts at 70% on everything (the tutorial's starter
// comes hungry: it's the lesson)
const freshPet = (id, room, spot, now, hungry) => {
  return {
    room,
    spot,
    act: room === 'yard' ? 'yard' : 'home',
    // already there (not mid-teleport)
    since: now - TELEPORT_MS,
    stats: { clean: START_STAT, energy: START_STAT, tummy: hungry ? 14 : START_STAT },
    sleepEnd: null,
    sleepRate: 0,
    sleepGain: 0,
    meal: null,
    done: false,
    cleanUntil: 0,
    until: now + 8000,
    from: null,
  };
}

// A new home for these creatures. `tutorial` makes the first one hungry (the
// Crib tutorial has the player feed it).
export function freshState(ids, now = Date.now(), { tutorial = false } = {}) {
  const state = {
    v: VERSION,
    t: now,
    room: 'living',
    landscape: false,
    pets: {},
    members: [],
    away: {},
    known: null,
    home: freshHome(),
    pantry: { ...FRESH_PANTRY },
    gift: null,
    coinAcc: 0,
  };
  syncPets(state, ids, now, { tutorial });
  return state;
}

// spot → creature id (or null) for a room
export function occupancy(state, room) {
  const occ = spotsFor(room, state.home).map(() => null);
  Object.keys(state.pets).forEach((id) => {
    const p = state.pets[id];
    if (p.room === room && p.spot < occ.length) occ[p.spot] = id;
  });
  return occ;
}

// A free spot in a room: any of the living room's, else one of the first two
// free (the design keeps a room's friends together). -1 when full.
export function freeSpot(state, room, rnd = Math.random) {
  const free = occupancy(state, room)
    .map((v, k) => (v == null ? k : -1))
    .filter((k) => k >= 0);
  if (!free.length) return -1;
  return free[Math.floor(rnd() * Math.min(free.length, room === 'living' ? free.length : 2))];
}

// Who lives in the Crib, from the creatures the player owns (`ids`): the
// members they kept, then — while there's room for CRIB_MAX — creatures
// unlocked since the last sync (all of them, the first time). Members move
// in, everyone else moves out. Returns true when anything changed.
export function syncPets(state, ids, now = Date.now(), { tutorial = false } = {}) {
  let changed = false;
  const owned = new Set(ids);
  const known = new Set(Array.isArray(state.known) ? state.known : Array.isArray(state.members) ? Object.keys(state.pets) : []);
  if (!state.away) state.away = {};
  const members = (Array.isArray(state.members) ? state.members : Object.keys(state.pets)).filter((id, k, a) => owned.has(id) && a.indexOf(id) === k).slice(0, CRIB_MAX);
  ids.forEach((id) => {
    if (members.length < CRIB_MAX && !members.includes(id) && !known.has(id) && !state.away[id]) members.push(id);
  });
  if (!Array.isArray(state.known) || state.known.join() !== ids.join()) changed = true;
  state.known = [...ids];
  if (!Array.isArray(state.members) || members.join() !== state.members.join()) changed = true;
  state.members = members;
  Object.keys(state.pets).forEach((id) => {
    if (!members.includes(id)) {
      delete state.pets[id];
      changed = true;
    }
  });
  members.forEach((id) => {
    if (state.pets[id]) return;
    let room = 'living';
    let spot = freeSpot(state, room, () => 0);
    if (spot < 0) {
      room = 'yard';
      spot = freeSpot(state, room, () => 0);
    }
    if (spot < 0) {
      // a full house: double up on the living room's last spot
      room = 'living';
      spot = spotsFor('living', state.home).length - 1;
    }
    state.pets[id] = freshPet(id, room, spot, now, tutorial && id === '0');
    changed = true;
  });
  return changed;
}

// The hatchery's switch: moves a creature the player owns (`ids`) into the
// Crib or out of it. { ok } or { ok: false, reason: 'full' | 'none' }.
export function setMember(state, id, on, ids, now = Date.now()) {
  if (!ids.includes(id)) return { ok: false, reason: 'none' };
  const away = state.away || (state.away = {});
  if (on) {
    if (state.members.includes(id)) return { ok: true };
    if (state.members.length >= CRIB_MAX) return { ok: false, reason: 'full' };
    delete away[id];
    state.members = [...state.members, id];
  } else {
    away[id] = true;
    state.members = state.members.filter((m) => m !== id);
  }
  syncPets(state, ids, now);
  return { ok: true };
}

// Whether a creature is fixing this stat right now: in the bath, in bed, or
// at the table with a meal going (sitting at the table hungry isn't fixing
// anything — it still looks and asks hungry).
const fixing = (pet, s, now = Date.now()) => pet.act === s.fix && (s.fix !== 'eat' || (!!pet.meal && now < pet.meal.t0 + pet.meal.ms));

export const needOf = (pet, now = Date.now()) => {
  let m = null;
  let mv = NEED_AT;
  STATS.forEach((s) => {
    if (pet.stats[s.k] < mv && !fixing(pet, s, now)) {
      mv = pet.stats[s.k];
      m = s.k;
    }
  });
  return m;
};

// How a creature looks from its stats (the user's rule): every stat under
// NEED_AT (not counting the one it's fixing right now) makes it sad — unless
// the only low one is Clean, which makes it smelly. null when it's fine.
export const lookOf = (pet, now = Date.now()) => {
  const low = STATS.filter((s) => pet.stats[s.k] < NEED_AT && !fixing(pet, s, now)).map((s) => s.k);
  if (!low.length) return null;
  return low.length === 1 && low[0] === 'clean' ? 'smelly' : 'sad';
};

export const sleepGain =(energy, h) => Math.max(0, Math.min(100 - Math.round(energy), Math.round(100 * (1 - Math.exp(-h / 3)))));

// what the bath station a creature is in does: { mul, energy?, coins? }
export const bathOf = (state, pet) => {
  const sp = pet.room === 'bath' ? spotsFor('bath', state.home)[pet.spot] : null;
  return bathStyle(sp && sp.style);
};

// a creature is still teleporting (the scene plays it) for a moment after a move
export const teleporting = (pet, now) => now - pet.since < TELEPORT_MS;

// Coins per second for the whole squad: each creature by how it feels, the
// duck bath's bonus, the living room's decor on top of a positive rate. Only
// while the Crib is open (the design's coinRate).
export function coinRate(state, now = Date.now()) {
  let rate = 0;
  Object.values(state.pets).forEach((p) => {
    const m = (p.stats.clean + p.stats.energy + p.stats.tummy) / 3;
    rate += m >= 70 ? 0.6 : m >= 45 ? 0.3 : m >= 25 ? 0.05 : -0.25;
    if (p.act === 'bath' && !teleporting(p, now)) {
      const b = bathOf(state, p);
      if (b.coins) rate += b.coins;
    }
  });
  if (rate > 0) rate *= 1 + perk(state.home, 'living');
  return rate;
}

// Sends a creature to do something (home = back to the living room).
// Returns { ok } or { ok: false, reason: 'full' | 'same' | 'moving' }.
export function sendTo(state, id, act, { h, now = Date.now(), rnd = Math.random } = {}) {
  const p = state.pets[id];
  if (!p || !ACTS[act]) return { ok: false, reason: 'none' };
  if (act === p.act) return { ok: false, reason: 'same' };
  if (teleporting(p, now)) return { ok: false, reason: 'moving' };
  const room = ACTS[act].room;
  const spot = freeSpot(state, room, rnd);
  if (spot < 0) return { ok: false, reason: 'full' };
  const wasBath = p.act === 'bath';
  p.from = { room: p.room, spot: p.spot, at: now };
  p.room = room;
  p.spot = spot;
  p.act = act;
  p.since = now;
  p.meal = null;
  p.done = false;
  p.until = now + 8000 + rnd() * 6000;
  if (wasBath) p.cleanUntil = now + 4000;
  if (act === 'sleep') {
    const hours = h || 2;
    const gain = sleepGain(p.stats.energy, hours);
    p.sleepEnd = now + hours * SEC_PER_HR * 1000;
    p.sleepRate = gain / (hours * SEC_PER_HR);
    p.sleepGain = gain;
  } else {
    p.sleepEnd = null;
    p.sleepRate = 0;
    p.sleepGain = 0;
  }
  return { ok: true };
}

// Starts a meal for a creature at the table. Pays from the pantry first,
// then with coins (the caller has `coins` and pays what this returns in
// `cost`). `free` is the tutorial's cookie. The fridge decides what's on
// offer; the kitchen's decor makes meals fuller.
// Returns { ok, cost } or { ok: false, reason: 'busy' | 'fridge' | 'coins' }.
export function startMeal(state, id, k, { free = false, coins = 0, now = Date.now() } = {}) {
  const p = state.pets[id];
  const F = foodOf(k);
  if (!F || !p || p.act !== 'eat' || teleporting(p, now) || p.meal) return { ok: false, reason: 'busy' };
  if (!free && !fridgeFoods(state.home).includes(k)) return { ok: false, reason: 'fridge' };
  let cost = 0;
  if (!free) {
    if ((state.pantry[k] || 0) > 0) state.pantry[k] -= 1;
    else if (coins >= F.price) cost = F.price;
    else return { ok: false, reason: 'coins' };
  }
  const gain = Math.max(1, Math.min(mealFill(state, F), 100 - Math.round(p.stats.tummy)));
  p.meal = { k, t0: now, ms: F.sec * 1000, base: p.stats.tummy, gain, done: false };
  return { ok: true, cost };
}

// The kitchen's pantry shop: food bought ahead goes into the pantry, and
// meals take from the pantry before they cost coins. A pack of FOOD_PACK
// costs FOOD_PACK - 1 of them. Only what the fridge holds is on sale.
export const FOOD_PACK = 5;
export const foodCost = (F, n) => F.price * (n >= FOOD_PACK ? n - Math.floor(n / FOOD_PACK) : n);

// Buys `n` of food `k` into the pantry (the caller has `coins` and pays the
// `cost` this returns). Returns { ok, cost } or { ok: false, reason:
// 'fridge' | 'coins' }.
export function buyFood(state, k, n, { coins = 0 } = {}) {
  const F = foodOf(k);
  if (!F || !fridgeFoods(state.home).includes(k)) return { ok: false, reason: 'fridge' };
  const cost = foodCost(F, n);
  if (coins < cost) return { ok: false, reason: 'coins' };
  state.pantry[k] = (state.pantry[k] || 0) + n;
  return { ok: true, cost };
}

// what a food fills in this home (the kitchen's decor adds to it)
export const mealFill = (state, F) => Math.round(F.fill * (1 + perk(state.home, 'kitchen')));

// Moves the squad on to `now`. Returns the events that happened, for the
// screen's toasts and "+N" labels:
//   { type: 'plus', id, text }      a label over the creature
//   { type: 'coins', n }            coins to credit (while open)
//   { type: 'home', id, why }       came home: 'hungry' (dance/yard) | 'woke'
//   { type: 'wander', id }          moved to another yard spot
export function tick(state, now, { open = true, rnd = Math.random } = {}) {
  const events = [];
  const dtm = Math.max(0, now - state.t);
  state.t = now;
  if (!dtm) return events;
  const dt = dtm / 1000;
  const perks = { bath: perk(state.home, 'bath'), bed: perk(state.home, 'bed'), dance: perk(state.home, 'dance'), yard: perk(state.home, 'yard') };
  const tvE = tvRate(state.home);

  if (open) {
    state.coinAcc = (state.coinAcc || 0) + coinRate(state, now) * dt;
    if (Math.abs(state.coinAcc) >= 1) {
      const n = state.coinAcc > 0 ? Math.floor(state.coinAcc) : Math.ceil(state.coinAcc);
      state.coinAcc -= n;
      events.push({ type: 'coins', n });
    }
  }

  Object.keys(state.pets).forEach((id) => {
    const p = state.pets[id];
    if (teleporting(p, now)) return;
    const R = RATE[p.act];
    const s = p.stats;
    Object.keys(R).forEach((k) => {
      let rr = R[k];
      if (rr > 0 && p.act === 'bath') rr *= bathOf(state, p).mul * (1 + perks.bath);
      if (p.act === 'tv' && k === 'energy') rr = tvE;
      // the dance room's and the yard's furniture and decor slow the draining
      if (rr < 0 && (p.act === 'dance' || p.act === 'yard')) rr *= Math.max(0.2, 1 - perks[p.act]);
      // a low stat drains slower (the design's soft factor)
      const soft = rr < 0 ? 0.25 + 0.75 * Math.min(1, s[k] / 50) : 1;
      s[k] = clamp(s[k] + rr * soft * dt);
    });
    if (p.act === 'sleep') s.energy = clamp(s.energy + p.sleepRate * (1 + perks.bed) * dt);
    if (p.act === 'bath') {
      const b = bathOf(state, p);
      if (b.energy) s.energy = clamp(s.energy + b.energy * dt);
    }
    if (p.act === 'eat' && p.meal) {
      const M = p.meal;
      const q = Math.min(1, (now - M.t0) / M.ms);
      s.tummy = Math.max(s.tummy, clamp(M.base + M.gain * q));
      if (q >= 1 && !M.done) {
        M.done = true;
        events.push({ type: 'plus', id, text: `+${M.gain} TUMMY` });
      }
      if (now > M.t0 + M.ms + MEAL_LINGER_MS) {
        p.meal = null;
        if (s.tummy >= 95) events.push({ type: 'plus', id, text: 'ALL FULL!' });
      }
    }
    if (!p.done && p.act === 'bath' && s.clean >= 100) {
      p.done = true;
      events.push({ type: 'plus', id, text: 'SQUEAKY CLEAN!' });
      if (open) events.push({ type: 'coins', n: 10 });
    }
    if ((p.act === 'dance' || p.act === 'yard') && s.tummy < 20) {
      if (sendTo(state, id, 'home', { now, rnd }).ok) events.push({ type: 'home', id, why: 'hungry' });
    } else if (p.act === 'sleep' && p.sleepEnd && now >= p.sleepEnd) {
      events.push({ type: 'plus', id, text: `+${p.sleepGain} ENERGY` });
      if (open) events.push({ type: 'coins', n: 10 });
      if (sendTo(state, id, 'home', { now, rnd }).ok) events.push({ type: 'home', id, why: 'woke' });
    }
    // out in the yard, creatures wander between the free games
    if (p.act === 'yard' && now >= p.until) {
      const s2 = freeSpot(state, 'yard', rnd);
      if (s2 >= 0 && s2 !== p.spot) {
        p.spot = s2;
        events.push({ type: 'wander', id });
      }
      p.until = now + 8000 + rnd() * 6000;
    }
  });
  return events;
}

// Catches the squad up after the Crib was closed: at most OFFLINE_CAP_MS of
// their time passes, no coins change hands.
export function advanceOffline(state, now = Date.now()) {
  const dt = Math.min(Math.max(0, now - state.t), OFFLINE_CAP_MS);
  const events = tick(state, state.t + dt, { open: false });
  state.t = now;
  state.coinAcc = 0;
  // nothing is mid-teleport after time away
  Object.values(state.pets).forEach((p) => {
    if (p.since > now) p.since = now;
  });
  return events;
}

// what a loaded document needs to be a state (an older or partial one)
export function normalize(doc, ids, now = Date.now()) {
  if (!doc || typeof doc !== 'object' || !doc.pets) return freshState(ids, now);
  const state = { ...freshState([], now), ...doc, pets: {} };
  state.home = normalizeHome(doc.home);
  Object.keys(doc.pets).forEach((id) => {
    const p = doc.pets[id];
    if (!p || !p.stats || !ACTS[p.act]) return;
    const spots = spotsFor(p.room, state.home) || [];
    if (!spots.length || p.spot >= spots.length) return;
    state.pets[id] = { ...freshPet(id, p.room, p.spot, now), ...p, stats: { clean: clamp(+p.stats.clean || 0), energy: clamp(+p.stats.energy || 0), tummy: clamp(+p.stats.tummy || 0) } };
  });
  state.t = Math.min(+doc.t || now, now);
  syncPets(state, ids, now);
  return state;
}

// After the furniture changed (an upgrade, a bath station, a game moved or
// put away): creatures on a spot that's gone go back to the living room.
// Returns the ids that moved.
export function applyLayout(state, now = Date.now()) {
  const moved = [];
  ['tv', 'bath', 'dance', 'yard'].forEach((room) => {
    const n = spotsFor(room, state.home).length;
    Object.keys(state.pets).forEach((id) => {
      const p = state.pets[id];
      if (p.room !== room || p.spot < n) return;
      const spot = Math.max(0, freeSpot(state, 'living', () => 0));
      p.from = { room: p.room, spot: p.spot, at: now };
      p.room = 'living';
      p.spot = spot;
      p.act = 'home';
      p.since = now;
      p.meal = null;
      p.sleepEnd = null;
      p.sleepRate = 0;
      p.sleepGain = 0;
      moved.push(id);
    });
  });
  return moved;
}
