import { NativeEventEmitter, NativeModules } from 'react-native';
import { PRODUCTS } from '../economy';
import { ALL_IDS, CONSUMABLE_IDS, PurchaseError, notifyPrices, prices, setPrice, verify } from './common';

export { PurchaseError, priceLabel, subscribePrices } from './common';

// In-app purchases on Android — Google Play Billing 8, through the app's own
// native module (android/app/src/main/java/com/plushcrush/app/billing). The
// iOS twin is index.ios.js; what they share is in common.js. Products:
// PRODUCTS in src/economy.js.
//
// The app never grants anything itself. Every purchase goes to the
// verifyPurchase Cloud Function, which checks it with Google Play, writes the
// grant to the profile, and then acknowledges or consumes it. Purchases that
// didn't make it there — the app closed mid-way, a payment that was pending,
// Remove Ads on a new phone — are sent again by syncPurchases() at sign-in,
// so nothing paid for is lost. The player's uid is hashed into each purchase
// (its obfuscated account id) and a creature key's creature rides as its
// obfuscated profile id, so the server can trust both.

const Native = NativeModules.PlayBilling;

let connecting = null;
function connect() {
  if (!Native) return Promise.resolve(false);
  if (!connecting) {
    connecting = Native.connect()
      .then((ok) => {
        if (!ok) connecting = null; // try again next time
        return ok;
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
    const list = await Native.getProducts(ALL_IDS);
    list.forEach((p) => setPrice(p.id, p.price));
    notifyPrices();
    return list.length > 0;
  } catch {
    return false;
  }
}

const deliver = (purchase) =>
  verify({ platform: 'android', productId: purchase.products && purchase.products[0], purchaseToken: purchase.purchaseToken });

// Buys `key` (a PRODUCTS key) for the signed-in player. Resolves with the
// server's answer ({ granted: 'adsFree' | 'key' | 'coins' | 'creation', … }),
// or { pending: true } for a payment Google Play hasn't cleared yet (it's
// granted by syncPurchases once it does). Rejects with a PurchaseError.
export async function buy(key, { uid, creatureId = '' }, retried = false) {
  const product = PRODUCTS[key];
  if (!product) throw new PurchaseError('failed', `Unknown product ${key}`);
  if (!(await connect())) throw new PurchaseError('unavailable');
  if (!prices[product.id]) await loadProducts();
  if (!prices[product.id]) throw new PurchaseError('unavailable');
  let purchases;
  try {
    purchases = await Native.purchase(product.id, uid, creatureId);
  } catch (e) {
    if (e.code === 'already_owned') {
      await syncPurchases();
      // A creation or a key that Play still holds (the server never got to
      // consume it): the sync just granted and consumed it, so the store
      // sheet opens normally now — once.
      if (CONSUMABLE_IDS.includes(product.id) && !retried) return buy(key, { uid, creatureId }, true);
      // Remove Ads bought before (another phone, or not synced yet)
      return { granted: 'restored' };
    }
    const passThrough = ['cancelled', 'busy', 'network'];
    throw new PurchaseError(passThrough.includes(e.code) ? e.code : 'unavailable', e.message);
  }
  const p = purchases.find((x) => x.products.includes(product.id)) || purchases[0];
  if (!p) throw new PurchaseError('failed', 'No purchase came back');
  if (p.state === 'pending') return { pending: true };
  try {
    return await deliver(p);
  } catch (e) {
    // Paid, but the server couldn't confirm it yet: syncPurchases retries.
    throw new PurchaseError('verify', e.message);
  }
}

// Sends every purchase Google Play reports for this account to the server
// (it skips any it has already granted). Call once signed in. Quiet when
// Google Play simply isn't there (an emulator without a Play account, a
// phone without Play services).
export async function syncPurchases() {
  if (!(await connect())) return;
  let list;
  try {
    list = await Native.getPurchases();
  } catch (e) {
    return; // billing unavailable or disconnected — try again next sign-in
  }
  for (const p of list) {
    if (p.state === 'purchased') await deliver(p).catch((e) => console.warn('purchase sync failed:', e.message));
  }
}

// A payment that was pending (cash at a store, say) clears while the app is
// open: Play reports it outside any purchase flow.
if (Native) {
  new NativeEventEmitter(Native).addListener('PlayBillingPurchases', (list) => {
    (list || []).filter((p) => p.state === 'purchased').forEach((p) => deliver(p).catch(() => {}));
  });
}
