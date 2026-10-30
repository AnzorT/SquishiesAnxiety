// The player's XP and level (PLAYER_XP.md). One total on the profile, `pxp`,
// filled by the mini-games, the daily challenges and squishing; the level
// comes from it. The curve, the level road and what earns XP are Firestore
// config/levels (functions/squad.js levelsOf, which the server reads too —
// it pays the road's prizes: `levelClaim`), so they change without an app
// update. Pure functions: src/firebase/firestore.js writes what they return.
import squad from '../functions/squad.js';

// config/levels as App last saw it (setLevelsConfig, before the screens
// redraw; nothing yet: the defaults)
let levelsCfg = null;
export const setLevelsConfig = (cfg) => {
  levelsCfg = cfg || null;
};
export const levelsConfig = () => squad.levelsOf(levelsCfg);
// what earns XP: { challenge, chest, squishEvery, squishDay, replay, games, blitz }
export const xpRules = () => squad.levelsOf(levelsCfg).xp;

export const xpToNext = (L) => squad.xpToNext(L, levelsCfg);
export const xpToReach = (L) => squad.xpToReach(L, levelsCfg);
export const playerLevel = (pxp) => squad.playerLevel(pxp, levelsCfg);

// What a profile from before player XP (no `pxp` yet) counts as: the XP of
// the level it had, plus its Squishdoku Puzzle XP (which this replaces).
const legacyXp = (profile) => xpToReach(Math.max(1, Math.floor(profile?.level ?? 1))) + Math.max(0, Math.floor(profile?.sdk?.xp ?? 0));

export const pxpOf = (profile) => (typeof profile?.pxp === 'number' ? Math.max(0, profile.pxp) : legacyXp(profile));

// The one-time move over to player XP: the fields to write, or null once
// done. The levels it brings aren't announced (`lvSeen`); their prizes wait
// on the road.
export function migrateXp(profile) {
  if (!profile || typeof profile.pxp === 'number') return null;
  const pxp = legacyXp(profile);
  const { level } = playerLevel(pxp);
  return { pxp, level, lvSeen: level };
}

// { level, into, need, pxp }: the LV pill and its bar.
export function xpView(profile) {
  const pxp = pxpOf(profile);
  return { ...playerLevel(pxp), pxp };
}

// `n` more XP: { xp, before, after, levelUps } — before / after are
// playerLevel()s (the result screens' bar), levelUps the levels reached.
export function addXp(profile, n) {
  const xp = Math.max(0, Math.round(n || 0));
  const total = pxpOf(profile);
  const before = playerLevel(total);
  const after = playerLevel(total + xp);
  const levelUps = [];
  for (let L = before.level + 1; L <= after.level; L++) levelUps.push(L);
  return { xp, before, after, levelUps };
}

// A mini-game level's XP, × config's `games`.
export const gameXp = (n) => Math.round(n * xpRules().games);

// A mini-game level's XP after a win: `full` the first time, else the
// better of config's `replay` share of it (half: the user, 2026-10-25) and
// what it adds over `prevFull` (the XP the best result so far would pay now).
export const winXp = (full, prevFull = null) => (prevFull == null ? full : Math.max(Math.round(full * xpRules().replay), full - prevFull));

// --- the level road ---------------------------------------------------------------
//
// A prize for each level on config/levels' road (1 to 50 by default):
// [{ lv, r: { k, n, t }, reached, got, claimable }]. A level not reached
// shows locked even if its prize was claimed (when a level took less XP
// before a config change); it shows claimed again once reached.
export function roadView(profile) {
  const { road } = levelsConfig();
  const { level } = xpView(profile);
  const got = profile?.levelGot || {};
  return road.map((r, i) => {
    const lv = i + 1;
    const reached = level >= lv;
    return { lv, r, reached, got: reached && !!got[lv], claimable: reached && !got[lv] };
  });
}

export const roadClaimable = (profile) => roadView(profile).filter((n) => n.claimable).length;

// The prize for reaching `lv` (null past the road's end).
export const roadPrize = (lv) => levelsConfig().road[lv - 1] || null;

export const CHEST_NAME = { common: 'Common', rare: 'Rare', epic: 'Epic', legendary: 'Legendary', set: 'Rainbow' };
const fmt = (n) => String(Math.round(n)).replace(/\B(?=(\d{3})+(?!\d))/g, ',');

// "1,200 coins", "50 gems", "a Rare chest"
export function prizeText(r) {
  if (!r) return '';
  if (r.k === 'coins') return `${fmt(r.n)} coins`;
  if (r.k === 'gems') return `${fmt(r.n)} gems`;
  return `${r.t === 'epic' ? 'an' : 'a'} ${CHEST_NAME[r.t] || ''} chest`;
}
