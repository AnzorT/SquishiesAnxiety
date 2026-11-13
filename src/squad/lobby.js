// The lobby's state on the profile (the design's squad-lobby.js, kept in
// localStorage there): which squishy is selected (shown in the lobby, ringed
// in the Squad grid), and which owned ones the player hasn't looked at yet
// (NEW, counted on the Squad tile). Written by src/firebase/firestore.js
// (setLobbySelected, markSquadSeen).
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

// Before the first visit there's no `lobby` yet: App seeds `seen` with
// everything owned then, so only what comes after wears NEW.
export const lobbySeeded = (profile) => !!profile?.lobby?.seen;
const seenSet = (profile) => new Set(profile?.lobby?.seen || []);

export const isNewId = (profile, id) => lobbySeeded(profile) && owns(profile, String(id)) && !seenSet(profile).has(String(id));

export function newIds(profile) {
  if (!lobbySeeded(profile)) return [];
  const seen = seenSet(profile);
  return ownedIdList(profile).filter((id) => !seen.has(id));
}
