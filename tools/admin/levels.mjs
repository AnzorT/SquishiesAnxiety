// Writes the player levels (PLAYER_XP.md) to Firestore config/levels: the XP each level takes, the
// level road's prizes, and what earns XP — read by the app and by the server (which pays the road's
// prizes). The defaults live in functions/squad.js DEFAULT_LEVELS; this seeds the doc from them, after
// which the doc is the source: edit it in the Firebase console (or a JSON file here) and it applies
// at once, no app update or deploy. A field left out or broken falls back to its default.
//
//   xpPerLevel  reaching level L takes xpPerLevel × L XP, from 0 at every level (100: 9 → 10 is 1,000)
//   road        one prize per level from level 1: { k: 'coins', n } | { k: 'gems', n } |
//               { k: 'chest', t: 'common' | 'rare' | 'epic' | 'legendary' | 'set' } — add rows to add levels
//   xp          { challenge, chest, squishEvery, squishDay, replay, games, blitz: { squishdoku, sort, stack } }
//
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/levels.mjs              (shows what's there)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/levels.mjs --seed       (writes the defaults if there's none)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/levels.mjs --file x.json (replaces it with x.json)
import { createRequire } from 'node:module';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore } = require('firebase-admin/firestore');
const { DEFAULT_LEVELS, levelsOf } = require(path.join(ROOT, 'functions', 'squad.js'));

if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to the service-account key.');
  process.exit(1);
}
const db = getFirestore(initializeApp({ credential: applicationDefault(), projectId: 'squishy-app-61445' }));
const ref = db.collection('config').doc('levels');
const args = process.argv.slice(2);
const snap = await ref.get();
if (args[0] === '--seed') {
  if (snap.exists) console.log('config/levels exists already — left as it is');
  else {
    await ref.set(DEFAULT_LEVELS);
    console.log(`config/levels written with the defaults: ${DEFAULT_LEVELS.road.length} levels on the road, ${DEFAULT_LEVELS.xpPerLevel} XP × level`);
  }
} else if (args[0] === '--file') {
  const doc = JSON.parse(fs.readFileSync(args[1], 'utf8'));
  const n = levelsOf(doc);
  // what the app and the server will use (a broken field falls back)
  if (doc.road && n.road === DEFAULT_LEVELS.road) throw new Error('that road has a broken prize (see the format above)');
  await ref.set(doc);
  console.log(`config/levels replaced: ${n.road.length} levels on the road, ${n.xpPerLevel} XP × level`);
} else {
  console.log(JSON.stringify(snap.exists ? snap.data() : null, null, 2));
}
process.exit(0);
