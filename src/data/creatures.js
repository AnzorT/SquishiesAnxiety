// What's left here after the creature roster/art/3D-model data moved to
// Firestore (see functions/index.js's one-time migration and
// src/data/creatureCache.js) — app-level constants that were never part of
// that catalog data in the first place.

// The creature every new account already owns: Glorp. Every other one is
// unlocked with stickers, coins or $0.99 (src/economy.js) — each gets its
// key, redeemed with the hold-to-unlock gesture on its Home card. (Accounts
// made before this owned Puffle and Nubbin too, and keep them.) Ids match
// the live Firestore `creatures` collection (0 Glorp).
export const STARTER_CREATURE_IDS = ['0'];

// Soft-body dent physics constants — identical for every creature.
export const PHYS = { strength: 2.2, stiff: 0.55, damp: 0.68, wobbleKick: 0.4 };
