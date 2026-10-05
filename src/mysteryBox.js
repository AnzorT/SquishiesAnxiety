import { tierOf } from './theme/candyTheme';
import { boxSettings, pickTokenCreature, tokenAmount, tokenCandidates, tokenCount, tokenPrice } from './economy';
import { todayKey } from './dailySpin';

// Mystery Box rules (the v3 design's box, on the sticker economy in
// src/economy.js):
//  · every day the player gets dailyBoxes() boxes for one rewarded video
//    each — free, without the video, with Remove Ads. They come back on the
//    next calendar day (the phone's date, like the Daily Spin). Once they're
//    used, a box costs boxPrice() coins, paid with the OPEN button. Both
//    numbers come from config/mysteryBox (src/economy.js);
//  · a box gives 1–3 tokens of one locked creature, picked by rarity (the
//    odds and prices: src/economy.js, tunable in Firestore); a full set puts
//    the creature's key on its card. The very first box ever fills #1
//    Mittens' set;
//  · once every roster creature is owned, the next box is the Secret: "Prism
//    Nimbo" (the design's rainbow version of creature #0).
//
// A box paid for (its video watched, or its coins) waits as `boxPending`
// until it's opened, even if the player leaves. Opening writes the pull in
// one go when the box bursts (openBox in firebase/firestore.js) — a write
// mid-tapping would stall the taps. The day's count is `boxDayOpens` for the
// day in `boxDay`; `boxOpens` counts every box ever opened.

// The box's prices, from config/mysteryBox (defaults 500 coins, 2 a day).
export const boxPrice = () => boxSettings().boxPrice;
export const dailyBoxes = () => boxSettings().dailyBoxes;
export const BOX_TAPS = 10;
export const SECRET = { id: '0', tier: 'Secret', name: 'Prism Nimbo' };

// Daily boxes used today / still left today.
export function boxDailyUsed(profile, today = todayKey()) {
  return profile?.boxDay === today ? Math.min(dailyBoxes(), profile?.boxDayOpens ?? 0) : 0;
}
export function boxDailyLeft(profile, today = todayKey()) {
  return dailyBoxes() - boxDailyUsed(profile, today);
}

// The profile fields that use up one of today's boxes.
export function dailyBoxUse(profile, today = todayKey()) {
  return { boxDay: today, boxDayOpens: boxDailyUsed(profile, today) + 1 };
}

// 'ad' (a daily box, one video) | 'free' (a daily box with Remove Ads) |
// 'coins' (today's are used up), or 'paid' while a paid box waits.
//
// The tutorial (src/tutorial/steps.js) bends this twice, as the design does:
// the very first box ever is free — no video in the first minute of play —
// and the tutorial's second box is paid with the coins its goal step just
// earned, whatever the day's boxes say.
export function boxPayMode(profile, today = todayKey()) {
  if (profile?.boxPending) return 'paid';
  if ((profile?.boxOpens ?? 0) === 0) return 'free';
  if (profile?.tut === 'box2tap') return 'coins';
  if (boxDailyLeft(profile, today) > 0) return profile?.adsFree ? 'free' : 'ad';
  return 'coins';
}

export function boxPriceLabel(mode) {
  return mode === 'paid' ? 'READY' : mode === 'free' ? 'FREE' : mode === 'ad' ? 'VIDEO' : String(boxPrice());
}

// "5h 12m" until today's boxes come back (local midnight).
export function untilNewBoxes(now = new Date()) {
  const midnight = new Date(now.getFullYear(), now.getMonth(), now.getDate() + 1);
  const mins = Math.max(1, Math.ceil((midnight - now) / 60000));
  const h = Math.floor(mins / 60);
  return h ? `${h}h ${mins % 60}m` : `${mins}m`;
}

// Only the numbered roster creatures (ids '0'–'29') are in the box.
export function boxRoster(creatures = []) {
  return creatures.filter((c) => tierOf(c.id));
}

export function ownedCount(creatures, ownedIds = []) {
  return boxRoster(creatures).filter((c) => ownedIds.includes(c.id)).length;
}

// One pull. `random` is injectable for tests.
//   kind 'secret' — Prism Nimbo, once everything is owned
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
  if (!candidates.length) return { kind: 'coins', tier: 'Common', amount: boxSettings().spareBoxCoins };
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

// DOUBLE IT: after a box, a rewarded video (none with Remove Ads) doubles
// what came out — the same tokens again (up to the creature's full set) or
// the coins again. MAX_DOUBLES a day, counted in `boxDoubles: { day, n }`.
// The Secret and a set that's already full have nothing to double.
export const MAX_DOUBLES = 5;
export function doublesLeft(profile, today = todayKey()) {
  const d = profile?.boxDoubles;
  const used = d && d.day === today ? Math.max(0, Math.floor(d.n || 0)) : 0;
  return Math.max(0, MAX_DOUBLES - used);
}
export const canDouble = (pull) => !!pull && !pull.doubled && (pull.kind === 'coins' || (pull.kind === 'tokens' && !pull.complete));

// The pull doubled: { pull } to show (amount, have, complete updated) and
// the profile fields to write besides the day's count, or null.
export function doublePull(pull) {
  if (!canDouble(pull)) return null;
  if (pull.kind === 'coins') return { pull: { ...pull, amount: pull.amount * 2, doubled: true }, coins: pull.amount };
  const extra = Math.min(pull.amount, pull.need - pull.have);
  const have = pull.have + extra;
  return { pull: { ...pull, amount: pull.amount + extra, have, complete: have >= pull.need, doubled: true }, tokens: extra };
}
