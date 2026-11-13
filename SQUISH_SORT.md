# Squish Sort: the memory mini-game

The second mini-game, asked for on 2026-10-24. Squishies sit on the shelves of a fridge. You see them for about 5 seconds, then the doors shut, the fridge shakes and jumps, and everyone tumbles out. Put each one back on its spot.

## The user's asks (2026-10-24)
- A fridge for the food squishies. The fridge shows for ~5 s, closes, shakes and jumps, then opens, and the creatures go back where they were. Make it challenging, and add it to the PLAY list.
- After trying it: "too simple". Make the fridge bigger, the creatures smaller, add more shelves, and put random foods everywhere to confuse the player.
- Levels and difficulty, like Squishdoku.
- Then: shrink the fridge a little so the doors show. Level 1 should be easy, on about one shelf, and the levels should build up from there.
- 2026-10-28: "i want it to be in real fridge". Several fridge types, "small fridge medium big large extra large XXL … VERY VERY LARGE", each one gaining shelves "until a certain thing", and "your job is to decide when and what". The same for the cupboard.

## Containers
| Container | Squishies | Clutter |
|---|---|---|
| Snack Fridge | Snack Shack, Fruit Patch, Sweet Bakery | 16 foods (milk, eggs, cheese, apple, jam, cupcake, lemon, watermelon…) |
| Toy Cupboard | Pet Shop, Forest Friends, Dreamland, Sky & Stars | 16 toys (ball, blocks, duck, drum, rocket…) |

- Each container keeps its own level, stars and skill.
- The squishies come from the whole group, owned or not, without hidden groups or the pass creature (`src/sort/themes.js` `poolOf`).
- Some foods look a lot like food squishies (a cupcake, a lemon, a watermelon slice). They just have no faces.

## Seven sizes (2026-10-28)
Each container grows through seven real models, one per size. The fridge and the cupboard share the sizes and the levels, and only the look differs (`src/sort/models.js`):

| Size | Levels | Shelves × spots | Fridge | Cupboard |
|---|---|---|---|---|
| SMALL | 1-5 | 1 × 3, then 2 × 3 from level 3 | Mini Fridge: one door, a freezer box inside at the top, a vent grille, little feet | Bedside Cabinet: one door, a drawer on top, tapered legs |
| MEDIUM | 6-11 | 3 × 3, then 4 × 3 from level 9 | Retro Fridge: mint, a rounded top, a chrome lever handle and badge, splayed chrome legs | Hall Cupboard: one tall panelled door, a cornice, a plinth |
| BIG | 12-18 | 3 × 4, then 4 × 4 from level 15 | Top-Freezer Fridge: almond, its own freezer door on top, salad drawers, magnets and a drawing | Toy Cupboard: the old candy cupboard, two doors with a heart and a star, ball feet |
| LARGE | 19-25 | 5 × 4, then 6 × 4 from level 22 | Bottom-Freezer Fridge: stainless steel, a long bar handle, a freezer drawer | Wardrobe: walnut, two doors, a clothes rail, a drawer, bracket feet |
| EXTRA LARGE | 26-32 | 5 × 5, then 6 × 5 from level 29 | Side-by-Side Fridge: black steel, two tall doors, an ice and water dispenser | Mirror Wardrobe: white, a mirror door, two drawers |
| XXL | 33-41 | 7 × 5, then 8 × 5 from level 37 | French-Door Fridge: steel, two doors over two drawers, a dispenser and a little display | Grand Armoire: cherry, an arched carved crown, arched door panels, bun feet |
| VERY VERY LARGE | 42-50 | 7 × 6, then 8 × 6 from level 46 | Restaurant Fridge: brushed steel, a header with a 3°C thermometer, wire shelves, a lock, casters | Giant Wardrobe: dark oak, little cupboards on top, a row of drawers below |

- **Why these steps:** every model is at least as wide as the one before and gains a shelf partway through, so no level has fewer spots than the one before it. The biggest is 8 × 6. That's one column more than the old 8 × 5, and the spots still come out about 46 dp on the Galaxy A15.
- **On screen:** the bigger models take more of the width (56% of the play area for the small ones, up to 80% for the very very large). A one-door model sits off-centre, away from its hinge, so the open door has room on that side. The doors open as far as the room either side allows: 106°, or down to 98° for the widest ones.
- **Doors:** an open door shows its inside: a fridge's has door bins with bottles, a cupboard's is plain wood. Android's `backfaceVisibility` ignores a parent's turn, so the front and the inside swap by the door's angle. Before this, an open door showed its outside.
- **What the player sees:**
  - A model's first level opens with **BIGGER FRIDGE!** (or **BIGGER CUPBOARD!**) and its size and name.
  - A new shelf adds a **+1 SHELF** chip.
  - Every intro shows the size and name, e.g. "XXL · FRENCH-DOOR FRIDGE".
  - The HUD shows the model's name.
  - The hub card shows the model you're up to, drawn small with its doors opening.
  - The level map has a picture and a banner at each new model, and a "+1 SHELF · 4 SHELVES" banner at each new shelf.
  - How to play has a "BIGGER AND BIGGER" line.

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
50 levels per container, in 14 bands of one size across the seven models (above). Squishies on EASY by band: 2, 3 | 3, 4 | 5, 6 | 7, 7 | 8, 8 | 9, 9 | 10, 10 (`src/sort/levels.js` MODEL_SIZES). There's always at least one empty spot.

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
- **XP** (the player level, PLAYER_XP.md, since 2026-10-25): (10 + ½ × level + 5 × tier) × (0.6 + 0.2 × stars); half on a replay. A Blitz win gives 200.
- **Map:** a winding path of 50 nodes (`src/sort/LevelMap.js`) with tier dots, stars, size banners, each model's picture (`iconOf`, built with its level's node), and a squishy bobbing on the current level.

## Blitz (asked for on 2026-10-24: "in the fridge game i also want to have a blitz option")
Like Squishdoku's Blitz, from the hub's BLITZ ⚡ card:
- **10 rounds in a row.** The fridge and the toy cupboard take turns. Each round plays like a Regular level from further up the map: levels 2, 5, 8, 11, 14, 17, 20, 24, 28 and 33, with their size, twists and peek. The Blitz skill (`bSkill`) can move each one a tier.
- **One clock for the whole run**, 5:00 (the rounds' 3-star times add up to about 3:45). It runs only while you sort. It's stopped through the peek, the shake and between rounds.
- **One mistake** (a wrong spot, or an impostor put in) stops the clock. Then:
  - **One revive per run:** a rewarded ad, free with Remove Ads, back to sorting the same round.
  - Otherwise it's **BACK TO ROUND 1**.
  - The clock running out ends the run too, and can't be revived.
- **The prize:** 800 coins for all 10 rounds. The best round reached and the best time are saved.
- **Reused from Squishdoku:** the pips, the revive, fail and win cards, the pause card and the sd_* Blitz sounds.
- **Code:**
  - `levels.js`: `BLITZ_*`, `blitzSpec`, `blitzTheme`, `afterBlitz`.
  - `Game.js`: `SortBlitz` / the `blitz` prop.
  - Saved as `sort.blitz.{reached, bestMs, wins}` and `sort.bSkill`.

## Code
- `src/sort/levels.js`: bands, tiers, specs, skill, stars, coins, and the `sort` record. `src/sort/board.js`: dealing, swaps, the shake, clutter and the drop rules. Tests: `node src/sort/board.test.js`.
- `src/sort/models.js`: the seven fridges and seven cupboards (shape, doors, handles, what's on them, colours).
- `src/sort/Container.js`: draws any model: the body, what's above and below the inside, the inside (glass, wire or wood shelves, salad drawers, a clothes rail, the lamp), the doors and the feet. It also has the geometry (spot size, door angle, the off-centre shift) and `MiniContainer`, the full drawing shrunk for the picker, hub and map. `src/sort/props.js`: the clutter art. `src/sort/Game.js`: the timeline, drag/tap, hearts, clock, win/fail. `src/sort/Cards.js`: result, fail, pause, how to play. `src/sort/Hub.js`, `src/sort/LevelMap.js`, `src/screens/SortScreen.js`.
- Sounds: `tools/audio/sort_sfx.py` writes `assets/audio/sort/fs_*` and `src/audio/sortFiles.js`. Stars, coins, the win and the tick reuse Squishdoku's sd_* sounds.
- Saved on the profile (client-written, like Squishdoku's `sdk`): `sort.{fridge|cupboard}.{lv, best, skill}`, `sort.plays`, `sort.wins`, `sort.seen`. Coins go through `saveSort`.

## Status
- 2026-10-28, the seven sizes, on the Pixel_8_Pro debug build:
  - checked: all 14 models drawn at game size, open and shut, through a dev gallery that has since been deleted. Also the hub cards, the map's picture and banners, and level 4 played (intro, peek, shake, tumble, a tap-placed squishy landing on its spot).
  - not yet: a BIGGER FRIDGE! intro in play (the test account is on level 4), the bigger models in a real level, and speed on the A15.
  - The layout math was checked for every level at 448 × 849 dp (Pixel 8 Pro) and 384 × 690 dp (A15): nothing runs off screen or into the counter.

### 2026-10-24
- Played on the Pixel_8_Pro debug build: hub, picker card, deal, peek, close, shake, open, tumble, drag and tap placing, a mistake, the win with its result card, time's up, pause. The clutter and the bigger fridge were checked after the user's "too simple".
- Still to check: the level map on screen, the toy cupboard in play, impostors / swap / mixed-up in play, speed on a release build on the A15. Nobody has listened to the fs_* sounds yet.
- Blitz, played on the Pixel_8_Pro on 2026-10-24:
  - checked: the hub card, round 1 in the fridge solved (pip, clock held, round 2 in the cupboard), a mistake opening the revive card, the revive through a test ad (the clock held through it), a second mistake giving BACK TO ROUND 1 and the best round saved, GO AGAIN.
  - not yet: a full 10-round win, a timeout.
