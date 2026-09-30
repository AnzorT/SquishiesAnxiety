import firestore from '@react-native-firebase/firestore';
import { STARTER_CREATURE_IDS } from '../data/creatures';
import { boxPayMode, boxPrice, dailyBoxUse } from '../mysteryBox';
import { tokenPrice } from '../economy';

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
    // One free "photo → 3D" creature generation per profile. Spent (and, if
    // the job fails through no fault of the player's, refunded) only by the
    // generateCustomModel Cloud Function — see functions/index.js and the
    // firestore.rules guard that blocks the client from writing this field
    // itself. More come from a real-money purchase, reconciled by hand for
    // now by setting this directly in the Firebase console.
    generationCredits: 1,
    ownedIds: STARTER_CREATURE_IDS,
    // Creature ids a key has been bought for but not yet redeemed via the
    // Home card's hold-to-unlock gesture — see openBox (a full set of a
    // creature's tokens) and unlockWithKey below.
    keys: {},
    stats: { presses: 0, longestHoldMs: 0, playTime: {} },
    // The two achievements with no natural profile-derived signal (the rest
    // — creature unlocks, earn10k/100k, unlockAll — are computed straight
    // from ownedIds/totalEarned, see src/achievements.js).
    achievements: { speedTap: false, watchAd: false },
    createdAt: firestore.FieldValue.serverTimestamp(),
  });
}

// Accounts created before this app matched the new roster have an
// `ownedIds` that predates STARTER_CREATURE_IDS (e.g. the old single 'buddy'
// starter) — without this, the free starter (Glorp) would show up locked for
// them. Called once per profile load from App.js; idempotent and
// additive-only (arrayUnion), so it never takes a creature away (accounts
// from when Puffle and Nubbin were free starters keep them).
export async function ensureStarterCreaturesOwned(uid, ownedIds = []) {
  const missing = STARTER_CREATURE_IDS.filter((id) => !ownedIds.includes(id));
  if (!missing.length) return;
  await userDocRef(uid).update({ ownedIds: firestore.FieldValue.arrayUnion(...missing) });
}

export function subscribeToUserProfile(uid, onChange) {
  return userDocRef(uid).onSnapshot(
    (snap) => onChange(snap.exists ? snap.data() : null),
    (error) => {
      console.error('subscribeToUserProfile failed:', error);
      onChange(null);
    }
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

export async function submitFeedback(uid, text) {
  const trimmed = text?.trim();
  if (!trimmed) return;
  await firestore().collection('feedback').add({
    uid,
    text: trimmed,
    createdAt: firestore.FieldValue.serverTimestamp(),
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

// A rewarded ad finished — the running total and the biggest boost ever
// taken feed the "Movie Night" (5 ads) and "Max Boost" (×4) achievements.
// An ad-free boost (Remove Ads bought) passes watched = false: it still
// counts toward Max Boost, not toward the ads.
export async function recordAdWatched(uid, multiplier, currentMaxMult = 0, watched = true) {
  const update = {};
  if (watched) update.adsWatched = firestore.FieldValue.increment(1);
  if (multiplier > currentMaxMult) update.maxMult = multiplier;
  if (Object.keys(update).length) await userDocRef(uid).update(update);
}

// --- Mystery Box (rules in src/mysteryBox.js) ---------------------------
//
// These work from the profile the app already has and skip the transaction:
// Firestore applies a write to its local cache at once (and queues it while
// offline), so the box never waits on the network. Like the rest of the
// economy above, this is client-trusted.

const inc = (n) => firestore.FieldValue.increment(n);
const logFail = (what) => (e) => console.warn(`${what} failed:`, e);

// A daily box's video was watched: that box is paid for (one of today's
// dailyBoxes() used) and waits as `boxPending` until it's opened, even if the
// player leaves first.
export function payBoxWithAd(uid, profile) {
  userDocRef(uid)
    .update({ boxPending: true, ...dailyBoxUse(profile) })
    .catch(logFail('payBoxWithAd'));
}

// Today's boxes are used up: charge boxPrice() and set the box up to be
// opened. False if there aren't enough coins.
export function payBoxWithCoins(uid, profile) {
  const price = boxPrice();
  if ((profile?.coins ?? 0) < price) return false;
  userDocRef(uid).update({ coins: inc(-price), boxPending: true }).catch(logFail('payBoxWithCoins'));
  return true;
}

// Opens a box in one write and hands out `pull` (rolled beforehand with
// rollBox, see MysteryBoxScreen): a creature's tokens — a full set puts its
// key on its Home card (the other way to a key is $0.99, src/billing; coins
// only buy boxes) — or coins, or the Secret. A free daily box (Remove Ads) uses up one of today's boxes
// here; a paid one was settled when it was paid for. `paidAhead` covers a
// payment made a moment ago that the profile passed in doesn't show yet.
// Returns false if this box still has to be paid for.
export function openBox(uid, profile, pull, paidAhead = false) {
  const mode = paidAhead ? 'paid' : boxPayMode(profile);
  if (!pull || (mode !== 'free' && mode !== 'paid')) return false;
  const update = { boxPending: false, boxOpens: inc(1), [`tierPulls.${pull.tier}`]: inc(1) };
  if (mode === 'free') Object.assign(update, dailyBoxUse(profile));
  if (pull.kind === 'secret') update.secretFound = true;
  else if (pull.kind === 'coins') update.coins = inc(pull.amount);
  else if (pull.complete) {
    update[`keys.${pull.id}`] = true;
    update[`tokens.${pull.id}`] = tokenPrice(pull.id);
  } else update[`tokens.${pull.id}`] = inc(pull.amount);
  userDocRef(uid).update(update).catch(logFail('openBox'));
  return true;
}

// --- player-made creatures (the "Create your own squishy" flow) ---------
//
// Stored under users/{uid}/customCreatures. Two kinds:
//  · photo path  — { sourceImageUrl, status: 'pending' }. The
//    `generateCustomModel` Cloud Function (functions/index.js) picks it up,
//    runs Tripo image-to-3D, and patches in { status: 'ready', modelUrl,
//    modelPath } (or { status: 'failed', error }). `status` also goes
//    'running' with a `progress` 0–100 while Tripo works.
//  · assemble path — { build, status: 'ready' }. No Tripo; plays as the 2D
//    assembled art.
// `audio`, if present, is a small base64 data URL for the squish sound.

function customCreaturesRef(uid) {
  return userDocRef(uid).collection('customCreatures');
}

export function subscribeToCustomCreatures(uid, onChange) {
  return customCreaturesRef(uid)
    .orderBy('createdAt', 'asc')
    .onSnapshot(
      (snap) => onChange(snap.docs.map((doc) => ({ id: doc.id, ...doc.data() }))),
      (error) => {
        console.error('subscribeToCustomCreatures failed:', error);
        onChange([]);
      }
    );
}

// Create the doc. Pass a pre-generated `id` when the caller has already
// uploaded customUploads/{uid}/{id}.jpg (so paths line up). Returns the id.
export async function addCustomCreature(uid, { id, name, sourceImageUrl, sourceImagePath, build, audio }) {
  const doc = {
    name: name?.trim() || 'My Squishy',
    audio: audio || null,
    build: build || null,
    sourceImageUrl: sourceImageUrl || null,
    sourceImagePath: sourceImagePath || null,
    // photo → Tripo has to run; assemble → nothing to generate.
    status: sourceImageUrl ? 'pending' : 'ready',
    progress: 0,
    created: new Date().toLocaleDateString(undefined, { month: 'short', day: 'numeric' }),
    createdAt: firestore.FieldValue.serverTimestamp(),
  };
  if (id) {
    await customCreaturesRef(uid).doc(id).set(doc);
    return id;
  }
  const ref = await customCreaturesRef(uid).add(doc);
  return ref.id;
}

// Re-arm a failed generation (the Cloud Function re-triggers on the write).
export async function retryCustomCreature(uid, creatureId) {
  await customCreaturesRef(uid).doc(creatureId).set(
    { status: 'pending', progress: 0, error: firestore.FieldValue.delete() },
    { merge: true }
  );
}

export async function deleteCustomCreature(uid, creatureId) {
  await customCreaturesRef(uid).doc(creatureId).delete();
}

export function newCustomCreatureId(uid) {
  return customCreaturesRef(uid).doc().id;
}

export function subscribeToCreatures(onChange) {
  return firestore()
    .collection('creatures')
    .orderBy('order', 'asc')
    .onSnapshot(
      (snap) => onChange(snap.docs.map((doc) => ({ id: doc.id, ...doc.data() }))),
      (error) => {
        console.error('subscribeToCreatures failed:', error);
        onChange([]);
      }
    );
}

// The Mystery Box numbers (rarity odds, token odds, token prices) — a
// hand-edited doc, config/mysteryBox (see BOX_DEFAULTS in src/economy.js).
// `onChange` gets null until it exists.
export function subscribeToBoxConfig(onChange) {
  return firestore()
    .collection('config')
    .doc('mysteryBox')
    .onSnapshot(
      (snap) => onChange(snap.exists ? snap.data() : null),
      (error) => {
        console.error('subscribeToBoxConfig failed:', error);
        onChange(null);
      }
    );
}
