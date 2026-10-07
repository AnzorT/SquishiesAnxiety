// PlushCrush Cloud Functions — image-to-3D generation via Tripo.
//
// Flow (see the client's CreateScreen / SquishyToy):
//   1. The app uploads a resized JPEG to Storage (customUploads/{uid}/{id}.jpg),
//      then creates users/{uid}/customCreatures/{id} with
//      { status: 'pending', sourceImageUrl }.
//   2. `generateCustomModel` (below) fires on that doc create. All talk to
//      Tripo happens *here*, server-side — the client never calls Tripo
//      directly. First it spends the player's `generationCredits` (a plain
//      counter on users/{uid}; the client SDK is blocked by firestore.rules
//      from writing that field itself — see below): 1 is granted free per
//      profile at signup, more are bought in the app (Google Play / the
//      App Store; the verifyPurchase function below grants them, and counts
//      them in `paidCredits` too). If the player has none, the job ends at
//      `status: 'blocked'` without ever calling Tripo. Otherwise it hands
//      Tripo the image URL (with the same TRIPO_TASK_OPTS tuning used for
//      every 3D creature, so custom ones run the physics just as smoothly),
//      polls the task to completion, downloads the resulting GLB, stores it
//      at customModels/{uid}/{id}.glb, and patches the doc with
//      { status: 'ready', modelUrl, modelPath }. A credit is refunded if the
//      job fails for any reason that isn't the player's fault (low platform
//      balance, a Tripo-side error, a timeout) — it's only ever *kept* spent
//      on a real `ready` result.
//   3. The app watches the doc; once `ready` the creature plays on the 3D
//      squish rig (SquishyToy loads modelUrl and runs the same soft-body
//      physics as the built-in 3D creatures — nothing is baked into the GLB).
//
// Tripo billing is PREPAID ("pay-before-you-go" — their own term), not
// auto-charged: a task simply fails once the balance runs out, and nothing
// refills it automatically. `checkTripoBalance` (below) is the safety net —
// it polls the balance on a schedule and stops new generations *before* they
// fail on the player, instead of after.
//
// Verified against the live API (2026-09-19):
//   - Task create/poll:  https://api.tripo3d.ai/v2/openapi/task[/{id}]
//   - Account balance:   https://openapi.tripo3d.ai/v3/account/balance
//   (different hosts — this is correct, not a typo; Tripo runs task
//   generation and account management on separate API surfaces.)
//
// `model_version` must be one of Tripo's current H3 versions (their docs
// only list v3.0-20250812 / v3.1-20260211 now) — the old 'v2.5-20250123'
// this used to be pinned to is stale enough that it silently ignored
// `face_limit` and produced a ~101k-triangle mesh for a custom creature
// instead of the intended ~10k, which is what actually made that specific
// toy laggy on-device (see the per-frame weld/normal cost in SquishyToy.js's
// tickPhysics — it scales with the real mesh, not with what we asked for).
// On the current model version, `face_limit` alone is a real ceiling via
// ordinary decimation — see the tuning section below for why
// `smart_low_poly` was tried and deliberately dropped.
//
// Setup:
//   cd functions && npm install
//   firebase functions:secrets:set TRIPO_API_KEY      # paste your Tripo key
//   firebase deploy --only functions,firestore:rules,storage
//
// Node 20 has global fetch/Blob/crypto — no node-fetch needed.

const { onDocumentWritten } = require('firebase-functions/v2/firestore');
const { onSchedule } = require('firebase-functions/v2/scheduler');
const { defineSecret } = require('firebase-functions/params');
const { setGlobalOptions } = require('firebase-functions/v2');
const logger = require('firebase-functions/logger');
const admin = require('firebase-admin');
const { randomUUID } = require('crypto');
const { spendCredit } = require('./purchases');

admin.initializeApp();
setGlobalOptions({ region: 'us-central1', maxInstances: 10 });

const TRIPO_API_KEY = defineSecret('TRIPO_API_KEY');
const TRIPO_TASK_BASE = 'https://api.tripo3d.ai/v2/openapi';
const TRIPO_ACCOUNT_BASE = 'https://openapi.tripo3d.ai/v3';

// --- tuning ---------------------------------------------------------------
// Tripo model tier + generation options. `face_limit` keeps the GLB small
// enough that the on-device adjacency build + per-frame physics stay smooth
// (computeVertexNormals + weldNormals in tickPhysics scale with mesh size) —
// 2500 matches the premade roster's own target polycount.
//
// `smart_low_poly` was tried alongside face_limit (2026-09-19) and made
// quality on a detailed/fuzzy-textured source photo (a piped-icing plush
// penguin) collapse into a crude cone shape instead of the actual silhouette
// — Tripo's own docs describe it as forcing "hand-crafted" retopology, which
// at only 2500 faces has too little budget to preserve high-frequency detail
// and instead mangles the shape. Deliberately left off: plain `face_limit`
// on its own is still a real ceiling on v3.x (unlike the stale v2.5 this
// used to be pinned to, which ignored it outright), just via ordinary
// decimation instead of forced retopology — shape-preserving, not just
// triangle-count-preserving.
// `quad` is left unset (defaults to false), which is triangle topology.
const TRIPO_MODEL_VERSION = 'v3.0-20250812';
const TRIPO_TASK_OPTS = { texture: true, pbr: true, face_limit: 2500, auto_size: true };
// How many custom creatures a single user may generate per rolling 24h.
const DAILY_LIMIT = 10;
// Poll cadence / ceiling (image-to-model is typically 30–90s).
const POLL_MS = 3000;
const POLL_MAX = 170; // ~8.5 min

// image_to_model with texture+pbr on H3 runs ~30–60 credits per Tripo's own
// pricing table; this is a safety margin above the worst case. Below this,
// generateCustomModel refuses new jobs (status: 'capacity') instead of
// letting the player wait through a poll that's doomed to fail on credit.
const MIN_CREDITS_PER_JOB = 80;
// checkTripoBalance flags this as "getting low" well before it's actually 0,
// so there's lead time to top up (see functions/index.js's header comment).
const LOW_BALANCE_ALERT_CREDITS = 1000; // ≈ 15–30 generations of runway

const STATUS_DOC = 'system/tripoStatus';
const CAPACITY_MESSAGE = "We're topping up 3D credits — try again shortly. You have not been charged.";
// Every profile is born with one free generation (see createUserProfile in
// src/firebase/firestore.js); further ones are bought — see the header
// comment above.
const NO_CREDIT_MESSAGE = 'No creature generations available. Purchase one to create another squishy.';

// One credit spent from a profile snapshot — see spendCredit in
// purchases.js (a bought credit goes first).
const spendCreditUpdate = (snap) => spendCredit(snap.exists ? snap.data() : {});

// --- balance watcher --------------------------------------------------
// Runs hourly. Writes the live balance to Firestore (so generateCustomModel
// can check it cheaply, and so you can glance at it) and logs at ERROR
// severity when it's low — wire a Cloud Logging alert on that to get pinged
// (Console → Logging → create alert on `severity=ERROR AND
// jsonPayload.message=~"Tripo balance low"`, or on this function's logs).
exports.checkTripoBalance = onSchedule(
  { schedule: 'every 60 minutes', secrets: [TRIPO_API_KEY] },
  async () => {
    const res = await fetch(`${TRIPO_ACCOUNT_BASE}/account/balance`, {
      headers: { Authorization: `Bearer ${TRIPO_API_KEY.value()}` },
    });
    const body = await res.json();
    if (!res.ok || body.code !== 0) {
      logger.error('checkTripoBalance: could not read balance', body);
      return;
    }
    const balance = body.data.balance;
    const low = balance < LOW_BALANCE_ALERT_CREDITS;
    await admin
      .firestore()
      .doc(STATUS_DOC)
      .set(
        { balance, frozen: body.data.frozen, low, checkedAt: admin.firestore.FieldValue.serverTimestamp() },
        { merge: true }
      );
    if (low) {
      logger.error(`Tripo balance low: ${balance} credits left (alert threshold ${LOW_BALANCE_ALERT_CREDITS}) — top up soon.`);
    } else {
      logger.info(`Tripo balance OK: ${balance} credits`);
    }
  }
);

exports.generateCustomModel = onDocumentWritten(
  {
    document: 'users/{uid}/customCreatures/{id}',
    secrets: [TRIPO_API_KEY],
    timeoutSeconds: 540,
    memory: '512MiB',
  },
  async (event) => {
    const before = event.data?.before?.data();
    const after = event.data?.after?.data();
    if (!after) return; // deleted
    const { uid, id } = event.params;
    const userRef = admin.firestore().doc(`users/${uid}`);

    // Assemble-path creatures are born 'ready' client-side straight away —
    // no Tripo call, nothing else below this ever touches them — so without
    // this branch a fresh one would never spend the generation credit the
    // client's CREATE button already gated on, leaving "1 free generation"
    // incorrectly still showing as available after it was used. The client
    // already prevents pressing CREATE at 0 credits, so this is bookkeeping
    // to match that, not a gate — clamp at 0 instead of letting a rare
    // double-tap race go negative.
    if (!before && after.status === 'ready' && !after.sourceImageUrl) {
      await admin.firestore().runTransaction(async (tx) => {
        const update = spendCreditUpdate(await tx.get(userRef));
        if (update) tx.set(userRef, update, { merge: true });
      });
      return;
    }

    // Run once when the job enters 'pending' (initial create or a retry) and
    // has a source image. Assemble-path creatures are handled above.
    if (after.status !== 'pending' || !after.sourceImageUrl) return;
    if (before && before.status === 'pending') return; // already handled / no-op write

    const ref = event.data.after.ref;
    const data = after;
    const patch = (fields) => ref.set(fields, { merge: true });
    const headers = {
      Authorization: `Bearer ${TRIPO_API_KEY.value()}`,
      'Content-Type': 'application/json',
    };
    // set by the spend below: whether the credit used was a bought one
    let spentPaid = false;
    const refundCredit = () =>
      userRef
        .set(
          {
            generationCredits: admin.firestore.FieldValue.increment(1),
            ...(spentPaid ? { paidCredits: admin.firestore.FieldValue.increment(1) } : {}),
          },
          { merge: true }
        )
        .catch((e) => logger.error(`[${uid}/${id}] credit refund failed`, e));

    try {
      // --- rate limit --------------------------------------------------
      const since = admin.firestore.Timestamp.fromMillis(Date.now() - 24 * 60 * 60 * 1000);
      const recent = await admin
        .firestore()
        .collection(`users/${uid}/customCreatures`)
        .where('createdAt', '>=', since)
        .count()
        .get();
      if (recent.data().count > DAILY_LIMIT) {
        await patch({ status: 'failed', error: 'Daily creation limit reached — try again tomorrow.' });
        return;
      }

      // --- spend a generation credit --------------------------------------
      // Atomic so two jobs created back-to-back can't both spend the same
      // last credit. Missing field (profile predates this system) defaults
      // to the same one-free-generation every profile is meant to start
      // with (see createUserProfile). This is the ONLY gate that decides
      // whether Tripo ever gets called — everything below it either
      // succeeds (credit stays spent) or refunds via refundCredit().
      const hasCredit = await admin.firestore().runTransaction(async (tx) => {
        const update = spendCreditUpdate(await tx.get(userRef));
        if (!update) return false;
        spentPaid = 'paidCredits' in update;
        tx.set(userRef, update, { merge: true });
        return true;
      });
      if (!hasCredit) {
        await patch({ status: 'blocked', error: NO_CREDIT_MESSAGE });
        return;
      }

      // --- balance guard -------------------------------------------------
      // Cheap Firestore read against checkTripoBalance's last snapshot — fail
      // fast with a friendly status instead of burning a poll cycle on a job
      // that's going to hit "insufficient credit" anyway. If the watcher
      // hasn't run yet (fresh deploy), there's no doc and we proceed —
      // Tripo's own error (below) is still the final backstop.
      const statusSnap = await admin.firestore().doc(STATUS_DOC).get();
      if (statusSnap.exists && statusSnap.data().balance < MIN_CREDITS_PER_JOB) {
        await refundCredit();
        await patch({ status: 'capacity', error: CAPACITY_MESSAGE });
        return;
      }

      await patch({ status: 'running', progress: 0 });

      // --- 1. create the Tripo task ----------------------------------------
      const createRes = await fetch(`${TRIPO_TASK_BASE}/task`, {
        method: 'POST',
        headers,
        body: JSON.stringify({
          type: 'image_to_model',
          model_version: TRIPO_MODEL_VERSION,
          file: { type: 'jpg', url: data.sourceImageUrl },
          ...TRIPO_TASK_OPTS,
        }),
      });
      const create = await createRes.json();
      if (create.code === 2010) {
        // "You don't have enough credit to create this task" — Tripo froze
        // nothing for a failed create, so no Tripo credit was spent, but we
        // did spend the player's generation credit above — give it back.
        // Surface the same friendly capacity state as the pre-check above.
        await refundCredit();
        await patch({ status: 'capacity', error: CAPACITY_MESSAGE });
        return;
      }
      if (!createRes.ok || create.code !== 0 || !create.data?.task_id) {
        throw new Error(`Tripo create task failed: ${JSON.stringify(create)}`);
      }
      const taskId = create.data.task_id;
      await patch({ tripoTaskId: taskId });
      logger.info(`[${uid}/${id}] Tripo task ${taskId} created`);

      // --- 2. poll to completion -----------------------------------------
      let output = null;
      for (let i = 0; i < POLL_MAX; i++) {
        await sleep(POLL_MS);
        const t = await (await fetch(`${TRIPO_TASK_BASE}/task/${taskId}`, { headers })).json();
        const d = t.data || {};
        if (typeof d.progress === 'number') await patch({ progress: d.progress });
        if (d.status === 'success') {
          output = d.output || {};
          break;
        }
        if (['failed', 'cancelled', 'unknown', 'banned', 'expired'].includes(d.status)) {
          throw new Error(`Tripo task ${d.status}`);
        }
      }
      const glbUrl = output && (output.pbr_model || output.model || output.base_model);
      if (!glbUrl) throw new Error('Tripo task did not return a model URL in time');

      // --- 3. download the GLB (its URL expires within minutes) ----------
      const glbRes = await fetch(glbUrl);
      if (!glbRes.ok) throw new Error(`GLB download failed: ${glbRes.status}`);
      const glb = Buffer.from(await glbRes.arrayBuffer());
      logger.info(`[${uid}/${id}] GLB downloaded (${(glb.length / 1024 / 1024).toFixed(2)} MB)`);

      // --- 4. store it in our own bucket with a download token ----------
      const token = randomUUID();
      const modelPath = `customModels/${uid}/${id}.glb`;
      const bucket = admin.storage().bucket();
      await bucket.file(modelPath).save(glb, {
        resumable: false,
        contentType: 'model/gltf-binary',
        metadata: { metadata: { firebaseStorageDownloadTokens: token } },
      });
      const modelUrl =
        `https://firebasestorage.googleapis.com/v0/b/${bucket.name}/o/` +
        `${encodeURIComponent(modelPath)}?alt=media&token=${token}`;

      // --- 5. done -----------------------------------------------------
      await patch({ status: 'ready', progress: 100, modelUrl, modelPath, error: admin.firestore.FieldValue.delete() });
      logger.info(`[${uid}/${id}] ready`);
    } catch (err) {
      logger.error(`[${uid}/${id}] generation failed`, err);
      // Whatever failed here happened after the credit was spent (the
      // daily-limit and no-credit exits above return before this point) and
      // isn't the player's fault — give the credit back.
      await refundCredit();
      await patch({ status: 'failed', error: String((err && err.message) || err) });
    }
  }
);

const sleep = (ms) => new Promise((r) => setTimeout(r, ms));

// --- Daily Spin ---------------------------------------------------------
// One free spin of the wheel per calendar day (the player's own day — the
// app sends its UTC offset). The server rolls the prize and hands it out in
// the same transaction, because one prize — 15% off the next custom
// creature, which costs real money — must not be something the app can
// grant itself (firestore.rules stops the client writing `lastSpinDay`,
// `creationDiscountPct`, `spins` and `wheelJackpot`). Rules and odds live in
// dailySpin.js. The app calls this over plain HTTPS with its ID token
// (src/firebase/callFunction.js), so it needs no extra native module.
//
// `bonus: true` is a SPIN AGAIN, paid with a rewarded video the app played:
// allowed after the day's free spin, up to MAX_AD_SPINS a day (dailySpin.js).
//
// Returns { already: true } if today's spin is used (or, for a bonus spin,
// the day's video spins), otherwise the prize:
// { index, kind: 'coins' | 'create' | 'unlock', amount?, discountPct?,
//   creatureId?, lockedIds?, allOwned? }.
//
// `creationDiscountPct` is only recorded for now: there's no purchase flow
// yet. Whatever sells a creation later must charge 15% less while it's set
// and clear it once used.
const { onCall, HttpsError } = require('firebase-functions/v2/https');
const { FieldValue } = require('firebase-admin/firestore');
const { WHEEL, rollWheel, dayKey, spinOutcome, spinAllowed } = require('./dailySpin');

exports.spinWheel = onCall(async (request) => {
  const uid = request.auth && request.auth.uid;
  if (!uid) throw new HttpsError('unauthenticated', 'Sign in to spin.');
  const db = admin.firestore();
  const day = dayKey(Date.now(), request.data && request.data.tzOffsetMinutes);
  const bonus = !!(request.data && request.data.bonus);
  const index = rollWheel();
  // The FREE creature needs the catalog (the numbered roster — 30 creatures
  // since the 2026-10-03 plush roster; any numeric id counts).
  const rosterIds =
    WHEEL[index].kind === 'unlock'
      ? (await db.collection('creatures').select().get()).docs.map((d) => d.id).filter((id) => /^\d+$/.test(id))
      : [];

  const userRef = db.collection('users').doc(uid);
  return db.runTransaction(async (tx) => {
    const snap = await tx.get(userRef);
    if (!snap.exists) throw new HttpsError('failed-precondition', 'No profile.');
    const profile = snap.data();
    const allowed = spinAllowed(profile, day, bonus);
    if (!allowed) return { already: true, day, bonus };

    const { result, changes } = spinOutcome({ profile, rosterIds, day, index });
    const update = { ...allowed, spins: FieldValue.increment(changes.spins) };
    if (changes.coins) {
      update.coins = FieldValue.increment(changes.coins);
      update.totalEarned = FieldValue.increment(changes.coins);
    }
    if (changes.jackpot) update.wheelJackpot = true;
    if (changes.discountPct) update.creationDiscountPct = changes.discountPct;
    if (changes.unlockId) {
      update.ownedIds = FieldValue.arrayUnion(changes.unlockId);
      update[`keys.${changes.unlockId}`] = false;
    }
    tx.update(userRef, update);
    logger.info(`[${uid}] daily spin ${day}${bonus ? ' (video)' : ''}: ${result.kind}`, result);
    return result;
  });
});

// --- The squad economy: chests, gems, Stars, the collection ------------------
//
// One callable for every move (the rules: squad.js). The app sends
// { move, ...args, tzOffsetMinutes }; the move runs in a transaction on the
// player's profile and the result goes back. Chests can only drop creatures
// that have art: the catalog's numbered creature docs.
const squad = require('./squad');

exports.squad = onCall(async (request) => {
  const uid = request.auth && request.auth.uid;
  if (!uid) throw new HttpsError('unauthenticated', 'Sign in first.');
  const data = request.data || {};
  const fn = squad.MOVES[data.move];
  if (!fn) throw new HttpsError('invalid-argument', 'Unknown move.');
  const db = admin.firestore();
  const day = dayKey(Date.now(), data.tzOffsetMinutes);
  const needsArt = ['openChest', 'buyCreature'].includes(data.move);
  const artIds = needsArt ? (await db.collection('creatures').select().get()).docs.map((d) => d.id).filter((id) => /^\d+$/.test(id)) : [];
  const args = {
    tier: String(data.tier || ''),
    deal: !!data.deal,
    id: String(data.id ?? ''),
    cur: data.cur === 'stars' ? 'stars' : 'coins',
    f: String(data.f || ''),
    i: Number(data.i),
    reward: data.reward && typeof data.reward === 'object' ? { kind: String(data.reward.kind || ''), amount: Number(data.reward.amount) || 0 } : null,
    day,
    artIds,
  };

  const userRef = db.collection('users').doc(uid);
  return db.runTransaction(async (tx) => {
    const snap = await tx.get(userRef);
    if (!snap.exists) throw new HttpsError('failed-precondition', 'No profile.');
    const begun = squad.withStart(snap.data());
    const out = fn(begun.p, args);
    if (out.error) {
      if (Object.keys(begun.set).length) tx.update(userRef, begun.set);
      return { error: out.error };
    }
    const update = { ...begun.set, ...out.set };
    if (Object.keys(update).length) tx.update(userRef, update);
    logger.info(`[${uid}] squad ${data.move}`, out.result);
    return out.result;
  });
});

// --- In-app purchases -------------------------------------------------------
//
// The app sends every Google Play / App Store purchase to verifyPurchase
// (the handler and its rules: verifyPurchase.js, purchases.js). Here it's
// wired to the real stores.
//
// Setup, Google Play (once): enable the "Google Play Android Developer API"
// in this Firebase project's Google Cloud console, and in the Play Console →
// Users and permissions, invite the functions' service account (the Compute
// Engine default one, PROJECT_NUMBER-compute@developer.gserviceaccount.com)
// with "View financial data" and "Manage orders and subscriptions".
//
// Setup, App Store (once): set APPLE_APP_ID to the app's numeric Apple ID
// (App Store Connect → the app → App Information), e.g. in functions/.env:
//   APPLE_APP_ID=1234567890
// Apple signs every StoreKit 2 transaction; they're checked against Apple's
// root certificate (apple/AppleRootCA-G3.cer, from
// https://www.apple.com/certificateauthority/), with online revocation
// checks. Sandbox purchases (TestFlight, sandbox testers) verify without the
// app id; live ones need it.
const fs = require('fs');
const path = require('path');
const { GoogleAuth } = require('google-auth-library');
const { defineString } = require('firebase-functions/params');
const { PACKAGE_NAME } = require('./purchases');
const { makeVerifyPurchase, makeVerifyApple } = require('./verifyPurchase');

const APPLE_APP_ID = defineString('APPLE_APP_ID', { default: '' });
const playAuth = new GoogleAuth({ scopes: ['https://www.googleapis.com/auth/androidpublisher'] });

async function playApi(tokenPath, method = 'GET') {
  const client = await playAuth.getClient();
  const url = `https://androidpublisher.googleapis.com/androidpublisher/v3/applications/${PACKAGE_NAME}/purchases/products/${tokenPath}`;
  const res = await client.request({ url, method, data: method === 'POST' ? {} : undefined, validateStatus: () => true });
  if (res.status >= 300) {
    const err = new Error(`Play API ${method} ${tokenPath.split('/')[0]}: HTTP ${res.status} ${JSON.stringify(res.data && res.data.error && res.data.error.message)}`);
    err.status = res.status;
    throw err;
  }
  return res.data || {};
}

let appleRoots = null;
const verifyApple = makeVerifyApple({
  roots: () => (appleRoots = appleRoots || [fs.readFileSync(path.join(__dirname, 'apple', 'AppleRootCA-G3.cer'))]),
  appAppleId: () => APPLE_APP_ID.value(),
});

exports.verifyPurchase = onCall(
  makeVerifyPurchase({ db: admin.firestore(), FieldValue, HttpsError, logger, playApi, verifyApple })
);
