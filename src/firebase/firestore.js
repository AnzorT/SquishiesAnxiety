import firestore from '@react-native-firebase/firestore';
import { STARTER_CREATURE_IDS } from '../data/creatures';
import { bumpDaily as bumpDailyRules, claimDaily as claimDailyRules, claimChest as claimChestRules } from '../progression';

// Coins and unlocks are client-authoritative (writes go straight from the
// device to Firestore, guarded only by firestore.rules) — fine for a
// prototype economy, but note there's no server-side validation of *how
// much* a client credits itself. A Cloud Function would be the next step
// to close that off before this handles anything real.

function userDocRef(uid) {
  return firestore().collection('users').doc(uid);
}

const inc = (n) => firestore.FieldValue.increment(n);
const logFail = (what) => (e) => console.warn(`${what} failed:`, e);

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
    stats: { presses: 0, longestHoldMs: 0, playTime: {} },
    // The two achievements with no natural profile-derived signal (the rest
    // — creature unlocks, earn10k/100k, unlockAll — are computed straight
    // from ownedIds/totalEarned, see src/achievements.js).
    achievements: { speedTap: false, watchAd: false },
    // Progression (src/progression.js): the guided tutorial starts at its
    // first step, level 1.
    tut: 'start',
    level: 1,
    createdAt: firestore.FieldValue.serverTimestamp(),
  });
}

// --- progression (src/progression.js) ---------------------------------------
//
// Client-written like coins (see the note at the top).

export function setTutorialStep(uid, step) {
  userDocRef(uid).update({ tut: step }).catch(logFail('setTutorialStep'));
}

export function setLevel(uid, level) {
  userDocRef(uid).update({ level }).catch(logFail('setLevel'));
}

// The day the streak screen last opened by itself (after the Daily Spin),
// so it does once a day on every device.
export function markStreakSeen(uid, date) {
  userDocRef(uid).update({ streakSeen: date }).catch(logFail('markStreakSeen'));
}

// `n` more of a daily-challenge event (squish, earn, ad, bath…). Returns the
// titles of the challenges this completed, for the toast. The Crib's events
// (a friend sent to a bath, a snack…) also count as care given, for the
// achievements (`cribCare`).
const CRIB_EVENTS = ['bath', 'feed', 'sleep', 'dance', 'tv', 'play'];
export function bumpDaily(uid, profile, ev, n = 1) {
  const { update, completed } = bumpDailyRules(profile, ev, n);
  if (CRIB_EVENTS.includes(ev)) update.cribCare = inc(n);
  userDocRef(uid).update(update).catch(logFail('bumpDaily'));
  return completed;
}

// Claims a finished challenge: its coins. Returns them (0 if nothing).
export function claimDailyChallenge(uid, profile, id) {
  const r = claimDailyRules(profile, id);
  if (!r) return 0;
  userDocRef(uid)
    .update({ ...r.update, coins: inc(r.coins), totalEarned: inc(r.coins) })
    .catch(logFail('claimDailyChallenge'));
  return r.coins;
}

// Opens the daily chest: its coins, one token of `tokenCreatureId` (the
// cheapest locked creature, chosen by the caller), the streak and the level,
// and the streak day's reward (src/progression.js STREAK_REWARDS): coins,
// more tokens of the same creature, a free box (waiting as `boxPending`;
// coins instead if one already waits) or half price on the next creation
// (`streakDiscount`, used up by buying it — functions/purchases.js).
// Returns { coins, reward } (null if it isn't ready). Tokens that fill a set
// put the key on the card, as a box does.
// The daily chest's coins and streak (a streak day's gems or chest are the
// server's: squad dailyGift, which the caller sends).
export function claimDailyChest(uid, profile) {
  const r = claimChestRules(profile);
  if (!r) return null;
  const reward = r.reward;
  let coins = r.coins;
  const update = { ...r.update, chests: inc(1) };
  if (reward.kind === 'coins') coins += reward.amount;
  else if (reward.kind === 'half') update.streakDiscount = true;
  update.coins = inc(coins);
  update.totalEarned = inc(coins);
  userDocRef(uid).update(update).catch(logFail('claimDailyChest'));
  return { coins, reward };
}

// --- the Squad Crib (src/crib/): the squad's rooms, stats and furniture, one
// document per player (users/{uid}/crib/state), written by the Crib screen
// alone — it loads it once, simulates, and saves (see CribScreen.js).

const cribDocRef = (uid) => userDocRef(uid).collection('crib').doc('state');

// The Crib's state is kept in memory once read (and on every save), so
// opening the Crib again doesn't wait on a Firestore round trip: it used to
// read the doc on every visit, showing an empty portrait Crib meanwhile,
// then rebuild once the doc (and its saved orientation) arrived. This
// device is the only writer of the doc, so the copy stays current.
// `preloadCrib` reads it in the background after sign-in.
const cribCache = new Map(); // uid → the last state read or saved
const cribLoads = new Map(); // uid → the read in flight

export async function loadCrib(uid) {
  if (cribCache.has(uid)) return cribCache.get(uid);
  if (!cribLoads.has(uid)) {
    cribLoads.set(
      uid,
      cribDocRef(uid)
        .get()
        .then((snap) => {
          const doc = snap.exists ? snap.data() : null;
          if (!cribCache.has(uid)) cribCache.set(uid, doc);
          return cribCache.get(uid);
        })
        .catch((e) => {
          console.warn('loadCrib failed:', e);
          return null;
        })
        .finally(() => cribLoads.delete(uid)),
    );
  }
  return cribLoads.get(uid);
}

// The Crib's state if it's already in memory (`undefined` if not read yet,
// `null` for a player with no Crib saved yet).
export const peekCrib = (uid) => cribCache.get(uid);
export const preloadCrib = (uid) => {
  if (uid) loadCrib(uid);
};

export function saveCrib(uid, state) {
  cribCache.set(uid, state);
  cribDocRef(uid).set(state).catch(logFail('saveCrib'));
}

// Something bought in the Crib's shop (its coins go through cribCoins), and
// how many friends live in the Crib — both for the achievements.
export function noteCribBuy(uid) {
  userDocRef(uid).update({ cribBuys: inc(1) }).catch(logFail('noteCribBuy'));
}
export function setCribSize(uid, n) {
  userDocRef(uid).update({ cribSize: n }).catch(logFail('setCribSize'));
}

// Coins the squad made (or cost) in the Crib; only earnings count towards
// the lifetime total. The caller keeps `coins` from going under zero.
export function cribCoins(uid, n) {
  if (!n) return;
  const update = { coins: inc(n) };
  if (n > 0) update.totalEarned = inc(n);
  userDocRef(uid).update(update).catch(logFail('cribCoins'));
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

    const update = {
      'stats.presses': firestore.FieldValue.increment(1),
      'stats.longestHoldMs': longestHoldMs,
      [`stats.playTime.${creatureId}`]: priorPlay + holdMs,
    };
    // a roster creature's growth XP: 1 per squish (the squad economy's
    // `xp`, which the server reads when it grows one — functions/squad.js)
    if (/^\d+$/.test(String(creatureId))) update[`xp.${creatureId}`] = firestore.FieldValue.increment(1);
    transaction.update(ref, update);
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

// The real-money price levels — a hand-edited doc, config/pricing (see
// setPricing in src/economy.js). `onChange` gets null until it exists.
export function subscribeToPricing(onChange) {
  return firestore()
    .collection('config')
    .doc('pricing')
    .onSnapshot(
      (snap) => onChange(snap.exists ? snap.data() : null),
      (error) => {
        console.error('subscribeToPricing failed:', error);
        onChange(null);
      }
    );
}
