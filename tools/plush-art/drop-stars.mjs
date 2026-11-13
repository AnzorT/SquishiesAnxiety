// Deletes the dropped Stars currency (2026-10-09) from every player:
// the `stars` field on users/{uid}. Nothing else changes.
//
//   GOOGLE_APPLICATION_CREDENTIALS=/path/to/key.json node tools/plush-art/drop-stars.mjs [--dry]
//
// Same service-account key as publish.mjs. --dry only lists who has Stars.

import { createRequire } from 'node:module';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const DRY = process.argv.includes('--dry');
const PROJECT_ID = 'squishy-app-61445';

if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to a service-account key (see publish.mjs).');
  process.exit(1);
}

// firebase-admin is already installed for the Cloud Functions
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore, FieldValue } = require('firebase-admin/firestore');

const db = getFirestore(initializeApp({ credential: applicationDefault(), projectId: PROJECT_ID }));
const users = await db.collection('users').get();
let n = 0;
for (const u of users.docs) {
  if (u.get('stars') === undefined) continue;
  const who = `users/${u.id} (${u.get('nickname') || u.get('email') || '?'}): ${u.get('stars')} Stars`;
  if (!DRY) await u.ref.update({ stars: FieldValue.delete() });
  console.log(DRY ? `would clear ${who}` : `cleared ${who}`);
  n++;
}
console.log(`${n} of ${users.size} players had Stars${DRY ? ' — dry run, nothing written' : ', all cleared'}`);
