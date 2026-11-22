// The web demo's saves (src/web/Demo.js; a build with EXPO_PUBLIC_DEMO=1, tools/web/demo.mjs). In that build
// metro.config.js hands the app this file in place of src/firebase/firestore.js, so the games' saves land in the page's
// own profile, in memory: nothing reaches Firebase, and a reload starts over. Only the saves the demo's games make are
// here (the rest of firestore.js is never called by them).
import { addXp, pxpOf } from '../../playerXp';

let profile = {};
const subs = new Set();

export const demoProfile = () => profile;
export function setDemoProfile(p) {
  profile = p;
  subs.forEach((fn) => fn(profile));
}
export function subscribeDemo(fn) {
  subs.add(fn);
  return () => subs.delete(fn);
}

// a copy of `obj` with `path` (['stack', 'blitz', 'top']) set to `value`
function withPath(obj, path, value) {
  const [k, ...rest] = path;
  const here = obj && typeof obj === 'object' ? obj : {};
  return { ...here, [k]: rest.length ? withPath(here[k], rest, value) : value };
}

// as firestore.js saveGame: the fields (dotted paths), the coins, and the player's XP and level
function saveGame(uid, update = {}, coins = 0, xp = 0) {
  let p = profile;
  Object.entries(update).forEach(([k, v]) => {
    p = withPath(p, k.split('.'), v);
  });
  if (coins > 0) p = { ...p, coins: (p.coins || 0) + coins, totalEarned: (p.totalEarned || 0) + coins };
  if (xp > 0) {
    const r = addXp(p, xp);
    p = { ...p, pxp: pxpOf(p) + r.xp, ...(r.levelUps.length ? { level: r.after.level } : {}) };
  }
  setDemoProfile(p);
}

export const saveSquishdoku = (uid, update, coins = 0, xp = 0) => saveGame(uid, update, coins, xp);
export const saveSort = (uid, update, coins = 0, xp = 0) => saveGame(uid, update, coins, xp);
export const saveStack = (uid, update, coins = 0, xp = 0) => saveGame(uid, update, coins, xp);
export const saveHop = (uid, update, coins = 0, xp = 0) => saveGame(uid, update, coins, xp);
