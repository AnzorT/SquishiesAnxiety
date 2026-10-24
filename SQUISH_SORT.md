# Squish Sort: the memory mini-game

The second mini-game, asked for on 2026-10-24. Squishies sit on the shelves of a fridge. You see them for about 5 seconds, then the doors shut, the fridge shakes and jumps, and everyone tumbles out. Put each one back on its spot.

## The user's asks (2026-10-24)
- A fridge for the food squishies. The fridge shows for ~5 s, closes, shakes and jumps, then opens, and the creatures go back where they were. Make it challenging, and add it to the PLAY list.
- After trying it: "too simple". Make the fridge bigger, the creatures smaller, add more shelves, and put random foods everywhere to confuse the player.
- Levels and difficulty, like Squishdoku.
- Then: shrink the fridge a little so the doors show. Level 1 should be easy, on about one shelf, and the levels should build up from there.

## Containers
| Container | Squishies | Clutter |
|---|---|---|
| Snack Fridge | Snack Shack, Fruit Patch, Sweet Bakery | 16 foods (milk, eggs, cheese, apple, jam, cupcake, lemon, watermelon…) |
| Toy Cupboard | Pet Shop, Forest Friends, Dreamland, Sky & Stars | 16 toys (ball, blocks, duck, drum, rocket…) |

- Each container keeps its own level, stars and skill.
- The squishies come from the whole group, owned or not, without hidden groups or the pass creature (`src/sort/themes.js` `poolOf`).
- Some foods look a lot like food squishies (a cupcake, a lemon, a watermelon slice). They just have no faces.

## A level
1. **Deal:** the clutter and the squishies pop onto the shelves.
2. **Peek** (REMEMBER!): about 5 s. A little longer when there are more squishies, shorter on harder tiers.
3. **Close:** the doors shut.
4. **Shake:** a rattle, then two jumps with landings. Behind the shut doors, the clutter gets moved around.
5. **Open:** the doors fly open and the lamp flickers.
6. **Tumble:** the squishies fall out onto the counter (the tray).
7. **Sort:** drag a squishy to its spot, or tap it and then tap the spot. Only the spot under the finger lights up, and there are no dashed outlines. A wrong spot costs a heart, and 3 mistakes end the level. The clock runs: 20 s + 4 s per squishy.

## Twists
- **Impostors:** squishies in the tray that were never inside. Putting one in costs a heart, and it's found out.
- **Sneaky swap:** near the end of the peek, two squishies trade places, or one hops to an empty spot.
- **Mixed up:** after the shake, some squishies are left inside on the wrong spots. Move them home, or drag them out to the tray at no cost. Dropping a squishy on its home where a mixed-up one sits swaps the two.
- **Moving clutter:** the shake moves the clutter to other spots. It never lands on a squishy's home, and at least one empty spot is always left that belongs to nobody, so the gaps don't give the answer away. Dropping on clutter does nothing.

## Levels and difficulty (like Squishdoku)
50 levels per container, in bands of one size:

| Levels | Shelves × spots | Squishies (easy) |
|---|---|---|
| 1-3 | 1 × 4 | 2 |
| 4-7 | 2 × 4 | 3 |
| 8-12 | 3 × 4 | 4 |
| 13-18 | 4 × 4 | 5 |
| 19-25 | 5 × 4 | 6 |
| 26-33 | 6 × 5 | 7 |
| 34-41 | 7 × 5 | 8 |
| 42-50 | 8 × 5 | 9 |

The fridge takes about 72% of the screen's width, so the open doors show either side.

- **Tiers:** each level asks for EASY, MEDIUM, HARD or EXPERT. The tier rises inside each band, with breathers in between (`src/sort/levels.js` BANDS).
  - Each tier adds a squishy.
  - Medium has one twist, Hard two, Expert all three.
  - No twists on levels 1-5. Then they arrive one at a time: impostors at level 6, mixed up at 10, the swap at 14.
- **Clutter:** about 4 spots in 10, plus one per tier. At least 1 spot stays empty on small shelves, 3 on big ones.
- **Adaptive difficulty:** a hidden skill per container. It goes up after quick clean wins and down after fails and mistakes, and it moves the tier one step at most. The size never changes.
- **Stars:**
  - 3 stars: no mistakes, and under the par time (5 s + 2.6 s per squishy, more for twists).
  - 2 stars: at most one mistake.
  - 1 star: any other win.
- **Coins:** based on the squishies and twists, × stars, × tier.
- **Map:** a winding path of 50 nodes (`src/sort/LevelMap.js`) with tier dots, stars, size banners, and a squishy bobbing on the current level.

## Code
- `src/sort/levels.js`: bands, tiers, specs, skill, stars, coins, and the `sort` record. `src/sort/board.js`: dealing, swaps, the shake, clutter and the drop rules. Tests: `node src/sort/board.test.js`.
- `src/sort/Container.js`: the fridge or cupboard (doors on hinges, lamp, shelves) and the mini one. `src/sort/props.js`: the clutter art. `src/sort/Game.js`: the timeline, drag/tap, hearts, clock, win/fail. `src/sort/Cards.js`: result, fail, pause, how to play. `src/sort/Hub.js`, `src/sort/LevelMap.js`, `src/screens/SortScreen.js`.
- Sounds: `tools/audio/sort_sfx.py` writes `assets/audio/sort/fs_*` and `src/audio/sortFiles.js`. Stars, coins, the win and the tick reuse Squishdoku's sd_* sounds.
- Saved on the profile (client-written, like Squishdoku's `sdk`): `sort.{fridge|cupboard}.{lv, best, skill}`, `sort.plays`, `sort.wins`, `sort.seen`. Coins go through `saveSort`.

## Status (2026-10-24)
- Played on the Pixel_8_Pro debug build: hub, picker card, deal, peek, close, shake, open, tumble, drag and tap placing, a mistake, the win with its result card, time's up, pause. The clutter and the bigger fridge were checked after the user's "too simple".
- Still to check: the level map on screen, the toy cupboard in play, impostors / swap / mixed-up in play, speed on a release build on the A15. Nobody has listened to the fs_* sounds yet.
