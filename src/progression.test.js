// Checks of the progression rules (src/progression.js): the day's
// challenges, their progress, claims, the chest, the streak and the level.
//
//   node --experimental-vm-modules src/progression.test.js
// (plain Node: the module imports nothing from React Native)

import assert from 'node:assert/strict';
import { challengesFor, dailyRows, bumpDaily, claimDaily, claimChest, streakOf, streakMultiplier, streakTrack, streakReward, dailyView, dailyUnlocked, cribUnlocked, level, DAILY_LEVEL, CHEST_COINS } from './progression.js';

const DAY = '2026-10-03';
const YESTERDAY = '2026-10-02';

// the same six every time, 3 game + 3 crib, each at one of its goal sizes
const a = challengesFor(DAY);
const b = challengesFor(DAY);
assert.deepEqual(a, b);
assert.equal(a.length, 6);
assert.deepEqual(a.map((c) => c.side), ['game', 'game', 'game', 'crib', 'crib', 'crib']);
assert.notDeepEqual(challengesFor('2026-10-04'), a, 'another day picks another set');

// a fresh profile: nothing done
let profile = { coins: 0 };
let rows = dailyRows(profile, DAY);
assert.ok(rows.every((r) => r.prog === 0 && r.open && !r.claimable && !r.claimed));

// squishing fills the squish challenge; completing it reports the title once
const squish = a.find((c) => c.ev === 'squish');
let r = bumpDaily(profile, 'squish', squish.goal - 1, DAY);
profile = { ...profile, ...r.update };
assert.deepEqual(r.completed, []);
r = bumpDaily(profile, 'squish', 1, DAY);
profile = { ...profile, ...r.update };
assert.deepEqual(r.completed, [dailyRows(profile, DAY).find((x) => x.ev === 'squish').title]);
assert.ok(dailyRows(profile, DAY).find((x) => x.ev === 'squish').claimable);

// claiming pays the reward once
const c = claimDaily(profile, squish.id, DAY);
assert.equal(c.coins, 60);
profile = { ...profile, ...c.update };
assert.equal(claimDaily(profile, squish.id, DAY), null, 'no double claim');
assert.ok(dailyRows(profile, DAY).find((x) => x.ev === 'squish').claimed);

// the chest waits for all six
assert.equal(claimChest(profile, DAY), null);
for (const ch of a) {
  r = bumpDaily(profile, ch.ev, ch.goal, DAY);
  profile = { ...profile, ...r.update };
  const cl = claimDaily(profile, ch.id, DAY);
  if (cl) profile = { ...profile, ...cl.update };
}
assert.equal(dailyView(profile, new Date(`${DAY}T10:00:00`)).chestReady, true);

// the chest: coins, streak 1, no level yet (level < 3)
let chest = claimChest(profile, DAY);
assert.equal(chest.coins, CHEST_COINS);
profile = { ...profile, ...chest.update };
assert.equal(profile.streak, 1);
assert.equal(profile.lastFull, DAY);
assert.equal(profile.level, undefined, 'no level a day before DAILY_LEVEL');
assert.equal(claimChest(profile, DAY), null, 'once a day');
assert.equal(streakOf(profile, new Date(`${DAY}T20:00:00`)), 1);
assert.equal(streakMultiplier(profile, new Date(`${DAY}T20:00:00`)), 1.05);

// yesterday's chest keeps the streak alive today; the day before breaks it
assert.equal(streakOf({ streak: 4, lastFull: YESTERDAY }, new Date(`${DAY}T09:00:00`)), 4);
assert.equal(streakOf({ streak: 4, lastFull: '2026-10-01' }, new Date(`${DAY}T09:00:00`)), 0);

// a new day starts the challenges over, and the chest on it extends the streak and the level (from level 3)
const NEXT = '2026-10-04';
profile = { ...profile, level: DAILY_LEVEL };
assert.ok(dailyRows(profile, NEXT).every((x) => x.prog === 0 && !x.claimed));
for (const ch of challengesFor(NEXT)) {
  profile = { ...profile, ...bumpDaily(profile, ch.ev, ch.goal, NEXT).update };
  profile = { ...profile, ...claimDaily(profile, ch.id, NEXT).update };
}
chest = claimChest(profile, NEXT);
profile = { ...profile, ...chest.update };
assert.equal(profile.streak, 2);
assert.equal(profile.level, DAILY_LEVEL + 1);
assert.equal(profile.levelDay, NEXT);
assert.equal(level(profile), DAILY_LEVEL + 1);

// a missed day: the streak starts over at 1
profile = { ...profile, lastFull: '2026-10-01', streak: 9 };
for (const ch of challengesFor('2026-10-05')) {
  profile = { ...profile, ...bumpDaily(profile, ch.ev, ch.goal, '2026-10-05').update };
  profile = { ...profile, ...claimDaily(profile, ch.id, '2026-10-05').update };
}
profile = { ...profile, ...claimChest(profile, '2026-10-05').update };
assert.equal(profile.streak, 1);

// the chest pays its streak day's reward; day 10 is half price on a creation
assert.deepEqual(chest.reward, streakReward(2));
assert.equal(streakReward(1).kind, 'coins');
assert.equal(streakReward(10).kind, 'half');
assert.equal(streakReward(11), streakReward(1), 'the track starts over after day 10');
assert.equal(profile.bestStreak, 2, 'a broken streak keeps the best one');

// the track: today's chest pays day streak+1 until it's opened
const morning = new Date(`${DAY}T09:00:00`);
let t = streakTrack({ streak: 3, lastFull: YESTERDAY }, morning);
assert.equal(t.length, 10);
assert.deepEqual(t.filter((d) => d.done).map((d) => d.n), [1, 2, 3]);
assert.equal(t.find((d) => d.today).n, 4);
t = streakTrack({ streak: 4, lastFull: DAY }, morning);
assert.deepEqual(t.filter((d) => d.done).map((d) => d.n), [1, 2, 3, 4]);
assert.equal(t.find((d) => d.today).n, 4);
t = streakTrack({ streak: 10, lastFull: YESTERDAY }, morning);
assert.equal(t[0].n, 11, 'day 11 starts the next ten');
assert.equal(t[0].today, true);
assert.deepEqual(streakTrack({}, morning).map((d) => d.done), Array(10).fill(false));
// the coin bonus stops growing after ten days
assert.equal(streakMultiplier({ streak: 14, lastFull: DAY }, morning), 1.5);

// the gates: the Crib from level 2, Daily Challenges from level 3 once the
// tutorial has shown them
assert.equal(cribUnlocked({ level: 1 }), false);
assert.equal(cribUnlocked({ level: 2 }), true);
assert.equal(dailyUnlocked({ level: 3, tut: 'done' }), true);
assert.equal(dailyUnlocked({ level: 3 }), true);
assert.equal(dailyUnlocked({ level: 3, tut: 'box1' }), false, 'a replay hides them again');
assert.equal(dailyUnlocked({ level: 3, tut: 'c_daily' }), true);
assert.equal(dailyUnlocked({ level: 2, tut: 'done' }), false);

console.log('progression: all checks passed');
