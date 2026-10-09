// Real-money products and their prices. The game's economy itself — coins,
// gems, chests and the collection — is src/squad (rules in
// functions/squad.js, run by the `squad` Cloud Function).

// Google Play / App Store products — the same ids in both stores (see
// REDESIGN_V3.md). `base` is the product sold by default; `usd` its price,
// shown until the store's own localized price loads.
//
// Price levels: Firestore `config/pricing` can set a price in US dollars for
// each ({ removeAds: 2.99, creation: 5.99 }), and the app then sells that
// level's own store product, `<base>_<cents>` (creature_creation_599) — it
// must exist in both stores at that price. The 15%
// off creation follows the creation price (85% of it, cents rounded down)
// unless `creationDiscount` is set too; the half-price one (the 10-day
// streak's reward) is half of it unless `creationHalf` is set. The server
// grants every level like its base product (functions/purchases.js).
export const PRODUCTS = {
  removeAds: { base: 'remove_ads', usd: 1.99 },
  creation: { base: 'creature_creation', usd: 4.99 },
  creationDiscount: { base: 'creature_creation_15off', usd: 4.24 },
  creationHalf: { base: 'creature_creation_half', usd: 2.49 },
  // gem packs (functions/squad.js GEM_PACKS; the first of each is doubled)
  gems80: { base: 'gems_80', usd: 0.99, gems: 80 },
  gems450: { base: 'gems_450', usd: 4.99, gems: 450, bonus: '+12%' },
  gems950: { base: 'gems_950', usd: 9.99, gems: 950, bonus: '+19%', tag: 'POPULAR' },
  gems2000: { base: 'gems_2000', usd: 19.99, gems: 2000, bonus: '+25%' },
  gems5500: { base: 'gems_5500', usd: 49.99, gems: 5500, bonus: '+38%' },
  gems12000: { base: 'gems_12000', usd: 99.99, gems: 12000, bonus: '+50%', tag: 'BEST VALUE' },
};
export const GEM_KEYS = ['gems80', 'gems450', 'gems950', 'gems2000', 'gems5500', 'gems12000'];
const CONSUMABLE_KEYS = ['creation', 'creationDiscount', 'creationHalf', ...GEM_KEYS];

let pricing = {}; // PRODUCTS key → price in USD cents, from config/pricing

const cents = (usd) => (typeof usd === 'number' && Number.isFinite(usd) && usd > 0 && usd < 10000 ? Math.round(usd * 100) : null);

// App calls this with the config/pricing document (or null) whenever it
// changes. A missing or bad price means the base product.
export function setPricing(doc) {
  const d = doc || {};
  const next = {};
  ['removeAds', 'creation'].forEach((k) => {
    const c = cents(d[k]);
    if (c) next[k] = c;
  });
  const discount = cents(d.creationDiscount) || (next.creation ? Math.floor(next.creation * 0.85) : null);
  if (discount) next.creationDiscount = discount;
  const half = cents(d.creationHalf) || (next.creation ? Math.floor(next.creation * 0.5) : null);
  if (half) next.creationHalf = half;
  pricing = next;
}

// The store product to sell for `key` right now.
export function productId(key) {
  const p = PRODUCTS[key];
  if (!p) return null;
  return pricing[key] ? `${p.base}_${pricing[key]}` : p.base;
}

// Every product the app may sell right now (to load their store prices).
export const productIds = () => Object.keys(PRODUCTS).map(productId);

// "$1.49" — the price set in Firebase (or the default), until the store's
// own localized price has loaded.
export function fallbackPriceLabel(key) {
  const p = PRODUCTS[key];
  if (!p) return '';
  return `$${((pricing[key] || Math.round(p.usd * 100)) / 100).toFixed(2)}`;
}

// A product id (a base product or a price level of it) → its PRODUCTS key.
export function productKey(id) {
  const m = /^(gems_(?:80|450|950|2000|5500|12000)|remove_ads|creature_creation_15off|creature_creation_half|creature_creation)(?:_[1-9]\d{0,5})?$/.exec(String(id || ''));
  return m ? Object.keys(PRODUCTS).find((k) => PRODUCTS[k].base === m[1]) : null;
}

export const isConsumable = (id) => CONSUMABLE_KEYS.includes(productKey(id));

// Without ads, a ×N boost starts straight away; this recharge after each
// one keeps the same pace as watching the video would.
export const AD_FREE_BOOST_RECHARGE_MS = 30000;
