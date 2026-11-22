// Deletes every player, so everyone starts from nothing (the user's ruling,
// 2026-10-19, for the switch to the 86 roster):
//   · every Firebase Auth account (they register again)
//   · users/{uid} and everything under it (customCreatures, crib)
//   · purchases/* — the receipts are tied to the old uids, and a kept one
//     would refuse a re-registered player restoring Remove Ads ("belongs to
//     another player"); Play keeps the real purchase, so a restore grants it
//     again
//   · Storage customUploads/ and customModels/ (painted creatures)
// Kept: the catalog (creatures/), config/, feedback/.
//
// Runs with admin credentials (the service-account key, as publish.mjs):
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/wipe-players.mjs         (counts only)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/wipe-players.mjs --yes   (deletes)
import { createRequire } from 'node:module';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getAuth } = require('firebase-admin/auth');
const { getFirestore } = require('firebase-admin/firestore');
const { getStorage } = require('firebase-admin/storage');

const YES = process.argv.includes('--yes');
if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to the service-account key (see the top of this file).');
  process.exit(1);
}
const app = initializeApp({ credential: applicationDefault(), projectId: 'squishy-app-61445', storageBucket: 'squishy-app-61445.firebasestorage.app' });
const auth = getAuth(app);
const db = getFirestore(app);
const bucket = getStorage(app).bucket();

// Auth accounts
const uids = [];
let page;
do {
  page = await auth.listUsers(1000, page && page.pageToken);
  page.users.forEach((u) => uids.push(u.uid));
} while (page.pageToken);
const users = (await db.collection('users').select().get()).size;
const purchases = (await db.collection('purchases').select().get()).size;
let files = 0;
for (const prefix of ['customUploads/', 'customModels/']) files += (await bucket.getFiles({ prefix }))[0].length;
console.log(`${uids.length} accounts, ${users} profiles (with their crib and custom creatures), ${purchases} purchase records, ${files} custom-creature files`);
if (!YES) {
  console.log('nothing deleted — run again with --yes to delete all of it');
  process.exit(0);
}

for (let i = 0; i < uids.length; i += 1000) {
  const r = await auth.deleteUsers(uids.slice(i, i + 1000));
  if (r.failureCount) r.errors.forEach((e) => console.warn(`account ${uids[i + e.index]}: ${e.error.message}`));
}
console.log('accounts deleted');
await db.recursiveDelete(db.collection('users'));
console.log('profiles deleted');
await db.recursiveDelete(db.collection('purchases'));
console.log('purchase records deleted');
for (const prefix of ['customUploads/', 'customModels/']) await bucket.deleteFiles({ prefix });
console.log('custom-creature files deleted — done');
