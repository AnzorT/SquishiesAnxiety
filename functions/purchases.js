// In-app purchases — the rules, kept free of Firebase and HTTP so they can be
// tested alone. verifyPurchase.js checks a purchase with Google Play or the
// App Store, applies these to the player's profile, and records it.
//
// Products — the same ids in the Play Console and App Store Connect (the
// app's list is PRODUCTS in src/economy.js):
//  · remove_ads              — one-time, $0.99: `adsFree: true` (no banner,
//                              no forced ads, free daily boxes, boosts
//                              without videos).
//  · creature_key            — $0.99, consumable: the key for one creature,
//                              chosen in the app (see appAccountToken below). The
//                              other way to a key is a full set of the
//                              creature's tokens from Mystery Boxes.
//  · creature_creation       — $4.99, consumable: one custom-creature
//                              generation (`generationCredits` + 1, spent by
//                              generateCustomModel). `paidCredits` + 1 too:
//                              how many of the credits were bought, so the
//                              app shows them as paid (not FREE) and never
//                              puts an ad break after one.
//  · creature_creation_15off — the same at 15% off, bought instead while the
//                              Daily Spin's prize (`creationDiscountPct`) is
//                              waiting; it uses the prize up. (Stores can't
//                              discount a product on the fly, so the
//                              discounted price is its own product.)
//  · creature_creation_half  — the same at half price, bought instead while
//                              the 10-day streak's reward (`streakDiscount`,
//                              set by the app with the day-10 chest) is
//                              waiting; it uses the reward up.
//  · gems_80 … gems_12000    — consumable gem packs ($0.99 80, $4.99 450,
//                              $9.99 950, $19.99 2000, $49.99 5500, $99.99
//                              12000; GEM_PACKS in squad.js). A pack's first
//                              purchase gives double (`gemFirst`).
//
//  · offer_*                — the Deals tab's offers (REDESIGN_V6 step 7):
//                              what each sells is Firestore config/offers
//                              (squad.js DEFAULT_OFFERS until it exists): a
//                              bundle's gems, coins and chests (rolled here,
//                              at once), the gem jar's gems, the season pass.
//                              The gem packs' amounts come from it too.
//
// Price levels: each product can also be sold at other prices, as its own
// store product named `<id>_<cents>` (creature_key_149 is a $1.49 key). The
// app picks the level from Firestore `config/pricing` (src/economy.js); any
// level grants the same as its base product.

const crypto = require('crypto');

const PACKAGE_NAME = 'com.plushcrush.app'; // Android application id
const BUNDLE_ID = 'com.plushcrush.app'; // iOS bundle identifier
const REMOVE_ADS = 'remove_ads';
const CREATURE_KEY = 'creature_key';
const CREATION = 'creature_creation';
const CREATION_DISCOUNTED = 'creature_creation_15off';
const CREATION_HALF = 'creature_creation_half';
const { GEM_PACKS, offersOf, openGroup, jarGems, lineup } = require('./squad');
const GEM_IDS = Object.keys(GEM_PACKS);
const PRODUCT_IDS = [REMOVE_ADS, CREATURE_KEY, CREATION, CREATION_DISCOUNTED, CREATION_HALF, ...GEM_IDS];
const CONSUMABLES = [CREATURE_KEY, CREATION, CREATION_DISCOUNTED, CREATION_HALF, ...GEM_IDS];

// A product id → its base product (one of PRODUCT_IDS), for the base id
// itself or any price level of it (`<base>_<cents>`); null for anything else.
// (creature_creation_15off and _half are tried before creature_creation.)
const LEVEL_RE = /^(gems_(?:80|450|950|2000|5500|12000)|remove_ads|creature_key|creature_creation_15off|creature_creation_half|creature_creation)(?:_([1-9]\d{0,5}))?$/;
// an offer's product: offer_ and words (each starting with a letter), then
// maybe a price level
const OFFER_RE = /^(offer_[a-z][a-z0-9]*(?:_[a-z][a-z0-9]*)*)(?:_([1-9]\d{0,5}))?$/;
function baseProduct(productId) {
  const id = String(productId || '');
  const m = LEVEL_RE.exec(id) || OFFER_RE.exec(id);
  return m ? m[1] : null;
}
// the enabled offer that sells `productId`, from config/offers
const offerFor = (productId, offers) => offersOf(offers).offers.find((o) => o.enabled !== false && o.product === baseProduct(productId)) || null;
const isConsumable = (productId, offers) => {
  const base = baseProduct(productId);
  if (CONSUMABLES.includes(base)) return true;
  const o = base && base.startsWith('offer_') ? offerFor(productId, offers) : null;
  return !!(o && o.consumable);
};

// Paid back, in coins (3 Mystery Boxes' worth), for a key bought for a
// creature that got unlocked another way in the meantime.
const KEY_REFUND_COINS = 1500;

const sha256 = (s) => crypto.createHash('sha256').update(String(s)).digest('hex');

// iOS purchases carry an `appAccountToken`, a UUID the app sets. It holds
// the player — the first 26 hex digits of sha256(uid), with the version and
// variant digits fixed — and, for a creature key, the creature's roster
// number in the last 6 (ffffff for none). The app builds the same thing
// (appAccountToken in src/billing/common.js); Apple signs it into the
// transaction, so the server can trust both halves. (On Android the same two
// facts ride in the purchase's obfuscated account and profile ids.)
function appAccountToken(uid, creatureId = null) {
  const h = sha256(uid);
  const tail = creatureId != null && /^\d+$/.test(String(creatureId)) ? Number(creatureId).toString(16).padStart(6, '0') : 'ffffff';
  const hex = h.slice(0, 12) + '4' + h.slice(13, 16) + '8' + h.slice(17, 26) + tail;
  return `${hex.slice(0, 8)}-${hex.slice(8, 12)}-${hex.slice(12, 16)}-${hex.slice(16, 20)}-${hex.slice(20, 32)}`;
}

// Whether a token belongs to `uid`, and the creature it names (or null).
function readAccountToken(token, uid) {
  const got = String(token || '').toLowerCase();
  const want = appAccountToken(uid);
  if (got.length !== want.length || got.slice(0, 30) !== want.slice(0, 30)) return { mine: false, creatureId: null };
  const tail = got.replace(/-/g, '').slice(26);
  return { mine: true, creatureId: tail === 'ffffff' ? null : String(parseInt(tail, 16)) };
}

// A Google Play ProductPurchase (purchases.products.get) → what it is.
function checkPlayPurchase(play, uid) {
  // purchaseState: 0 purchased, 1 cancelled, 2 pending
  if (play.purchaseState === 2) return { error: 'pending' };
  if (play.purchaseState !== 0) return { error: 'not_purchased' };
  // The app hashes the player's uid into the purchase, so a token can't be
  // redeemed on another account.
  if (play.obfuscatedExternalAccountId && play.obfuscatedExternalAccountId !== sha256(uid)) return { error: 'wrong_account' };
  return { creatureId: play.obfuscatedExternalProfileId || null, orderId: play.orderId || null, test: play.purchaseType === 0 };
}

// An App Store transaction, already verified and decoded
// (SignedDataVerifier.verifyAndDecodeTransaction) → what it is.
function checkAppleTransaction(tx, uid, productId) {
  if (tx.bundleId !== BUNDLE_ID) return { error: 'wrong_app' };
  if (tx.productId !== productId) return { error: 'wrong_product' };
  if (tx.revocationDate) return { error: 'refunded' };
  const who = readAccountToken(tx.appAccountToken, uid);
  if (!who.mine) return { error: 'wrong_account' };
  return { creatureId: who.creatureId, orderId: tx.transactionId || null, test: tx.environment !== 'Production' };
}

// What a checked purchase grants. `profile` is the users/{uid} doc,
// `rosterIds` the catalog's creature ids. Returns { error } or
// { update, result }: `update` describes the profile write in plain values
// (verifyPurchase.js turns them into Firestore increments/deletes),
// `result` goes back to the app.
// An offer's grant (config/offers): `set` holds the profile fields to write
// as they are (verifyPurchase writes them as given).
function offerGrant(offer, profile, offers, { artIds = [], hidden, setRewards, need, day, random } = {}) {
  const num = (n) => (typeof n === 'number' && Number.isFinite(n) ? n : 0);
  const bought = { ...(profile.offersBought || {}), [offer.id]: true };
  if (offer.kind === 'bundle') {
    const gems = num(offer.gems);
    const coins = num(offer.coins);
    let p = { ...profile, gems: num(profile.gems) + gems, coins: num(profile.coins) + coins, totalEarned: num(profile.totalEarned) + coins };
    let set = { gems: p.gems, coins: p.coins, totalEarned: p.totalEarned };
    const hot = lineup(day, hidden);
    const chests = (offer.chests || []).map((size, i) => {
      const o = openGroup(p, hot[i % hot.length], size, { artIds, random, setRewards, need });
      Object.entries(o.set).forEach(([k, v]) => {
        if (k.startsWith('col.')) p = { ...p, col: { ...(p.col || {}), [k.slice(4)]: v } };
        else p = { ...p, [k]: v };
      });
      set = { ...set, ...o.set };
      return o.result;
    });
    return { update: { set: { ...set, offersBought: bought } }, result: { granted: 'bundle', offer: offer.id, gems, coins, chests } };
  }
  if (offer.kind === 'jar') {
    const gems = jarGems(profile, offer);
    return { update: { set: { gems: num(profile.gems) + gems, jarBase: num(profile.totalEarned), offersBought: bought } }, result: { granted: 'gems', gems, offer: offer.id } };
  }
  if (offer.kind === 'pass') {
    const season = offersOf(offers).pass.season;
    return { update: { set: { passPrem: { ...(profile.passPrem || {}), [season]: true }, offersBought: bought } }, result: { granted: 'pass', season } };
  }
  return { error: 'unknown_product' };
}

function grantFor({ productId, creatureId, profile, rosterIds, offers = null, artIds = [], hidden, setRewards, need, day, random }) {
  const base = baseProduct(productId);
  if (!base) return { error: 'unknown_product' };

  if (base.startsWith('offer_')) {
    const offer = offerFor(productId, offers);
    if (!offer) return { error: 'unknown_product' };
    return offerGrant(offer, profile, offers, { artIds, hidden, setRewards, need, day, random });
  }

  if (GEM_PACKS[base]) {
    const first = !(profile.gemFirst || {})[base];
    // the amount config/offers gives the pack, else the product's own
    const pack = offersOf(offers).packs.find((x) => x.product === base);
    const gems = (pack ? pack.gems : GEM_PACKS[base]) * (first ? 2 : 1);
    return { update: { gems, gemFirst: first ? base : null }, result: { granted: 'gems', gems, doubled: first } };
  }

  if (base === REMOVE_ADS) return { update: { adsFree: true }, result: { granted: 'adsFree' } };

  if (base === CREATION || base === CREATION_DISCOUNTED || base === CREATION_HALF) {
    return {
      update: { credits: 1, paidCredits: 1, clearDiscount: base === CREATION_DISCOUNTED, clearStreakDiscount: base === CREATION_HALF },
      result: { granted: 'creation' },
    };
  }

  const id = creatureId;
  if (!id || !rosterIds.includes(id)) return { error: 'unknown_creature' };
  if ((profile.ownedIds || []).includes(id) || (profile.keys || {})[id] === true) {
    return { update: { coins: KEY_REFUND_COINS }, result: { granted: 'coins', coins: KEY_REFUND_COINS, creatureId: id } };
  }
  return { update: { keys: { [id]: true } }, result: { granted: 'key', creatureId: id } };
}

// One custom-creature generation spent from a profile (users/{uid} data):
// the fields to write, or null with no credit left. A missing
// generationCredits is the one free credit every profile starts with.
// `paidCredits` counts how many of generationCredits were bought; a bought
// one is spent first, so the app — which labels it PAID and puts no ad break
// after it — and the server agree on which was used.
function spendCredit(profile = {}) {
  const credits = typeof profile.generationCredits === 'number' ? profile.generationCredits : 1;
  if (credits <= 0) return null;
  const paid = typeof profile.paidCredits === 'number' ? Math.min(profile.paidCredits, credits) : 0;
  return paid > 0 ? { generationCredits: credits - 1, paidCredits: paid - 1 } : { generationCredits: credits - 1 };
}

module.exports = {
  PACKAGE_NAME,
  BUNDLE_ID,
  REMOVE_ADS,
  CREATURE_KEY,
  CREATION,
  CREATION_DISCOUNTED,
  CREATION_HALF,
  PRODUCT_IDS,
  CONSUMABLES,
  baseProduct,
  isConsumable,
  offerFor,
  KEY_REFUND_COINS,
  sha256,
  appAccountToken,
  readAccountToken,
  checkPlayPurchase,
  checkAppleTransaction,
  grantFor,
  spendCredit,
};
