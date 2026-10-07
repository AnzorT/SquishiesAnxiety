// The squad economy's moves, run by the `squad` Cloud Function
// (functions/index.js, rules in functions/squad.js). Each resolves the
// move's result, or rejects with the rule's error code ('not_enough_gems',
// 'no_chest' …) as the message. The profile listener picks up the writes.
import callFunction from '../firebase/callFunction';
import { tzOffsetMinutes } from '../dailySpin';

async function move(name, args = {}) {
  const res = await callFunction('squad', { move: name, ...args, tzOffsetMinutes: tzOffsetMinutes() });
  if (res && res.error) throw new Error(res.error);
  return res;
}

export const startSquad = () => move('start');
// the daily chest's gift: Stars, and the streak day's reward ({ kind: 'stars', amount } | { kind: 'chest' })
export const dailyGift = (reward) => move('dailyGift', { reward });
export const buyChest = (tier) => move('buyChest', { tier });
export const buyDeal = () => move('buyChest', { deal: true });
export const videoChest = () => move('videoChest');
// → { id, rar, f, isNew, newFinish, stars, reward, tier }
export const openChest = (tier) => move('openChest', { tier });
export const buyCreature = (id, cur) => move('buyCreature', { id, cur });
export const growCreature = (id) => move('grow', { id });
export const buyFinish = (id, f) => move('buyFinish', { id, f });
export const equipFinish = (id, f) => move('equip', { id, f });
export const swapGems = (i) => move('swap', { i });
