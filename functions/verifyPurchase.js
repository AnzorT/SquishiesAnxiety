// verifyPurchase — the callable the app sends every store purchase to (right
// after buying, and again at sign-in for anything the store still lists; see
// src/billing). It checks the purchase with the store, grants what it pays
// for (rules in purchases.js) exactly once — `purchases/{id}` records every
// grant — and, for Google Play, acknowledges or consumes it. (On iOS the app
// finishes the transaction once this answers.)
//
//   Android: { platform: 'android', productId, purchaseToken }
//   iOS:     { platform: 'ios', productId, jws } — the StoreKit 2 signed
//            transaction (react-native-iap's verificationResultIOS)
//
// The stores are passed in (makeVerifyPurchase), so the whole handler can be
// tested against the Firestore emulator with fakes: verifyPurchase.test.js.

const { SignedDataVerifier, Environment } = require('@apple/app-store-server-library');
const { PRODUCT_IDS, CREATURE_KEY, CONSUMABLES, BUNDLE_ID, sha256, checkPlayPurchase, checkAppleTransaction, grantFor } = require('./purchases');

// verifyApple(jws) for makeVerifyPurchase: checks a StoreKit 2 signed
// transaction's certificate chain up to `roots` (Apple's root CA in
// production) and decodes it. The transaction names its environment;
// 'Production' needs the app's numeric Apple ID (`appAppleId()`), 'Sandbox'
// (TestFlight, sandbox testers) doesn't, and 'Xcode' (local StoreKit test
// files, signed by Xcode rather than Apple) is refused.
function makeVerifyApple({ roots, onlineChecks = true, appAppleId = () => 0 }) {
  return async function verifyApple(jws) {
    let env;
    try {
      env = JSON.parse(Buffer.from(jws.split('.')[1], 'base64url').toString('utf8')).environment;
    } catch (e) {
      throw new Error('not a signed transaction');
    }
    if (env === 'Production') {
      const appId = Number(appAppleId());
      if (!appId) throw new Error('APPLE_APP_ID is not set');
      return new SignedDataVerifier(roots(), onlineChecks, Environment.PRODUCTION, BUNDLE_ID, appId).verifyAndDecodeTransaction(jws);
    }
    if (env === 'Sandbox') return new SignedDataVerifier(roots(), onlineChecks, Environment.SANDBOX, BUNDLE_ID).verifyAndDecodeTransaction(jws);
    throw new Error(`unsupported environment ${env}`);
  };
}

// playApi(path, method) → Google Play Developer API purchases.products call
//   (index.js); verifyApple(jws) → the decoded, verified transaction.
function makeVerifyPurchase({ db, FieldValue, HttpsError, logger, playApi, verifyApple }) {
  return async function verifyPurchase(request) {
    const uid = request.auth && request.auth.uid;
    if (!uid) throw new HttpsError('unauthenticated', 'Sign in first.');
    const data = request.data || {};
    const platform = data.platform === 'ios' ? 'ios' : 'android';
    const { productId } = data;
    if (!PRODUCT_IDS.includes(productId)) throw new HttpsError('invalid-argument', 'Unknown purchase.');

    // --- 1. ask the store ---------------------------------------------------
    let checked;
    let recordId;
    let play = null;
    let tokenPath = null;
    if (platform === 'android') {
      const token = data.purchaseToken;
      if (typeof token !== 'string' || !token) throw new HttpsError('invalid-argument', 'Missing purchase token.');
      tokenPath = `${encodeURIComponent(productId)}/tokens/${encodeURIComponent(token)}`;
      try {
        play = await playApi(tokenPath);
      } catch (e) {
        logger.error(`[${uid}] Google Play couldn't look up ${productId}`, e.message);
        throw new HttpsError(e.status === 404 || e.status === 400 ? 'not-found' : 'unavailable', 'Google Play could not confirm this purchase.');
      }
      checked = checkPlayPurchase(play, uid);
      recordId = sha256(token);
    } else {
      if (typeof data.jws !== 'string' || !data.jws) throw new HttpsError('invalid-argument', 'Missing transaction.');
      let tx;
      try {
        tx = await verifyApple(data.jws);
      } catch (e) {
        logger.error(`[${uid}] App Store transaction failed verification for ${productId}`, e.message);
        throw new HttpsError('permission-denied', 'The App Store could not confirm this purchase.');
      }
      checked = checkAppleTransaction(tx, uid, productId);
      recordId = `ios_${tx.transactionId}`;
    }
    if (checked.error === 'pending') return { pending: true };
    if (checked.error) throw new HttpsError('failed-precondition', checked.error);

    // --- 2. grant it, once -------------------------------------------------
    const userRef = db.collection('users').doc(uid);
    const recordRef = db.collection('purchases').doc(recordId);
    const rosterIds =
      productId === CREATURE_KEY
        ? (await db.collection('creatures').select().get()).docs.map((d) => d.id).filter((id) => /^\d+$/.test(id))
        : [];

    const result = await db.runTransaction(async (tx) => {
      const [record, user] = await Promise.all([tx.get(recordRef), tx.get(userRef)]);
      if (record.exists) {
        if (record.data().uid !== uid) throw new HttpsError('permission-denied', 'This purchase belongs to another player.');
        return { ...record.data().result, already: true };
      }
      if (!user.exists) throw new HttpsError('failed-precondition', 'No profile.');
      const grant = grantFor({ productId, creatureId: checked.creatureId, profile: user.data(), rosterIds });
      if (grant.error) throw new HttpsError('failed-precondition', grant.error);

      const g = grant.update;
      const update = {};
      if (g.adsFree) update.adsFree = true;
      if (g.coins) {
        update.coins = FieldValue.increment(g.coins);
        update.totalEarned = FieldValue.increment(g.coins);
      }
      if (g.credits) update.generationCredits = FieldValue.increment(g.credits);
      if (g.clearDiscount) update.creationDiscountPct = FieldValue.delete();
      Object.entries(g.keys || {}).forEach(([id, v]) => {
        update[`keys.${id}`] = v;
      });
      tx.update(userRef, update);
      tx.set(recordRef, {
        uid,
        platform,
        productId,
        orderId: checked.orderId,
        test: !!checked.test,
        result: grant.result,
        createdAt: FieldValue.serverTimestamp(),
      });
      logger.info(`[${uid}] ${platform} purchase ${productId} ${checked.orderId || ''}`, grant.result);
      return grant.result;
    });

    // --- 3. Google Play: the purchase is delivered ---------------------------
    // (Unacknowledged purchases are refunded after 3 days; a failure here is
    // retried by the app's next sync, which lands on `already` above.)
    if (platform === 'android') {
      try {
        if (CONSUMABLES.includes(productId)) {
          if (play.consumptionState !== 1) await playApi(`${tokenPath}:consume`, 'POST');
        } else if (play.acknowledgementState !== 1) {
          await playApi(`${tokenPath}:acknowledge`, 'POST');
        }
      } catch (e) {
        logger.warn(`[${uid}] couldn't acknowledge/consume ${productId}`, e.message);
      }
    }
    return result;
  };
}

module.exports = { makeVerifyPurchase, makeVerifyApple };
