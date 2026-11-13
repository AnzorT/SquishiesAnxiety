// Firestore for the in-app game (webgame/): the admin's remote config and the player's new house.
import firestore from '@react-native-firebase/firestore';

const userDoc = (uid) => firestore().collection('users').doc(uid);
// the new house's layout (the design's own save, a JSON string), next to the old Crib's users/{uid}/crib/state
// (same rules: only the player reads and writes it)
const houseDoc = (uid) => userDoc(uid).collection('crib').doc('house6');

// config/game: the admin's switches boiled down (functions/gameConfig.js). Calls back with {} when there is none.
export function subscribeToGameConfig(onChange) {
  return firestore()
    .collection('config')
    .doc('game')
    .onSnapshot(
      (snap) => {
        const d = snap && snap.exists ? snap.data() : null;
        if (!d) return onChange({});
        const { updatedAt, ...config } = d; // a Timestamp can't cross into the WebView
        onChange(config);
      },
      (e) => {
        console.warn('subscribeToGameConfig failed:', e);
        onChange({});
      }
    );
}

export async function loadHouse(uid) {
  try {
    const snap = await houseDoc(uid).get();
    return snap.exists ? snap.data().data || null : null;
  } catch (e) {
    console.warn('loadHouse failed:', e);
    return null;
  }
}

export function saveHouse(uid, data) {
  if (typeof data !== 'string' || !data) return;
  houseDoc(uid)
    .set({ data, t: firestore.FieldValue.serverTimestamp() })
    .catch((e) => console.warn('saveHouse failed:', e));
}

// Coins spent (or earned) inside the game. The game keeps its own count from the player's coins, so only the
// change is written (another change on the server in between isn't overwritten).
export function gameCoins(uid, delta) {
  if (!delta) return;
  const update = { coins: firestore.FieldValue.increment(delta) };
  if (delta > 0) update.totalEarned = firestore.FieldValue.increment(delta);
  userDoc(uid).update(update).catch((e) => console.warn('gameCoins failed:', e));
}

// The creature key the game knows a creature by (its rig key, else its name: "Mittens" -> "mittens").
export const creatureKey = (c) => (c && c.rig && c.rig.key) || String((c && c.name) || '').toLowerCase().replace(/[^a-z]/g, '');
