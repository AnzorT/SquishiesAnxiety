// Squish Hop's levels, rooms, scoring and rewards (SQUISH_HOP.md), and the
// profile's `hop` record they're saved in. Pure functions: the screen writes
// what they return.
//
// Unlike the other mini-games, every level is fixed: levelData.js holds each
// board, made and checked by the solver ahead of time (the prototype's
// tools/gen.mjs), so a level is the same board every time it's played,
// replayed or retried. There's no adaptive difficulty: a level's tier is how
// hard its board measured (the solver's effort) against the other levels.
// The levels walk through the Crib's rooms, each bringing in a twist, and the
// time of day moves on through each room's levels.
import LEVEL_DATA from './levelData.js';
import { DCH, parse, starsFor as engineStars } from './engine.js';
import { addXp, gameXp, winXp } from '../playerXp.js';

export const LEVELS = LEVEL_DATA.length;

export const TIER_NAMES = ['EASY', 'MEDIUM', 'HARD', 'EXPERT'];
export const TIER_COLORS = ['#3ddc97', '#5fb8ff', '#ff8a4a', '#e01e4a'];

// The Crib's rooms (src/crib/roomArt.js): where the floor starts in the
// 852 × 393 scene (FLOOR_TOP / SCENE_H), the part of the room to show on a
// phone (cx, 0 left … 1 right), the cushion colour that stands out on its
// floor, the floor colour behind it, and the dent a cushion leaves.
export const ROOMS = {
  living: { name: 'Living Room', floor: 200 / 393, cx: 0.5, cushion: 'mint', rug: true, bg: '#dba163' },
  kitchen: { name: 'Kitchen', floor: 236 / 393, cx: 0.42, cushion: 'lilac', bg: '#efc499' },
  bath: { name: 'Bathroom', floor: 236 / 393, cx: 0.45, cushion: 'pink', bg: '#ffffff', dent: 'rgba(60,110,150,0.45)' },
  bed: { name: 'Bedroom', floor: 212 / 393, cx: 0.5, cushion: 'lilac', bg: '#dba163' },
  yard: { name: 'Yard', floor: 214 / 393, cx: 0.66, cushion: 'pink', bg: '#96cb74', dent: 'rgba(255,255,255,0.8)' },
  dance: { name: 'Dance Room', floor: 200 / 393, cx: 0.24, dance: true, bg: '#3b2030' },
};
// the time of day through a room's levels, from the phases its art has
const PHASE_ORDER = ['morning', 'day', 'evening', 'night'];
const PHASES_OF = {
  living: PHASE_ORDER,
  kitchen: PHASE_ORDER,
  bath: ['day'],
  bed: PHASE_ORDER,
  yard: PHASE_ORDER,
  dance: ['day'],
};

// what each twist is called on the map and in the banner that brings it in
export const TWISTS = {
  friends: { name: 'FRIENDS', text: 'FRIENDS!', sub: 'The ★ opens when everyone is with you' },
  arrows: { name: 'ARROWS', text: 'ARROWS!', sub: 'Hop off an arrow cushion the way it points' },
  bubbles: { name: 'BUBBLES', text: 'BUBBLES!', sub: 'Land on a bubble and it bounces you one further' },
  piles: { name: 'PILES', text: 'PILES!', sub: 'Two cushions on top of each other take two hops' },
  ordered: { name: 'IN ORDER', text: 'IN ORDER!', sub: 'Pick the friends up 1, 2, 3…' },
  beats: { name: 'ON THE BEAT', text: 'ON THE BEAT!', sub: 'Coloured tiles light up every third hop. Land on them lit' },
};

// The rooms in level order (runs of the same room in levelData.js): the map's
// bands. { room, from, to } with 1-based levels.
export const CHAPTERS = [];
LEVEL_DATA.forEach((L, i) => {
  const last = CHAPTERS[CHAPTERS.length - 1];
  if (last && last.room === L.room) last.to = i + 1;
  else CHAPTERS.push({ room: L.room, from: i + 1, to: i + 1 });
});
const chapterOf = (lv) => CHAPTERS.findIndex((c) => lv >= c.from && lv <= c.to);

// the map's list (src/sort/LevelMap.js): a band per room
export const LEVEL_LIST = LEVEL_DATA.map((L, i) => ({ band: chapterOf(i + 1), room: L.room, tier: L.tier, news: L.news }));

const clampLv = (lv) => Math.max(1, Math.min(LEVELS, Math.floor(lv) || 1));

// The room and time of day level `lv` is played in. `key` changes when the
// picture does (the room-switch flash).
export function stageOf(lv) {
  const L = clampLv(lv);
  const ch = CHAPTERS[chapterOf(L)];
  const phases = PHASES_OF[ch.room] || ['day'];
  const k = Math.min(phases.length - 1, Math.floor(((L - ch.from) / (ch.to - ch.from + 1)) * phases.length));
  return { room: ch.room, phase: phases[k], key: `${ch.room}:${k}` };
}

// Level `lv` (1-based): { lv, ...its data, lv (parsed board), sol (the full
// clear as directions), room, phase, stageKey, beats, cushions, twists }.
export function levelSpec(lv) {
  const L = clampLv(lv);
  const d = LEVEL_DATA[L - 1];
  const board = parse(d.map);
  const stage = stageOf(L);
  const twists = [];
  if (board.friends.length) twists.push(board.order.some((o) => o > 0) ? 'ordered' : 'friends');
  if (board.arrow.some((a) => a >= 0)) twists.push('arrows');
  if (board.bubble.some(Boolean)) twists.push('bubbles');
  if (board.life.some((x) => x === 2)) twists.push('piles');
  if (board.beat.some((b) => b >= 0)) twists.push('beats');
  return {
    lv: L,
    map: d.map,
    tier: d.tier,
    news: d.news,
    sols: d.sols,
    effort: d.effort,
    board,
    sol: [...d.solution].map((c) => DCH.indexOf(c)),
    room: stage.room,
    phase: stage.phase,
    stageKey: stage.key,
    beats: board.beat.some((b) => b >= 0),
    cushions: board.life.filter((x) => x > 0).length,
    twists,
  };
}

// --- scoring ----------------------------------------------------------------------

// 3: every cushion cleared before the ★; 2: up to 3 left; 1: more left. A
// hint (watched for with an ad) takes one off, never the last.
export const starsFor = (left, hinted) => engineStars(left, hinted);

const STAR_MULT = [0, 1, 1.5, 2];
// Bigger boards and more twists pay more; harder tiers 15% more each.
export function coinsFor(spec, stars) {
  const base = 8 + 0.6 * spec.cushions + 4 * spec.twists.length + 2 * spec.board.friends.length;
  return Math.round(base * STAR_MULT[stars] * (1 + 0.15 * spec.tier));
}

// The player's XP for a win (src/playerXp.js): Squish Sort's and Squish
// Stack's formula, by the level number. A hint's lost star costs XP too.
export function xpFor(spec, stars) {
  return Math.round((10 + Math.floor(spec.lv / 2) + 5 * spec.tier) * (0.6 + 0.2 * stars));
}

// --- the profile's record -----------------------------------------------------------

export function record(profile) {
  const s = (profile && profile.hop) || {};
  return {
    lv: clampLv(s.lv || 1),
    best: s.best || {},
    plays: s.plays || 0,
    wins: s.wins || 0,
    seen: !!s.seen,
  };
}

// total stars won
export const starsOf = (rec) => Object.values(rec.best).reduce((a, n) => a + (n || 0), 0);
// levels beaten
export const doneOf = (rec) => rec.lv - 1 + (rec.best[LEVELS] ? 1 : 0);

// The fields to write after a level is won, and what it paid: coins, the
// player's XP (half on a replay: winXp) and the levels it reached (`before` /
// `after`: the result's XP bar). result: { left, hinted }
export function afterLevel(profile, spec, result) {
  const rec = record(profile);
  const stars = starsFor(result.left, !!result.hinted);
  const update = {
    'hop.plays': rec.plays + 1,
    'hop.wins': rec.wins + 1,
    'hop.seen': true,
  };
  const coins = coinsFor(spec, stars);
  const best = rec.best[spec.lv] || 0;
  const xp = winXp(gameXp(xpFor(spec, stars)), best ? gameXp(xpFor(spec, best)) : null);
  if (stars > best) update[`hop.best.${spec.lv}`] = stars;
  const unlocked = spec.lv === rec.lv && rec.lv < LEVELS;
  if (unlocked) update['hop.lv'] = rec.lv + 1;
  return { update, coins, xp, ...addXp(profile, xp), stars, unlocked };
}

// a RETRY after getting stuck counts as a play
export const afterStuck = (profile) => ({ 'hop.plays': record(profile).plays + 1, 'hop.seen': true });
