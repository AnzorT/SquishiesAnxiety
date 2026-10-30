import { BY_ID, HIDDEN, isOut, owns } from '../squad/data';
import ART from './art';

// Which creatures Squish Stack stacks: the player's own first, topped up
// from the rest of the roster (a level needs up to 8 different ones, and a
// new player owns one). Out creatures only (not on config/roster's hidden
// list), no pass creature, and never the Masked or Elemental Heroes (tall
// figures don't stack).
// Each is drawn from its cut-out (art.js: the body alone, no floor shadow,
// bundled); a creature published since falls back to its rig still
// (`thumb.url`) with a typical body box.
const LEFT_OUT = new Set(['heroes', 'elemental']);
const TYPICAL = [0.12, 0.17, 0.88, 0.92];

// [{ id, key, uri, source, ar, box, mine }]
//   source, ar  the picture and its height / width
//   box         where the body sits in it ([left, top, right, bottom], fractions)
//   uri         the rig still (heads, the map's mascot)
export function castOf(creatures, profile, hidden = HIDDEN) {
  return (creatures || [])
    .filter((c) => c && c.thumb && c.thumb.url && BY_ID[String(c.id)])
    .map((c) => ({ c, d: BY_ID[String(c.id)] }))
    .filter(({ d }) => !LEFT_OUT.has(d.set) && isOut(d, hidden) && !d.pass)
    .map(({ c, d }) => {
      const art = ART[d.key];
      return {
        id: String(c.id),
        key: d.key,
        uri: c.thumb.url,
        source: art ? art.src : { uri: c.thumb.url },
        ar: art ? art.ar : 1,
        box: art ? [0, 0, 1, 1] : TYPICAL,
        mine: owns(profile || {}, String(c.id)),
      };
    });
}

// `n` different ones for a level, owned ones first, in a random order (so
// which one is the biggest changes every play).
export function pickCast(cast, n, rand = Math.random) {
  const shuffle = (a) => {
    const b = a.slice();
    for (let i = b.length - 1; i > 0; i--) {
      const j = Math.floor(rand() * (i + 1));
      [b[i], b[j]] = [b[j], b[i]];
    }
    return b;
  };
  const chosen = [...shuffle(cast.filter((c) => c.mine)), ...shuffle(cast.filter((c) => !c.mine))].slice(0, n);
  return shuffle(chosen);
}
