// Achievement list shared between AchievementsScreen (renders it) and
// App.js (diffs it against the previous profile snapshot to fire a toast
// the moment one flips to done) — kept in one place so the two can't drift.
//
// The prototype also has a couple of achievements that only make sense as
// live SquishScreen events (60 taps in 60 seconds, watching a rewarded ad).
// Instrumenting those means editing SquishScreen, which is out of scope for
// this pass, so everything here is derived purely from the profile document
// (ownedIds, totalEarned) instead.

const CREATURE_ACHIEVEMENTS = {
  pebble: { title: 'Flipper Fanatic', desc: 'Unlock Pebble' },
  suki: { title: 'Purrfectly Squishy', desc: 'Unlock Suki' },
  glimmer: { title: 'Sparkle Squad', desc: 'Unlock Glimmer' },
  gouda: { title: 'Big Cheese', desc: 'Unlock Gouda' },
};

export function computeAchievements(creatures = [], ownedIds = [], totalEarned = 0) {
  const collectibles = creatures.filter((c) => (c.price ?? 0) > 0);

  const creatureEntries = collectibles.map((c) => {
    const copy = CREATURE_ACHIEVEMENTS[c.id] ?? { title: `Unlock ${c.name}`, desc: `Unlock ${c.name}` };
    return { key: c.id, done: ownedIds.includes(c.id), creature: c, ...copy };
  });

  const unlockAllDone = collectibles.length > 0 && collectibles.every((c) => ownedIds.includes(c.id));

  return [
    ...creatureEntries,
    { key: 'unlockAll', done: unlockAllDone, badgeLabel: 'ALL', title: 'Collector Supreme', desc: `Unlock all ${collectibles.length} creatures` },
    { key: 'earn10k', done: totalEarned >= 10000, badgeLabel: '10K', title: 'Pocket Change', desc: 'Earn 10,000 coins' },
    { key: 'earn100k', done: totalEarned >= 100000, badgeLabel: '100K', title: 'Squish Tycoon', desc: 'Earn 100,000 coins' },
  ];
}
