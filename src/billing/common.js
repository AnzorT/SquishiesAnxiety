import callFunction from '../firebase/callFunction';
import { fallbackPriceLabel, productId } from '../economy';

// What Google Play (index.android.js) and the App Store (index.ios.js) share:
// the store's prices, the errors a purchase can end in, and the call that
// hands a purchase to the verifyPurchase Cloud Function — the only place
// anything is granted.

// --- store prices -----------------------------------------------------------

export const prices = {}; // product id → the store's localized price
const priceListeners = new Set();

export function setPrice(id, label) {
  if (label) prices[id] = label;
}
export function notifyPrices() {
  priceListeners.forEach((fn) => fn({ ...prices }));
}

// `key` is a PRODUCTS key ('removeAds', 'gems950', 'creation', …): the
// store's price for the product sold right now (its price level from
// config/pricing), or the dollar price until that has loaded.
export function priceLabel(key, loaded = prices) {
  return loaded[productId(key)] || fallbackPriceLabel(key);
}

export function subscribePrices(fn) {
  priceListeners.add(fn);
  fn({ ...prices });
  return () => priceListeners.delete(fn);
}

// --- errors -------------------------------------------------------------------

// code: 'cancelled' | 'unavailable' | 'network' | 'busy' | 'failed' |
// 'verify' (paid, but the server couldn't confirm it yet — the next sync
// tries again).
export class PurchaseError extends Error {
  constructor(code, message) {
    super(message || code);
    this.code = code;
  }
}

// { platform: 'android', productId, purchaseToken } or
// { platform: 'ios', productId, jws } → the server's answer.
export function verify(payload) {
  return callFunction('verifyPurchase', payload);
}

// --- the iOS account token ------------------------------------------------------
//
// StoreKit carries one UUID the app sets, `appAccountToken`, signed into the
// transaction by Apple. It holds the player — the first 26 hex digits of
// sha256(uid), with the version and variant digits fixed — and, for a
// creature key, the creature's roster number in the last 6 (ffffff for
// none). functions/purchases.js builds and reads the same thing.

export function appAccountToken(uid, creatureId = null) {
  const h = sha256Hex(String(uid));
  const tail = creatureId != null && /^\d+$/.test(String(creatureId)) ? Number(creatureId).toString(16).padStart(6, '0') : 'ffffff';
  const hex = h.slice(0, 12) + '4' + h.slice(13, 16) + '8' + h.slice(17, 26) + tail;
  return `${hex.slice(0, 8)}-${hex.slice(8, 12)}-${hex.slice(12, 16)}-${hex.slice(16, 20)}-${hex.slice(20, 32)}`;
}

// SHA-256 of a string (UTF-8), as hex. Hermes has no crypto.subtle.
const K = [
  0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5, 0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3,
  0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174, 0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
  0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967, 0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13,
  0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85, 0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
  0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3, 0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208,
  0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2,
];
export function sha256Hex(text) {
  const bytes = [];
  for (const ch of text) {
    const cp = ch.codePointAt(0);
    if (cp < 0x80) bytes.push(cp);
    else if (cp < 0x800) bytes.push(0xc0 | (cp >> 6), 0x80 | (cp & 63));
    else if (cp < 0x10000) bytes.push(0xe0 | (cp >> 12), 0x80 | ((cp >> 6) & 63), 0x80 | (cp & 63));
    else bytes.push(0xf0 | (cp >> 18), 0x80 | ((cp >> 12) & 63), 0x80 | ((cp >> 6) & 63), 0x80 | (cp & 63));
  }
  const bitLen = bytes.length * 8;
  bytes.push(0x80);
  while (bytes.length % 64 !== 56) bytes.push(0);
  for (let i = 7; i >= 0; i--) bytes.push(i >= 4 ? 0 : (bitLen >>> (i * 8)) & 0xff);
  const H = [0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a, 0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19];
  const w = new Array(64);
  const rotr = (x, n) => (x >>> n) | (x << (32 - n));
  for (let off = 0; off < bytes.length; off += 64) {
    for (let i = 0; i < 16; i++) w[i] = (bytes[off + i * 4] << 24) | (bytes[off + i * 4 + 1] << 16) | (bytes[off + i * 4 + 2] << 8) | bytes[off + i * 4 + 3];
    for (let i = 16; i < 64; i++) {
      const s0 = rotr(w[i - 15], 7) ^ rotr(w[i - 15], 18) ^ (w[i - 15] >>> 3);
      const s1 = rotr(w[i - 2], 17) ^ rotr(w[i - 2], 19) ^ (w[i - 2] >>> 10);
      w[i] = (w[i - 16] + s0 + w[i - 7] + s1) | 0;
    }
    let [a, b, c, d, e, f, g, h] = H;
    for (let i = 0; i < 64; i++) {
      const t1 = (h + (rotr(e, 6) ^ rotr(e, 11) ^ rotr(e, 25)) + ((e & f) ^ (~e & g)) + K[i] + w[i]) | 0;
      const t2 = ((rotr(a, 2) ^ rotr(a, 13) ^ rotr(a, 22)) + ((a & b) ^ (a & c) ^ (b & c))) | 0;
      h = g;
      g = f;
      f = e;
      e = (d + t1) | 0;
      d = c;
      c = b;
      b = a;
      a = (t1 + t2) | 0;
    }
    H[0] = (H[0] + a) | 0;
    H[1] = (H[1] + b) | 0;
    H[2] = (H[2] + c) | 0;
    H[3] = (H[3] + d) | 0;
    H[4] = (H[4] + e) | 0;
    H[5] = (H[5] + f) | 0;
    H[6] = (H[6] + g) | 0;
    H[7] = (H[7] + h) | 0;
  }
  return H.map((x) => (x >>> 0).toString(16).padStart(8, '0')).join('');
}
