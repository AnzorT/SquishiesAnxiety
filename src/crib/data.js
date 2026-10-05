// The Squad Crib's rules and layout, from the design's "Squad Crib v5.dc.html"
// (its ACTS, RATE, STATS, SLEEP, ROOMS and PH tables). Pure data — the
// simulation is model.js, the drawing Scene.js. Everything is in the design's
// scene units: the scene is 852×393 and a creature 72 wide, scaled to the
// screen when drawn.

import catalog from './catalog.js';
import { freshHome, layout } from './home.js';

export const SCENE_W = 852;
export const SCENE_H = 393;
export const SIZE = 72; // a creature's box in the scene

// an hour of the creatures' day passes in 15 s ("demo speed" in the design)
export const SEC_PER_HR = 15;
export const SLEEP = [0.5, 1, 2, 4, 8, 12]; // the sleep picker's hours

// What a creature can be sent to do, and the room it happens in. `hint` is
// the action button's small text, `verb` the card's status line, `stop` the
// "bring home" button. 'tv' happens in the living room, on the sofa.
export const ACTS = {
  home: { room: 'living', label: 'Home', verb: 'Chilling at home' },
  bath: { room: 'bath', label: 'Bath', hint: '+ clean', verb: 'In the bubble bath', stop: 'Enough bath', icon: 'bath', light: '#d6f2fc', color: '#5fb6dc' },
  eat: { room: 'kitchen', label: 'Snack', hint: '+ tummy', verb: 'Snacking', stop: 'Enough snacks', icon: 'food', light: '#ffefc2', color: '#f2b84a' },
  sleep: { room: 'bed', label: 'Sleep', hint: '+ energy', verb: 'Sleeping', stop: 'Wake up', icon: 'sleep', light: '#ebe2fb', color: '#9b84d8' },
  dance: { room: 'dance', label: 'Dance', hint: 'till hungry', verb: 'Dancing', stop: 'Stop dancing', icon: 'music', light: '#ffd6e6', color: '#ff5c8a' },
  yard: { room: 'yard', label: 'Play', hint: 'till hungry', verb: 'Playing outside', stop: 'Come inside', icon: 'ball', light: '#d8efc6', color: '#7fae6a' },
  tv: { room: 'tv', label: 'Watch TV', hint: 'rest', verb: 'Watching TV on the couch', stop: 'Turn off TV', icon: 'tv', light: '#ffe0d6', color: '#f2665a' },
};
export const ACT_ORDER = ['bath', 'eat', 'sleep', 'dance', 'yard', 'tv'];

// stat change per second while doing each thing
export const RATE = {
  home: { clean: -0.05, energy: -0.04, tummy: -0.06 },
  tv: { clean: 0, energy: 0.35, tummy: -0.08 },
  bath: { clean: 5, energy: 0, tummy: -0.1 },
  eat: { clean: -0.05, energy: 0, tummy: 0 },
  sleep: { clean: 0, energy: 0, tummy: -0.1 },
  dance: { clean: -0.12, energy: -0.18, tummy: -0.18 },
  yard: { clean: -0.18, energy: -0.15, tummy: -0.18 },
};

export const STATS = [
  { k: 'clean', label: 'Clean', fix: 'bath', color: '#5fb6dc', light: '#d6f2fc' },
  { k: 'energy', label: 'Energy', fix: 'sleep', color: '#f2b84a', light: '#ffefc2' },
  { k: 'tummy', label: 'Tummy', fix: 'eat', color: '#f2665a', light: '#ffd9d2' },
];
export const NEED_AT = 40; // a stat under this is a need (the bubble, the sad / smelly look) — the user's number
export const START_STAT = 70; // a new creature's clean, energy and tummy

// the need bubbles' colours (the design's BUB)
export const BUBBLE = {
  clean: ['#d6f2fc', '#8fd0ec', '#5fb6dc'],
  tummy: ['#fff3c4', '#ffd66b', '#f2b84a'],
  energy: ['#f3ecff', '#c9b6f0', '#9b84d8'],
};

// Where creatures stand in each room ({x, y} = feet, scene units). The rooms
// whose spots come with the furniture (the sofa's seats, the tub, the dance
// floor, the yard's games) take them from the player's home — see
// spotsFor().
const LIVING = [80, 170, 260, 350, 440].map((x) => ({ x, y: 262 })).concat([125, 215, 305, 395, 485].map((x) => ({ x, y: 322 })), [80, 170, 260, 350, 440].map((x) => ({ x, y: 384 })));
export const ROOMS = {
  living: { name: 'Living Room', sub: 'hang-out spot', spots: LIVING },
  tv: { name: 'Living Room', view: 'living', spots: [] },
  kitchen: { name: 'Kitchen', sub: 'snack table', spots: [170, 272, 374, 476, 578, 680].map((x) => ({ x, y: 292 })) },
  bath: { name: 'Bathroom', sub: 'bubble bath for everyone', spots: [] },
  bed: { name: 'Bedroom', sub: '2 friends per bed', spots: [130, 330, 530, 730].flatMap((x) => [{ x: x - 42, y: 300 }, { x: x + 42, y: 300 }]) },
  dance: { name: 'Dance Room', sub: 'dance till you are hungry', spots: [] },
  hatch: { name: 'Hatchery', sub: 'where friends come from', spots: [] },
  yard: { name: 'Yard', sub: 'play till you are hungry', spots: [] },
};
export const ROOM_ORDER = ['living', 'kitchen', 'bath', 'bed', 'dance', 'hatch', 'yard'];
// the room a creature in `room` is seen in ('tv' is the living room)
export const viewOf = (room) => ROOMS[room].view || room;

// A room's spots in this home: the furniture's for the sofa, the bath, the
// dance floor, the yard, the snack table and the beds (home.js's layout —
// they move with the furniture), the fixed ones elsewhere.
const FURNISHED = ['tv', 'bath', 'dance', 'yard', 'kitchen', 'bed'];
export function spotsFor(room, home) {
  return FURNISHED.includes(room) ? layout(home || FRESH)[room] : ROOMS[room].spots;
}
const FRESH = freshHome();

export const FOODS = catalog.foods;
export const foodOf = (k) => FOODS.find((f) => f.k === k) || null;
export const FRESH_PANTRY = { carrot: 3, cookie: 2, marshmallow: 2 };

// the time of day: a phase for the room art, the tint over the whole scene
// (the design's ph.overlay) and the darkness the lamps light up (nl.dark)
export const PH = {
  morning: { label: 'MORNING', sun: '#ffe38a', tint: 'rgba(255,170,140,0.05)' },
  day: { label: 'DAYTIME', sun: '#fff3a0' },
  evening: { label: 'EVENING', sun: '#ffb36b', tint: 'rgba(90,20,120,0.1)', dark: [40, 20, 70, 0.22], glow: 0.18 },
  night: { label: 'NIGHT', sun: '#fff6d8', tint: 'rgba(20,24,70,0.22)', dark: [16, 12, 48, 0.52], glow: 0.34 },
};
export const phaseOf = (hour) => (hour >= 6 && hour < 10 ? 'morning' : hour >= 10 && hour < 17 ? 'day' : hour >= 17 && hour < 20 ? 'evening' : 'night');

export const fmtMin = (m) => (m >= 60 ? `${Math.floor(m / 60)}h ${m % 60}m` : `${m}m`);
