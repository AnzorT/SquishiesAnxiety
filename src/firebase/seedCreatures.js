import firestore from '@react-native-firebase/firestore';
import { CREATURES } from '../data/creatures';

// Runs once on app boot. If the `creatures` collection is already
// populated (any real deploy will manage this from the Firebase console
// instead), this is a no-op. Exported so App.js can also use it to override
// whatever's actually stored in Firestore — see the comment there.
export const DEFAULT_CREATURES = CREATURES;

// Seeds any DEFAULT_CREATURES not already present, rather than bailing out
// the moment the collection is non-empty — so adding a new creature here
// still reaches projects that were already seeded from an earlier version
// of this list.
export async function ensureCreaturesSeeded() {
  const snap = await firestore().collection('creatures').get();
  const existingIds = new Set(snap.docs.map((doc) => doc.id));
  const missing = DEFAULT_CREATURES.filter(({ id }) => !existingIds.has(id));
  if (!missing.length) return;

  const batch = firestore().batch();
  missing.forEach(({ id, ...data }) => {
    batch.set(firestore().collection('creatures').doc(id), data);
  });
  await batch.commit();
}
