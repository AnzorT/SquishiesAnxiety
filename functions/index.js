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
// Setup:
//   cd functions && npm install
//   firebase functions:secrets:set TRIPO_API_KEY      # paste your Tripo key
//   firebase deploy --only functions,firestore:rules,storage
//
// Node 20 has global fetch/Blob/crypto — no node-fetch needed.

const { onDocumentWritten } = require('firebase-functions/v2/firestore');
const { defineSecret } = require('firebase-functions/params');
const { setGlobalOptions } = require('firebase-functions/v2');
const logger = require('firebase-functions/logger');
const admin = require('firebase-admin');
const { randomUUID } = require('crypto');

admin.initializeApp();
setGlobalOptions({ region: 'us-central1', maxInstances: 10 });

const TRIPO_API_KEY = defineSecret('TRIPO_API_KEY');
const TRIPO_BASE = 'https://api.tripo3d.ai/v2/openapi';

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

      await patch({ status: 'running', progress: 0 });

      // --- 1. create the Tripo task ----------------------------------------
      const createRes = await fetch(`${TRIPO_BASE}/task`, {
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
        const t = await (await fetch(`${TRIPO_BASE}/task/${taskId}`, { headers })).json();
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
