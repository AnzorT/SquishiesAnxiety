import { tierOf } from './theme/candyTheme';
import { SPARE_BOX_COINS, pickTokenCreature, tokenAmount, tokenCandidates, tokenCount, tokenPrice } from './economy';
import { todayKey } from './dailySpin';

// Mystery Box rules (the v3 design's box, on the sticker economy in
// src/economy.js):
//  · every day the player gets DAILY_BOXES boxes for one rewarded video
//    each — free, without the video, with Remove Ads. They come back on the
//    next calendar day (the phone's date, like the Daily Spin). Once they're
//    used, a box costs BOX_PRICE coins, paid with the OPEN button;
//  · a box gives 1–3 tokens of one locked creature, picked by rarity (the
//    odds and prices: src/economy.js, tunable in Firestore); a full set puts
//    the creature's key on its card. The very first box ever fills Puffle's
//    set;
//  · once all 20 are owned, the next box is the Secret: "Prism Glorp".
//
// A box paid for (its video watched, or its coins) waits as `boxPending`
// until it's opened, even if the player leaves. Opening writes the pull in
// one go when the box bursts (openBox in firebase/firestore.js) — a write
// mid-tapping would stall the taps. The day's count is `boxDayOpens` for the
// day in `boxDay`; `boxOpens` counts every box ever opened.

export const BOX_PRICE = 500;
export const DAILY_BOXES = 2;
export const BOX_TAPS = 10;
export const SECRET = { id: '0', tier: 'Secret', name: 'Prism Glorp' };

// Daily boxes used today / still left today.
export function boxDailyUsed(profile, today = todayKey()) {
  return profile?.boxDay === today ? Math.min(DAILY_BOXES, profile?.boxDayOpens ?? 0) : 0;
}
export function boxDailyLeft(profile, today = todayKey()) {
  return DAILY_BOXES - boxDailyUsed(profile, today);
}

// The profile fields that use up one of today's boxes.
export function dailyBoxUse(profile, today = todayKey()) {
  return { boxDay: today, boxDayOpens: boxDailyUsed(profile, today) + 1 };
}

// 'ad' (a daily box, one video) | 'free' (a daily box with Remove Ads) |
// 'coins' (today's are used up), or 'paid' while a paid box waits.
export function boxPayMode(profile, today = todayKey()) {
  if (profile?.boxPending) return 'paid';
  if (boxDailyLeft(profile, today) > 0) return profile?.adsFree ? 'free' : 'ad';
  return 'coins';
}

export function boxPriceLabel(mode) {
  return mode === 'paid' ? 'READY' : mode === 'free' ? 'FREE' : mode === 'ad' ? 'VIDEO' : String(BOX_PRICE);
}

// "5h 12m" until today's boxes come back (local midnight).
export function untilNewBoxes(now = new Date()) {
  const midnight = new Date(now.getFullYear(), now.getMonth(), now.getDate() + 1);
  const mins = Math.max(1, Math.ceil((midnight - now) / 60000));
  const h = Math.floor(mins / 60);
  return h ? `${h}h ${mins % 60}m` : `${mins}m`;
}

// Only the numbered roster creatures (ids '0'–'19') are in the box.
export function boxRoster(creatures = []) {
  return creatures.filter((c) => tierOf(c.id));
}

export function ownedCount(creatures, ownedIds = []) {
  return boxRoster(creatures).filter((c) => ownedIds.includes(c.id)).length;
}

// One pull. `random` is injectable for tests.
//   kind 'secret' — Prism Glorp, once everything is owned
//   kind 'tokens' — `amount` of creature `id`'s tokens; `have`/`need` after
//                   it, `complete` when that fills its set (its key is ready)
//   kind 'coins'  — `amount` coins, when there's no locked creature left to
//                   give tokens for (only keyed ones waiting on Home)
export function rollBox(creatures, profile, random = Math.random) {
  const roster = boxRoster(creatures);
  const ownedIds = profile?.ownedIds ?? [];
  if (roster.length && roster.every((c) => ownedIds.includes(c.id)) && !profile?.secretFound) {
    return { ...SECRET, kind: 'secret' };
  }
  const candidates = tokenCandidates(roster, profile);
  if (!candidates.length) return { kind: 'coins', tier: 'Common', amount: SPARE_BOX_COINS };
  const first = (profile?.boxOpens ?? 0) === 0;
  const c = first ? candidates[0] : pickTokenCreature(candidates, random);
  const need = tokenPrice(c.id);
  const before = tokenCount(profile, c.id);
  const amount = first ? need - before : tokenAmount(need - before, random);
  return { kind: 'tokens', id: c.id, name: c.name, tier: tierOf(c.id), amount, have: before + amount, need, complete: before + amount >= need };
}

// Can the player squish what came out of the box right away?
export function pullIsPlayable(pull) {
  return !!pull && pull.kind === 'secret';
}
