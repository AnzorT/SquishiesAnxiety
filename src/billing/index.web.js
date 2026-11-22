import { PurchaseError } from './common';

export { PurchaseError, priceLabel, subscribePrices } from './common';

// In-app purchases on web (src/web/README.md): there's no store in a browser, so nothing can be bought here. Prices
// show as the app's fallback labels, and a buy says the store isn't available (the same as a phone without Google
// Play). The Android twin is index.android.js.
export async function loadProducts() {
  return false;
}

export async function buy() {
  throw new PurchaseError('unavailable', 'Purchases are not available in the web version');
}

export async function syncPurchases() {}
