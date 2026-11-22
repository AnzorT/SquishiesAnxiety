import { selectedId } from '../squad/lobby';
import HEADS from '../squishdoku/heads';

// Who's in a Squish Hop level (SQUISH_HOP.md): the hopper is the player's own
// squishy (the one on the Lobby, if it has a cut-out), and the friends to pick
// up are others, the player's own first. Squish Stack's cast (stack/roster.js
// castOf: each drawn by its body cut-out). A level's friends are the same
// every time it's played, like its board.

// a seeded random (the level number), so a level always has the same friends
function rng(seed) {
  let s = (seed * 2654435761) % 2147483647 || 1;
  return () => {
    s = (s * 16807) % 2147483647;
    return (s - 1) / 2147483646;
  };
}
function shuffle(a, rand) {
  const b = a.slice();
  for (let i = b.length - 1; i > 0; i--) {
    const j = Math.floor(rand() * (i + 1));
    [b[i], b[j]] = [b[j], b[i]];
  }
  return b;
}

// the hopper: the Lobby's squishy, else the first owned one, else anyone
export function hopperOf(cast, profile) {
  const id = profile ? String(selectedId(profile) || '') : '';
  return cast.find((c) => c.id === id) || cast.find((c) => c.mine) || cast[0] || null;
}

// level `lv`'s `n` friends: owned ones first, in an order fixed by the level
export function friendsOf(cast, hopper, n, lv) {
  if (!n) return [];
  const rand = rng(lv);
  const rest = cast.filter((c) => !hopper || c.id !== hopper.id);
  const pool = [...shuffle(rest.filter((c) => c.mine), rand), ...shuffle(rest.filter((c) => !c.mine), rand)];
  return pool.slice(0, n);
}

// a creature's head with a face (squishdoku/heads.js), or null
export const headOf = (c, face = 'happy') => (c && HEADS[c.key] ? HEADS[c.key][face] : null);
