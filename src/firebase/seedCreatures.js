import firestore from '@react-native-firebase/firestore';

// Runs once on app boot. If the `creatures` collection is already
// populated (any real deploy will manage this from the Firebase console
// instead), this is a no-op. Exported so App.js can also use it to override
// whatever's actually stored in Firestore — see the comment there.
export const DEFAULT_CREATURES = [
  {
    id: 'buddy',
    name: 'Buddy',
    description: 'Soft and squishy, always up for a squeeze.',
    colors: ['#7EC3EE'],
    price: 0,
    order: 0,
  },
  {
    id: 'pebble',
    name: 'Pebble',
    description: 'A speckled seal pup who flops around and loves belly boops.',
    colors: ['#9AA7AE'],
    species: 'seal',
    price: 150,
    order: 1,
  },
  {
    id: 'suki',
    name: 'Suki',
    description: 'A seal-point kitten with big round eyes and cold little paws.',
    colors: ['#C9C2B8'],
    species: 'cat',
    price: 300,
    order: 2,
  },
  {
    id: 'glimmer',
    name: 'Glimmer',
    description: 'A glittery jelly ball that pops with sparkles on release.',
    colors: ['#E3A62B'],
    species: 'sparkle',
    price: 400,
    order: 3,
  },
  {
    id: 'gouda',
    name: 'Gouda',
    description: 'A squishy cheese cube, riddled with holes.',
    colors: ['#F3C13D'],
    species: 'cheese',
    price: 500,
    order: 4,
  },
];

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
