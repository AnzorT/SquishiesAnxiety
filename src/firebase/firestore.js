import firestore from '@react-native-firebase/firestore';
import { STARTER_CREATURE_IDS } from '../data/creatures';

// Coins and unlocks are client-authoritative (writes go straight from the
// device to Firestore, guarded only by firestore.rules) — fine for a
// prototype economy, but note there's no server-side validation of *how
// much* a client credits itself. A Cloud Function would be the next step
// to close that off before this handles anything real.

function userDocRef(uid) {
  return firestore().collection('users').doc(uid);
}

export async function createUserProfile(uid, { email, age, nickname }) {
  await userDocRef(uid).set({
    email,
    age,
    nickname: nickname?.trim() || 'Squisher',
    coins: 250,
    totalEarned: 250,
    adsFree: false,
    ownedIds: STARTER_CREATURE_IDS,
    // Creature ids a key has been bought for but not yet redeemed via the
    // Home card's hold-to-unlock gesture — see buyKey/unlockWithKey below.
    keys: {},
    stats: { presses: 0, longestHoldMs: 0, playTime: {} },
    // The two achievements with no natural profile-derived signal (the rest
    // — creature unlocks, earn10k/100k, unlockAll — are computed straight
    // from ownedIds/totalEarned, see src/achievements.js).
    achievements: { speedTap: false, watchAd: false },
    createdAt: firestore.FieldValue.serverTimestamp(),
  });
}

// Accounts created before this app matched the new 10-creature roster have
// an `ownedIds` that predates STARTER_CREATURE_IDS (e.g. the old single
// 'buddy' starter) — without this, every one of the new roster's 3 free
// starters (Glorp/Puffle/Nubbin) would show up locked for them. Called once
// per profile load from App.js; idempotent and additive-only (arrayUnion),
// so it's a no-op once an account already has all three.
export async function ensureStarterCreaturesOwned(uid, ownedIds = []) {
  const missing = STARTER_CREATURE_IDS.filter((id) => !ownedIds.includes(id));
  if (!missing.length) return;
  await userDocRef(uid).update({ ownedIds: firestore.FieldValue.arrayUnion(...missing) });
}

export function subscribeToUserProfile(uid, onChange) {
  return userDocRef(uid).onSnapshot(
    (snap) => onChange(snap.exists ? snap.data() : null),
    () => onChange(null)
  );
}

export async function addCoins(uid, amount) {
  if (!amount) return;
  await userDocRef(uid).update({
    coins: firestore.FieldValue.increment(amount),
    // Cumulative lifetime total — unlike `coins` this never goes down on a
    // purchase, so it's what the "earn N coins" achievements track.
    totalEarned: firestore.FieldValue.increment(amount),
  });
}

export async function updateNickname(uid, nickname) {
  const trimmed = nickname?.trim();
  if (!trimmed) return;
  await userDocRef(uid).update({ nickname: trimmed });
}

export async function claimAdsFree(uid) {
  await userDocRef(uid).update({ adsFree: true });
}

export async function submitFeedback(uid, text) {
  const trimmed = text?.trim();
  if (!trimmed) return;
  await firestore().collection('feedback').add({
    uid,
    text: trimmed,
    createdAt: firestore.FieldValue.serverTimestamp(),
  });
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

// Store screen sells a *key*, not the creature itself — the creature only
// actually unlocks once its key is redeemed via the Home card's
// hold-to-unlock gesture (see unlockWithKey). Mirrors purchaseCreature's
// shape/guards, just writes to `keys` instead of `ownedIds`.
export async function buyKey(uid, creatureId, price) {
  const ref = userDocRef(uid);
  return firestore().runTransaction(async (transaction) => {
    const snap = await transaction.get(ref);
    const data = snap.data() || {};
    const coins = data.coins ?? 0;
    const ownedIds = data.ownedIds ?? [];
    const keys = data.keys ?? {};

    if (ownedIds.includes(creatureId) || keys[creatureId]) return { ok: true };
    if (coins < price) return { ok: false, reason: 'insufficient_coins' };

    transaction.update(ref, {
      coins: firestore.FieldValue.increment(-price),
      [`keys.${creatureId}`]: true,
    });
    return { ok: true };
  });
}

// The hold-to-unlock gesture on a locked-but-keyed Home card calls this once
// the hold completes — consumes the key and adds the creature to ownedIds.
export async function unlockWithKey(uid, creatureId) {
  const ref = userDocRef(uid);
  return firestore().runTransaction(async (transaction) => {
    const snap = await transaction.get(ref);
    const data = snap.data() || {};
    const ownedIds = data.ownedIds ?? [];
    const keys = data.keys ?? {};

    if (ownedIds.includes(creatureId)) return { ok: true };
    if (!keys[creatureId]) return { ok: false, reason: 'no_key' };

    transaction.update(ref, {
      ownedIds: firestore.FieldValue.arrayUnion(creatureId),
      [`keys.${creatureId}`]: false,
    });
    return { ok: true };
  });
}

// Called once per squish-and-release on SquishScreen — tracks the three
// numbers SettingsSheet's "YOUR STATS" block shows (total presses, longest
// single hold, and — derived from playTime by the caller — the favorite
// creature). Firestore's client SDK has no atomic "max", so the running
// longestHoldMs is resolved in a transaction rather than a plain increment.
export async function recordPress(uid, creatureId, holdMs) {
  const ref = userDocRef(uid);
  return firestore().runTransaction(async (transaction) => {
    const snap = await transaction.get(ref);
    const data = snap.data() || {};
    const stats = data.stats ?? { presses: 0, longestHoldMs: 0, playTime: {} };
    const longestHoldMs = Math.max(stats.longestHoldMs ?? 0, holdMs);
    const priorPlay = (stats.playTime ?? {})[creatureId] ?? 0;

    transaction.update(ref, {
      'stats.presses': firestore.FieldValue.increment(1),
      'stats.longestHoldMs': longestHoldMs,
      [`stats.playTime.${creatureId}`]: priorPlay + holdMs,
    });
    return { ok: true };
  });
}

// Flags the two achievements that only make sense as a live SquishScreen
// event (speedTap: 60 taps/60s, watchAd: watched a rewarded ad) — the rest
// of the achievement list is derived purely from ownedIds/totalEarned, see
// src/achievements.js.
export async function markAchievement(uid, key) {
  await userDocRef(uid).update({ [`achievements.${key}`]: true });
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
