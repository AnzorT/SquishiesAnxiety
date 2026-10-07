// The 50 achievements of the v3 design ("ASMR Creature Squash v3.dc.html",
// ACHIEVEMENTS), in its order and words, then the newer ones below. Shared by AchievementsScreen
// (renders it) and App.js (diffs it against the previous snapshot to fire a
// toast the moment one flips to done).
//
// Every entry is derived from the player's profile document:
//   ownedIds, totalEarned, stats.{presses, longestHoldMs, playTime},
//   adsWatched / maxMult (recordAdWatched), the custom creature count, and
//   the `achievements` flags for the two live SquishScreen events that have
//   no counter (speedTap: 60 taps in 60s; watchAd: first rewarded ad).
// The chest ones read chestOpens / tierPulls (written by the `squad` Cloud
// Function as chests open; the old Mystery Box's boxOpens still count), the
// finish, set and growth ones the collection (`col`), the Daily Spin ones
// spins / wheelJackpot (written by the spinWheel Cloud Function).
//
// Since the 2026-10-03 drop there are more, for what the game has now: the
// level (up to 100 — a level a day once Daily Challenges open, see
// src/progression.js), the daily streak (bestStreak) and chests opened
// (chests), and the Crib: care given (cribCare, counted with the Crib's
// daily-challenge events), furniture bought (cribBuys) and how many friends
// live there (cribSize).

import { creaturesOfTier } from './theme/candyTheme';
import { SETS, setInfo } from './squad/data';

const A =(key, title, desc, look, value, max = 1) => ({ key, title, desc, ...look, value, max });
const creature = (id) => ({ creatureId: String(id) });
const badge = (label) => ({ badgeLabel: label });

export function computeAchievements(creatures = [], profile = {}, customCount = 0) {
  const owned = new Set(profile.ownedIds ?? []);
  const byId = new Map(creatures.map((c) => [String(c.id), c]));
  const stats = profile.stats ?? {};
  const flags = profile.achievements ?? {};

  const has = (id) => (owned.has(String(id)) ? 1 : 0);
  const nameOf = (id, fallback) => byId.get(String(id))?.name ?? fallback;
  const total = creatures.length || 30;
  const ownedCount = creatures.length ? creatures.filter((c) => owned.has(String(c.id))).length : owned.size;
  // The rarity ones go by tier, not by a fixed id: the design wrote "creature
  // #17/#18", the Rainbow and the Golden one for its 20-creature roster, and
  // the 30-creature roster spreads the tiers differently (tierOf). The badge
  // shows the first creature of that tier (the only one, for Rainbow/Golden).
  const ofTier = (tier) => creaturesOfTier(creatures, tier);
  const ownedOfTier = (tier) => ofTier(tier).filter((c) => owned.has(String(c.id))).length;
  const firstOfTier = (tier, fallbackId) => creature(ofTier(tier)[0]?.id ?? fallbackId);
  const earned = profile.totalEarned ?? 0;
  const presses = stats.presses ?? 0;
  const holdS = Math.floor((stats.longestHoldMs ?? 0) / 1000);
  const played = Object.values(stats.playTime ?? {}).filter((ms) => ms > 0).length;
  const ads = Math.max(profile.adsWatched ?? 0, flags.watchAd ? 1 : 0);
  const boxes = (profile.chestOpens ?? 0) + (profile.boxOpens ?? 0);
  const pulls = profile.tierPulls ?? {};
  const spins = profile.spins ?? 0;
  const lv = Math.max(1, Math.floor(profile.level ?? 1));
  const bestStreak = Math.max(profile.bestStreak ?? 0, profile.streak ?? 0);
  const chests = profile.chests ?? 0;
  const care = profile.cribCare ?? 0;
  const buys = profile.cribBuys ?? 0;
  const cribSize = profile.cribSize ?? 0;
  const col = Object.values(profile.col ?? {});
  const finishes = (k) => col.filter((e) => e.f && e.f[k]).length;
  const grown = col.filter((e) => (e.st ?? 0) >= 1).length;
  const bestFriends = col.filter((e) => e.st === 2).length;
  const setsDone = SETS.filter((k) => setInfo(profile, k).done).length;

  const list = [
    A('unlock3', 'Bun Appétit', `Unlock ${nameOf(3, 'Bao')}`, creature(3), has(3)),
    A('unlock4', 'Sweet Tooth', `Unlock ${nameOf(4, 'Dunkie')}`, creature(4), has(4)),
    A('unlock5', 'Hot & Crispy', `Unlock ${nameOf(5, 'Frybo')}`, creature(5), has(5)),
    A('unlock6', 'Waddle Squad', `Unlock ${nameOf(6, 'Pip')}`, creature(6), has(6)),
    A('unlock7', 'Stacked!', `Unlock ${nameOf(7, 'Bunbun')}`, creature(7), has(7)),
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
    A('own16', 'Legend Found', 'Unlock a Legendary creature', firstOfTier('Legendary', 24), ownedOfTier('Legendary')),
    A('own17', 'Twin Legends', 'Unlock 2 Legendary creatures', firstOfTier('Legendary', 24), ownedOfTier('Legendary'), 2),
    A('own18', 'Over the Rainbow', 'Get a Rainbow squishy', badge('RBW'), finishes('r')),
    A('own19', 'Golden Touch', 'Get a Golden squishy', badge('GLD'), finishes('g')),
    A('box1', 'Peek Inside', 'Open your first chest', badge('BOX'), boxes),
    A('box5', 'Box Fan', 'Open 5 chests', badge('5'), boxes, 5),
    A('box10', 'Unboxing Pro', 'Open 10 chests', badge('10'), boxes, 10),
    A('box25', 'Box Hoarder', 'Open 25 chests', badge('25'), boxes, 25),
    A('box50', 'Mystery Master', 'Open 50 chests', badge('50'), boxes, 50),
    A('pullEpic', 'Epic Luck', 'Pull an Epic from a chest', badge('EPIC'), pulls.Epic ?? 0),
    A('pullLegendary', 'Legendary Pull', 'Pull a Legendary from a chest', badge('LEG'), pulls.Legendary ?? 0),
    A('pullRainbow', 'Rainbow Pull', 'Pull a Rainbow finish from a chest', badge('RBW'), pulls.Rainbow ?? 0),
    A('pullGolden', 'Pure Gold', 'Pull a Golden finish from a chest', badge('GLD'), pulls.Golden ?? 0),
    A('secret', 'Set Collector', 'Complete a set', badge('SET'), setsDone),
    A('spin1', 'Lucky Spin', 'Spin the daily wheel', badge('SPIN'), spins),
    A('spin7', 'Week of Spins', 'Spin the wheel 7 times', badge('7'), spins, 7),
    A('jackpot', 'Jackpot!', 'Win a free creature or 15% off a creation on the wheel', badge('★'), profile.wheelJackpot ? 1 : 0),
    A('ads5', 'Movie Night', 'Watch 5 video ads', badge('▶5'), ads, 5),
    A('boost4', 'Max Boost', 'Activate a ×4 coin boost', badge('×4'), (profile.maxMult ?? 0) >= 4 ? 1 : 0),
    A('custom1', 'Creator', 'Create your own squishy', badge('NEW'), customCount),
    A('custom3', 'Toy Designer', 'Create 3 custom squishies', badge('×3'), customCount, 3),
    A('play5', 'Friendly Squisher', 'Play with 5 different creatures', badge('5♥'), played, 5),
    A('play10', 'Best Friends', 'Play with 10 different creatures', badge('10♥'), played, 10),
    // levels: 2 and 3 come with the tutorial, then one a day from the chest
    A('lv3', 'Challenger', 'Reach level 3 and unlock Daily Challenges', badge('LV3'), lv, 3),
    A('lv5', 'Rising Star', 'Reach level 5', badge('LV5'), lv, 5),
    A('lv10', 'Squish Regular', 'Reach level 10', badge('10'), lv, 10),
    A('lv25', 'Dedicated Squisher', 'Reach level 25', badge('25'), lv, 25),
    A('lv50', 'Half Way There', 'Reach level 50', badge('50'), lv, 50),
    A('lv75', 'Squish Veteran', 'Reach level 75', badge('75'), lv, 75),
    A('lv100', 'Squish Centurion', 'Reach level 100 with the Daily Challenges', badge('100'), lv, 100),
    // the daily chest and the streak
    A('chest1', 'Treasure Hunter', 'Open your first daily chest', badge('CHEST'), chests),
    A('chest30', 'Chest Collector', 'Open 30 daily chests', badge('×30'), chests, 30),
    A('streak3', 'On a Roll', 'Keep a 3-day streak', badge('3🔥'), bestStreak, 3),
    A('streak7', 'Week Warrior', 'Keep a 7-day streak', badge('7🔥'), bestStreak, 7),
    A('streak10', 'Half Price Hero', 'Reach day 10 of a streak', badge('10🔥'), bestStreak, 10),
    A('streak30', 'Unstoppable', 'Keep a 30-day streak', badge('30🔥'), bestStreak, 30),
    // the Crib
    A('care1', 'Caretaker', 'Send a friend to a bath, snack, nap or play in the Crib', badge('♥'), care),
    A('care50', 'Super Sitter', 'Take care of your Crib friends 50 times', badge('50♥'), care, 50),
    A('care250', 'Crib Parent', 'Take care of your Crib friends 250 times', badge('250'), care, 250),
    A('buy1', 'First Makeover', 'Buy something for the Crib', badge('NEW'), buys),
    A('buy10', 'Home Decorator', 'Buy 10 things for the Crib', badge('×10'), buys, 10),
    A('buy30', 'Dream House', 'Buy 30 things for the Crib', badge('×30'), buys, 30),
    A('crib10', 'Full House', 'Have 10 friends living in the Crib', badge('10'), cribSize, 10),
    // the box's DOUBLE IT
    A('double1', 'Growing Up', 'Grow a squishy to Grown', badge('UP'), grown),
    A('double25', 'Best Friends', 'Make a squishy your Best Friend', badge('BFF'), bestFriends),
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
