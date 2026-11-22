// The lobby's state on the profile (the design's squad-lobby.js, kept in
// localStorage there): which squishy is selected (the one Squish Time and the
// games start with). Written by src/firebase/firestore.js (setLobbySelected).
import { owns } from './data';

export const ownedIdList = (profile) => [...new Set([...Object.keys(profile?.col || {}), ...(profile?.ownedIds || [])])];

// The selected one while it's owned; else Mittens (the Welcome chest's), else
// the first owned.
export function selectedId(profile) {
  const sel = profile?.lobby?.sel;
  if (sel != null && owns(profile || {}, String(sel))) return String(sel);
  const own = ownedIdList(profile);
  return own.includes('1') ? '1' : own[0] ?? '0';
}
