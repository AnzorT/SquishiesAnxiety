import firestore from '@react-native-firebase/firestore';

// Runs once on app boot. If the `creatures` collection is already
// populated (any real deploy will manage this from the Firebase console
// instead), this is a no-op.
const DEFAULT_CREATURES = [
  {
    id: 'buddy',
    name: 'Buddy',
    description: 'Soft and squishy, always up for a squeeze.',
    colors: ['#B18AE8', '#F293B8', '#7EC3EE', '#7FD9AC', '#F5B27E'],
    price: 0,
    order: 0,
  },
  {
    id: 'ember',
    name: 'Ember',
    description: 'Runs warm — toastier than the rest of the shelf.',
    colors: ['#F5B27E', '#F293B8'],
    price: 150,
    order: 1,
  },
  {
    id: 'mochi',
    name: 'Mochi',
    description: 'Dense, doughy, and extremely patient.',
    colors: ['#7FD9AC', '#B18AE8'],
    price: 300,
    order: 2,
  },
  {
    id: 'glacier',
    name: 'Glacier',
    description: 'Cool to the touch, slow to bounce back.',
    colors: ['#7EC3EE', '#7FD9AC'],
    price: 500,
    order: 3,
  },
];

export async function ensureCreaturesSeeded() {
  const snap = await firestore().collection('creatures').limit(1).get();
  if (!snap.empty) return;

  const batch = firestore().batch();
  DEFAULT_CREATURES.forEach(({ id, ...data }) => {
    batch.set(firestore().collection('creatures').doc(id), data);
  });
  await batch.commit();
}
