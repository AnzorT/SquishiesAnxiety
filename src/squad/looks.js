// The creatures' border looks (REDESIGN_V9, 2026-11-16: the user's new character art, four looks of every creature,
// "an option to control ... from firebase"). Wherever the app draws a creature still (cards, chests, the Shop, the
// Squad, Achievements, the loaders: everything that shows a creature's `thumb.url`), the picture is the chosen look's.
// The animated creatures (the menu's, the house's, Squish Time's) are drawn live and stay as they are.
//
// Firestore config/roster (tools/admin/roster.mjs --look, or the Firebase console):
//   look   1 shading only · 2 thin ink line · 3 bold ink line · 4 bold colour line (the default) · 0 the old pictures
//   looks  { <creature id or key>: n } — one creature in another look than the rest
// A change shows the next time a screen draws: no app update.
// The live, animated creatures get the look's outline too (2026-11-16, the user): src/components/RigCreature.js asks
// useRigLook, and the game's pages read state.looks (menuLooks); both draw it with webgame/app/rig-look.js.
//
// The pictures ship in the app (android/app/src/main/assets/looks/<n>/<key>.webp, tools/looks/encode.py). Prickle and
// Wisecrack have none in the zip and keep their old pictures.
import { useEffect, useReducer } from 'react';
import { Platform } from 'react-native';
import LOOK_KEYS from './lookKeys';
import { BY_ID } from './data';

export const LOOK_DEFAULT = 4;
const HAS = new Set(LOOK_KEYS);

// the look a creature is shown in (0: its old picture)
export function lookOf(cfg, c) {
  const per = cfg && cfg.looks && typeof cfg.looks === 'object' ? (cfg.looks[c.id] ?? cfg.looks[c.key]) : undefined;
  const raw = per ?? (cfg ? cfg.look : undefined);
  const n = Number(raw);
  return raw != null && Number.isInteger(n) && n >= 0 && n <= 4 ? n : LOOK_DEFAULT;
}

// a look's picture: from the app's own files (Android: its assets; web: Metro serves them at /android_asset/)
export const lookUri = (key, n) => (Platform.OS === 'web' ? `/android_asset/looks/${n}/${key}.webp` : `asset:/looks/${n}/${key}.webp`);

// The catalog (Firestore `creatures`) with each creature's still picture in its look.
export function withLooks(creatures, cfg) {
  if (!Array.isArray(creatures) || !creatures.length) return creatures;
  return creatures.map((c) => {
    const r = c && BY_ID[String(c.id)];
    if (!r || !HAS.has(r.key)) return c;
    const n = lookOf(cfg, r);
    if (!n) return c;
    return { ...c, thumb: { ...(c.thumb || {}), url: lookUri(r.key, n) } };
  });
}

// For the menu's pages (src/game/player.js): the default look and the creatures shown in another one, by key.
export function menuLooks(cfg) {
  const n = lookOf(cfg ? { look: cfg.look } : null, {});
  const over = {};
  if (cfg && cfg.looks && typeof cfg.looks === 'object') {
    LOOK_KEYS.forEach((key) => {
      const r = Object.values(BY_ID).find((x) => x.key === key);
      if (r) {
        const m = lookOf(cfg, r);
        if (m !== n) over[key] = m;
      }
    });
  }
  return { n, over, keys: LOOK_KEYS };
}

// --- the live rigs ------------------------------------------------------------------------------------------------
// App.js hands config/roster over as it changes (setLookConfig); a RigCreature on screen redraws with the new look.
let rigCfg = null;
const rigSubs = new Set();
const BY_KEY = {};
Object.values(BY_ID).forEach((c) => { BY_KEY[c.key] = c; });
export function setLookConfig(cfg) {
  if (cfg === rigCfg) return;
  rigCfg = cfg;
  rigSubs.forEach((f) => f());
}
// the look a live rig of the creature `key` is drawn in (0: it has no look pictures, so no outline either)
export function rigLookOf(key) {
  const r = BY_KEY[key];
  return r && HAS.has(key) ? lookOf(rigCfg, r) : 0;
}
export function useRigLook(key) {
  const [, redraw] = useReducer((x) => x + 1, 0);
  useEffect(() => {
    rigSubs.add(redraw);
    return () => rigSubs.delete(redraw);
  }, []);
  return rigLookOf(key);
}
