// node src/playerXp.test.js — the player's XP and level (src/playerXp.js).
import assert from 'node:assert/strict';
import { addXp, gameXp, migrateXp, prizeText, pxpOf, roadClaimable, roadPrize, roadView, setLevelsConfig, winXp, xpRules, xpToNext, xpToReach, xpView } from './playerXp.js';

// a profile from before player XP: its level's XP plus its Puzzle XP
assert.equal(pxpOf({ level: 3 }), 500);
assert.equal(pxpOf({ level: 3, sdk: { xp: 500 } }), 1000);
assert.equal(pxpOf({}), 0);
assert.equal(pxpOf({ pxp: 50, level: 9 }), 50, 'pxp, once there, is the truth');
assert.deepEqual(migrateXp({ level: 10, sdk: { xp: 30 } }), { pxp: 5430, level: 10, lvSeen: 10 });
assert.deepEqual(migrateXp({ level: 3, sdk: { xp: 500 } }), { pxp: 1000, level: 4, lvSeen: 4 }, 'Puzzle XP can lift the level');
assert.equal(migrateXp({ pxp: 0 }), null);
assert.equal(migrateXp(null), null);

// the bar
assert.deepEqual(xpView({ pxp: 530 }), { level: 3, into: 30, need: 400, pxp: 530 });

// adding XP: the levels it reaches
let r = addXp({ pxp: 190 }, 20);
assert.equal(r.xp, 20);
assert.equal(r.before.level, 1);
assert.equal(r.after.level, 2);
assert.deepEqual(r.levelUps, [2]);
r = addXp({ pxp: 0 }, xpToReach(5));
assert.deepEqual(r.levelUps, [2, 3, 4, 5]);
assert.deepEqual(addXp({ pxp: 10 }, 5).levelUps, []);
assert.equal(addXp({ pxp: 10 }, -5).xp, 0, 'never takes XP away');

// a replay pays half; beating the best pays the difference when that's more
assert.equal(winXp(40), 40, 'the first win');
assert.equal(winXp(40, 40), 20);
assert.equal(winXp(40, 32), 20, 'a small gain still pays half');
assert.equal(winXp(60, 20), 40, 'a big gain pays the difference');

// the road
const view = roadView({ pxp: 500, levelGot: { 1: true } }, null);
assert.equal(view.length, 50);
assert.deepEqual(view.slice(0, 4).map((n) => [n.lv, n.got, n.claimable]), [[1, true, false], [2, false, true], [3, false, true], [4, false, false]]);
assert.equal(roadClaimable({ pxp: 500, levelGot: { 1: true } }, null), 2);
assert.equal(roadClaimable({ pxp: 0 }, null), 1, "level 1's prize waits from the start");
// a prize claimed above today's level (the curve changed since) shows locked, not claimed
assert.deepEqual(roadView({ pxp: 500, levelGot: { 1: true, 7: true } }).slice(6, 7).map((n) => [n.lv, n.reached, n.got, n.claimable]), [[7, false, false, false]]);
assert.equal(roadPrize(51), null);
assert.equal(prizeText({ k: 'coins', n: 1200 }), '1,200 coins');
assert.equal(prizeText({ k: 'gems', n: 30 }), '30 gems');
assert.equal(prizeText({ k: 'chest', t: 'epic' }), 'an Epic chest');
assert.equal(prizeText({ k: 'chest', t: 'set' }), 'a Rainbow chest');

// config/levels changes the curve, the road and the XP at once
setLevelsConfig({ xpPerLevel: 50, road: [{ k: 'coins', n: 1 }, { k: 'gems', n: 2 }, { k: 'coins', n: 3 }], xp: { replay: 0.25, games: 2, challenge: 40 } });
assert.equal(xpToNext(9), 500);
assert.equal(xpView({ pxp: 250 }).level, 3);
assert.equal(roadView({ pxp: 0 }).length, 3);
assert.deepEqual(roadPrize(2), { k: 'gems', n: 2 });
assert.equal(winXp(40, 40), 10);
assert.equal(gameXp(21), 42);
assert.equal(xpRules().challenge, 40);
assert.equal(xpRules().chest, 100, 'what it leaves out stays the default');
setLevelsConfig(null);
assert.equal(xpToNext(9), 1000);
assert.equal(roadView({}).length, 50);

console.log('playerXp: all checks passed');
