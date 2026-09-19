import * as FileSystem from 'expo-file-system';

// On-device mirror of the Firestore `creatures` collection. Firestore reads
// there require an authenticated user (see firestore.rules), but the splash
// screen renders before login even happens (see App.js's stage machine) —
// so on a brand-new install, before the person has ever signed in, there is
// genuinely nothing to show yet. Every login after the first one, though,
// this cache already has yesterday's (or today's) catalog on disk, so the
// splash can render immediately, before Firestore or auth have resolved.
const CATALOG_PATH = `${FileSystem.documentDirectory}creatureCatalog.json`;

export async function loadCachedCreatures() {
  try {
    const info = await FileSystem.getInfoAsync(CATALOG_PATH);
    if (!info.exists) return [];
    const text = await FileSystem.readAsStringAsync(CATALOG_PATH);
    const parsed = JSON.parse(text);
    return Array.isArray(parsed) ? parsed : [];
  } catch {
    return [];
  }
}

// Best-effort — a failed write just means the next cold start (before login)
// won't have a cache yet either, same as today.
export async function saveCreaturesToCache(creatures) {
  try {
    await FileSystem.writeAsStringAsync(CATALOG_PATH, JSON.stringify(creatures));
  } catch {
    // ignore
  }
}
