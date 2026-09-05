// PlushCrush Cloud Functions — image-to-3D generation via Tripo.
//
// Flow (see the client's CreateScreen / SquishyToy):
//   1. The app uploads a resized JPEG to Storage (customUploads/{uid}/{id}.jpg),
//      then creates users/{uid}/customCreatures/{id} with
//      { status: 'pending', sourceImageUrl }.
//   2. `generateCustomModel` (below) fires on that doc create: it hands Tripo
//      the image URL, polls the task to completion, downloads the resulting
//      GLB, stores it at customModels/{uid}/{id}.glb, and patches the doc with
//      { status: 'ready', modelUrl, modelPath }.
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
// Verified against the live API (2026-09-05):
//   - Task create/poll:  https://api.tripo3d.ai/v2/openapi/task[/{id}]
//   - Account balance:   https://openapi.tripo3d.ai/v3/account/balance
//   (different hosts — this is correct, not a typo; Tripo runs task
//   generation and account management on separate API surfaces.)
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

admin.initializeApp();
setGlobalOptions({ region: 'us-central1', maxInstances: 10 });

const TRIPO_API_KEY = defineSecret('TRIPO_API_KEY');
const TRIPO_TASK_BASE = 'https://api.tripo3d.ai/v2/openapi';
const TRIPO_ACCOUNT_BASE = 'https://openapi.tripo3d.ai/v3';

// --- tuning ---------------------------------------------------------------
// Tripo model tier + generation options. `face_limit` keeps the GLB small
// enough that the on-device adjacency build + per-frame physics stay smooth.
const TRIPO_MODEL_VERSION = 'v2.5-20250123';
const TRIPO_TASK_OPTS = { texture: true, pbr: true, face_limit: 10000, auto_size: true };
// How many custom creatures a single user may generate per rolling 24h.
const DAILY_LIMIT = 10;
// Poll cadence / ceiling (image-to-model is typically 30–90s).
const POLL_MS = 3000;
const POLL_MAX = 170; // ~8.5 min

// image_to_model with texture+pbr on H2/H3 runs ~30–60 credits per Tripo's
// own pricing table; this is a safety margin above the worst case. Below
// this, generateCustomModel refuses new jobs (status: 'capacity') instead of
// letting the player wait through a poll that's doomed to fail on credit.
const MIN_CREDITS_PER_JOB = 80;
// checkTripoBalance flags this as "getting low" well before it's actually 0,
// so there's lead time to top up (see functions/index.js's header comment).
const LOW_BALANCE_ALERT_CREDITS = 1000; // ≈ 15–30 generations of runway

const STATUS_DOC = 'system/tripoStatus';
const CAPACITY_MESSAGE = "We're topping up 3D credits — try again shortly. You have not been charged.";

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

    // Run once when the job enters 'pending' (initial create or a retry) and
    // has a source image. Assemble-path creatures are born 'ready' → skipped.
    if (after.status !== 'pending' || !after.sourceImageUrl) return;
    if (before && before.status === 'pending') return; // already handled / no-op write

    const ref = event.data.after.ref;
    const data = after;
    const patch = (fields) => ref.set(fields, { merge: true });
    const headers = {
      Authorization: `Bearer ${TRIPO_API_KEY.value()}`,
      'Content-Type': 'application/json',
    };

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

      // --- balance guard -------------------------------------------------
      // Cheap Firestore read against checkTripoBalance's last snapshot — fail
      // fast with a friendly status instead of burning a poll cycle on a job
      // that's going to hit "insufficient credit" anyway. If the watcher
      // hasn't run yet (fresh deploy), there's no doc and we proceed —
      // Tripo's own error (below) is still the final backstop.
      const statusSnap = await admin.firestore().doc(STATUS_DOC).get();
      if (statusSnap.exists && statusSnap.data().balance < MIN_CREDITS_PER_JOB) {
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
        // nothing for a failed create, so no credit was spent. Surface the
        // same friendly capacity state as the pre-check above.
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
      await patch({ status: 'failed', error: String((err && err.message) || err) });
    }
  }
);

const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
