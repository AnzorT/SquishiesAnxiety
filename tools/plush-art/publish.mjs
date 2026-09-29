// Publishes the rendered plush art (render.mjs → out/) to Firebase:
//   · each image goes to Storage at creatureArt/plush-v1/{id}/{variant}.webp
//   · each `creatures/{id}` doc gets a `plush` field the app reads:
//       plush: { v: 1, lg: { url, frame }, lgLocked, md, mdLocked, sm }
// Nothing about the art lives in the app bundle.
//
// The catalog is admin-only (firestore.rules), so this runs with admin
// credentials: a service-account key from Firebase console → Project
// settings → Service accounts → "Generate new private key".
//
//   GOOGLE_APPLICATION_CREDENTIALS=/path/to/key.json node tools/plush-art/publish.mjs
//   (add --dry to only print what would be written)
//
// Re-running is safe: files are overwritten in place and each doc's `plush`
// field is replaced; nothing else in the doc is touched.

import { createRequire } from 'node:module';
import crypto from 'node:crypto';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const OUT = path.join(HERE, 'out');
const DRY = process.argv.includes('--dry');
const PROJECT_ID = 'squishy-app-61445';
const BUCKET = 'squishy-app-61445.firebasestorage.app';
const PREFIX = 'creatureArt/plush-v1';

// firebase-admin is already installed for the Cloud Functions
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore } = require('firebase-admin/firestore');
const { getStorage } = require('firebase-admin/storage');

const manifest = JSON.parse(fs.readFileSync(path.join(OUT, 'manifest.json'), 'utf8'));

if (!DRY && !process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to a service-account key (see the top of this file), or pass --dry.');
  process.exit(1);
}

const app = DRY ? null : initializeApp({ credential: applicationDefault(), projectId: PROJECT_ID, storageBucket: BUCKET });
const db = DRY ? null : getFirestore(app);
const bucket = DRY ? null : getStorage(app).bucket();

const downloadUrl = (objectPath, token) =>
  `https://firebasestorage.googleapis.com/v0/b/${BUCKET}/o/${encodeURIComponent(objectPath)}?alt=media&token=${token}`;

for (const id of Object.keys(manifest).sort((a, b) => a - b)) {
  const plush = { v: 1 };
  for (const [variant, info] of Object.entries(manifest[id])) {
    const local = path.join(OUT, id, `${variant}.webp`);
    const objectPath = `${PREFIX}/${id}/${variant}.webp`;
    const token = crypto.randomUUID();
    if (!DRY) {
      await bucket.upload(local, {
        destination: objectPath,
        metadata: {
          contentType: 'image/webp',
          cacheControl: 'public, max-age=31536000',
          metadata: { firebaseStorageDownloadTokens: token },
        },
      });
    }
    plush[variant] = { url: downloadUrl(objectPath, token), frame: info.frame };
  }
  if (DRY) {
    console.log(`creatures/${id}.plush →`, Object.keys(plush).filter((k) => k !== 'v').join(', '));
    continue;
  }
  const ref = db.collection('creatures').doc(id);
  const snap = await ref.get();
  if (!snap.exists) {
    console.warn(`creatures/${id} does not exist — skipped`);
    continue;
  }
  await ref.update({ plush });
  console.log(`creatures/${id} (${snap.get('name')}) ✓`);
}
console.log(DRY ? 'dry run — nothing written' : 'done');
