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

// What a NEW account owns (2026-11-21, the user: "starter becomes Mittens"): Mittens (1, Pet Shop) as well as the
// starter above. The starter alone (0, Nimbo) sits in the Sky & Stars group, which config/roster switches off, and a
// switched-off group's creatures don't show even to their owners: a new player saw no creature anywhere (an empty
// Squish Time card, "Playing as" with no name). Mittens is the one the intro brings out of the box, and the default
// pick (src/squad/lobby.js selectedId prefers 1). Existing accounts are not changed (ensureStarterCreaturesOwned
// still only tops up STARTER_CREATURE_IDS).
export const NEW_PLAYER_CREATURE_IDS = ['0', '1'];

// Soft-body dent physics constants — identical for every creature.
export const PHYS = { strength: 2.2, stiff: 0.55, damp: 0.68, wobbleKick: 0.4 };
