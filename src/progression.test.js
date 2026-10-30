// Checks of the progression rules (src/progression.js): the day's
// challenges, their progress, claims, the chest, the streak and the level.
//
//   node --experimental-vm-modules src/progression.test.js
// (plain Node: the module imports nothing from React Native)

import assert from 'node:assert/strict';
import { challengesFor, dailyRows, bumpDaily, claimDaily, claimChest, streakOf, streakMultiplier, streakTrack, streakReward, dailyView, dailyUnlocked, cribUnlocked, level, DAILY_LEVEL, CHEST_COINS, CHEST_XP, CHALLENGE_XP, SQUISH_XP, SQUISH_XP_DAY } from './progression.js';

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

// the chest: coins, XP, streak 1 — and no level of its own any more (PLAYER_XP.md)
let chest = claimChest(profile, DAY);
assert.equal(chest.coins, CHEST_COINS);
assert.equal(chest.xp, CHEST_XP);
assert.equal('level' in chest.update, false);
profile = { ...profile, ...chest.update };
assert.equal(profile.streak, 1);
assert.equal(profile.lastFull, DAY);
assert.equal(claimChest(profile, DAY), null, 'once a day');
assert.equal(streakOf(profile, new Date(`${DAY}T20:00:00`)), 1);
assert.equal(streakMultiplier(profile, new Date(`${DAY}T20:00:00`)), 1.05);

// yesterday's chest keeps the streak alive today; the day before breaks it
assert.equal(streakOf({ streak: 4, lastFull: YESTERDAY }, new Date(`${DAY}T09:00:00`)), 4);
assert.equal(streakOf({ streak: 4, lastFull: '2026-10-01' }, new Date(`${DAY}T09:00:00`)), 0);

// a new day starts the challenges over, and the chest on it extends the streak
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
assert.equal(level(profile), DAILY_LEVEL, 'the chest leaves the level to the XP');

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
// …by the XP once a profile has it (200 reaches level 2, 500 level 3)
assert.equal(cribUnlocked({ pxp: 199, level: 5 }), false, 'pxp wins over the old level');
assert.equal(cribUnlocked({ pxp: 200 }), true);
assert.equal(dailyUnlocked({ pxp: 499, tut: 'done' }), false);
assert.equal(dailyUnlocked({ pxp: 500, tut: 'done' }), true);

// a claim pays its XP with its coins
{
  const p0 = { daily: { date: DAY, prog: { squish: 500 }, claimed: {}, chest: false } };
  const sq = dailyRows(p0, DAY).find((x) => x.ev === 'squish');
  assert.equal(sq.xp, CHALLENGE_XP);
  assert.equal(claimDaily(p0, sq.id, DAY).xp, CHALLENGE_XP);
}

// squishing: 1 XP every SQUISH_XP squishes, up to SQUISH_XP_DAY a day; other events none
{
  const at = (n) => ({ daily: { date: DAY, prog: { squish: n }, claimed: {}, chest: false } });
  assert.equal(bumpDaily(at(0), 'squish', 1, DAY).xp, 0);
  assert.equal(bumpDaily(at(SQUISH_XP - 1), 'squish', 1, DAY).xp, 1);
  assert.equal(bumpDaily(at(3), 'squish', 12, DAY).xp, 3);
  assert.equal(bumpDaily(at(SQUISH_XP * SQUISH_XP_DAY - 1), 'squish', 1, DAY).xp, 1, 'the last one of the day');
  assert.equal(bumpDaily(at(SQUISH_XP * SQUISH_XP_DAY), 'squish', SQUISH_XP, DAY).xp, 0, 'capped');
  assert.equal(bumpDaily(at(SQUISH_XP * SQUISH_XP_DAY), 'squish', 1, '2026-10-04').xp, 0, 'a new day starts from 0');
  assert.equal(bumpDaily(at(0), 'earn', 500, DAY).xp, 0);
}

console.log('progression: all checks passed');
