import { BY_ID, HIDDEN, isOut, owns } from '../squad/data';
import HEADS from './heads';

// Which creatures Squishdoku draws: the player's own (one owned = every
// piece and score creature is that one), never the Masked or Elemental
// Heroes, and only from the groups that are out (config/roster: hidden).
// With none of those owned, any of the rest. Rig stills (`thumb.url`) from
// the catalog.
const LEFT_OUT = new Set(['heroes', 'elemental']);
// rig still -> the creature's key, for its board head (headOf)
const KEY_OF = new Map();

export function rosterOf(creatures, profile, hidden = HIDDEN) {
  const fit = (creatures || []).filter((c) => c && c.thumb && c.thumb.url && BY_ID[String(c.id)] && !LEFT_OUT.has(BY_ID[String(c.id)].set) && isOut(BY_ID[String(c.id)], hidden));
  fit.forEach((c) => KEY_OF.set(c.thumb.url, BY_ID[String(c.id)].key));
  const mine = fit.filter((c) => owns(profile || {}, String(c.id)));
  return (mine.length ? mine : fit).map((c) => c.thumb.url);
}

// A roster creature's board head (heads.js: the head alone, in its idle,
// happy and sad faces, bundled), or null for one published since (the board
// then draws its rig still).
export const headOf = (uri) => HEADS[KEY_OF.get(uri)] || null;

// A key that changes only when what the player owns does (for memos).
export const ownedKey = (profile) => `${(profile?.ownedIds || []).join()}|${Object.keys(profile?.col || {}).join()}`;
