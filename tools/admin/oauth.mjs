// Social sign-in setup (REDESIGN_V6 step 8): stores a provider's credentials in Firestore
// secrets/oauth, which only the Cloud Functions read (firestore.rules lets no client near it).
// The `oauth` function (functions/index.js, oauth.js) then starts offering that provider.
//
// At each provider, register this redirect URI:
//   https://us-central1-squishy-app-61445.cloudfunctions.net/oauth/callback
//   · Google: Google Cloud console → APIs & Services → Credentials → OAuth client ID, type "Web
//     application" (needs the OAuth consent screen filled in first). Client ID + secret.
//   · Facebook: developers.facebook.com → the app → Facebook Login → Settings (Valid OAuth Redirect
//     URIs). App ID + App secret.
//   · TikTok: developers.tiktok.com → the app → Login Kit (Web), redirect URI. Client key + secret.
// And once: in Google Cloud IAM, give the functions' service account
// (PROJECT_NUMBER-compute@developer.gserviceaccount.com) the "Service Account Token Creator" role, so
// it can sign the custom tokens.
//
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/oauth.mjs                      (what's set, secrets hidden)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/oauth.mjs google <clientId> <secret>
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/oauth.mjs facebook <appId> <appSecret>
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/oauth.mjs tiktok <clientKey> <clientSecret>
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/oauth.mjs off <provider>
import { createRequire } from 'node:module';
import crypto from 'node:crypto';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore, FieldValue } = require('firebase-admin/firestore');

if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to the service-account key.');
  process.exit(1);
}
const ref = getFirestore(initializeApp({ credential: applicationDefault(), projectId: 'squishy-app-61445' })).collection('secrets').doc('oauth');
const [cmd, a, b] = process.argv.slice(2);
const KEYS = { google: 'clientId', facebook: 'clientId', tiktok: 'clientKey' };
const cur = (await ref.get()).data() || {};
if (!cur.stateKey) await ref.set({ stateKey: crypto.randomBytes(32).toString('base64url') }, { merge: true });

if (KEYS[cmd]) {
  if (!a || !b) throw new Error(`usage: oauth.mjs ${cmd} <id> <secret>`);
  await ref.set({ [cmd]: { [KEYS[cmd]]: a, secret: b } }, { merge: true });
  console.log(`${cmd} sign-in set`);
} else if (cmd === 'off') {
  await ref.update({ [a]: FieldValue.delete() });
  console.log(`${a} sign-in off`);
} else {
  const now = (await ref.get()).data() || {};
  Object.keys(KEYS).forEach((p) => console.log(`${p}: ${now[p] ? `on (${now[p][KEYS[p]]})` : 'not set'}`));
}
