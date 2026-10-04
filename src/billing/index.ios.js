import * as RNIap from 'react-native-iap';
import { isConsumable, productId, productIds } from '../economy';
import { PurchaseError, appAccountToken, notifyPrices, prices, setPrice, verify } from './common';

export { PurchaseError, priceLabel, subscribePrices } from './common';

// In-app purchases on iOS — StoreKit 2, through react-native-iap (linked for
// iOS only: react-native.config.js keeps it out of the Android build, which
// uses the app's own Play Billing 8 module, index.android.js). What the two
// share is in common.js; products: PRODUCTS in src/economy.js (with the
// price level config/pricing picks), the same ids in App Store Connect.
//
// As on Android the app never grants anything itself: each purchase's
// Apple-signed transaction (StoreKit 2's jwsRepresentation) goes to the
// verifyPurchase Cloud Function, which checks the signature up to Apple's
// root certificate and grants it once. Only then does the app finish the
// transaction — until it does, StoreKit hands it back at every launch
// (Transaction.updates → purchaseUpdatedListener below), so a purchase
// interrupted by a crash or a lost connection is delivered next time.
// Remove Ads comes back on a new iPhone from the current entitlements
// (syncPurchases). The player and a key's creature ride in the purchase's
// appAccountToken (common.js), which Apple signs too.
//
// NOT YET RUN on a device: there's no iOS build of the app yet (see
// REDESIGN_V3.md, "iOS").

RNIap.setup({ storekitMode: 'STOREKIT2_MODE' });

const deliver = async (purchase) => {
  const result = await verify({ platform: 'ios', productId: purchase.productId, jws: purchase.verificationResultIOS });
  if (!result || !result.pending) {
    await RNIap.finishTransaction({ purchase, isConsumable: isConsumable(purchase.productId) }).catch(() => {});
  }
  return result;
};

let listening = false;
function listen() {
  if (listening) return;
  listening = true;
  // unfinished transactions from earlier runs, Ask to Buy approvals, …
  RNIap.purchaseUpdatedListener((purchase) => {
    if (purchase && purchase.verificationResultIOS) deliver(purchase).catch((e) => console.warn('purchase delivery failed:', e.message));
  });
}

let connecting = null;
function connect() {
  listen(); // before connecting, so launch-time updates aren't missed
  if (!connecting) {
    connecting = RNIap.initConnection()
      .then((ok) => {
        if (!ok) connecting = null;
        return !!ok;
      })
      .catch(() => {
        connecting = null;
        return false;
      });
  }
  return connecting;
}

export async function loadProducts() {
  if (!(await connect())) return false;
  try {
    const list = await RNIap.getProducts({ skus: productIds() });
    list.forEach((p) => setPrice(p.productId, p.localizedPrice));
    notifyPrices();
    return list.length > 0;
  } catch {
    return false;
  }
}

// Same contract as the Android buy(): the server's answer, { pending: true }
// for an Ask to Buy waiting on a parent, or a PurchaseError.
export async function buy(key, { uid, creatureId = '' }) {
  const id = productId(key); // its price level (config/pricing)
  if (!id) throw new PurchaseError('failed', `Unknown product ${key}`);
  if (!(await connect())) throw new PurchaseError('unavailable');
  if (!prices[id]) await loadProducts();
  if (!prices[id]) throw new PurchaseError('unavailable');
  let purchase;
  try {
    purchase = await RNIap.requestPurchase({
      sku: id,
      appAccountToken: appAccountToken(uid, creatureId || null),
      andDangerouslyFinishTransactionAutomaticallyIOS: false,
    });
  } catch (e) {
    if (e.code === 'E_USER_CANCELLED') throw new PurchaseError('cancelled');
    if (e.code === 'E_DEFERRED_PAYMENT') return { pending: true };
    if (e.code === 'E_NETWORK_ERROR') throw new PurchaseError('network', e.message);
    throw new PurchaseError('unavailable', e.message);
  }
  if (Array.isArray(purchase)) purchase = purchase[0];
  if (!purchase || !purchase.verificationResultIOS) throw new PurchaseError('failed', 'No transaction came back');
  try {
    return await deliver(purchase);
  } catch (e) {
    // Paid, but the server couldn't confirm it yet: the transaction stays
    // unfinished, so StoreKit delivers it again at the next launch.
    throw new PurchaseError('verify', e.message);
  }
}

// Remove Ads bought on another iPhone (or never confirmed): send the current
// entitlements to the server, which skips anything already granted.
export async function syncPurchases() {
  if (!(await connect())) return;
  let list;
  try {
    list = await RNIap.getAvailablePurchases();
  } catch (e) {
    return;
  }
  for (const p of list) {
    if (p.verificationResultIOS) await deliver(p).catch((e) => console.warn('purchase sync failed:', e.message));
  }
}
