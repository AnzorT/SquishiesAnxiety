// Achievement list — matches "ASMR Creature Squash Game.html" exactly (10
// fixed achievements: five per-creature unlocks, two coin-earned totals, a
// full-collection badge — now the full 20-creature roster — and two live
// SquishScreen events). Shared by
// AchievementsScreen (renders it) and App.js (diffs it against the previous
// snapshot to fire a toast the moment one flips to done).
//
// unlock3..unlock7 / earn10k / earn100k / unlockAll are all derivable from
// the profile document (ownedIds, totalEarned) the same way the rest of the
// app is. speedTap (60 taps in 60s) and watchAd (watched a rewarded ad) are
// live SquishScreen events with no natural profile field to derive them
// from, so those two are tracked as an explicit `achievements` map on the
// profile (see src/firebase/firestore.js's markAchievement) and passed in
// here as `liveFlags`.

import { CREATURES } from './data/creatures';

const CREATURE_ACHIEVEMENTS = [
  { key: 'unlock3', creatureId: '3', title: 'Egg-cellent!' },
  { key: 'unlock4', creatureId: '4', title: 'Spiky Squish' },
  { key: 'unlock5', creatureId: '5', title: 'Star Struck' },
  { key: 'unlock6', creatureId: '6', title: 'Head in Clouds' },
  { key: 'unlock7', creatureId: '7', title: 'Noodle Master' },
];

export function computeAchievements(creatures = CREATURES, ownedIds = [], totalEarned = 0, liveFlags = {}) {
  const byId = new Map(creatures.map((c) => [c.id, c]));

  const creatureEntries = CREATURE_ACHIEVEMENTS.map(({ key, creatureId, title }) => {
    const creature = byId.get(creatureId);
    return {
      key,
      done: ownedIds.includes(creatureId),
      creature,
      title,
      desc: `Unlock ${creature ? creature.name : ''}`,
    };
  });

  const allCreatureIds = creatures.length ? creatures.map((c) => c.id) : CREATURES.map((c) => c.id);
  const unlockAllDone = allCreatureIds.every((id) => ownedIds.includes(id));

  return [
    ...creatureEntries,
    { key: 'earn10k', done: totalEarned >= 10000, badgeLabel: '10K', title: 'Pocket Change', desc: 'Earn 10,000 Squish Points' },
    { key: 'earn100k', done: totalEarned >= 100000, badgeLabel: '100K', title: 'Squish Tycoon', desc: 'Earn 100,000 Squish Points' },
    { key: 'unlockAll', done: unlockAllDone, badgeLabel: 'ALL', title: 'Collector Supreme', desc: 'Unlock all 20 creatures' },
    { key: 'speedTap', done: !!liveFlags.speedTap, badgeLabel: '60', title: 'Speed Squisher', desc: 'Tap 60 times in 60 seconds' },
    { key: 'watchAd', done: !!liveFlags.watchAd, badgeLabel: 'AD', title: 'Ad Enthusiast', desc: 'Watch a video ad' },
  ];
}
