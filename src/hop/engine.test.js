// node src/hop/engine.test.js: Squish Hop's levels, board geometry and scoring.
// (The solver itself is tested against brute force by the prototype's
// tools/check.mjs, on the same engine.)
import assert from "node:assert/strict";
import { DCH, leftOf, newState, parse, search, tryMove } from "./engine.js";
import LEVEL_DATA from "./levelData.js";
import { cellAt, layout, project, standOn } from "./board.js";
import {
  CHAPTERS,
  LEVELS,
  LEVEL_LIST,
  coinsFor,
  levelSpec,
  record,
  stageOf,
  starsFor,
  xpFor,
  afterBlitz,
  blitzPrize,
} from "./levels.js";
import { BLITZ_COINS, blitzShape, blitzSpec } from "./blitz.js";

let n = 0;
const ok = (name, fn) => {
  fn();
  n++;
  console.log(`ok - ${name}`);
};

ok("every level parses and its stored answer is a full clear", () => {
  LEVEL_DATA.forEach((d, i) => {
    const lv = parse(d.map);
    let st = newState(lv);
    for (const c of d.solution) {
      const m = tryMove(lv, st, DCH.indexOf(c));
      assert.ok(m.ok, `level ${i + 1}: ${c} blocked (${m.why})`);
      st = m.st;
    }
    assert.ok(st.done, `level ${i + 1} doesn't end on the ★`);
    assert.equal(leftOf(lv, st.life), 0, `level ${i + 1} leaves cushions`);
  });
});

ok("the ★ stays shut until every other cushion is cleared", () => {
  // S next to the ★, with one more cushion below S
  const lv = parse(["SG", ".#"]);
  const m = tryMove(lv, newState(lv), 1);
  assert.equal(m.ok, false);
  assert.equal(m.why, "locked");
  // the last cushion: hopping off it onto the ★ is fine
  const lv2 = parse(["S.G"]);
  let st = tryMove(lv2, newState(lv2), 1).st;
  const end = tryMove(lv2, st, 1);
  assert.ok(end.ok && end.st.done);
  // a pile's second layer still counts: hopping off it once leaves one
  const lv3 = parse(["SDG"]);
  const onPile = tryMove(lv3, newState(lv3), 1).st;
  assert.equal(tryMove(lv3, onPile, 1).why, "locked");
});

ok("random play on every level never ends with cushions left", () => {
  let seed = 7;
  const rand = () => ((seed = (seed * 16807) % 2147483647) / 2147483647);
  LEVEL_DATA.forEach((d, i) => {
    const lv = parse(d.map);
    for (let k = 0; k < 30; k++) {
      let st = newState(lv);
      for (let step = 0; step < 400 && !st.done; step++) {
        const ms = [0, 1, 2, 3].map((dir) => tryMove(lv, st, dir)).filter((m) => m.ok);
        if (!ms.length) break;
        st = ms[Math.floor(rand() * ms.length)].st;
      }
      if (st.done) assert.equal(leftOf(lv, st.life), 0, `level ${i + 1}`);
    }
  });
});

ok(
  "levels 5+ have exactly one full clear (sampled small boards are searched)",
  () => {
    LEVEL_DATA.forEach((d, i) => {
      if (i < 4) return;
      assert.equal(d.sols, 1, `level ${i + 1}`);
    });
    // the first eight are small enough to count every clear quickly
    LEVEL_DATA.slice(0, 8).forEach((d, i) => {
      const r = search(parse(d.map), newState(parse(d.map)), {
        count: true,
        cap: 10,
        limit: 2e6,
      });
      assert.ok(!r.aborted, `level ${i + 1} search aborted`);
      assert.equal(
        r.sols.length,
        d.sols,
        `level ${i + 1}: ${r.sols.length} clears, data says ${d.sols}`,
      );
    });
  },
);

ok("a tap on any cell finds that cell, on every board, at phone sizes", () => {
  for (const d of LEVEL_DATA) {
    const lv = parse(d.map);
    for (const [aw, ah, floor] of [
      [390, 520, 60],
      [360, 430, 0],
      [412, 610, 120],
    ]) {
      const B = layout(lv.w, lv.h, aw, ah, floor);
      for (let i = 0; i < lv.w * lv.h; i++) {
        const x = i % lv.w;
        const y = Math.floor(i / lv.w);
        for (const [u, v] of [
          [0.5, 0.5],
          [0.15, 0.2],
          [0.85, 0.85],
        ]) {
          const p = project(B, x + u, y + v);
          assert.equal(
            cellAt(B, p.x, p.y),
            i,
            `${lv.w}x${lv.h} cell ${i} at (${u}, ${v})`,
          );
        }
      }
      // the board fits the area
      const tl = project(B, 0, 0);
      const br = project(B, lv.w, lv.h);
      const bl = project(B, 0, lv.h);
      assert.ok(bl.x >= 0 && br.x <= aw, `${lv.w}x${lv.h} too wide for ${aw}`);
      assert.ok(br.y <= ah, `${lv.w}x${lv.h} too tall for ${ah}`);
      assert.ok(tl.y >= -ah * 0.07, `${lv.w}x${lv.h} starts too high`);
      // nearer looks bigger
      assert.ok(standOn(B, lv.w * (lv.h - 1)).s > standOn(B, 0).s);
    }
  }
});

ok("levels.js: 100 levels in six rooms, in order", () => {
  assert.equal(LEVELS, 100);
  assert.deepEqual(
    CHAPTERS.map((c) => c.room),
    ["living", "kitchen", "bath", "bed", "yard", "dance"],
  );
  assert.equal(CHAPTERS[0].from, 1);
  assert.equal(CHAPTERS[CHAPTERS.length - 1].to, 100);
  assert.equal(LEVEL_LIST.length, 100);
});
ok("levels.js: time of day moves on through a room", () => {
  assert.equal(stageOf(1).phase, "morning");
  assert.equal(stageOf(14).phase, "night");
  assert.equal(stageOf(31).phase, "day");
  assert.notEqual(stageOf(1).key, stageOf(15).key);
});
ok("levels.js: the same level is the same board every time", () => {
  assert.deepEqual(levelSpec(37).map, levelSpec(37).map);
  assert.deepEqual(levelSpec(37).sol, levelSpec(37).sol);
});
ok("levels.js: stars, coins and XP", () => {
  assert.equal(starsFor(0, false), 3);
  assert.equal(starsFor(3, false), 2);
  assert.equal(starsFor(4, false), 1);
  assert.equal(starsFor(0, true), 2);
  assert.equal(starsFor(9, true), 1);
  const s1 = levelSpec(1);
  const s100 = levelSpec(100);
  assert.ok(coinsFor(s1, 3) > coinsFor(s1, 1));
  assert.ok(coinsFor(s100, 3) > coinsFor(s1, 3));
  assert.ok(xpFor(s100, 3) > xpFor(s1, 3));
  assert.deepEqual(record({}), {
    lv: 1,
    best: {},
    plays: 0,
    wins: 0,
    seen: false,
    blitz: { top: 0, runs: 0 },
  });
  assert.equal(record({ hop: { lv: 500 } }).lv, 100);
});

ok("blitz: every board is a full clear, the climb never shrinks, clocks under a second a hop past 5 s", () => {
  for (const seed of [1, 99, 123456, 987654321]) {
    for (let i = 0; i < 30; i++) {
      const s = blitzSpec(i, seed);
      let st = newState(s.board);
      for (const d of s.sol) {
        const m = tryMove(s.board, st, d);
        assert.ok(m.ok, `board ${i} seed ${seed}: hop ${d} blocked (${m.why})`);
        st = m.st;
      }
      assert.ok(st.done && leftOf(s.board, st.life) === 0, `board ${i} seed ${seed}`);
      assert.ok(s.ms <= (5 + s.sol.length) * 1000 && s.ms >= 0.75 * (5 + s.sol.length) * 1000 - 1000);
      if (i) {
        const a = blitzShape(i - 1);
        const b = blitzShape(i);
        assert.ok(b.w * b.h >= a.w * a.h, `board ${i} shrinks`);
      }
    }
  }
  // the same seed and board give the same board (a run is replayable)
  assert.deepEqual(blitzSpec(7, 42).map, blitzSpec(7, 42).map);
});

ok("blitz: the run's record and its pay", () => {
  const none = afterBlitz({}, { cleared: 0 });
  assert.equal(none.coins, 0);
  assert.equal(none.update["hop.blitz.runs"], 1);
  const run = afterBlitz({ pxp: 0, hop: { blitz: { top: 2, runs: 3 } } }, { cleared: 4 });
  assert.equal(run.newTop, true);
  assert.equal(run.update["hop.blitz.top"], 4);
  assert.equal(run.update["hop.blitz.runs"], 4);
  assert.equal(run.coins, BLITZ_COINS[9] + 2 * BLITZ_COINS[12] + BLITZ_COINS[16]);
  assert.equal(run.xp, 80);
  assert.equal(afterBlitz({ hop: { blitz: { top: 9 } } }, { cleared: 4 }).update["hop.blitz.top"], undefined);
  assert.equal(blitzPrize(10).xp, 200);
});

console.log(`\n${n} passed`);
