// Writes the Shop's offers (REDESIGN_V6 step 7, ruling 2) to Firestore config/offers: what the Deals
// and Gems tabs sell, read by the app and by the server (verifyPurchase grants an offer from it).
// The design's set lives in functions/squad.js DEFAULT_OFFERS; this seeds the doc from it, after which
// the doc is the source: edit it in the Firebase console (or a JSON file here) to change an offer's
// contents, badge, timer, order, or switch it off — no app update needed. Each offer's price is its
// store product's (create the products in the Play Console: offer_starter, offer_collector,
// offer_mega, offer_gem_jar, offer_pass_spooky; remove_ads and the gem packs exist already).
//
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/offers.mjs              (shows what's there)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/offers.mjs --seed       (writes the design's set if there's none)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/offers.mjs --file x.json (replaces it with x.json)
import { createRequire } from 'node:module';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore } = require('firebase-admin/firestore');
const { DEFAULT_OFFERS, offersOf } = require(path.join(ROOT, 'functions', 'squad.js'));

if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to the service-account key.');
  process.exit(1);
}
const db = getFirestore(initializeApp({ credential: applicationDefault(), projectId: 'squishy-app-61445' }));
const ref = db.collection('config').doc('offers');
const args = process.argv.slice(2);
const snap = await ref.get();
if (args[0] === '--seed') {
  if (snap.exists) console.log('config/offers exists already — left as it is');
  else {
    await ref.set(DEFAULT_OFFERS);
    console.log('config/offers written with the design\'s offers');
  }
} else if (args[0] === '--file') {
  const doc = JSON.parse(fs.readFileSync(args[1], 'utf8'));
  const n = offersOf(doc);
  if (!n.offers.length) throw new Error('no offers in that file');
  await ref.set(doc);
  console.log(`config/offers replaced: ${n.offers.length} offers, ${n.packs.length} packs`);
} else {
  console.log(JSON.stringify(snap.exists ? snap.data() : null, null, 2));
}
