// What's left here after the creature roster/art/3D-model data moved to
// Firestore (see functions/index.js's one-time migration and
// src/data/creatureCache.js) — app-level constants that were never part of
// that catalog data in the first place.

// Starter creatures every new account already owns (unlocked, no key/coins
// required) — the rest are bought as a key in the Store, then redeemed with
// a hold-to-unlock gesture on their Home card. Ids match the live Firestore
// `creatures` collection (0 Glorp, 1 Puffle, 2 Nubbin).
export const STARTER_CREATURE_IDS = ['0', '1', '2'];

// Soft-body dent physics constants — identical for every creature.
export const PHYS = { strength: 2.2, stiff: 0.55, damp: 0.68, wobbleKick: 0.4 };
