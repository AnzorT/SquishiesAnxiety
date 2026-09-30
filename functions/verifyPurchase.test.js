// End-to-end check of verifyPurchase against the Firestore emulator:
//
//   cd functions
//   firebase emulators:exec --only firestore --project demo-plushcrush "node verifyPurchase.test.js"
//
// Google Play is faked (canned purchases.products responses). The App Store
// part is real apart from the root of trust: the test makes its own
// certificate chain with Apple's certificate markers (needs `openssl` on the
// PATH — Git for Windows has one), signs StoreKit 2 style transactions with
// it, and runs them through the same makeVerifyApple + Apple's
// app-store-server-library the live function uses.

const assert = require('assert');
const crypto = require('crypto');
const fs = require('fs');
const os = require('os');
const path = require('path');
const { execFileSync } = require('child_process');
const admin = require('firebase-admin');
const { HttpsError } = require('firebase-functions/v2/https');
const { makeVerifyPurchase, makeVerifyApple } = require('./verifyPurchase');
const { appAccountToken, sha256, KEY_REFUND_COINS, spendCredit, baseProduct } = require('./purchases');

// --- price levels: <base>_<cents> ------------------------------------------------
assert.strictEqual(baseProduct('creature_key'), 'creature_key');
assert.strictEqual(baseProduct('creature_key_149'), 'creature_key');
assert.strictEqual(baseProduct('creature_creation_15off'), 'creature_creation_15off');
assert.strictEqual(baseProduct('creature_creation_15off_509'), 'creature_creation_15off');
assert.strictEqual(baseProduct('creature_creation_599'), 'creature_creation');
assert.strictEqual(baseProduct('remove_ads_299'), 'remove_ads');
assert.strictEqual(baseProduct('remove_ads_'), null);
assert.strictEqual(baseProduct('remove_ads_01'), null);
assert.strictEqual(baseProduct('gems'), null);

// --- spending a creation credit (generateCustomModel), bought ones first ------
assert.deepStrictEqual(spendCredit({}), { generationCredits: 0 }, 'a profile without the field has its one free credit');
assert.deepStrictEqual(spendCredit({ generationCredits: 0 }), null, 'no credit left');
assert.deepStrictEqual(spendCredit({ generationCredits: 1 }), { generationCredits: 0 });
assert.deepStrictEqual(spendCredit({ generationCredits: 2, paidCredits: 1 }), { generationCredits: 1, paidCredits: 0 }, 'the bought one goes first');
assert.deepStrictEqual(spendCredit({ generationCredits: 1, paidCredits: 3 }), { generationCredits: 0, paidCredits: 0 }, 'never more paid than credits');

if (!process.env.FIRESTORE_EMULATOR_HOST) {
  console.error('Run under the Firestore emulator (see the top of this file).');
  process.exit(1);
}
admin.initializeApp({ projectId: 'demo-plushcrush' });
const db = admin.firestore();
const { FieldValue } = admin.firestore;
const logger = { info() {}, warn() {}, error() {} };

// --- a fake Google Play ------------------------------------------------------
const play = {}; // purchase token → ProductPurchase
const playCalls = [];
async function playApi(tokenPath, method = 'GET') {
  playCalls.push(`${method} ${tokenPath}`);
  const token = decodeURIComponent(tokenPath.split('/tokens/')[1].split(':')[0]);
  const p = play[token];
  if (!p) {
    const e = new Error('not found');
    e.status = 404;
    throw e;
  }
  if (tokenPath.endsWith(':consume')) p.consumptionState = 1;
  if (tokenPath.endsWith(':acknowledge')) p.acknowledgementState = 1;
  return { ...p };
}

// --- a test certificate chain shaped like Apple's --------------------------
const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'iap-test-'));
const ssl = (...args) => execFileSync('openssl', args, { cwd: dir, stdio: 'pipe' });
function makeChain(prefix) {
  ssl('ecparam', '-name', 'prime256v1', '-genkey', '-noout', '-out', `${prefix}root.key`);
  ssl('req', '-x509', '-new', '-key', `${prefix}root.key`, '-sha256', '-days', '30', '-subj', `/CN=${prefix}Test Root`, '-addext', 'basicConstraints=critical,CA:TRUE', '-addext', 'keyUsage=critical,keyCertSign,cRLSign', '-out', `${prefix}root.pem`);
  fs.writeFileSync(path.join(dir, `${prefix}int.ext`), 'basicConstraints=critical,CA:TRUE\nkeyUsage=critical,keyCertSign,cRLSign\n1.2.840.113635.100.6.2.1=DER:0500\n');
  fs.writeFileSync(path.join(dir, `${prefix}leaf.ext`), 'basicConstraints=critical,CA:FALSE\nkeyUsage=critical,digitalSignature\n1.2.840.113635.100.6.11.1=DER:0500\n');
  for (const [name, signer, ext] of [
    ['int', 'root', 'int.ext'],
    ['leaf', 'int', 'leaf.ext'],
  ]) {
    ssl('ecparam', '-name', 'prime256v1', '-genkey', '-noout', '-out', `${prefix}${name}.key`);
    ssl('req', '-new', '-key', `${prefix}${name}.key`, '-subj', `/CN=${prefix}Test ${name}`, '-out', `${prefix}${name}.csr`);
    ssl('x509', '-req', '-in', `${prefix}${name}.csr`, '-CA', `${prefix}${signer}.pem`, '-CAkey', `${prefix}${signer}.key`, '-CAcreateserial', '-days', '30', '-sha256', '-extfile', `${prefix}${ext}`, '-out', `${prefix}${name}.pem`);
  }
  const der = (f) => ssl('x509', '-in', f, '-outform', 'der');
  return {
    rootDer: der(`${prefix}root.pem`),
    x5c: [`${prefix}leaf.pem`, `${prefix}int.pem`, `${prefix}root.pem`].map((f) => der(f).toString('base64')),
    leafKey: fs.readFileSync(path.join(dir, `${prefix}leaf.key`), 'utf8'),
  };
}
const good = makeChain('good-');
const rogue = makeChain('rogue-'); // a chain the verifier doesn't trust

let txSeq = 1000;
function signedTransaction(chain, fields) {
  const b64 = (o) => Buffer.from(JSON.stringify(o)).toString('base64url');
  const now = Date.now();
  const payload = {
    transactionId: String(txSeq++),
    originalTransactionId: String(txSeq),
    bundleId: 'com.plushcrush.app',
    purchaseDate: now,
    originalPurchaseDate: now,
    quantity: 1,
    type: 'Consumable',
    inAppOwnershipType: 'PURCHASED',
    signedDate: now,
    environment: 'Sandbox',
    ...fields,
  };
  const input = `${b64({ alg: 'ES256', x5c: chain.x5c })}.${b64(payload)}`;
  const sig = crypto.sign('sha256', Buffer.from(input), { key: chain.leafKey, dsaEncoding: 'ieee-p1363' });
  return `${input}.${sig.toString('base64url')}`;
}

const verifyApple = makeVerifyApple({ roots: () => [good.rootDer], onlineChecks: false });
const verify = makeVerifyPurchase({ db, FieldValue, HttpsError, logger, playApi, verifyApple });
const as = (uid, data) => verify({ auth: { uid }, data });
async function fails(promise, code, message) {
  try {
    await promise;
  } catch (e) {
    assert.strictEqual(e.code, code, `${message}: got ${e.code} ${e.message}`);
    return e;
  }
  throw new Error(`${message}: expected ${code}, but it succeeded`);
}
const profile = async (uid) => (await db.collection('users').doc(uid).get()).data();

(async () => {
  // a small catalog and two players
  const batch = db.batch();
  for (let i = 0; i < 20; i++) batch.set(db.collection('creatures').doc(String(i)), { name: `C${i}` });
  batch.set(db.collection('users').doc('ann'), { coins: 100, ownedIds: ['0', '3'], keys: {}, generationCredits: 0, creationDiscountPct: 15, adsFree: false });
  batch.set(db.collection('users').doc('bob'), { coins: 0, ownedIds: ['0'], keys: {}, generationCredits: 0, adsFree: false });
  await batch.commit();

  // ---------------- Google Play -------------------------------------------
  const acct = sha256('ann');
  play.t1 = { purchaseState: 0, acknowledgementState: 0, consumptionState: 0, obfuscatedExternalAccountId: acct, orderId: 'GPA.1', purchaseType: 0 };
  let r = await as('ann', { platform: 'android', productId: 'remove_ads', purchaseToken: 't1' });
  assert.deepStrictEqual(r, { granted: 'adsFree' });
  assert.strictEqual((await profile('ann')).adsFree, true);
  assert.ok(playCalls.includes('POST remove_ads/tokens/t1:acknowledge'), 'Remove Ads is acknowledged');

  r = await as('ann', { platform: 'android', productId: 'remove_ads', purchaseToken: 't1' });
  assert.strictEqual(r.already, true, 'a second sync grants nothing new');
  assert.strictEqual(playCalls.filter((c) => c === 'POST remove_ads/tokens/t1:acknowledge').length, 1, 'acknowledged once');

  play.t2 = { purchaseState: 0, consumptionState: 0, obfuscatedExternalAccountId: acct, obfuscatedExternalProfileId: '5', orderId: 'GPA.2' };
  r = await as('ann', { platform: 'android', productId: 'creature_key', purchaseToken: 't2' });
  assert.deepStrictEqual(r, { granted: 'key', creatureId: '5' });
  assert.strictEqual((await profile('ann')).keys['5'], true);
  assert.ok(playCalls.includes('POST creature_key/tokens/t2:consume'), 'a key is consumed, so it can be bought again');

  play.t3 = { purchaseState: 0, consumptionState: 0, obfuscatedExternalAccountId: acct, obfuscatedExternalProfileId: '3' };
  r = await as('ann', { platform: 'android', productId: 'creature_key', purchaseToken: 't3' });
  assert.deepStrictEqual(r, { granted: 'coins', coins: KEY_REFUND_COINS, creatureId: '3' }, 'a key for an owned creature pays coins back');
  assert.strictEqual((await profile('ann')).coins, 100 + KEY_REFUND_COINS);

  play.t4 = { purchaseState: 0, consumptionState: 0, obfuscatedExternalAccountId: acct };
  r = await as('ann', { platform: 'android', productId: 'creature_creation', purchaseToken: 't4' });
  assert.deepStrictEqual(r, { granted: 'creation' });
  let p = await profile('ann');
  assert.deepStrictEqual([p.generationCredits, p.creationDiscountPct], [1, 15], 'full price keeps the Daily Spin discount');
  assert.strictEqual(p.paidCredits, 1, 'a bought credit is counted as paid');

  play.t5 = { purchaseState: 0, consumptionState: 0, obfuscatedExternalAccountId: acct };
  r = await as('ann', { platform: 'android', productId: 'creature_creation_15off', purchaseToken: 't5' });
  p = await profile('ann');
  assert.deepStrictEqual([p.generationCredits, p.creationDiscountPct], [2, undefined], 'the discounted one uses the discount up');
  assert.strictEqual(p.paidCredits, 2);

  play.t6 = { purchaseState: 2, obfuscatedExternalAccountId: acct };
  r = await as('ann', { platform: 'android', productId: 'remove_ads', purchaseToken: 't6' });
  assert.deepStrictEqual(r, { pending: true }, 'a pending payment grants nothing yet');
  assert.strictEqual((await db.collection('purchases').doc(sha256('t6')).get()).exists, false);

  play.t7 = { purchaseState: 0, obfuscatedExternalAccountId: sha256('someone-else') };
  await fails(as('bob', { platform: 'android', productId: 'remove_ads', purchaseToken: 't7' }), 'failed-precondition', 'another account\'s purchase');
  await fails(as('bob', { platform: 'android', productId: 'remove_ads', purchaseToken: 't1' }), 'failed-precondition', 'Ann\'s token on Bob');
  await fails(as('bob', { platform: 'android', productId: 'remove_ads', purchaseToken: 'nope' }), 'not-found', 'an unknown token');
  await fails(as('bob', { platform: 'android', productId: 'gems', purchaseToken: 't1' }), 'invalid-argument', 'an unknown product');
  await fails(as('bob', { platform: 'android', productId: 'creature_keys', purchaseToken: 't1' }), 'invalid-argument', 'not a price level');
  await fails(as('bob', { platform: 'android', productId: 'creature_key_0', purchaseToken: 't1' }), 'invalid-argument', 'a zero price level');

  // price levels (config/pricing): each grants what its base product does
  const bobAcct = sha256('bob');
  play.L1 = { purchaseState: 0, consumptionState: 0, obfuscatedExternalAccountId: bobAcct, obfuscatedExternalProfileId: '7' };
  r = await as('bob', { platform: 'android', productId: 'creature_key_149', purchaseToken: 'L1' });
  assert.deepStrictEqual(r, { granted: 'key', creatureId: '7' }, 'a $1.49 key');
  assert.ok(playCalls.includes('POST creature_key_149/tokens/L1:consume'), 'a key price level is consumed');
  play.L2 = { purchaseState: 0, consumptionState: 0, obfuscatedExternalAccountId: bobAcct };
  r = await as('bob', { platform: 'android', productId: 'creature_creation_599', purchaseToken: 'L2' });
  assert.deepStrictEqual(r, { granted: 'creation' }, 'a $5.99 creation');
  assert.ok(playCalls.includes('POST creature_creation_599/tokens/L2:consume'));
  play.L3 = { purchaseState: 0, acknowledgementState: 0, obfuscatedExternalAccountId: bobAcct };
  r = await as('bob', { platform: 'android', productId: 'remove_ads_299', purchaseToken: 'L3' });
  assert.deepStrictEqual(r, { granted: 'adsFree' }, 'a $2.99 Remove Ads');
  assert.ok(playCalls.includes('POST remove_ads_299/tokens/L3:acknowledge'), 'Remove Ads levels are acknowledged, not consumed');
  p = await profile('bob');
  assert.deepStrictEqual([p.keys['7'], p.generationCredits, p.paidCredits, p.adsFree], [true, 1, 1, true]);
  await db.collection('users').doc('bob').update({ keys: {}, generationCredits: 0, paidCredits: FieldValue.delete(), adsFree: false });
  await fails(verify({ data: { productId: 'remove_ads', purchaseToken: 't1' } }), 'unauthenticated', 'signed out');
  assert.strictEqual((await profile('bob')).adsFree, false, 'Bob got nothing');

  // ---------------- App Store --------------------------------------------
  let jws = signedTransaction(good, { productId: 'remove_ads', type: 'Non-Consumable', appAccountToken: appAccountToken('bob') });
  r = await as('bob', { platform: 'ios', productId: 'remove_ads', jws });
  assert.deepStrictEqual(r, { granted: 'adsFree' });
  assert.strictEqual((await profile('bob')).adsFree, true);
  r = await as('bob', { platform: 'ios', productId: 'remove_ads', jws });
  assert.strictEqual(r.already, true, 'restoring it again grants nothing new');

  jws = signedTransaction(good, { productId: 'creature_key', appAccountToken: appAccountToken('bob', '12').toUpperCase() });
  r = await as('bob', { platform: 'ios', productId: 'creature_key', jws });
  assert.deepStrictEqual(r, { granted: 'key', creatureId: '12' }, 'the creature rides in the account token (StoreKit hands it back in capitals)');

  jws = signedTransaction(good, { productId: 'creature_creation', appAccountToken: appAccountToken('bob') });
  r = await as('bob', { platform: 'ios', productId: 'creature_creation', jws });
  assert.strictEqual((await profile('bob')).generationCredits, 1);
  assert.strictEqual((await profile('bob')).paidCredits, 1);

  jws = signedTransaction(rogue, { productId: 'remove_ads', appAccountToken: appAccountToken('ann') });
  await fails(as('ann', { platform: 'ios', productId: 'remove_ads', jws }), 'permission-denied', 'a transaction not signed by the trusted root');

  jws = signedTransaction(good, { productId: 'creature_creation', appAccountToken: appAccountToken('ann') });
  await fails(as('bob', { platform: 'ios', productId: 'creature_creation', jws }), 'failed-precondition', 'Ann\'s transaction on Bob');
  await fails(as('ann', { platform: 'ios', productId: 'remove_ads', jws }), 'failed-precondition', 'a creation transaction claimed as Remove Ads');

  jws = signedTransaction(good, { productId: 'remove_ads', bundleId: 'com.someone.else', appAccountToken: appAccountToken('ann') });
  await fails(as('ann', { platform: 'ios', productId: 'remove_ads', jws }), 'permission-denied', 'another app\'s transaction');

  jws = signedTransaction(good, { productId: 'remove_ads', environment: 'Xcode', appAccountToken: appAccountToken('ann') });
  await fails(as('ann', { platform: 'ios', productId: 'remove_ads', jws }), 'permission-denied', 'an Xcode test transaction');

  jws = signedTransaction(good, { productId: 'remove_ads', environment: 'Production', appAccountToken: appAccountToken('ann') });
  await fails(as('ann', { platform: 'ios', productId: 'remove_ads', jws }), 'permission-denied', 'a live transaction without APPLE_APP_ID set');

  jws = signedTransaction(good, { productId: 'remove_ads', revocationDate: Date.now(), appAccountToken: appAccountToken('ann') });
  await fails(as('ann', { platform: 'ios', productId: 'remove_ads', jws }), 'failed-precondition', 'a refunded transaction');

  const ledger = await db.collection('purchases').get();
  console.log(`verifyPurchase: all checks pass (${ledger.size} purchases recorded)`);
  fs.rmSync(dir, { recursive: true, force: true });
  process.exit(0);
})().catch((e) => {
  console.error('FAILED:', e.message);
  process.exit(1);
});
