import firestore from '@react-native-firebase/firestore';

// Coins and unlocks are client-authoritative (writes go straight from the
// device to Firestore, guarded only by firestore.rules) — fine for a
// prototype economy, but note there's no server-side validation of *how
// much* a client credits itself. A Cloud Function would be the next step
// to close that off before this handles anything real.

const STARTER_CREATURE_ID = 'buddy';

function userDocRef(uid) {
  return firestore().collection('users').doc(uid);
}

export async function createUserProfile(uid, { email, age }) {
  await userDocRef(uid).set({
    email,
    age,
    coins: 0,
    ownedIds: [STARTER_CREATURE_ID],
    createdAt: firestore.FieldValue.serverTimestamp(),
  });
}

export function subscribeToUserProfile(uid, onChange) {
  return userDocRef(uid).onSnapshot(
    (snap) => onChange(snap.exists ? snap.data() : null),
    () => onChange(null)
  );
}

export async function addCoins(uid, amount) {
  if (!amount) return;
  await userDocRef(uid).update({ coins: firestore.FieldValue.increment(amount) });
}

export async function purchaseCreature(uid, creatureId, price) {
  const ref = userDocRef(uid);
  return firestore().runTransaction(async (transaction) => {
    const snap = await transaction.get(ref);
    const data = snap.data() || {};
    const coins = data.coins ?? 0;
    const ownedIds = data.ownedIds ?? [];

    if (ownedIds.includes(creatureId)) return { ok: true };
    if (coins < price) return { ok: false, reason: 'insufficient_coins' };

    transaction.update(ref, {
      coins: firestore.FieldValue.increment(-price),
      ownedIds: firestore.FieldValue.arrayUnion(creatureId),
    });
    return { ok: true };
  });
}

export function subscribeToCreatures(onChange) {
  return firestore()
    .collection('creatures')
    .orderBy('order', 'asc')
    .onSnapshot(
      (snap) => onChange(snap.docs.map((doc) => ({ id: doc.id, ...doc.data() }))),
      () => onChange([])
    );
}
