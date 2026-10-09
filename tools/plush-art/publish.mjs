// Publishes the plush roster to Firebase:
//   · each rendered image (render.mjs → out/) goes to Storage at
//     creatureArt/plush-v2/{id}/{variant}.webp
//   · each `creatures/{id}` doc gets what the app reads:
//       name, description, order (= id),
//       plush: { v: 2, lg: { url, frame }, lgLocked, lgFace, lgLockedFace,
//                md, mdLocked, mdFace, mdLockedFace, sm },
//       rig:   { key, food, ink, mouthInk, cheek, sclera, iris, irisK, patch,
//                eyes, mouth, cheeks, head }   (the design's creatures-v2.js)
//       moves: the design's per-creature motion channels
// Nothing about the roster lives in the app bundle. A creature's 3D model is
// NOT set here: upload a Tripo GLB to Storage and put its download URL on the
// doc as `modelUrl` (the squish stage plays the 2D art until then).
//
// The catalog is admin-only (firestore.rules), so this runs with admin
// credentials: a service-account key from Firebase console → Project
// settings → Service accounts → "Generate new private key".
//
//   GOOGLE_APPLICATION_CREDENTIALS=/path/to/key.json node tools/plush-art/publish.mjs [flags]
//
//   (no flag)        update `plush`, `rig` and `moves` on the docs that exist
//   --catalog        REPLACE every roster doc (creatures/0 … 29) with the
//                    roster above — this is the 2026-10-03 roster swap: the
//                    old 20 creatures' fields (their svg, modelUrl…) go away
//                    and docs 20-29 are created
//   --reset-players  reset every player's progress to a fresh profile (what
//                    createUserProfile gives a new account): 250 coins, only
//                    the free creature (#0), no keys/tokens/boxes/stats/
//                    achievements/spins/levels. Keeps who they are (email,
//                    age, nickname), what they paid for (adsFree,
//                    generationCredits, paidCredits) and their custom
//                    creatures.
//   --dry            only print what would be written
//
// Re-running is safe: files are overwritten in place.

import { createRequire } from 'node:module';
import crypto from 'node:crypto';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { ROSTER } from './roster.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const OUT = path.join(HERE, 'out');
const args = process.argv.slice(2);
const DRY = args.includes('--dry');
const CATALOG = args.includes('--catalog');
const RESET = args.includes('--reset-players');
const PROJECT_ID = 'squishy-app-61445';
const BUCKET = 'squishy-app-61445.firebasestorage.app';
const PREFIX = 'creatureArt/plush-v2';

// firebase-admin is already installed for the Cloud Functions
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore, FieldValue } = require('firebase-admin/firestore');
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

// --- the catalog -------------------------------------------------------------

for (const c of ROSTER) {
  const entry = manifest[c.id];
  if (!entry) {
    console.warn(`creatures/${c.id} (${c.name}): not rendered — run render.mjs first; skipped`);
    continue;
  }
  const plush = { v: 2 };
  for (const [variant, info] of Object.entries(entry.art)) {
    const local = path.join(OUT, String(c.id), `${variant}.webp`);
    const objectPath = `${PREFIX}/${c.id}/${variant}.webp`;
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
  const fields = { plush, rig: entry.rig, moves: entry.moves };
  const doc = CATALOG ? { name: c.name, description: c.description, order: c.id, ...fields } : fields;
  if (DRY) {
    console.log(`creatures/${c.id} ${CATALOG ? 'SET' : 'update'} →`, Object.keys(doc).join(', '), `(${Object.keys(plush).length - 1} images)`);
    continue;
  }
  const ref = db.collection('creatures').doc(String(c.id));
  if (CATALOG) {
    await ref.set(doc); // replaces the doc: the old roster's fields go away
    console.log(`creatures/${c.id} (${c.name}) replaced ✓`);
  } else {
    const snap = await ref.get();
    if (!snap.exists) {
      console.warn(`creatures/${c.id} does not exist — skipped (use --catalog to create the roster)`);
      continue;
    }
    await ref.update(doc);
    console.log(`creatures/${c.id} (${snap.get('name')}) ✓`);
  }
}

// --- the players -------------------------------------------------------------

// A fresh profile's gameplay (createUserProfile in src/firebase/firestore.js)
// and every field the game has written since — the latter deleted, so a
// re-run also clears fields added later.
const FRESH = {
  coins: 250,
  totalEarned: 250,
  ownedIds: ['0'], // STARTER_CREATURE_IDS: the free creature
  keys: {},
  tokens: {},
  stats: { presses: 0, longestHoldMs: 0, playTime: {} },
  achievements: { speedTap: false, watchAd: false },
  // the guided tutorial from its first step, level 1 (src/progression.js)
  tut: 'start',
  level: 1,
};
const CLEARED = [
  // Mystery Box, boosts, ads
  'boxOpens', 'boxDay', 'boxDayOpens', 'boxPending', 'tierPulls', 'secretFound', 'adsWatched', 'maxMult',
  // Daily Spin (server-written, admin may clear) and its prize
  'spins', 'lastSpinDay', 'wheelJackpot', 'creationDiscountPct',
  // progression (2026-10-03 drop): daily challenges, streak, the level day
  'levelDay', 'daily', 'streak', 'lastFull', 'logins', 'lastLogin', 'bestStreak', 'streakSeen', 'streakDiscount', 'chests', 'adSpins',
  // the squad economy (functions/squad.js): with `gems` gone, the next squad
  // move or spin hands out the starting 600 gems and the welcome chest
  // again. `stars` is the dropped Stars currency (2026-10-09). `gemFirst` stays: it's about packs paid for with money.
  'gems', 'stars', 'col', 'pity', 'epic', 'chestBag', 'chestVideos', 'dealDay', 'giftDay', 'chestOpens', 'xp',
  // fields from versions that only existed during testing
  'stickerPile', 'stickers',
];

if (RESET) {
  if (DRY) {
    console.log('would reset every users/{uid} to', FRESH, 'and clear', CLEARED.join(', '));
  } else {
    const users = await db.collection('users').get();
    let n = 0;
    for (const u of users.docs) {
      const update = { ...FRESH };
      CLEARED.forEach((k) => (update[k] = FieldValue.delete()));
      await u.ref.update(update);
      n++;
      console.log(`users/${u.id} (${u.get('nickname') || u.get('email') || '?'}) reset`);
    }
    // the Crib's own doc (users/{uid}/crib/state), once it exists
    const cribs = await db.collectionGroup('crib').get();
    for (const d of cribs.docs) await d.ref.delete();
    console.log(`${n} players reset${cribs.size ? `, ${cribs.size} crib docs deleted` : ''}`);
  }
}

console.log(DRY ? 'dry run — nothing written' : 'done');
