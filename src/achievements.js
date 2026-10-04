// The 50 achievements of the v3 design ("ASMR Creature Squash v3.dc.html",
// ACHIEVEMENTS), in its order and words. Shared by AchievementsScreen
// (renders it) and App.js (diffs it against the previous snapshot to fire a
// toast the moment one flips to done).
//
// Every entry is derived from the player's profile document:
//   ownedIds, totalEarned, stats.{presses, longestHoldMs, playTime},
//   adsWatched / maxMult (recordAdWatched), the custom creature count, and
//   the `achievements` flags for the two live SquishScreen events that have
//   no counter (speedTap: 60 taps in 60s; watchAd: first rewarded ad).
// The Mystery Box ones read boxOpens / tierPulls / secretFound (written by
// openBox), the Daily Spin ones spins / wheelJackpot (written by the
// spinWheel Cloud Function).

const A = (key, title, desc, look, value, max = 1) => ({ key, title, desc, ...look, value, max });
const creature = (id) => ({ creatureId: String(id) });
const badge = (label) => ({ badgeLabel: label });

export function computeAchievements(creatures = [], profile = {}, customCount = 0) {
  const owned = new Set(profile.ownedIds ?? []);
  const byId = new Map(creatures.map((c) => [String(c.id), c]));
  const stats = profile.stats ?? {};
  const flags = profile.achievements ?? {};

  const has = (id) => (owned.has(String(id)) ? 1 : 0);
  const nameOf = (id, fallback) => byId.get(String(id))?.name ?? fallback;
  const total = creatures.length || 20;
  const ownedCount = creatures.length ? creatures.filter((c) => owned.has(String(c.id))).length : owned.size;
  const earned = profile.totalEarned ?? 0;
  const presses = stats.presses ?? 0;
  const holdS = Math.floor((stats.longestHoldMs ?? 0) / 1000);
  const played = Object.values(stats.playTime ?? {}).filter((ms) => ms > 0).length;
  const ads = Math.max(profile.adsWatched ?? 0, flags.watchAd ? 1 : 0);
  const boxes = profile.boxOpens ?? 0;
  const pulls = profile.tierPulls ?? {};
  const spins = profile.spins ?? 0;

  const list = [
    A('unlock3', 'Egg-cellent!', `Unlock ${nameOf(3, 'Dotty')}`, creature(3), has(3)),
    A('unlock4', 'Spiky Squish', `Unlock ${nameOf(4, 'Spike')}`, creature(4), has(4)),
    A('unlock5', 'Star Struck', `Unlock ${nameOf(5, 'Stellie')}`, creature(5), has(5)),
    A('unlock6', 'Head in Clouds', `Unlock ${nameOf(6, 'Puffington')}`, creature(6), has(6)),
    A('unlock7', 'Noodle Master', `Unlock ${nameOf(7, 'Noodle')}`, creature(7), has(7)),
    A('earn10k', 'Pocket Change', 'Earn 10,000 Squish Points', badge('10K'), earned, 10000),
    A('earn100k', 'Squish Tycoon', 'Earn 100,000 Squish Points', badge('100K'), earned, 100000),
    A('unlockAll', 'Collector Supreme', `Unlock all ${total} creatures`, badge('ALL'), ownedCount, total),
    A('speedTap', 'Speed Squisher', 'Tap 60 times in 60 seconds', badge('60'), flags.speedTap ? 1 : 0),
    A('watchAd', 'Ad Enthusiast', 'Watch a video ad', badge('AD'), ads),
    A('press1', 'First Squish', 'Squish any creature once', badge('1'), presses),
    A('press10', 'Warming Up', 'Squish 10 times', badge('10'), presses, 10),
    A('press50', 'Squishy Fingers', 'Squish 50 times', badge('50'), presses, 50),
    A('press100', 'Century Squeeze', 'Squish 100 times', badge('100'), presses, 100),
    A('press250', 'Jelly Juggler', 'Squish 250 times', badge('250'), presses, 250),
    A('press500', 'Squish Machine', 'Squish 500 times', badge('500'), presses, 500),
    A('press1000', 'Thousand Hugs', 'Squish 1,000 times', badge('1K'), presses, 1000),
    A('press5000', 'Squish Legend', 'Squish 5,000 times', badge('5K'), presses, 5000),
    A('hold3', 'Big Hug', 'Hold a squish for 3 seconds', badge('3s'), holdS, 3),
    A('hold10', 'Bear Hug', 'Hold a squish for 10 seconds', badge('10s'), holdS, 10),
    A('hold30', 'Never Let Go', 'Hold a squish for 30 seconds', badge('30s'), holdS, 30),
    A('earn1k', 'Coin Sprout', 'Earn 1,000 coins in total', badge('1K'), earned, 1000),
    A('earn50k', 'Gold Rush', 'Earn 50,000 coins in total', badge('50K'), earned, 50000),
    A('earn250k', 'Coin Mountain', 'Earn 250,000 coins in total', badge('250K'), earned, 250000),
    A('own5', 'Squad of Five', 'Own 5 creatures', badge('×5'), ownedCount, 5),
    A('own10', 'Double Digits', 'Own 10 creatures', badge('×10'), ownedCount, 10),
    A('own15', 'Almost There', 'Own 15 creatures', badge('×15'), ownedCount, 15),
    A('own16', 'Legend Found', 'Unlock creature #17', creature(16), has(16)),
    A('own17', 'Twin Legends', 'Unlock creature #18', creature(17), has(17)),
    A('own18', 'Over the Rainbow', 'Unlock the Rainbow creature', creature(18), has(18)),
    A('own19', 'Golden Touch', 'Unlock the Golden creature', creature(19), has(19)),
    A('box1', 'Peek Inside', 'Open your first mystery box', badge('BOX'), boxes),
    A('box5', 'Box Fan', 'Open 5 mystery boxes', badge('5'), boxes, 5),
    A('box10', 'Unboxing Pro', 'Open 10 mystery boxes', badge('10'), boxes, 10),
    A('box25', 'Box Hoarder', 'Open 25 mystery boxes', badge('25'), boxes, 25),
    A('box50', 'Mystery Master', 'Open 50 mystery boxes', badge('50'), boxes, 50),
    A('pullEpic', 'Epic Luck', 'Pull an Epic from a box', badge('EPIC'), pulls.Epic ?? 0),
    A('pullLegendary', 'Legendary Pull', 'Pull a Legendary from a box', badge('LEG'), pulls.Legendary ?? 0),
    A('pullRainbow', 'Rainbow Pull', 'Pull a Rainbow from a box', badge('RBW'), pulls.Rainbow ?? 0),
    A('pullGolden', 'Pure Gold', 'Pull a Golden from a box', badge('GLD'), pulls.Golden ?? 0),
    A('secret', 'Secret Keeper', 'Find the Secret creature', badge('?'), profile.secretFound ? 1 : 0),
    A('spin1', 'Lucky Spin', 'Spin the daily wheel', badge('SPIN'), spins),
    A('spin7', 'Week of Spins', 'Spin the wheel 7 times', badge('7'), spins, 7),
    A('jackpot', 'Jackpot!', 'Win a free creature or 15% off a creation on the wheel', badge('★'), profile.wheelJackpot ? 1 : 0),
    A('ads5', 'Movie Night', 'Watch 5 video ads', badge('▶5'), ads, 5),
    A('boost4', 'Max Boost', 'Activate a ×4 coin boost', badge('×4'), (profile.maxMult ?? 0) >= 4 ? 1 : 0),
    A('custom1', 'Creator', 'Create your own squishy', badge('NEW'), customCount),
    A('custom3', 'Toy Designer', 'Create 3 custom squishies', badge('×3'), customCount, 3),
    A('play5', 'Friendly Squisher', 'Play with 5 different creatures', badge('5♥'), played, 5),
    A('play10', 'Best Friends', 'Play with 10 different creatures', badge('10♥'), played, 10),
  ];

  return list.map(({ creatureId, value, max, ...rest }) => {
    const done = value >= max;
    return {
      ...rest,
      done,
      creature: creatureId ? byId.get(creatureId) : undefined,
      creatureId,
      // the design shows a progress bar only for multi-step goals not yet done
      progress: !done && max > 1 ? { cur: Math.min(max, value), max } : null,
    };
  });
}
