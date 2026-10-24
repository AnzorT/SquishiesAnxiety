// Gives (or takes away) the `tester` custom claim (REDESIGN_V6 ruling 5): that account, and only
// that account, sees the Test wallet (coins / gems / level) and the FPS counter in Settings, in debug
// and release builds; the testWallet Cloud Function refuses everyone else. The claim reaches the app
// the next time its sign-in token refreshes (sign out and in again to see it at once).
//
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/tester.mjs                 (who has it)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/tester.mjs <email>         (give it)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/tester.mjs <email> --off   (take it away)
import { createRequire } from 'node:module';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getAuth } = require('firebase-admin/auth');

if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to the service-account key.');
  process.exit(1);
}
const auth = getAuth(initializeApp({ credential: applicationDefault(), projectId: 'squishy-app-61445' }));
const [email, flag] = process.argv.slice(2);
if (!email) {
  let page;
  do {
    page = await auth.listUsers(1000, page && page.pageToken);
    page.users.filter((u) => u.customClaims && u.customClaims.tester).forEach((u) => console.log(`${u.email || u.uid} (${u.uid})`));
  } while (page.pageToken);
} else {
  const u = await auth.getUserByEmail(email);
  const claims = { ...(u.customClaims || {}) };
  if (flag === '--off') delete claims.tester;
  else claims.tester = true;
  await auth.setCustomUserClaims(u.uid, claims);
  console.log(`${email}: tester ${flag === '--off' ? 'off' : 'on'}`);
}
