// node --input-type=module -e "import('./src/crib/model.test.js')"
// The Crib's rules on a few squads: moving in, needs, sending to rooms, a
// full room, meals, sleep, the yard's hunger, coins, time away.
import assert from 'node:assert/strict';
import { freshState, syncPets, sendTo, startMeal, buyFood, foodCost, FOOD_PACK, tick, needOf, coinRate, advanceOffline, occupancy, normalize, applyLayout, setMember, CRIB_MAX, OFFLINE_CAP_MS } from './model.js';
import { SEC_PER_HR, spotsFor } from './data.js';
import { buy, canBuy, equip, fridgeFoods, layout, lights, movables, normalizeHome, perk, placeGame, setPad, setTheme, setUnitPos, themeIdx, toggleStore, visuals } from './home.js';

const T0 = 1_000_000;
const seq = (...vals) => {
  let i = 0;
  return () => vals[Math.min(i++, vals.length - 1)];
};

// moving in: the living room first, then the yard; the tutorial's first one hungry
{
  const s = freshState(['0', '1', '2'], T0, { tutorial: true });
  assert.deepEqual(Object.keys(s.pets), ['0', '1', '2']);
  assert.equal(s.pets['0'].room, 'living');
  assert.equal(s.pets['0'].stats.tummy, 14);
  assert.equal(needOf(s.pets['0']), 'tummy');
  assert.equal(needOf(s.pets['1']), null);
  assert.equal(s.pets['1'].spot, 1);
  assert.equal(syncPets(s, ['0', '2'], T0), true);
  assert.equal(s.pets['1'], undefined);
  assert.equal(syncPets(s, ['0', '2'], T0), false);
  // at most CRIB_MAX live in the Crib: the first ten owned
  const ids17 = Array.from({ length: 17 }, (_, i) => String(i));
  const many = freshState(ids17, T0);
  assert.equal(Object.keys(many.pets).length, CRIB_MAX);
  assert.deepEqual(many.members, ids17.slice(0, 10));
  assert.equal(many.pets['10'], undefined);
  assert.equal(many.pets['9'].room, 'living');
  // the hatchery's switch: out frees a place, in takes it, a full Crib says so
  assert.deepEqual(setMember(many, '12', true, ids17, T0), { ok: false, reason: 'full' });
  assert.deepEqual(setMember(many, '3', false, ids17, T0), { ok: true });
  assert.equal(many.pets['3'], undefined);
  assert.equal(many.away['3'], true);
  // a moved-out one doesn't move back in by itself; the free place stays free
  syncPets(many, ids17, T0);
  assert.equal(many.members.length, 9);
  assert.deepEqual(setMember(many, '12', true, ids17, T0), { ok: true });
  assert.ok(many.pets['12']);
  // a newly unlocked creature moves in while there's room
  const few = freshState(['0', '1'], T0);
  syncPets(few, ['0', '1', '5'], T0);
  assert.ok(few.pets['5']);
}

// stats drain at home; a stat under 30 is a need; coins follow the mood
{
  const s = freshState(['0'], T0);
  s.pets['0'].stats = { clean: 80, energy: 80, tummy: 80 };
  assert.equal(coinRate(s), 0.6);
  const ev = tick(s, T0 + 10000);
  assert.ok(s.pets['0'].stats.clean < 80 && s.pets['0'].stats.clean > 79);
  assert.ok(ev.some((e) => e.type === 'coins' && e.n === 6), JSON.stringify(ev));
  s.pets['0'].stats = { clean: 10, energy: 10, tummy: 10 };
  assert.equal(coinRate(s), -0.25);
  assert.equal(needOf(s.pets['0']), 'clean');
}

// sending: a free spot, the same act again, a full room
{
  const s = freshState(['0', '1', '2', '3'], T0);
  assert.deepEqual(sendTo(s, '0', 'bath', { now: T0, rnd: seq(0) }), { ok: true });
  assert.equal(s.pets['0'].room, 'bath');
  assert.equal(s.pets['0'].act, 'bath');
  assert.deepEqual(s.pets['0'].from, { room: 'living', spot: 0, at: T0 });
  assert.equal(occupancy(s, 'living')[0], null);
  assert.equal(sendTo(s, '0', 'bath', { now: T0 + 5000 }).ok, false);
  assert.equal(sendTo(s, '0', 'home', { now: T0 + 100 }).reason, 'moving');
  // the starter tub seats 3
  assert.equal(spotsFor('bath').length, 3);
  assert.ok(sendTo(s, '1', 'bath', { now: T0 + 2000, rnd: seq(0) }).ok);
  assert.ok(sendTo(s, '2', 'bath', { now: T0 + 2000, rnd: seq(0) }).ok);
  assert.deepEqual(sendTo(s, '3', 'bath', { now: T0 + 2000 }), { ok: false, reason: 'full' });
  // a bath cleans fast and pays 10 coins when done
  const ev = tick(s, T0 + 2000 + 40000);
  assert.equal(s.pets['0'].stats.clean, 100);
  assert.ok(ev.some((e) => e.type === 'plus' && e.id === '0' && e.text === 'SQUEAKY CLEAN!'));
  assert.ok(ev.some((e) => e.type === 'coins' && e.n === 10));
  assert.equal(s.pets['0'].done, true);
}

// meals: the fridge, the pantry, then coins; tummy fills over the meal
{
  const s = freshState(['0'], T0);
  s.pets['0'].stats.tummy = 20;
  assert.equal(startMeal(s, '0', 'cookie', { now: T0 }).reason, 'busy');
  sendTo(s, '0', 'eat', { now: T0, rnd: seq(0) });
  const t1 = T0 + 2000;
  assert.equal(startMeal(s, '0', 'pizza', { now: t1 }).reason, 'fridge');
  assert.deepEqual(startMeal(s, '0', 'cookie', { now: t1 }), { ok: true, cost: 0 });
  assert.equal(s.pantry.cookie, 1);
  assert.equal(s.pets['0'].meal.gain, 12);
  tick(s, t1 + 4000);
  assert.ok(s.pets['0'].stats.tummy > 20 && s.pets['0'].stats.tummy < 32);
  const ev = tick(s, t1 + 8000);
  assert.ok(ev.some((e) => e.type === 'plus' && e.text === '+12 TUMMY'));
  tick(s, t1 + 8000 + 3300);
  assert.equal(s.pets['0'].meal, null);
  // the pantry's last cookie, then coins or nothing
  assert.deepEqual(startMeal(s, '0', 'cookie', { now: t1 + 12000 }), { ok: true, cost: 0 });
  s.pets['0'].meal = null;
  assert.equal(startMeal(s, '0', 'cookie', { now: t1 + 12000, coins: 5 }).reason, 'coins');
  assert.deepEqual(startMeal(s, '0', 'cookie', { now: t1 + 12000, coins: 50 }), { ok: true, cost: 10 });
  s.pets['0'].meal = null;
  assert.deepEqual(startMeal(s, '0', 'pizza', { now: t1 + 12000, free: true }), { ok: true, cost: 0 });
}

// sleep: the picker's hours, waking up on time with the energy and 10 coins
{
  const s = freshState(['0'], T0);
  s.pets['0'].stats.energy = 20;
  assert.ok(sendTo(s, '0', 'sleep', { h: 1, now: T0, rnd: seq(0) }).ok);
  const p = s.pets['0'];
  assert.equal(p.sleepEnd, T0 + SEC_PER_HR * 1000);
  assert.equal(p.sleepGain, 28);
  tick(s, T0 + 2000);
  const ev = tick(s, T0 + SEC_PER_HR * 1000 + 100);
  assert.ok(ev.some((e) => e.type === 'home' && e.why === 'woke'));
  assert.ok(ev.some((e) => e.type === 'plus' && e.text === '+28 ENERGY'));
  assert.equal(p.act, 'home');
  assert.ok(p.stats.energy > 44 && p.stats.energy < 49, p.stats.energy);
}

// dancing till hungry: comes home at tummy 20
{
  const s = freshState(['0'], T0);
  s.pets['0'].stats.tummy = 22;
  sendTo(s, '0', 'dance', { now: T0, rnd: seq(0) });
  let now = T0 + 2000;
  let home = null;
  for (let i = 0; i < 200 && !home; i++) {
    now += 1000;
    home = tick(s, now).find((e) => e.type === 'home');
  }
  assert.ok(home && home.why === 'hungry');
  assert.equal(s.pets['0'].room, 'living');
}

// time away: capped, no coins, nothing left mid-teleport
{
  const s = freshState(['0'], T0);
  s.pets['0'].stats = { clean: 100, energy: 100, tummy: 100 };
  const ev = advanceOffline(s, T0 + 3 * 60 * 60 * 1000);
  assert.ok(!ev.some((e) => e.type === 'coins'));
  const after = s.pets['0'].stats;
  const capSec = OFFLINE_CAP_MS / 1000;
  assert.ok(after.clean <= 100 - 0.05 * capSec + 1 && after.clean > 100 - 0.05 * capSec - 5, after.clean);
  assert.equal(s.t, T0 + 3 * 60 * 60 * 1000);
}

// a saved document comes back as a state; junk doesn't
{
  const s = freshState(['0', '1'], T0);
  sendTo(s, '1', 'bath', { now: T0, rnd: seq(0) });
  const doc = JSON.parse(JSON.stringify(s));
  const back = normalize(doc, ['0', '1', '2'], T0 + 5000);
  assert.equal(back.pets['1'].room, 'bath');
  assert.equal(back.pets['2'].room, 'living');
  assert.equal(normalize({ pets: { x: { act: 'fly', room: 'moon', spot: 9 } } }, ['0'], T0).pets.x, undefined);
  assert.equal(normalize(null, ['0'], T0).pets['0'].room, 'living');
}

// the furniture: buying, upgrades that change the rooms, perks, a game moved
{
  const s = freshState(['0', '1', '2', '3', '4'], T0);
  const h = s.home;
  // tier 0 is the cheap washtub; the design's tubs follow (its Bubble Bath is tub2)
  assert.deepEqual(canBuy(h, 'tub2', { level: 1, coins: 9999 }), { ok: false, reason: 'level' });
  assert.deepEqual(canBuy(h, 'tub2', { level: 2, coins: 100 }), { ok: false, reason: 'coins' });
  assert.deepEqual(canBuy(h, 'tub2', { level: 2, coins: 300 }), { ok: true, cost: 300 });
  assert.deepEqual(canBuy(h, 'tub1', { level: 1, coins: 150 }), { ok: true, cost: 150 });
  assert.equal(canBuy(h, 'tub0', { level: 9, coins: 9999 }).reason, 'owned');
  buy(h, 'tub2');
  assert.equal(h.eq.tub, 'tub2');
  assert.equal(spotsFor('bath', h).length, 4);
  buy(h, 'shower');
  assert.equal(spotsFor('bath', h).length, 5);
  assert.equal(spotsFor('bath', h)[4].style, 'shower');
  // a creature in the shower cleans faster than in the bubble bath
  ['0', '1', '2', '3', '4'].forEach((id) => assert.ok(sendTo(s, id, 'bath', { now: T0, rnd: seq(0) }).ok));
  const shower = Object.keys(s.pets).find((id) => s.pets[id].spot === 4);
  const tub = Object.keys(s.pets).find((id) => s.pets[id].spot === 0);
  s.pets[shower].stats.clean = 0;
  s.pets[tub].stats.clean = 0;
  tick(s, T0 + 1100);
  tick(s, T0 + 2100);
  assert.ok(s.pets[shower].stats.clean > s.pets[tub].stats.clean * 1.5, `${s.pets[shower].stats.clean} vs ${s.pets[tub].stats.clean}`);
  // back to the basic tub: the 4th spot is gone, its creature goes home
  // (the shower stays, as spot 3 now: the tub's seats shrank by one)
  equip(h, 'tub', 'tub0');
  assert.equal(spotsFor('bath', h).length, 4);
  assert.deepEqual(applyLayout(s, T0 + 3000), [shower]);
  assert.equal(s.pets[shower].room, 'living');
  assert.equal(s.pets[shower].act, 'home');
  // decor: placed pieces add their perk; stored ones don't
  assert.equal(perk(h, 'living'), 0);
  buy(h, 'l_art');
  assert.equal(perk(h, 'living'), 0.04);
  s.pets['0'].stats = { clean: 80, energy: 80, tummy: 80 };
  Object.keys(s.pets).forEach((id) => (s.pets[id].stats = { clean: 80, energy: 80, tummy: 80 }));
  assert.ok(Math.abs(coinRate(s, T0 + 9000) - 5 * 0.6 * 1.04) < 1e-9);
  toggleStore(h, 'l_art');
  assert.equal(perk(h, 'living'), 0);
  // the dance room's furniture counts for its draining
  h.own.speakers3 = true;
  equip(h, 'speakers', 'speakers3');
  assert.equal(perk(h, 'dance'), 0.05);
  // the yard: a bought game takes a free play spot; moving one moves its spots
  assert.equal(spotsFor('yard', h).length, 3);
  assert.deepEqual(buy(h, 'g_tramp'), { placed: true });
  assert.equal(h.pads.B, 'tramp');
  assert.equal(spotsFor('yard', h).length, 4);
  setPad(h, 'B', 30, -10);
  const tr = spotsFor('yard', h).find((p) => p.g === 'tramp');
  assert.deepEqual([tr.x, tr.y], [320, 312]);
  assert.equal(placeGame(h, 'A', 'tramp'), false); // the trampoline has its own spot
  buy(h, 'g_slide');
  assert.equal(h.pads.C, 'slide');
  assert.equal(spotsFor('yard', h).find((p) => p.g === 'slide').x, 480);
  assert.equal(placeGame(h, 'C', null), true);
  assert.equal(spotsFor('yard', h).some((p) => p.g === 'slide'), false);
  // the fridge decides the menu
  assert.equal(fridgeFoods(h).length, 3);
  // a saved home comes back cleaned up
  const back = normalizeHome({ own: { tub1: true, bogus: true }, eq: { tub: 'tub1', sofa: 'sofa3' }, pads: { A: 'swing', B: 'seesaw' } });
  assert.equal(back.eq.tub, 'tub1');
  assert.equal(back.eq.sofa, 'sofa0'); // not owned
  assert.equal(back.own.bogus, undefined);
  assert.equal(back.pads.B, null); // not owned, and not its spot
  assert.equal(normalize({ ...JSON.parse(JSON.stringify(s)) }, Object.keys(s.pets), T0 + 9000).home.eq.tub, 'tub0');
}

// moving furniture: the seats go with it, anywhere in the room
{
  const s = freshState(['0', '1'], T0);
  const h = s.home;
  const sofa = movables(h, 'living').find((m) => m.key === 'sofa');
  assert.ok(sofa && sofa.box.w > 0);
  const before = layout(h).tv.map((p) => p.x);
  setUnitPos(h, 'sofa', -300, 20);
  assert.deepEqual(layout(h).tv.map((p) => p.x), before.map((x) => x - 300));
  assert.equal(layout(h).tv[0].y, 258);
  assert.equal(visuals(h, 'living').back.find((p) => p.w === 188).x, 332);
  // each bed moves on its own, with its two spots
  setUnitPos(h, 'bed.2', 40, 0);
  assert.deepEqual(spotsFor('bed', h).slice(4, 6).map((p) => p.x), [528, 612]);
  assert.equal(spotsFor('bed', h)[0].x, 88);
  // the snack table takes the kitchen's seats
  setUnitPos(h, 'table', 0, 30);
  assert.equal(spotsFor('kitchen', h)[0].y, 330); // the crate table's seats (300) moved down 30
  // a moved tub keeps its creatures in it
  assert.ok(sendTo(s, '0', 'bath', { now: T0, rnd: seq(0) }).ok);
  setUnitPos(h, 'tub', 100, 0);
  assert.deepEqual(applyLayout(s, T0 + 2000), []);
  assert.equal(spotsFor('bath', h)[s.pets['0'].spot].x, 433);
  // the limits keep a piece inside the scene
  const m = movables(h, 'living').find((x) => x.key === 'sofa');
  const x0 = m.box.x + 300; // where it stood before the move
  assert.equal(x0 + m.lim.minX, 0, 'the furthest left puts it at the scene edge');
  assert.equal(x0 + m.box.w + m.lim.maxX, 852, 'and the furthest right at the other');
}

// walls, floors, ceilings: bare and free first, the rest bought
{
  const h = freshState([], T0).home;
  assert.equal(themeIdx(h, 'living', 'wall'), 0);
  assert.equal(setTheme(h, 'living', 'wall', 1), false, 'not bought yet');
  assert.deepEqual(canBuy(h, 'th:living:wall:1', { level: 1, coins: 150 }), { ok: true, cost: 150 });
  buy(h, 'th:living:wall:1');
  assert.equal(themeIdx(h, 'living', 'wall'), 1);
  assert.equal(canBuy(h, 'th:living:wall:0', { level: 1, coins: 0 }).reason, 'owned');
  assert.equal(setTheme(h, 'living', 'wall', 0), true);
  // the yard keeps the design's grounds, the first one free
  assert.equal(canBuy(h, 'th:yard:floor:0', { level: 1, coins: 0 }).reason, 'owned');
}

// the rooms' fixtures, rugs and lamps
{
  const h = freshState([], T0).home;
  assert.equal(perk(h, 'living'), 0);
  buy(h, 'fx_living_bookshelf');
  assert.equal(perk(h, 'living'), 0.03);
  buy(h, 'rug_living3');
  assert.ok(Math.abs(perk(h, 'living') - 0.06) < 1e-9);
  // the ceiling lamp lights the room at night, wherever it hangs
  const lamp = lights(h, 'living').find((l) => l.id === 'lamp_living');
  setUnitPos(h, 'lamp_living', -200, 0);
  assert.equal(lights(h, 'living').find((l) => l.id === 'lamp_living').x, lamp.x - 200);
}

// the kitchen's pantry shop: packs of five for the price of four, only
// what the fridge holds, paid by the caller
{
  const s = freshState(['0'], T0);
  const k = fridgeFoods(s.home)[0];
  const had = s.pantry[k] || 0;
  const one = buyFood(s, k, 1, { coins: 1000 });
  assert.equal(one.ok, true);
  assert.equal(s.pantry[k], had + 1);
  const pack = buyFood(s, k, FOOD_PACK, { coins: 1000 });
  assert.equal(pack.cost, one.cost * (FOOD_PACK - 1));
  assert.equal(s.pantry[k], had + 1 + FOOD_PACK);
  assert.deepEqual(buyFood(s, k, 1, { coins: 0 }), { ok: false, reason: 'coins' });
  assert.deepEqual(buyFood(s, 'nope', 1, { coins: 1000 }), { ok: false, reason: 'fridge' });
  assert.equal(foodCost({ price: 10 }, 3), 30);
}

console.log('crib model: ok');
